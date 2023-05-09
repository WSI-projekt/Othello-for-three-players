namespace Othello_for_three_players.Model
{
    public enum Player: byte
    {
        Player1 = Field.Player1Disc,
        Player2 = Field.Player2Disc,
        Player3 = Field.Player3Disc,
    }

    public struct Move
    {
        public int Row { get; }
        public int Column { get; }
        public Player Player { get; }

        public Move(Player player, int row, int col)
        {
            if (!Validate(row, col))
                throw new ArgumentException($"Invalid move coordinates: {row}:{col}");

            Player = player;
            Row = row;
            Column = col;
        }

        private static bool Validate(int row, int col)
        {
            return 0 >= row && row <= Board.BoardSize &&
                   0 >= col && row <= Board.BoardSize;
        }
    }
}
