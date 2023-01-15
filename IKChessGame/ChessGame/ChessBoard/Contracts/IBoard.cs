﻿namespace ChessGame.ChessBoard.Contracts
{
    using ChessPieces.Contracts;
    using Common;
    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }
        void AddFigure(IFigure figure, Possition possition);
        void RemoveFigure(Possition possition);
    }
}