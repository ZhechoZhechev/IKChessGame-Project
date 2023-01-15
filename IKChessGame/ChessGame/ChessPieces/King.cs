namespace ChessGame.ChessPieces
{
    using Contracts;
    using Common;

    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color)
            : base(color)
        {
        }
    }
}
