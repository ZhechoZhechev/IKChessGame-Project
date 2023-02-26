using ChessGame.ChessBoard.Contracts;
using ChessGame.ChessPieces.Contracts;
using ChessGame.Common;
using ChessGame.Movements.Contracts;
using System;

namespace ChessGame.Movements
{
    public class NormalKingMovement : IMovement
    {
        private const string KingInvalidMove = "Kings can move on positions next to him!";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if ((rowDistance == 1 && colDistance == 0) || (rowDistance == 0 && colDistance == 1) || (rowDistance == 1 && colDistance == 1))
            {
                if (figureAtPosition == null || figureAtPosition.Color != figure.Color)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KingInvalidMove);
        }
    }
}
