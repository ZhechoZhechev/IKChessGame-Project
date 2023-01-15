namespace ChessGame.ChessPieces
{
    using Contracts;
    using Common;

    public class Rook : BaseFigure, IFigure
    {
        public Rook(ChessColor color)
            : base(color)
        {
        }
    }
}
