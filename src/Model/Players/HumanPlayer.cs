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

        public override (Move move, bool wasMade) MakeMove(Board board)
        {
            return (makeMoveDelegate(board, ID), true); //todo - fix hardcoded 'true' later on...
        }
        public override (Move move, bool wasMade) MakeMoveOnlyForTesting(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
