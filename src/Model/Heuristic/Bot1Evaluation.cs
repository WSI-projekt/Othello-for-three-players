namespace Othello_for_three_players.Model.Heuristic
{
    public class Bot1Evaluation : IEvaluation
    {
        MobilityEvaluation mobilityEvaluation;
        CornerEvaluation cornerEvaluation;
        PegsAmountEvaluation pegsAmountEvaluation;
        StabilityEvaluation stabilityEvaluation;

        public Bot1Evaluation(Board board)
        {
            mobilityEvaluation= new MobilityEvaluation(board);
            cornerEvaluation= new CornerEvaluation(board);
            pegsAmountEvaluation = new PegsAmountEvaluation(board);
            stabilityEvaluation= new StabilityEvaluation(board);
        }
        public override (double, double, double) Evaluate()
        {

            double a=0, b=0, c=0;
            double wyna, wynb, wync;

            (wyna, wynb, wync) = mobilityEvaluation.Evaluate();
            a += wyna; b += wynb; c += wync;

            (wyna, wynb, wync) = cornerEvaluation.Evaluate();
            a += wyna; b += wynb; c += wync;

            (wyna, wynb, wync) = pegsAmountEvaluation.Evaluate();
            a += wyna; b += wynb; c += wync;

            (wyna, wynb, wync) = stabilityEvaluation.Evaluate();
            a += wyna; b += wynb; c += wync;

            return (a, b, c);

        }
    }
}
