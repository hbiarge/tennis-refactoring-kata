using System;

namespace Tennis
{
    public class LoveScorer : IScorer
    {
        private readonly int _score;
        private readonly int _score2;

        public LoveScorer(int score)
        {
            _score = score;
        }

        public IScorer Player1Win()
        {
            throw new NotImplementedException();
        }

        public IScorer Player2Win()
        {
            throw new NotImplementedException();
        }

        public string GetScore()
        {
            switch (_score)
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
    }

    public class LoveScorer : IScorer
    {
        private readonly int _score;
        private readonly int _score2;

        public LoveScorer(int score)
        {
            _score = score;
        }

        public IScorer Player1Win()
        {
            throw new NotImplementedException();
        }

        public IScorer Player2Win()
        {
            throw new NotImplementedException();
        }

        public string GetScore()
        {
            switch (_score)
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
    }
}