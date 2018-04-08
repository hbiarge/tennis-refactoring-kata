using System;

namespace Tennis.Scorers
{
    public class WinScorer : IScorer
    {
        private readonly string playerOneName;
        private readonly string playerTwoName;
        private readonly string winner;

        public WinScorer(string playerOneName, string playerTwoName, string winner)
        {
            this.playerOneName = playerOneName;
            this.playerTwoName = playerTwoName;
            this.winner = winner;
        }

        public string PlayerOneName => playerOneName;

        public string PlayerTwoName => playerTwoName;

        public IScorer PlayerOneWin()
        {
            return this;
        }

        public IScorer PlayerTwoWin()
        {
            return this;
        }

        public string GetScore()
        {
            return $"Win for {winner}";
        }
    }
}