namespace ChessGame.Common.Console
{
    using System;
    using System.Collections.Generic;

    using ChessPieces.Contracts;
    public static class ConsoleHelpers
    {
        private static readonly IDictionary<string, bool[,]> Patterns = new Dictionary<string, bool[,]>
        {
            { "Pawn", new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { "Rook", new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, true, false, true, false, true, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { "Knight", new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, true, false, false, false, },
                    { false, false, false, true, true, true, true, false, false, },
                    { false, false, true, true, true, false, true, false, false, },
                    { false, false, false, true, false, true, true, false, false, },
                    { false, false, false, false, true, true, true, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { "Bishop", new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, false, true, true, false, false, },
                    { false, false, true, false, false, false, true, false, false, },
                    { false, false, false, true, false, true, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, true, true, true, false, true, true, true, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { "King", new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, true, true, false, true, false, true, true, false, },
                    { false, true, true, true, false, true, true, true, false, },
                    { false, true, true, true, true, true, true, true, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { "Queen", new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, true, false, true, false, true, false, false, },
                    { false, false, false, true, false, true, false, false, false, },
                    { false, true, false, true, true, true, false, true, false, },
                    { false, false, true, false, true, false, true, false, false, },
                    { false, false, true, true, false, true, true, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
        };
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

            var figurePattern = Patterns[figure.GetType().Name];

            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + i, top + j);
                    if (figurePattern[j, i])
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

        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command.Split('-');

            if (positionAsStringParts.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPosition = Possition.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Possition.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }

        public static void ClearRow(int row) 
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
