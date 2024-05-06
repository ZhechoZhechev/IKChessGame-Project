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
            throw new NotImplementedException();
        }
    }
}
