using System;
using Tennis.Scorers;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private IScorer scorer;

        public TennisGame1(string player1Name, string player2Name)
        {
            scorer = new LoveScorer(player1Name, player2Name, new Score());
        }

        public void WonPoint(string playerName)
        {
            if (playerName == scorer.PlayerOneName)
            {
                scorer = scorer.PlayerOneWin();
                return;
            }

            if (playerName == scorer.PlayerTwoName)
            {
                scorer = scorer.PlayerTwoWin();
                return;
            }

            throw new InvalidOperationException($"Unknown player name: {playerName}");
        }

        public string GetScore()
        {
            return scorer.GetScore();
        }
    }
}