namespace ChessGame.ChessPieces
{
    using Contracts;
    using Common;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color)
            : base(color)
        {
        }
    }
}
