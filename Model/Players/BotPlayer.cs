namespace Othello_for_three_players.Model.Players
{
    public class BotPlayer : Player
    {
        public BotPlayer(PlayerID ID) : base(ID)
        {}

        public override Move MakeMove(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
