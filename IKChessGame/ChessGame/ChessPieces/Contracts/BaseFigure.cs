
namespace ChessGame.ChessPieces.Contracts
{
    using System.Collections.Generic;

    using Common;
    using Movements.Contracts;
    public abstract class BaseFigure : IFigure
    {
        //TODO: Remove all inheritance and use FigureType enum
        protected BaseFigure(ChessColor color)
        {
            Color = color;
        }

        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
