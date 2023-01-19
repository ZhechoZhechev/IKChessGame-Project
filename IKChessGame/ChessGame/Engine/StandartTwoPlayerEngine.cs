
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

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private  IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        private int currentPlayerIndex;

        public StandartTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();

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
                    this.currentPlayerIndex = i;
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
    }
}
