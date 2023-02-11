
namespace ChessGame.Movements.Contracts
{
    using Common;
    using ChessBoard.Contracts;
    using ChessPieces.Contracts;
    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
