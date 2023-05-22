namespace Othello_for_three_players.Model.Heuristic
{
    public class PegsAmountEvaluation : IEvaluation
    {
        Board board;

        public PegsAmountEvaluation(Board b)
        {
            board = b;
        }

        public override (double, double, double) Evaluate()
        {
            double[] tab = new double[3];
            for(int i = 0; i < Board.Size; i++)
            {
                for(int j = 0; j < Board.Size; j++)
                {
                    int temp = (int)board[i,j] - 1;
                    if (temp != -1)
                    {
                        tab[temp] += 1;
                    }
                }
            }
            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}
