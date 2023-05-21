using Othello_for_three_players.Model;
using Othello_for_three_players.Model.Players;
using System.Text;

namespace Tests
{
    public static class TestsTools
    {
        public static void AssertEqualBoard(string fieldsDesc, Board actualBoard)
        {
            Field[,] expectedFields = new Field[Board.Size, Board.Size];

            fieldsDesc = RemoveWhitespaces(fieldsDesc);

            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    switch (GetCharFromDescription(fieldsDesc, row, col))
                    {
                        case '_':
                        case 'e':
                        case 'E':
                            expectedFields[row, col] = Field.Empty;
                            break;
                        case '1':
                            expectedFields[row, col] = Field.Player1Disc;
                            break;
                        case '2':
                            expectedFields[row, col] = Field.Player2Disc;
                            break;
                        case '3':
                            expectedFields[row, col] = Field.Player3Disc;
                            break;
                        default:
                            throw new ArgumentException("Invalid description");
                    }
                }
            }

            AssertEqualBoard(expectedFields, actualBoard);
        }

        public static void AssertEqualBoard(Field[,] expectedFields, Board actualBoard)
        {
            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    Assert.Equal(expectedFields[row, col], actualBoard[row, col]);
                }
            }
        }

        public static void AssertGeneratedMoves(string expMovesDesc, PlayerID playerID, List<Move> actualMoves)
        {
            List<Move> moves = new List<Move>();

            expMovesDesc = RemoveWhitespaces(expMovesDesc);

            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    char c = GetCharFromDescription(expMovesDesc, row, col);

                    if (char.IsDigit(c))
                        moves.Add(new Move(playerID, row, col));
                }
            }

            AssertGeneratedMoves(moves, actualMoves);
        }

        public static void AssertGeneratedMoves(List<KeyValuePair<Move, int>> expectedMoves, List<Move> actual)
        {
            List<Move> expMoves = new List<Move>(expectedMoves.Count);

            foreach (var m in expectedMoves)
            {
                expMoves.Add(m.Key);
            }

            AssertGeneratedMoves(expMoves, actual);
        }

        public static void AssertGeneratedMoves(List<Move> expectedMoves, List<Move> actualMoves)
        {
            foreach (Move move in expectedMoves)
            {
                Assert.Contains(move, actualMoves);
            }

            Assert.Equal(expectedMoves.Count, actualMoves.Count);
        }

        public static void AssertGeneratedMovesWithCaptures(string expMovesDesc, PlayerID playerID, List<KeyValuePair<Move, int>> actual)
        {
            var moves = new List<KeyValuePair<Move, int>>();

            expMovesDesc = RemoveWhitespaces(expMovesDesc);

            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    char c = GetCharFromDescription(expMovesDesc, row, col);

                    if (c >= '0' && c <= '3')
                        moves.Add(new KeyValuePair<Move, int>(new Move(playerID, row, col), c - '0'));
                    else if (c != '_' && c != 'e' && c != 'E')
                        throw new ArgumentException("Invalid description");
                }
            }

            AssertGeneratedMovesWithCaptures(moves, actual);
        }

        public static void AssertGeneratedMovesWithCaptures(List<KeyValuePair<Move, int>> expectedMoves, List<KeyValuePair<Move, int>> actual)
        {
            foreach (var move in expectedMoves)
            {
                Assert.Contains(move, actual);
            }

            Assert.Equal(expectedMoves.Count, actual.Count);
        }


        private static string RemoveWhitespaces(string s)
            => new string(s.Where(c => !char.IsWhiteSpace(c)).ToArray());

        private static char GetCharFromDescription(string description, int row, int col)
            => description[row * Board.Size + col];
    }
}
