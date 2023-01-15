 namespace ChessGame.ChessPieces
{
    using Contracts;
    using Common;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }
    }
}
