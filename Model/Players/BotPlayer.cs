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
                best.Evaluation = EvaluateHeuristicsBoard(playerID, board);
                return best;
            }

            // nonterminal
            List<Move> possibleMoves = board.GenerateAllPossibleMoves(playerID);
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

        public Vector3 EvaluateHeuristicsBoard(PlayerID ID, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
