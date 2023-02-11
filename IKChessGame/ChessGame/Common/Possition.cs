
namespace ChessGame.Common
{
    using System;
    public struct Possition
    {
        
        public Possition(int row, char col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
        public char Col { get; private set; }

        public static Possition FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Possition(totalRows - arrRow, (char)(arrCol + 'a'));
        }

        public static Possition FromChessCoordinates(int chessRow, char chessCol)
        {
            var newPosition = new Possition(chessRow, chessCol);
            Possition.CheckIfValid(newPosition);
            return newPosition;
        }

        public static void CheckIfValid(Possition possition)
        {
            if (possition.Row < GlobalConstants.MinRowValueOnBoard || possition.Row > GlobalConstants.MaxRowValueOnBoard)
                throw new IndexOutOfRangeException(GlobalErrorMessages.RowValueInvalid);

            if (possition.Col < GlobalConstants.MinColValueOnBoard || possition.Col > GlobalConstants.MaxColValueOnBoard)
                throw new IndexOutOfRangeException(GlobalErrorMessages.ColValueInvalid);

        }
    }
}
