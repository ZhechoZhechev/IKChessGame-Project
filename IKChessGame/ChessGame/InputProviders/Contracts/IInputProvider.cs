namespace ChessGame.InputProviders.Contracts
{
    using System.Collections.Generic;

    using Players.Contracts;
    public interface IInputProvider
    {
        IList<IPlayer> GetPLayers(int numberOfPlayers);
    }
}
