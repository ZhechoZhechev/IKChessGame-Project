
namespace ChessGame.Renderers
{
    using System;
    using System.Threading;

    using ChessBoard.Contracts;
    using Common.Console;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "CHESS GAME";
        private const int CharactersPerRowPerBoardSquare = 9;
        private const int CharactersPerColPerBoardSquare = 9;
        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            Thread.Sleep(1001);

        }

        public void RenderBoard(IBoard board)
        {
            var startRowPrint = Console.WindowHeight / 2 - (board.TotalRows / 2) * CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowWidth / 2 - (board.TotalCols / 2) * CharactersPerColPerBoardSquare;

            var currRowPrint = startRowPrint;
            var currColPrint = startColPrint;

            Console.BackgroundColor = ConsoleColor.White;

            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currRowPrint = startRowPrint + left * CharactersPerRowPerBoardSquare;
                    currColPrint = startColPrint + top * CharactersPerColPerBoardSquare;

                    Console.SetCursorPosition(currColPrint, currRowPrint);
                    Console.Write(" ");
                }
            }


            Console.ReadLine();
        }
    }
}
