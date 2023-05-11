using Othello_for_three_players.Model.Players;

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
            fields[move.Row, move.Column] = (Field)move.Player;

            // TODO: Change board after movement
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

        public List<Move> GenerateAllPossibleMovesForAPlayer(PlayerID playerID)
        {
            throw new NotImplementedException();
        }

        public void StartingPosition()
        {
            Clear();

            // Player1 Discs
            fields[3, 3] = Field.Player1Disc;
            fields[4, 4] = Field.Player1Disc;
            fields[5, 5] = Field.Player1Disc;

            // Player2 Discs
            fields[3, 4] = Field.Player2Disc;
            fields[4, 5] = Field.Player2Disc;
            fields[3, 5] = Field.Player2Disc;

            // Player3 Discs
            fields[3, 4] = Field.Player3Disc;
            fields[4, 5] = Field.Player3Disc;
            fields[5, 3] = Field.Player3Disc;
        }

        public static Board ExecuteMoveReturnCopy(Move move, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
