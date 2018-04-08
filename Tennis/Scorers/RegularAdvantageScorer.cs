using System;

namespace Tennis.Scorers
{
    public class RegularAdvantageScorer : IScorer
    {
        private readonly string playerOneName;
        private readonly Score playerOneScore;
        private readonly string playerTwoName;
        private readonly Score playerTwoScore;

        public RegularAdvantageScorer(string playerOneName, Score playerOneScore, string playerTwoName, Score playerTwoScore)
        {
            this.playerOneName = playerOneName;
            this.playerOneScore = playerOneScore;
            this.playerTwoName = playerTwoName;
            this.playerTwoScore = playerTwoScore;
        }

        public string PlayerOneName => playerOneName;

        public string PlayerTwoName => playerTwoName;

        public IScorer PlayerOneWin()
        {
            if (playerOneScore == Score.Forty)
            {
                return new WinScorer(playerOneName, playerTwoName, winner: playerOneName);
            }

            if (playerOneScore.NextScoreResultInLoveWith(playerTwoScore))
            {
                return new LoveScorer(playerOneName, playerTwoName, playerTwoScore);
            }

            return new RegularAdvantageScorer(playerOneName, playerOneScore.NextScore(), playerTwoName, playerTwoScore);
        }

        public IScorer PlayerTwoWin()
        {
            if (playerTwoScore == Score.Forty)
            {
                return new WinScorer(playerOneName, playerTwoName, winner: playerTwoName);
            }

            if (playerTwoScore.NextScoreResultInLoveWith(playerOneScore))
            {
                return new LoveScorer(playerOneName, playerTwoName, playerOneScore);
            }

            return new RegularAdvantageScorer(playerOneName, playerOneScore, playerTwoName, playerTwoScore.NextScore());
        }

        public string GetScore()
        {
            return $"{playerOneScore}-{playerTwoScore}";
        }
    }
}