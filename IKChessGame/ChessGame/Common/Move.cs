namespace ChessGame.Common
{
    public struct Move
    {

        public Move(Possition from, Possition to)
            : this()
        {
            From = from;
            To = to;
        }
        public Possition From { get; private set; }
        public Possition To { get; private set; }
    }
}
