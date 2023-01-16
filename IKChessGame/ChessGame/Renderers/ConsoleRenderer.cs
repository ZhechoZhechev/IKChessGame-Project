
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


            Console.ReadLine();
        }
    }
}
