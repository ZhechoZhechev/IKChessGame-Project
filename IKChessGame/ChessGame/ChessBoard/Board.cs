
namespace ChessGame.ChessBoard
{
    using System;

    using Common;
    using ChessPieces.Contracts;
    using Contracts;

    public class Board : IBoard
    {
        private readonly IFigure[,] board;

        public Board(int rows = GlobalConstants.StandardChessRowsCount, int cols = GlobalConstants.StandardChessColsCount)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }
        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Possition possition)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.FigureCannotBeNull);
            Possition.CheckIfValid(possition);

            int arrayRow = this.GetArrayRow(possition.Row);
            int arrayCol = this.GetArrayCol(possition.Col);
            this.board[arrayRow, arrayCol] = figure;
        }

        public void RemoveFigure(Possition possition)
        {
            Possition.CheckIfValid(possition);

            int arrayRow = this.GetArrayRow(possition.Row);
            int arrayCol = this.GetArrayCol(possition.Col);
            this.board[arrayRow, arrayCol] = null;
        }

        public IFigure GetFigureAtPosition(Possition possition)
        {
            int arrayRow = this.GetArrayRow(possition.Row);
            int arrayCol = this.GetArrayCol(possition.Col);
            return this.board[arrayRow, arrayCol];
        }
        public void MoveFigureAtPosition(IFigure figure, Possition from, Possition to)
        {
            int arrayFromRow = this.GetArrayRow(from.Row);
            int arrayFromCol = this.GetArrayCol(from.Col);
            this.board[arrayFromRow, arrayFromCol] = null;

            int arrayToRow = this.GetArrayRow(to.Row);
            int arrayToCol = this.GetArrayCol(to.Col);
            this.board[arrayToRow, arrayToCol] = figure;
        }

        private int GetArrayRow(int chessRows)
            => this.TotalRows - chessRows;

        private int GetArrayCol(char chessCol)
            => chessCol - 'a';

    }
}
