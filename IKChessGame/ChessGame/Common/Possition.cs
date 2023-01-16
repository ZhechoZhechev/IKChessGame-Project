namespace ChessGame.Common
{
   public struct Possition
    {
        public static Possition FromArrayCoordinates(int arrRow, int arrCol, int totalRows) 
        {
            return new Possition(totalRows - arrRow, (char)(arrCol + 'a'));
        }
        public Possition(int row, char col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; } 
        public char Col { get; private set; }
    }
}
