using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sentan.Core
{
    public class Corpus
    {
        IDictionary<string, int> _tokens = new Dictionary<string, int>();

        public int EntryCount
        {
            get { return _tokens.Values.Sum(); }
        }

        public void Add(Document document)
        {
            foreach (var token in document)
            {
                if (_tokens.ContainsKey(token))
                {
                    _tokens[token]++;
                }
                else
                {
                    _tokens.Add(token, 1);
                }
            }
        }

        public void LoadFromDirectory(string directory)
        {
            foreach (var file in Directory.GetFiles(directory, "*.txt"))
            {
                foreach (var line in File.ReadAllLines(file))
                {
                    Add(new Document(line));
                }
            }
        }

        public int GetTokenCount(string token)
        {
            return _tokens.ContainsKey(token) ? _tokens[token] : 0;
        }
    }
}