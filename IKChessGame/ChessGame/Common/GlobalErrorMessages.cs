namespace ChessGame.Common
{
    public class GlobalErrorMessages
    {
        public const string FigureCannotBeNull = "Figure can not be null!";
        public const string RowValueInvalid = "Selected row possition on board is not vallid";
        public const string ColValueInvalid = "Selected column possition on board is not vallid";
        public const string FigureAlreadyExists = "The player already owns this figure";
        public const string FigureDoesNotExists = "The player does not own this figure";
        public const string StandardGameStratNeedTwoPlayers = "You must have two players to start";
        public const string StandardGameStratNeedEightRowsAndCols = "Game board dimensions must be eight by eight";
    }
}
