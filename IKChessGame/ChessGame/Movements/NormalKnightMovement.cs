using System;
using ChessGame.Common;
using ChessGame.Movements.Contracts;
using ChessGame.ChessBoard.Contracts;
using ChessGame.ChessPieces.Contracts;

namespace ChessGame.Movements
{
    internal class NormalKnightMovement : IMovement
    {
        private const string KnightInvalindMove = "Knights move only in L shape pattern!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var color = figure.Color;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (figureAtPosition == null || color != figureAtPosition.Color)
            {
                if (rowDistance == 2 && colDistance == 1)
                {
                    return;
                }
                else if (colDistance == 2 && rowDistance == 1)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KnightInvalindMove);
        }
    }
}
