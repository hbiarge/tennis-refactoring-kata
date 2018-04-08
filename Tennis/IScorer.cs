namespace Tennis
{
    public interface IScorer
    {
        string PlayerOneName { get; }

        string PlayerTwoName { get; }

        IScorer PlayerOneWin();

        IScorer PlayerTwoWin();

        string GetScore();
    }
}