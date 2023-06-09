﻿using Othello_for_three_players.Model.Players;
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
        public const int Size = 9;

        private Field[,] fields;

        public Field this[int row, int col]
        { get { return fields[row, col]; } }

        public Board()
        {
            // No need to clean the board, because default
            // value of enum is 0

            fields = new Field[Size, Size];
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
                tmpFields.Clear();
            }

            if (fieldsToChange.Count == 0)
                throw new ArgumentException("No captures after move - move is invalid");

            while(fieldsToChange.Count > 0)
            {
                (int row, int col) = fieldsToChange.Dequeue();
                fields[row, col] = (Field)move.Player;
            }
            fields[move.Row, move.Column] = (Field)move.Player;
        }

        public void Clear()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
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

        public List<KeyValuePair<Move, int>> GeneratePossibleMovesWithCaptures(PlayerID playerID)
        {
            Dictionary<Move, int> result = new Dictionary<Move, int>();

            foreach (var field in PlayersDiscs(playerID))
            {
                foreach (var direction in Enum.GetValues<CaptureDirection>())
                {
                    int captures = 0;

                    foreach (var potentialMove in FieldsFrom(direction, field))
                    {
                        if (potentialMove.Value == (Field)playerID)
                            break;

                        if (potentialMove.Value != Field.Empty)
                            captures++;
                        else
                        {
                            if (captures > 0)
                            {
                                Move move = new Move(playerID, potentialMove.Row, potentialMove.Col);
                                UpdateCaptures(result, move, captures);
                            }
                            break;
                        }
                        
                    }
                }
            }

            return result.ToList();
        }

        private void UpdateCaptures(Dictionary<Move,int> captures, Move move, int newCaptures)
        {
            if (captures.ContainsKey(move))
                captures[move] += newCaptures;
            else
                captures.Add(move, newCaptures);

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

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
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

        public (int black, int white, int red) PlayerStats()
        {
            (int b, int w, int r) stats = (0,0,0);
            for(int row = 0; row < Size; row++)
            {
                for(int col=0; col < Size;col++)
                {
                    switch (fields[row, col])
                    {
                        case (Field)PlayerID.Player1:
                            stats.b++;
                            break;
                        case (Field)PlayerID.Player2:
                            stats.w++;
                            break;
                        case (Field)PlayerID.Player3:
                            stats.r++;
                            break;
                    }
                }
            }
            return stats;
        }

        private IEnumerable<SingleField> PlayersDiscs(PlayerID playerID)
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (fields[row, col] == (Field)playerID)
                        yield return new SingleField(row, col, (Field)playerID);
                }
            }
        }

        private IEnumerable<SingleField> FieldsFrom(CaptureDirection direction, int startRow, int startCol)
        {
            return direction switch
            {
                CaptureDirection.Up => FieldsUpFrom(startRow, startCol),
                CaptureDirection.UpRight => FieldsUpRightFrom(startRow, startCol),
                CaptureDirection.Right => FieldsRightFrom(startRow, startCol),
                CaptureDirection.DownRight => FieldsDownRightFrom(startRow, startCol),
                CaptureDirection.Down => FieldsDownFrom(startRow, startCol),
                CaptureDirection.DownLeft => FieldsDownLeftFrom(startRow, startCol),
                CaptureDirection.Left => FieldsLeftFrom(startRow, startCol),
                CaptureDirection.UpLeft => FieldsUpLeftFrom(startRow, startCol),
                _ => throw new ArgumentException("Unknown direction"),
            };
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
            for(int i = 1; startRow-i >=0 && startCol + i < Size; i++)
            {
                yield return new SingleField(startRow - i, startCol + i, fields[startRow - i, startCol+i]);
            }
        }

        private IEnumerable<SingleField> FieldsRightFrom(int startRow, int startCol)
        {
            for (int col = startCol + 1; col < Size; col++)
            {
                yield return new SingleField(startRow, col, fields[startRow, col]);
            }
        }

        private IEnumerable<SingleField> FieldsDownRightFrom(int startRow, int startCol)
        {
            for (int i = 1; startRow + i < Size && startCol + i < Size; i++)
            {
                yield return new SingleField(startRow + i, startCol + i, fields[startRow + i, startCol + i]);
            }
        }

        private IEnumerable<SingleField> FieldsDownFrom(int startRow, int startCol)
        {
            for (int row = startRow + 1; row < Size; row++)
            {
                yield return new SingleField(row, startCol, fields[row, startCol]);
            }
        }

        private IEnumerable<SingleField> FieldsDownLeftFrom(int startRow, int startCol)
        {
            for (int i = 1; startRow + i <Size && startCol - i >= 0; i++)
            {
                yield return new SingleField(startRow + i, startCol - i, fields[startRow + i, startCol - i]);
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
            for (int i = 1; startRow - i >= 0 && startCol - i >=0; i++)
            {
                yield return new SingleField(startRow - i, startCol - i, fields[startRow - i, startCol - i]);
            }
        }

        private readonly struct SingleField
        {
            public int Row { get; }
            public int Col { get; }
            public Field Value { get; }

            public SingleField(int row, int col, Field field)
            {
                Row = row;
                Col = col;
                Value = field;
            }

            public override string ToString()
            {
                string prefix = $"Field row: {Row}, col: {Col} ";

                if (Value == Field.Empty)
                    return prefix + "is empty";

                return prefix + $"- player {(int)Value} dics";
            }
        }
    }
}
