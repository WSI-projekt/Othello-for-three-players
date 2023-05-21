using Othello_for_three_players.Model.Players;

namespace Othello_for_three_players.Model
{
    public readonly struct Move: IEquatable<Move>
    {
        public int Row { get; }
        public int Column { get; }
        public PlayerID Player { get; }

        public Move(PlayerID player, int row, int col)
        {
            if (!Validate(row, col))
                throw new ArgumentException($"Invalid move coordinates: {row}:{col}");

            Player = player;
            Row = row;
            Column = col;
        }

        private static bool Validate(int row, int col)
        {
            return 0 <= row && row <= Board.Size &&
                   0 <= col && row <= Board.Size;
        }

        public bool Equals(Move other)
            => Row == other.Row && Column == other.Column && Player == other.Player;

        public override string ToString()
            => $"Player {(int)Player}, Row: {Row}, Column: {Column}";
    }
}
