using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Othello_for_three_players.Model
{
    internal class ShallowStruct
    {
        public Move PlayersMove { get; set; }
        public Vector3 Evaluation { get; set; }
    }
}
