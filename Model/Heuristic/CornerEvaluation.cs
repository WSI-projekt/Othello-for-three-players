using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_for_three_players.Model.Heuristic
{
    internal class CornerEvaluation : IEvaluation
    {

        Board board;

        public CornerEvaluation(Board b)
        {
            board = b;
        }

        public override (double a, double b, double c) Evaluate()
        {
            double[] tab = new double[2];

            int temp = (int)board[0, 0] - 1;
            if(temp != -1) { }
            tab[temp]++;

            temp = (int)board[Board.BoardSize - 1, 0] - 1;
            if (temp != -1) { }
            tab[temp]++;

            temp = (int)board[0, Board.BoardSize - 1] - 1;
            if (temp != -1) { }
            tab[temp]++;

            temp = (int)board[Board.BoardSize - 1, Board.BoardSize - 1] - 1;
            if (temp != -1) { }
            tab[temp]++;

            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}
