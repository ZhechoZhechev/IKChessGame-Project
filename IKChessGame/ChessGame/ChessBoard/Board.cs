
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
            CheckIfPossitionOfFigureIsValid(possition);

            int arrayRow = this.GetArrayRow(possition.Row);
            int arrayCol = this.GetArrayCol(possition.Col);
            this.board[arrayRow, arrayCol] = figure;
        }

        public void RemoveFigure(Possition possition)
        {
            CheckIfPossitionOfFigureIsValid(possition);

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

        private int GetArrayRow(int chessRows)
            => this.TotalRows - chessRows;

        private int GetArrayCol(char chessCol)
            => chessCol - 'a';

        private void CheckIfPossitionOfFigureIsValid(Possition possition)
        {
            if (possition.Row < GlobalConstants.MinRowValueOnBoard || possition.Row > GlobalConstants.MaxRowValueOnBoard)
                throw new IndexOutOfRangeException(GlobalErrorMessages.RowValueInvalid);

            if (possition.Col < GlobalConstants.MinColValueOnBoard || possition.Col > GlobalConstants.MaxColValueOnBoard)
                throw new IndexOutOfRangeException(GlobalErrorMessages.ColValueInvalid);
  
        }

    }
}
