namespace Othello_for_three_players.Model
{
    public enum Field: byte
    {
        Empty = 0,
        Player1Disc = 1,
        Player2Disc = 2,
        Player3Disc = 3,
    }

    public class Board
    {
        public const int BoardSize = 9;

        private Field[,] fields;

        public Field this[int row, int col]
            { get { return fields[row, col]; } }

        public Board()
        {
            fields = new Field[BoardSize, BoardSize];

            Clear();
        }

        public void MakeMove(Move move)
        {
            // TODO: maybe some validation

            fields[move.Row, move.Column] = (Field)move.Player;
        }

        public void Clear()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    fields[row, col] = Field.Empty;
                }
            }
        }
    }
}
