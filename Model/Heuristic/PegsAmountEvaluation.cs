﻿using System;
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
                    tab[(int)board[i, j]]++;
                }
            }
            tab[0] = tab[0] - (tab[1] + tab[2]) / 2.0;
            tab[1] = tab[1] - (tab[0] + tab[2]) / 2.0;
            tab[2] = tab[2] - (tab[1] + tab[0]) / 2.0;
            return (tab[0], tab[1], tab[2]);
        }
    }
}
