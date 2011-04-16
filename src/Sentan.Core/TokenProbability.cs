namespace Sentan.Core
{
    public class TokenProbability
    {
        public string Token { get; set; }
        public float Probability { get; set; }
        public Sentiment Sentiment { get; set; }
        public int PositiveTotal { get; set; }
        public int PositiveMatches { get; set; }
        public int NegativeTotal { get; set; }
        public int NegativeMatches { get; set; }
    }
}