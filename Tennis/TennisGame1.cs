using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        private IScorer _scorer;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;

            _scorer = new LoveScorer(0);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _scorer = _scorer.Player1Win();
            }
            else
            {
                _scorer = _scorer.Player2Win();
            }
        }

        public string GetScore()
        {
            if (IsScoreDraw())
            {
                return GetScoreForDraw();
            }

            if (IsScoreAdvantageOrWin())
            {
                return GetScoreForAdvantageOrWin();
            }

            var p1Score = GetPlayerScore(m_score1);
            var p2Score = GetPlayerScore(m_score2);
            return $"{p1Score}-{p2Score}";
        }

        private bool IsScoreDraw()
        {
            return m_score1 == m_score2;
        }

        private string GetScoreForDraw()
        {
            switch (m_score1)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private bool IsScoreAdvantageOrWin()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private string GetScoreForAdvantageOrWin()
        {
            var minusResult = m_score1 - m_score2;

            if (minusResult == 1)
            {
                return "Advantage player1";
            }

            if (minusResult == -1)
            {
                return "Advantage player2";
            }

            if (minusResult >= 2)
            {
                return "Win for player1";
            }

            return "Win for player2";
        }

        private static string GetPlayerScore(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new ArgumentOutOfRangeException(nameof(score));
            }
        }
    }
}