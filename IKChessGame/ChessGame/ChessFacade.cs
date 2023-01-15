namespace ChessGame
{
    using System;

    using Engine;
    using Engine.Contracts;
    using Engine.Inicialization;
    using InputProviders;
    using InputProviders.Contracts;
    using Renderers;
    using Renderers.Contracts;
    public static class ChessFacade
    {
        public static void Start() 
        {
            IRenderer renderer = new ConsoleRenderer();
            //renderer.RenderMainMenu();

            IInputProvider input = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandartTwoPlayerEngine(renderer, input);

            IGameInitializationStrategy gameInitializationStrategy = new StandartStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Run();

            Console.ReadLine();
        }
    }
}
