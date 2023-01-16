namespace ChessGame.Common.Console
{
    using System;

    using ChessPieces.Contracts;
    public static class ConsoleHelpers
    {
        public static ConsoleColor ToConsoleColor(this ChessColor chessColor) 
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Brown:
                    return ConsoleColor.DarkCyan;
                default:
                    throw new InvalidOperationException("Invalid Chess Color");
            }
        }
        public static void SetCursorAtCenter(int lenghtOfMessage) 
        {
            int centralRow = Console.WindowHeight / 2;
            int centralCol = Console.WindowWidth / 2 - lenghtOfMessage / 2;

            Console.SetCursorPosition(centralCol, centralRow);
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroundColor, int top, int left) 
        {
            if (figure == null) 
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            var pawnPattern = new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, true, true, true , false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, false, false, false, false, false, false, false }
            };

            if (figure.GetType().Name == "Pawn") 
            {
                for (int i = 0; i < pawnPattern.GetLength(0); i++)
                {
                    for (int j = 0; j < pawnPattern.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(left + i, top + j);
                        if (pawnPattern[j, i])
                        {
                            Console.BackgroundColor = figure.Color.ToConsoleColor();
                        }
                        else
                        {
                            Console.BackgroundColor = backgroundColor;
                        }
                        Console.Write(" ");
                    }
                }
            }
        }

        public static void PrintEmptySquare(ConsoleColor backgroundColor, int top, int left) 
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            { 
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + i, top + j);
                    Console.Write(" ");
                }
            }
        }
    }
}
