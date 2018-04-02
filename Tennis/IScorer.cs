namespace Tennis
{
    public interface IScorer
    {
        IScorer Player1Win();
        IScorer Player2Win();

        string GetScore();
    }
}