﻿namespace Othello_for_three_players.Model.Heuristic
{
    public class StabilityEvaluation : IEvaluation
    {
        Board board;

        public StabilityEvaluation(Board board)
        {
            this.board = board;
        }

        public override (double a, double b, double c) Evaluate()
        {
            double[] tab = new double[2];

            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}