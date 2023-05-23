using Othello_for_three_players.Model.Heuristic;
using System.Numerics;

namespace Othello_for_three_players.Model.Players
{
    public class BotPlayer : Player
    {
        public int RecurencyDepth;
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
        public override (Move move, bool wasMade) MakeMove(Board board)
        {
            var ret = Shallow(board, ID, HeuristicsUpperSumBound, 0);
            return (ret.Item1.PlayersMove, ret.Item2);
        }

        (ShallowStruct, bool) Shallow(Board board, PlayerID playerID, double upperSumBound, int recurencyDepth)
        {
            ShallowStruct best = new ShallowStruct();
            ShallowStruct current;

            if(recurencyDepth > RecurencyDepth) // terminal
            {
                best.Evaluation = EvaluateHeuristicsBoard(board);
                return (best, true);
            }

            // nonterminal
            List<Move> possibleMoves = board.GeneratePossibleMoves(playerID);
            if(possibleMoves.Count == 0)
            {
                return (best, false);
            }

            PlayerID nextPlayerID = GetNextPlayersID(playerID);

            Board firstChildBoard = Board.FromMove(possibleMoves.FirstOrDefault(), board);
            best = Shallow(firstChildBoard, nextPlayerID, upperSumBound, recurencyDepth + 1).Item1;
            best.PlayersMove = possibleMoves.FirstOrDefault();

            possibleMoves.RemoveAt(0); // deleting the first child

            foreach(Move move in possibleMoves)
            {
                Board nextInLineChildBoard = Board.FromMove(move, board);
                if (best.Evaluation[(int)playerID-1] >= upperSumBound)
                {
                    return (best, true);
                }

                current = Shallow(nextInLineChildBoard, nextPlayerID, upperSumBound - best.Evaluation[(int)playerID-1], recurencyDepth+1).Item1;
                current.PlayersMove = move;
                if (current.Evaluation[(int)playerID-1] > best.Evaluation[(int)playerID-1])
                {
                    best = current;
                }
            }
            return (best, true);
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
