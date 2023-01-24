
namespace ChessGame.ChessPieces
{
    using System.Collections.Generic;

    using Common;
    using Movements.Contracts;
    using Contracts;
    using Movements;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            return new List<IMovement>
            {
                new NormalPawnMovement()
            };

        }
    }
}
