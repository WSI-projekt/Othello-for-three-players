﻿using Othello_for_three_players.Model.Heuristic;
using System.Numerics;

namespace Othello_for_three_players.Model.Players
{
    public class BotPlayer : Player
    {
        private int RecurencyDepth;
        private double HeuristicsUpperSumBound;
        public BotPlayer(PlayerID ID, int recurencyDepth, int upperSumBound) : base(ID)
        {
            RecurencyDepth = recurencyDepth;
            HeuristicsUpperSumBound = upperSumBound;
        }
        public override (Move move,bool wasMade) MakeMoveOnlyForTesting(Board board)
        {
            var possible = board.GeneratePossibleMoves(ID);
            if(possible != null && possible.Count !=0) {return (possible[0],true); }
            return (new Move(ID,0,0),false);
        }
        public override Move MakeMove(Board board)
        {
            return Shallow(board, ID, HeuristicsUpperSumBound, 0).PlayersMove;
        }

        ShallowStruct Shallow(Board board, PlayerID playerID, double upperSumBound, int recurencyDepth)
        {
            ShallowStruct best = new ShallowStruct();
            ShallowStruct current;

            if(recurencyDepth > RecurencyDepth) // terminal
            {
                best.Evaluation = EvaluateHeuristicsBoard(board);
                return best;
            }

            // nonterminal
            List<Move> possibleMoves = board.GeneratePossibleMoves(playerID);
            PlayerID nextPlayerID = GetNextPlayersID(playerID);

            Board firstChildBoard = Board.FromMove(possibleMoves.FirstOrDefault(), board);
            best = Shallow(firstChildBoard, nextPlayerID, upperSumBound, recurencyDepth + 1);
            best.PlayersMove = possibleMoves.FirstOrDefault();

            possibleMoves.RemoveAt(0); // deleting the first child

            foreach(Move move in possibleMoves)
            {
                Board nextInLineChildBoard = Board.FromMove(move, board);
                if (best.Evaluation[(int)playerID] >= upperSumBound)
                {
                    return best;
                }

                current = Shallow(nextInLineChildBoard, nextPlayerID, upperSumBound - best.Evaluation[(int)playerID], recurencyDepth+1);
                current.PlayersMove = move;
                if (current.Evaluation[(int)playerID] > best.Evaluation[(int)playerID])
                {
                    best = current;
                }
            }
            return best;
        }

        public static PlayerID GetNextPlayersID(PlayerID playerID)
        {
            return (playerID == PlayerID.Player3) ? PlayerID.Player1 : (playerID + 1);
        }

        public Vector3 EvaluateHeuristicsBoard(Board board)
        {
            Bot1Evaluation evaluationBot = new Bot1Evaluation(board);
            var scoreValue = evaluationBot.Evaluate();
            return new Vector3((float)scoreValue.Item1, (float)scoreValue.Item2, 
                (float)scoreValue.Item3);
        }
    }
}
