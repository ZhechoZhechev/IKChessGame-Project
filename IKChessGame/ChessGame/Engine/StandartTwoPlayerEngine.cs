
namespace ChessGame.Engine
{
    using System.Collections.Generic;

    using Engine.Inicialization;
    using Players.Contracts;
    using Renderers.Contracts;
    using Contracts;
    using InputProviders.Contracts;
    using Common;
    using ChessBoard;
    using ChessBoard.Contracts;
    using ChessGame.Players;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

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
            var players = new List<IPlayer>
            {
                new Player("Zhechko", ChessColor.Black),
                new Player("Kokoscho", ChessColor.White)
            }; //input.GetPLayers(GlobalConstants.StardardGamePlayersNum);
            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(this.board);
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
