namespace Othello_for_three_players.Model.Heuristic
{
    public class MobilityEvaluation : IEvaluation
    {
        Board board;

        public MobilityEvaluation(Board board)
        {
            this.board = board;
        }
        public override (double a, double b, double c) Evaluate()
        {
            double[] tab = new double[3];
            tab[0] = board.GeneratePossibleMoves(Players.PlayerID.Player1).Count;
            tab[1] = board.GeneratePossibleMoves(Players.PlayerID.Player2).Count;
            tab[2] = board.GeneratePossibleMoves(Players.PlayerID.Player3).Count;

            double res1 = tab[0] - (tab[1] + tab[2]) / 2.0;
            double res2 = tab[1] - (tab[0] + tab[2]) / 2.0;
            double res3 = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (res1, res2, res3);
        }
    }
}
