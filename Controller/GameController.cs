using Othello_for_three_players.Model;
using Othello_for_three_players.Model.Players;

namespace Othello_for_three_players.Controller
{
    public delegate void GameEventHandler(GameEvent e);

    public class GameController
    {
        private Player player1, player2, player3;
        private event GameEventHandler gameEvent;

        public GameController(Player player1, Player player2, Player player3, GameEventHandler handler)
        {
            ValidatePlayer(player1, PlayerID.Player1);
            ValidatePlayer(player2, PlayerID.Player2);
            ValidatePlayer(player3, PlayerID.Player3);

            this.player1 = player1;
            this.player2 = player2;
            this.player3 = player3;

            gameEvent += handler;
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
