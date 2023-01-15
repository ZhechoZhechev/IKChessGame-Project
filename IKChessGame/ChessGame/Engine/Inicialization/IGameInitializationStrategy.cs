namespace ChessGame.Engine.Inicialization
{
    using System.Collections.Generic;

    using ChessBoard.Contracts;
    using Players.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
