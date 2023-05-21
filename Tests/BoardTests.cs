using Othello_for_three_players.Model;
using Othello_for_three_players.Model.Players;

namespace Tests
{
    public class BoardTests
    {
        [Fact]
        public void ClearBoard()
        {
            Board board = new Board();
            board.StartingPosition();

            board.Clear();

            TestsTools.AssertEqualBoard(
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _",
                board);
        }

        [Fact]
        public void GameSimulation()
        {
            Board board = new Board();
            board.StartingPosition();

            TestsTools.AssertEqualBoard(
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ 1 2 3 _ _ _" +
                "_ _ _ 3 1 2 _ _ _" +
                "_ _ _ 2 3 1 _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _",
                board);

            /*
             * --------------------------------------------------------------------------
             *                                     Move 1
             * --------------------------------------------------------------------------
             */

            var moves = board.GeneratePossibleMoves(PlayerID.Player1);
            var movesWithCap = board.GeneratePossibleMovesWithCaptures(PlayerID.Player1);

            var expPossibleMoves =
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ 1 2 1 _ _" +
                "_ _ _ _ _ _ 2 _ _" +
                "_ _ 1 _ _ _ 1 _ _" +
                "_ _ 2 _ _ _ _ _ _" +
                "_ _ 1 2 1 _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _";

            TestsTools.AssertGeneratedMoves(expPossibleMoves, PlayerID.Player1, moves);
            TestsTools.AssertGeneratedMovesWithCaptures(expPossibleMoves, PlayerID.Player1, movesWithCap);

            board.MakeMove(new Move(PlayerID.Player1, 3, 6));

            TestsTools.AssertEqualBoard(
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ 1 1 1 1 _ _" +
                "_ _ _ 3 1 2 _ _ _" +
                "_ _ _ 2 3 1 _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _",
                board);

            /*
             * --------------------------------------------------------------------------
             *                                     Move 2
             * --------------------------------------------------------------------------
             */

            moves = board.GeneratePossibleMoves(PlayerID.Player2);
            movesWithCap = board.GeneratePossibleMovesWithCaptures(PlayerID.Player2);

            expPossibleMoves =
             "_ _ _ _ _ _ _ _ _" +
             "_ _ _ _ _ _ _ _ _" +
             "_ _ _ 3 _ 1 2 1 _" +
             "_ _ _ _ _ _ _ _ _" +
             "_ _ 2 _ _ _ _ _ _" +
             "_ _ _ _ _ _ 2 _ _" +
             "_ _ _ 1 _ 1 _ _ _" +
             "_ _ _ _ _ _ _ _ _" +
             "_ _ _ _ _ _ _ _ _";

            TestsTools.AssertGeneratedMoves(expPossibleMoves, PlayerID.Player2, moves);
            TestsTools.AssertGeneratedMovesWithCaptures(expPossibleMoves, PlayerID.Player2, movesWithCap);

            board.MakeMove(new Move(PlayerID.Player2, 2, 5));

            TestsTools.AssertEqualBoard(
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ 2 _ _ _" +
                "_ _ _ 1 1 2 1 _ _" +
                "_ _ _ 3 1 2 _ _ _" +
                "_ _ _ 2 3 1 _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _",
                board);

            /*
             * --------------------------------------------------------------------------
             *                                     Move 3
             * --------------------------------------------------------------------------
             */

            moves = board.GeneratePossibleMoves(PlayerID.Player3);
            movesWithCap = board.GeneratePossibleMovesWithCaptures(PlayerID.Player3);

            expPossibleMoves =
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ 2 _ _" +
                "_ _ _ 1 2 _ _ 2 _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ 2 _ _" +
                "_ _ 1 _ _ _ 1 _ _" +
                "_ _ _ 1 _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _";

            TestsTools.AssertGeneratedMoves(expPossibleMoves, PlayerID.Player3, moves);
            TestsTools.AssertGeneratedMovesWithCaptures(expPossibleMoves, PlayerID.Player3, movesWithCap);

            board.MakeMove(new Move(PlayerID.Player3, 2, 3));

            TestsTools.AssertEqualBoard(
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ 3 _ 2 _ _ _" +
                "_ _ _ 3 1 2 1 _ _" +
                "_ _ _ 3 1 2 _ _ _" +
                "_ _ _ 2 3 1 _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _",
                board);
            /*
             * --------------------------------------------------------------------------
             *                                     Move 4
             * --------------------------------------------------------------------------
             */

            moves = board.GeneratePossibleMoves(PlayerID.Player1);
            movesWithCap = board.GeneratePossibleMovesWithCaptures(PlayerID.Player1);

            expPossibleMoves =
                "_ _ _ _ _ _ _ _ _" +
                "_ _ 1 _ 1 3 1 _ _" +
                "_ _ 1 _ _ _ 1 _ _" +
                "_ _ 1 _ _ _ _ _ _" +
                "_ _ 1 _ _ _ 1 _ _" +
                "_ _ 3 _ _ _ 1 _ _" +
                "_ _ 1 2 1 _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _";

            TestsTools.AssertGeneratedMoves(expPossibleMoves, PlayerID.Player1, moves);
            TestsTools.AssertGeneratedMovesWithCaptures(expPossibleMoves, PlayerID.Player1, movesWithCap);

            board.MakeMove(new Move(PlayerID.Player1, 1, 6));

            TestsTools.AssertEqualBoard(
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ 1 _ _" +
                "_ _ _ 3 _ 1 _ _ _" +
                "_ _ _ 3 1 2 1 _ _" +
                "_ _ _ 3 1 2 _ _ _" +
                "_ _ _ 2 3 1 _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _",
                board);

            /*
            * --------------------------------------------------------------------------
            *                                     Move 5
            * --------------------------------------------------------------------------
            */

            moves = board.GeneratePossibleMoves(PlayerID.Player2);
            movesWithCap = board.GeneratePossibleMovesWithCaptures(PlayerID.Player2);

            expPossibleMoves =
                "_ _ _ _ _ _ _ _ _" +
                "_ _ 2 3 _ 1 _ _ _" +
                "_ _ _ _ _ _ _ 1 _" +
                "_ _ 2 _ _ _ _ 1 _" +
                "_ _ 2 _ _ _ _ _ _" +
                "_ _ _ _ _ _ 2 _ _" +
                "_ _ _ 1 _ 1 _ _ _" +
                "_ _ _ _ _ _ _ _ _" +
                "_ _ _ _ _ _ _ _ _";

            TestsTools.AssertGeneratedMoves(expPossibleMoves, PlayerID.Player2, moves);
            TestsTools.AssertGeneratedMovesWithCaptures(expPossibleMoves, PlayerID.Player2, movesWithCap);
        }
    }
}