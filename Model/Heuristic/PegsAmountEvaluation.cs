using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Othello_for_three_players.Model.Heuristic
{
    internal class PegsAmountEvaluation : IEvaluation
    {
        Board board;

        int[,] evaluationtab = new int[9, 9] {
{4, -3, 2, 2, 2, 2, 2, -3, 4 },
{ -3, -4, -1,-1, -1, -1, -1 ,-4, -3 },
{ 2, -1, 1, 0,0, 0, 1, -1, 2 },
{ 2, -1, 0, 1,1, 1, 0, -1, 2 },
{ 2, -1, 0, 1,1, 1, 0, -1, 2 },
{ 2,-1, 0, 1,1, 1, 0, -1, 2 },
{ 2, -1, 1, 0,0, 0, 1, -1, 2 },
{ -3, -4, -1, -1,-1, -1, -1, -4, -3 },
{ 4, -3, 2, 2,2, 2, 2, -3, 4,}
        };

        public PegsAmountEvaluation(Board b)
        {
            board = b;
        }

        public override (double a, double b, double c) Evaluate(Board board)
        {
            double[] tab = new double[3];
            for(int i = 0; i < Board.BoardSize; i++)
            {
                for(int j = 0; j < Board.BoardSize; j++)
                {
                    int temp = (int)board[i,j] - 1;
                    if (temp != -1) { }
                    tab[temp]+= evaluationtab[i,j];
                }
            }
            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}
