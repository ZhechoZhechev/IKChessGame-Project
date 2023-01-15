namespace ChessGame.Common.Console
{
    using System;
    public static class ConsoleHelpers
    {
        public static void SetCursorAtCenter(int lenghtOfMessage) 
        {
            int centralRow = Console.WindowHeight / 2;
            int centralCol = Console.WindowWidth / 2 - lenghtOfMessage / 2;

            Console.SetCursorPosition(centralCol, centralRow);
        }
    }
}
