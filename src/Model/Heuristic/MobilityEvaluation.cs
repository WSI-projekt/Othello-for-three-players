using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_for_three_players.Model.Heuristic
{
    internal class MobilityEvaluation : IEvaluation
    {
        Board board;

        public MobilityEvaluation(Board board)
        {
            this.board = board;
        }
        public override (double a, double b, double c) Evaluate()
        {
            double[] tab = new double[2];
            tab[0] = board.GenerateAllPossibleMoves(Players.PlayerID.Player1).Count;
            tab[1] = board.GenerateAllPossibleMoves(Players.PlayerID.Player2).Count;
            tab[2] = board.GenerateAllPossibleMoves(Players.PlayerID.Player3).Count;
            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}
