
namespace ChessGame.ChessPieces
{
    using ChessGame.Common;
    using Contracts;
    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }
    }
}
