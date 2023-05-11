namespace Othello_for_three_players.Model.Utils
{
    public static class QueueConcatenation
    {
        /// <summary>
        /// Moves all elements form `q`
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="destQ">Destination queue</param>
        /// <param name="q">Source queue</param>
        public static void Concatenate<T>(this Queue<T> destQ, Queue<T> q)
        {
            while(q.Count > 0)
                destQ.Enqueue(q.Dequeue());
        }
    }
}
