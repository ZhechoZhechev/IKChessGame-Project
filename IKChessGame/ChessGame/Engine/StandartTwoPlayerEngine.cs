
namespace ChessGame.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    using Engine.Inicialization;
    using Players.Contracts;
    using Renderers.Contracts;
    using Contracts;
    using InputProviders.Contracts;
    using Common;
    using ChessBoard;
    using ChessBoard.Contracts;
    using Players;
    using ChessPieces.Contracts;
    using Movements.Contracts;
    using Movements.Strategies;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private  IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private int currentPlayerIndex;

        public StandartTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
            this.movementStrategy = new NormalMovementStrategy();
        }


        public IEnumerable<IPlayer> Players 
        {
            get 
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            //TODO: remove using ChessGame.Players and use the input for pplayers
            this.players = new List<IPlayer>
            {
                new Player("Zhechko", ChessColor.Black),
                new Player("Kokoscho", ChessColor.White)
            }; //input.GetPLayers(GlobalConstants.StardardGamePlayersNum);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(this.board);
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var allAvailableMovements = figure.Move(movementStrategy);
                    foreach (var movement in allAvailableMovements)
                    {
                        movement.ValidateMove(figure, board, move);
                    }

                    board.MoveFigureAtPosition(figure, from, to);
                    this.renderer.RenderBoard(board);

                    // TODO: On every move check if we are in check
                    // TODO: Check pawn on last row
                    // TODO: If not castle - move figure (check castle - check if castle is valid, check pawn for An-pasan)
                    // TODO: If in check - check checkmate
                    // TODO: If not in check - check draw
                    // TODO: Continue
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }

        }


        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].Color == ChessColor.White )
                {
                    this.currentPlayerIndex = i -1;
                    return;
                }
            }
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;

            if (this.currentPlayerIndex >= this.players.Count())
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Possition from)
        {
            
            if (figure == null)
                throw new InvalidOperationException("No figure at this position !");

            if(figure.Color != player.Color)
                throw new InvalidOperationException("Figure not yours!");
        }

        private void CheckIfToPositionIsEmpty( IFigure figure, Possition to)
        {
            var figureAtToPoss = this.board.GetFigureAtPosition(to);
            if (figureAtToPoss != null && figureAtToPoss.Color == figure.Color)
            {
                throw new InvalidOperationException("You already have a figure at that position!");
            }
        }


    }
}
