namespace Tennis.Scorers
{
    public class DeuceAdvantageScorer : IScorer
    {
        private readonly string playerOneName;
        private readonly Score playerOneScore;
        private readonly string playerTwoName;
        private readonly Score playerTwoScore;

        public DeuceAdvantageScorer(string playerOneName, Score playerOneScore, string playerTwoName, Score playerTwoScore)
        {
            this.playerOneName = playerOneName;
            this.playerOneScore = playerOneScore;
            this.playerTwoName = playerTwoName;
            this.playerTwoScore = playerTwoScore;
        }

        public string PlayerOneName => playerOneName;

        public string PlayerTwoName => playerTwoName;

        private bool IsPlayerOneAdvantage => playerOneScore > playerTwoScore;

        public IScorer PlayerOneWin()
        {
            if (IsPlayerOneAdvantage)
            {
                return new WinScorer(playerOneName, playerTwoName, winner: playerOneName);
            }

            return new LoveScorer(playerOneName, playerTwoName, playerOneScore.NextScore());
        }

        public IScorer PlayerTwoWin()
        {
            if (IsPlayerOneAdvantage)
            {
                return new LoveScorer(playerOneName, playerTwoName, playerOneScore.NextScore());
            }

            return new WinScorer(playerOneName, playerTwoName, winner: playerTwoName);
        }

        public string GetScore()
        {
            return IsPlayerOneAdvantage
                ? "Advantage player1"
                : "Advantage player2";
        }
    }
}