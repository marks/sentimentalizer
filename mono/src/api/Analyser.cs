using Sentan.Core;

namespace Sentimentalizer.Api
{
    public static class Analyser
    {
        static Corpus _positiveCorpuse = new Corpus();
        static Corpus _negativeCorpus = new Corpus();

        public static ClassificationResult Analyse(string text)
        {
            return new Classifier(_positiveCorpuse, _negativeCorpus).ClassifyData(text);
        }

        public static void TrainPositive(string path)
        {
            _positiveCorpuse.LoadFromDirectory(path);
        }

        public static void TrainNegative(string path)
        {
            _negativeCorpus.LoadFromDirectory(path);
        }
    }
}