namespace Othello_for_three_players.Model.Players
{
    public delegate Move MakeMoveFunction(Board board, PlayerID ID);

    public class HumanPlayer : Player
    {
        private MakeMoveFunction makeMoveDelegate;

        public HumanPlayer(PlayerID ID, MakeMoveFunction makeMoveFunction) : base(ID)
        {
            makeMoveDelegate = makeMoveFunction;
        }

        public override Move MakeMove(Board board)
        {
            return makeMoveDelegate(board, ID);
        }
    }
}
