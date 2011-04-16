using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sentan.Core
{
    public class Document : IEnumerable<string>
    {
        public IEnumerable<string> tokens;

        public Document(string data)
        {
            tokens = parse(data);
        }

        private IEnumerable<string> parse(string source)
        {
            var sourceTokens = cleanInput(source).Split(' ');

            return sourceTokens.Where(c => !c.Equals(" ", StringComparison.InvariantCultureIgnoreCase))
                               .Select(c => c.ToLowerInvariant())
                               .Distinct();
        }

        private string cleanInput(string input)
        {
            return Regex.Replace(input, @"[^\w\'@-]", " ");
        }

        public IEnumerator<string> GetEnumerator()
        {
            return tokens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tokens.GetEnumerator();
        }

        public static Document Create(string content)
        {
            return new Document(content);
        }
    }
}