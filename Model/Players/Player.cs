namespace Othello_for_three_players.Model.Players
{
    public abstract class Player
    {
        public PlayerID ID { get; }

        public Player(PlayerID ID)
        {
            this.ID = ID;
        }

        public abstract Move MakeMove(Board board);
    }
}
