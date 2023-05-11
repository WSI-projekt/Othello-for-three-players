using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_for_three_players.Model.Heuristic
{
    public abstract class IEvaluation
    {
        public abstract (double, double, double) Evaluate();

    }
}
