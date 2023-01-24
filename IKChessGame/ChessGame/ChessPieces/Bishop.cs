 namespace ChessGame.ChessPieces
{
    using System.Collections.Generic;

    using Contracts;
    using Common;
    using Movements.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
