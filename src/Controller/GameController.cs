using Othello_for_three_players.Model;
using Othello_for_three_players.Model.Players;

namespace Othello_for_three_players.Controller
{
    public delegate void GameEventHandler(GameEvent e);

    public class GameController
    {
        private Player player1, player2, player3;
        private event GameEventHandler gameEvent;
        private Board board;
        private MainForm visualisation;
        public GameController(Player player1, Player player2, Player player3, GameEventHandler handler, MainForm visualisation)
        {
            ValidatePlayer(player1, PlayerID.Player1);
            ValidatePlayer(player2, PlayerID.Player2);
            ValidatePlayer(player3, PlayerID.Player3);

            this.player1 = player1;
            this.player2 = player2;
            this.player3 = player3;

            gameEvent += handler;

            this.visualisation = visualisation;

            board = new Board();
        }
        public void PrepareBoard()
        {
            board.StartingPosition();
            visualisation.DrawDisksOnBoard_GameController(board, new Queue<(int row, int col)>());
        }
        public void TestMove()
        {
            Move move = new Move(PlayerID.Player1, 2, 5);
            Queue<(int row, int col)> q = new Queue<(int row, int col)>();
            q.Enqueue((3, 5));
            q.Enqueue((4, 5));
            //visualisation.MakeMove(board, PlayerID.Player1, move, q);
            while (visualisation.IsAnimationDone());
            move = new Move(PlayerID.Player2, 6, 4);
            q = new Queue<(int row, int col)>();
            q.Enqueue((4, 4));
            q.Enqueue((5, 4));
            //visualisation.MakeMove(board, PlayerID.Player2, move, q);
            while (visualisation.IsAnimationDone()) ;
        }
        public void BotSimulation()
        {
            int turn = 1, unableToMove = 0;
            while(unableToMove < 3)  
            {
                var player = turn%3 == 1 ? player1 : turn%3 == 2 ? player2 : player3;
                turn++;
                //var move = player.MakeMoveOnlyForTesting(board);
                var move = player.MakeMove(board);
                if (!move.wasMade)
                {
                    unableToMove++;
                    continue;
                }
                var boardcopy = Board.FromMove(move.move,board);
                visualisation.MakeMove(board, boardcopy, move.move);
                while (visualisation.IsAnimationDone()) ;
                board.MakeMove(move.move);
                visualisation.ShowStats(board.PlayerStats());
                unableToMove = 0;
            }
        }
        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void AddGameEventObserver(GameEventHandler handler)
            => gameEvent += handler;

        public void RemoveGameEventObserver(GameEventHandler handler)
            => gameEvent -= handler;


        private static void ValidatePlayer(Player player, PlayerID expectedID)
        {
            if (player.ID != expectedID)
                throw new ArgumentException(
                    $"Invalid player ID. Player number {(int)expectedID} must have ID equal to {expectedID}");
        }
    }
}
