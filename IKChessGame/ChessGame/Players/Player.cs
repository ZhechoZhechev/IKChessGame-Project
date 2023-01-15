
namespace ChessGame.Players
{
    using System;
    using System.Collections.Generic;

    using Common;
    using ChessPieces.Contracts;
    using Players.Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string name,ChessColor color)
        {
            this.Name = name;
            this.Color = color;
            this.figures = new List<IFigure>();
        }

        public ChessColor Color { get; private set; }

        public string Name { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.FigureCannotBeNull);
            CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.FigureCannotBeNull);
            CheckIfFigureDoesNotExists(figure);
            this.figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
                throw new InvalidOperationException(GlobalErrorMessages.FigureAlreadyExists);
        }

        private void CheckIfFigureDoesNotExists(IFigure figure)
        {
            if (!this.figures.Contains(figure))
                throw new InvalidOperationException(GlobalErrorMessages.FigureDoesNotExists);
        }
    }
}
