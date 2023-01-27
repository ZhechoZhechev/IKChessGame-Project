
namespace ChessGame.ChessPieces.Contracts
{
    using System.Collections.Generic;

    using Movements.Contracts;
    using Common;

    public interface IFigure
    {
        ChessColor Color { get;  }

        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
