
namespace ChessGame.Renderers
{
    using System;
    using System.Threading;

    using ChessBoard.Contracts;
    using ChessGame.Common;
    using Common.Console;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "CHESS GAME";

        private const ConsoleColor DarkSquare = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquare = ConsoleColor.Gray;

        public ConsoleRenderer()
        {
            if (Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("Plese set the Console window and buffer size 100x80." +
                    " For best experience use Raster Fonts 8x8");
                Environment.Exit(0);
            }
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            Thread.Sleep(1001);

        }

        public void RenderBoard(IBoard board)
        {
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currRowPrint = startRowPrint;
            var currColPrint = startColPrint;

            this.PrintBorder(startRowPrint, startColPrint, board.TotalRows, board.TotalCols);

            Console.BackgroundColor = ConsoleColor.White;

            int counter = 1;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currColPrint = startRowPrint + left * ConsoleConstants.CharactersPerRowPerBoardSquare;
                    currRowPrint = startColPrint + top * ConsoleConstants.CharactersPerColPerBoardSquare;

                    ConsoleColor backgroundColor;
                    if (counter % 2 == 0) 
                    {
                        backgroundColor = DarkSquare;
                        Console.BackgroundColor = DarkSquare;
                    }
                    else
                    {
                        backgroundColor = LightSquare;
                        Console.BackgroundColor = LightSquare;
                    }
                    var position = Possition.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currRowPrint, currColPrint);    


                    counter++;
                }
                counter++;
            }

        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayersIO);

            Console.SetCursorPosition(Console.WindowWidth / 2 - errorMessage.Length / 2, ConsoleConstants.ConsoleRowForPlayersIO);
            Console.Write(errorMessage);
            Thread.Sleep(2500);

            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayersIO);
        }

        private void PrintBorder(int startRowPrint, int startColPrint, int boardTotalRows, int boardTotalCols)
        {
            var start = startRowPrint + (ConsoleConstants.CharactersPerRowPerBoardSquare / 2);
            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startColPrint - 1);
                Console.Write((char)('A' + i));
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startColPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare));
                Console.Write((char)('A' + i));
            }

            start = startColPrint + (ConsoleConstants.CharactersPerColPerBoardSquare / 2);
            for (int i = 0; i < boardTotalRows; i++)
            {
                Console.SetCursorPosition(startRowPrint - 1, start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(boardTotalRows - i);
                Console.SetCursorPosition(startRowPrint + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare), start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(boardTotalRows - i);
            }

            // TODO: check this math!
            for (int i = startRowPrint - 2; i < startRowPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquare;
                Console.SetCursorPosition(i, startColPrint - 2);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquare;
                Console.SetCursorPosition(i, startColPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquare;
                Console.SetCursorPosition(startRowPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquare;
                Console.SetCursorPosition(startRowPrint - 2, i);
                Console.Write(" ");
            }
        }
    }
}
