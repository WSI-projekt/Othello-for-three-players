namespace Othello_for_three_players.Model.Heuristic
{
    public class StabilityEvaluation : IEvaluation
    {
        Board board;

        int[,] evaluationtab = new int[9, 9] {
            {  4, -3,  2,  2,  2,  2,  2, -3,  4 },
            { -3, -4, -1, -1, -1, -1, -1, -4, -3 },
            {  2, -1,  1,  0,  0,  0,  1, -1,  2 },
            {  2, -1,  0,  1,  1,  1,  0, -1,  2 },
            {  2, -1,  0,  1,  1,  1,  0, -1,  2 },
            {  2, -1,  0,  1,  1,  1,  0, -1,  2 },
            {  2, -1,  1,  0,  0,  0,  1, -1,  2 },
            { -3, -4, -1, -1, -1, -1, -1, -4, -3 },
            {  4, -3,  2,  2,  2,  2,  2, -3,  4 },
        };

        public StabilityEvaluation(Board board)
        {
            this.board = board;
        }

        public override (double a, double b, double c) Evaluate()
        {
            double[] tab = new double[3];

            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    int temp = (int)board[i, j] - 1;
                    if (temp != -1)
                    {
                        tab[temp] += evaluationtab[i, j];
                    }
                }
            }

            double res1 = tab[0] - (tab[1] + tab[2]) / 2.0;
            double res2 = tab[1] - (tab[0] + tab[2]) / 2.0;
            double res3 = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (res1, res2, res3);
        }
    }
}
