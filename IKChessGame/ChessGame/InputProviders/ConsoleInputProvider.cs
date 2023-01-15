namespace ChessGame.InputProviders
{
    using System;
    using System.Collections.Generic;

    using Players.Contracts;
    using Common.Console;
    using Common;
    using Players;
    using InputProviders.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PLayerNameText = "Enter player {0} name: ";
        public IList<IPlayer> GetPLayers(int numberOfPlayers) 
        {
            var players = new List<IPlayer>();
        
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PLayerNameText.Length);
                Console.Write(string.Format(PLayerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            return players;
        }
    }
}
