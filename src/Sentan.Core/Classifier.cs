namespace Sentan.Core
{
    public class Classifier
    {
        Corpus _positiveCorpus;
        Corpus _negativeCorpus;

        float totalProbability;
        float inverseTotalProbability;
        const float tolerance = 0.05f;

        public Classifier(Corpus positiveCorpus, Corpus negativeCorpus)
        {
            _positiveCorpus = positiveCorpus;
            _negativeCorpus = negativeCorpus;
        }

        public ClassificationResult ClassifyData(string text)
        {
            var result = new ClassificationResult { Text = text };
            var stopWords = Helpers.GetStopWords();

            foreach (var token in new Document(text))
            {
                if (stopWords.Contains(token))
                {
                    continue;
                }

                var positiveCount = _positiveCorpus.GetTokenCount(token);
                var negativeCount = _negativeCorpus.GetTokenCount(token);

                var tokenProbability = calculateProbability(positiveCount, _positiveCorpus.EntryCount, negativeCount, _negativeCorpus.EntryCount);
                recordProbability(tokenProbability);

                result.TokenProbabilities.Add(new TokenProbability
                {
                    Token = token,
                    Probability = tokenProbability,
                    PositiveTotal = _positiveCorpus.EntryCount,
                    PositiveMatches = positiveCount,
                    NegativeTotal = _negativeCorpus.EntryCount,
                    NegativeMatches = negativeCount,
                    Sentiment = calculateSentiment(tokenProbability)
                });
            }

            result.OverallProbability = combineProbabilities();
            result.Sentiment = calculateSentiment(result.OverallProbability);

            return result;
        }

        private Sentiment calculateSentiment(float probability)
        {
            if (probability <= (0.5f - tolerance))
            {
                return Sentiment.Negative;
            }

            if (probability >= (0.5f + tolerance))
            {
                return Sentiment.Positive;
            }

            return Sentiment.Neutral;
        }

        private float calculateProbability(float positiveCount, float positiveTotal, float negativeCount, float negativeTotal)
        {
            const float unknownWordStrength = 1f;
            const float unknownWordProbability = 0.5f;

            var total = positiveCount + negativeCount;
            var positiveRatio = positiveCount / positiveTotal;
            var negativeRatio = negativeCount / negativeTotal;

            var probability = positiveRatio / (positiveRatio + negativeRatio);
            
            return ((unknownWordStrength * unknownWordProbability) + (total * probability)) / (unknownWordStrength + total);
        }

        private void recordProbability(float probability)
        {
            if (float.IsNaN(probability))
            {
                return;
            }

            totalProbability = (totalProbability == 0) ? probability : totalProbability * probability;
            inverseTotalProbability = (inverseTotalProbability == 0) ? (1 - probability) : inverseTotalProbability * (1 - probability);
        }

        private float combineProbabilities()
        {
            return totalProbability / (totalProbability + inverseTotalProbability);
        }
    }
}