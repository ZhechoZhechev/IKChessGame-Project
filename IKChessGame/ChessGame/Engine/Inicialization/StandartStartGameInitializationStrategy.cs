namespace ChessGame.Engine.Inicialization
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Players.Contracts;
    using ChessBoard.Contracts;
    using ChessPieces;
    using ChessPieces.Contracts;

    public class StandartStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int StandardGameRowsNum = 8;
        private const int StandardGameColsNum = 8;

        private IList<Type> figureTypes;

        public StandartStartGameInitializationStrategy()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }
        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];
            //first player pawns 
            this.AddPawnsToBoardRow(firstPlayer, board, 7);
            //second player pawns
            this.AddPawnsToBoardRow(secondPlayer, board, 2);
            //first player main figures
            this.AddMainFiguresToBoardRow(firstPlayer, board, 8);
            //second player main figures
            this.AddMainFiguresToBoardRow(secondPlayer, board, 1);
        }

        private void AddMainFiguresToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < StandardGameRowsNum; i++)
            {
                var figureType = this.figureTypes[i];
                var currentFigure =  (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(currentFigure);
                var position = new Possition(chessRow, (char)(i + 'a'));
                board.AddFigure(currentFigure, position);
            }
        }
        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < StandardGameRowsNum; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Possition(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private void ValidateStategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StardardGamePlayersNum)
                throw new InvalidOperationException(GlobalErrorMessages.StandardGameStratNeedTwoPlayers);

            if (board.TotalRows != StandardGameRowsNum || board.TotalCols != StandardGameColsNum)
                throw new InvalidOperationException(GlobalErrorMessages.StandardGameStratNeedEightRowsAndCols);
        }
    }
}
