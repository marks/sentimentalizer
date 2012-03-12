using System.Collections.Generic;

namespace Sentan.Core
{
    public class ClassificationResult
    {
        public string Text { get; set; }
        public float OverallProbability { get; set; }
        public Sentiment Sentiment { get; set; }
        public IList<TokenProbability> TokenProbabilities { get; private set; }

        public ClassificationResult()
        {
            TokenProbabilities = new List<TokenProbability>();
            Sentiment = Sentiment.Neutral;
        }
    }
}