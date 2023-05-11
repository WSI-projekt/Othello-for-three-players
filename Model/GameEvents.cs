using Othello_for_three_players.Model.Players;

namespace Othello_for_three_players.Model
{
    public class GameEvent { }

    public class GameHaveStarted : GameEvent { }

    public class MoveWasMade
    {
        public Board OldBoard { get; }
        public Move Move { get; }
        public Board Board { get; }

        public MoveWasMade(Board oldBoard, Move move, Board board)
        {
            OldBoard = oldBoard;
            Move = move;
            Board = board;
        }
    }

    public class GameFinished: GameEvent { }

    public class Draw: GameFinished
    {
        public IReadOnlyCollection<PlayerID> Winners { get; }

        public Draw(IReadOnlyCollection<PlayerID> winners)
        {
            Winners = winners;
        }
    }

    public class PlayerWon: GameFinished
    {
        public PlayerID Winner { get; }

        public PlayerWon(PlayerID winner)
        {
            Winner = winner;
        }
    }
}
