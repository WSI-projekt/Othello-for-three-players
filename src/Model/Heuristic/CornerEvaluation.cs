namespace Othello_for_three_players.Model.Heuristic
{
    public class CornerEvaluation : IEvaluation
    {
        Board board;

        public CornerEvaluation(Board b)
        {
            board = b;
        }

        public override (double a, double b, double c) Evaluate()
        {
            double[] tab = new double[3];

            int temp = (int)board[0, 0] - 1;
            if (temp != -1)
            {
                tab[temp]++;
            }

            temp = (int)board[Board.Size - 1, 0] - 1;
            if (temp != -1)
            {
                tab[temp]++;
            }

            temp = (int)board[0, Board.Size - 1] - 1;
            if (temp != -1)
            {
                tab[temp]++;
            }

            temp = (int)board[Board.Size - 1, Board.Size - 1] - 1;
            if (temp != -1)
            {
                tab[temp]++;
            }

            double res1 = tab[0] - (tab[1] + tab[2]) / 2.0;
            double res2 = tab[1] - (tab[0] + tab[2]) / 2.0;
            double res3 = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (res1, res2, res3);
        }
    }
}
