namespace Tennis.Scorers
{
    public class LoveScorer : IScorer
    {
        private readonly string playerOneName;
        private readonly string playerTwoName;
        private readonly Score loveScore;

        public LoveScorer(string playerOneName, string playerTwoName, Score score)
        {
            this.playerOneName = playerOneName;
            this.playerTwoName = playerTwoName;
            this.loveScore = score;
        }

        public string PlayerOneName => playerOneName;

        public string PlayerTwoName => playerTwoName;

        public IScorer PlayerOneWin()
        {
            if (loveScore >= Score.Forty)
            {
                return new DeuceAdvantageScorer(playerOneName, loveScore.NextScore(), playerTwoName, loveScore);
            }

            return new RegularAdvantageScorer(playerOneName, loveScore.NextScore(), playerTwoName, loveScore);
        }

        public IScorer PlayerTwoWin()
        {
            if (loveScore >= Score.Forty)
            {
                return new DeuceAdvantageScorer(playerOneName, loveScore, playerTwoName, loveScore.NextScore());
            }

            return new RegularAdvantageScorer(playerOneName, loveScore, playerTwoName, loveScore.NextScore());
        }

        public string GetScore()
        {
            if (loveScore > Score.Thirty)
            {
                return "Deuce";
            }

            return $"{loveScore}-All";
        }
    }
}