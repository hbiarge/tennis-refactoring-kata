using System;

namespace Tennis.Scorers
{
    public struct Score : IComparable<Score>, IEquatable<Score>
    {
        private readonly int value;

        private Score(int value)
        {
            this.value = value;
        }

        public static Score Love => new Score();

        public static Score Fifteen => new Score(1);

        public static Score Thirty => new Score(2);

        public static Score Forty => new Score(3);

        public static bool operator ==(Score first, Score second) => first.value == second.value;

        public static bool operator !=(Score first, Score second) => first.value != second.value;

        public static bool operator >(Score first, Score second) => first.value > second.value;

        public static bool operator >=(Score first, Score second) => first.value >= second.value;

        public static bool operator <(Score first, Score second) => first.value < second.value;

        public static bool operator <=(Score first, Score second) => first.value <= second.value;

        public Score NextScore()
        {
            return new Score(value + 1);
        }

        public bool NextScoreResultInLoveWith(Score otherScore)
        {
            return otherScore.value - value == 1;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Score))
            {
                return Equals((Score)obj);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1113510858;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            switch (value)
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
                    return value.ToString();
            }
        }

        public int CompareTo(Score other)
        {
            return value.CompareTo(other.value);
        }

        public bool Equals(Score other)
        {
            return value.Equals(other.value);
        }
    }
}