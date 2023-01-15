
namespace ChessGame.Players.Contracts
{
    using ChessPieces.Contracts;
    using Common;
    public interface IPlayer
    {
        string Name { get; }
        ChessColor Color { get; }
        void AddFigure(IFigure figure);
        void RemoveFigure(IFigure figure);
    }
}
