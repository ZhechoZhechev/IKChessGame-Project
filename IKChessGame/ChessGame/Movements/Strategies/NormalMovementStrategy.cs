
namespace ChessGame.Movements.Strategies
{
    using Contracts;
    using System.Collections.Generic;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>
        {
            {"Pawn", new List<IMovement>
            {
                new NormalPawnMovement()
            }},
            {"Bishop", new List<IMovement>
            {
                new NormalBishopMovement()
            }},
            {"Rook", new List<IMovement>
            {
                new NormalRookMovement()
            }},
            {"King", new List<IMovement>
            {
                new NormalKingMovement()
            }}
        };
        public IList<IMovement> GetMovements(string figure)
        {
            return this.movements[figure];
        }
    }
}
