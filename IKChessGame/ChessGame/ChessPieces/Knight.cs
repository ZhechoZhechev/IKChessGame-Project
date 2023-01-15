namespace ChessGame.ChessPieces
{
    using Contracts;
    using Common;

    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color)
            : base(color)
        {
        }
    }
}
