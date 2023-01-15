namespace ChessGame.Engine.Contracts
{
    using System.Collections.Generic;

    using Engine.Inicialization;
    using Players.Contracts;
    public interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; } 
        void Initialize(IGameInitializationStrategy gameInitializationStrategy);
        void Run();
        void WinningConditions();

    }
}
