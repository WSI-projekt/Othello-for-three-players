﻿namespace Othello_for_three_players.Model.Heuristic
{
    public abstract class IEvaluation
    {
        public abstract (double a, double b, double c) Evaluate();

    }
}
