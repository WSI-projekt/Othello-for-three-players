using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_for_three_players.Model.Heuristic
{
    internal class StabilityEvaluation : IEvaluation
    {

        public StabilityEvaluation() { 
        }

        public override (double a, double b, double c) Evaluate(Board board)
        {
            double[] tab = new double[2];

            

            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}
