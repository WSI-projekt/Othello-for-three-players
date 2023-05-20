using Othello_for_three_players.Model.Players;
using Othello_for_three_players.Model.Utils;

namespace Othello_for_three_players.Model
{
    public enum Field: byte
    {
        Empty = 0,
        Player1Disc = 1,
        Player2Disc = 2,
        Player3Disc = 3,
    }

    public class Board: ICloneable
    {
        public const int BoardSize = 9;

        private Field[,] fields;

        public Field this[int row, int col]
        { get { return fields[row, col]; } }

        public Board()
        {
            // No need to clean the board, because default
            // value of enum is 0

            fields = new Field[BoardSize, BoardSize];
        }

        public static Board FromMove(Move move, Board board)
        {
            Board newBoard = (Board)board.Clone();
            newBoard.MakeMove(move);

            return newBoard;
        }

        public void MakeMove(Move move)
        {
            if (fields[move.Row, move.Column] != Field.Empty)
                throw new ArgumentException("Invalid move, you cannot put disc on already occupied field");

            var fieldsToChange = new Queue<(int row, int col)>();
            var tmpFields = new Queue<(int row, int col)>();

            foreach (var direction in Enum.GetValues<CaptureDirection>())
            {
                foreach (var field in FieldsFrom(direction, move.Row, move.Column))
                {
                    if (field.Value == Field.Empty)
                    {
                        tmpFields.Clear();
                        break;
                    }
                    else if (field.Value == (Field)move.Player)
                    {
                        fieldsToChange.Concatenate(tmpFields);
                        break;
                    }
                    else
                    {
                        tmpFields.Enqueue((field.Row, field.Col));
                    }
                }
            }

            if (fieldsToChange.Count == 1)
                throw new ArgumentException("No captures after move - move is invalid");

            while(fieldsToChange.Count > 0)
            {
                (int row, int col) = fieldsToChange.Dequeue();
                fields[row, col] = (Field)move.Player;
            }
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

        public List<Move> GeneratePossibleMoves(PlayerID playerID)
        {
            HashSet<Move> result = new HashSet<Move>();

            foreach (var field in PlayersDiscs(playerID))
            {
                foreach (var direction in Enum.GetValues<CaptureDirection>())
                {
                    bool enemyDiscFound = false;

                    foreach (var potentialMove in FieldsFrom(direction, field))
                    {
                        if (potentialMove.Value == (Field)playerID)
                            break;

                        if (potentialMove.Value != Field.Empty)
                            enemyDiscFound = true;
                        else
                        {
                            if (enemyDiscFound)
                                result.Add(new Move(playerID, potentialMove.Row, potentialMove.Col));
                            break;
                        }
                    }
                }
            }

            return result.ToList();
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
            fields[5, 3] = Field.Player2Disc;

            // Player3 Discs
            fields[4, 3] = Field.Player3Disc;
            fields[5, 4] = Field.Player3Disc;
            fields[3, 5] = Field.Player3Disc;
        }

        public object Clone()
        {
            Board result = new Board();

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    result.fields[row, col] = fields[row, col];
                }
            }

            return result;
        }


        private enum CaptureDirection: byte
        {
            Up,
            UpRight,
            Right,
            DownRight,
            Down,
            DownLeft,
            Left,
            UpLeft
        }


        private IEnumerable<SingleField> PlayersDiscs(PlayerID playerID)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (fields[row, col] == (Field)playerID)
                        yield return new SingleField(row, col, (Field)playerID);
                }
            }
        }

        private IEnumerable<SingleField> FieldsFrom(CaptureDirection direction, int startRow, int startCol)
        {
            switch (direction)
            {
                case CaptureDirection.Up:
                    return FieldsUpFrom(startRow, startCol);

                case CaptureDirection.UpRight:
                    return FieldsUpRightFrom(startRow, startCol);

                case CaptureDirection.Right:
                    return FieldsRightFrom(startRow, startCol);

                case CaptureDirection.DownRight:
                    return FieldsDownRightFrom(startRow, startCol);

                case CaptureDirection.Down:
                    return FieldsDownFrom(startRow, startCol);

                case CaptureDirection.DownLeft:
                    return FieldsDownLeftFrom(startRow, startCol);

                case CaptureDirection.Left:
                    return FieldsLeftFrom(startRow, startCol);

                case CaptureDirection.UpLeft:
                    return FieldsUpLeftFrom(startRow, startCol);

                default:
                    throw new ArgumentException("Unknown direction");
            }
        }

        private IEnumerable<SingleField> FieldsFrom(CaptureDirection direction, SingleField field)
            => FieldsFrom(direction, field.Row, field.Col);

        private IEnumerable<SingleField> FieldsUpFrom(int startRow, int startCol)
        {
            for (int row = startRow - 1; row >= 0; row--)
            {
                yield return new SingleField(row, startCol, fields[row, startCol]);
            }
        }

        private IEnumerable<SingleField> FieldsUpRightFrom(int startRow, int startCol)
        {
            for (int row = startRow - 1; row >= 0; row--)
            {
                for (int col = startCol + 1; col < startCol; col++)
                {
                    yield return new SingleField(row, col, fields[row, col]);
                }
            }
        }

        private IEnumerable<SingleField> FieldsRightFrom(int startRow, int startCol)
        {
            for (int col = startCol + 1; col < BoardSize; col++)
            {
                yield return new SingleField(col, startCol, fields[col, startCol]);
            }
        }

        private IEnumerable<SingleField> FieldsDownRightFrom(int startRow, int startCol)
        {
            for (int row = startRow + 1; row < BoardSize; row++)
            {
                for (int col = startCol + 1; col < BoardSize; col++)
                {
                    yield return new SingleField(row, col, fields[row, col]);
                }
            }
        }

        private IEnumerable<SingleField> FieldsDownFrom(int startRow, int startCol)
        {
            for (int row = startRow + 1; row < BoardSize; row++)
            {
                yield return new SingleField(row, startCol, fields[row, startCol]);
            }
        }

        private IEnumerable<SingleField> FieldsDownLeftFrom(int startRow, int startCol)
        {
            for (int row = startRow + 1; row < BoardSize; row++)
            {
                for (int col = startCol - 1; col >= 0; col--)
                {
                    yield return new SingleField(row, col, fields[row, col]);
                }
            }
        }

        private IEnumerable<SingleField> FieldsLeftFrom(int startRow, int startCol)
        {
            for (int col = startCol - 1; col >= 0; col--)
            {
                yield return new SingleField(startRow, col, fields[startRow, col]);
            }
        }

        private IEnumerable<SingleField> FieldsUpLeftFrom(int startRow, int startCol)
        {
            for (int row = startRow - 1; row >= 0; row--)
            {
                for (int col = startCol - 1; col >= 0; col--)
                {
                    yield return new SingleField(row, col, fields[row, col]);
                }
            }
        }

        private readonly struct SingleField
        {
            public int Row { get; }
            public int Col { get; }
            public Field Value { get; }

            public SingleField(int row, int col, Field field)
            {
                this.Row = row;
                this.Col = col;
                this.Value = field;
            }
        }
    }
}
