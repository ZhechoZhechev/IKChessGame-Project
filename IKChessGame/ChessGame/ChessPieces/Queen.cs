namespace ChessGame.ChessPieces
{
    using System.Collections.Generic;

    using Contracts;
    using Common;
    using Movements.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
