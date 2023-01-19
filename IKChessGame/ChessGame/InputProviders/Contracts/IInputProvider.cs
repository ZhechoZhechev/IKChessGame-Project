namespace ChessGame.InputProviders.Contracts
{
    using System.Collections.Generic;
    using ChessGame.Common;
    using Players.Contracts;
    public interface IInputProvider
    {
        IList<IPlayer> GetPLayers(int numberOfPlayers);

        Move GetNextPlayerMove(IPlayer player);
    }
}
