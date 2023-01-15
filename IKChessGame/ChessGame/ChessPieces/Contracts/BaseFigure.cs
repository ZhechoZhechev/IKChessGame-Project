using ChessGame.Common;

namespace ChessGame.ChessPieces.Contracts
{
    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            Color = color;
        }

        public ChessColor Color { get; private set; }
    }
}
