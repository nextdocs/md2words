using System.Collections.Generic;
using System.IO;

namespace MarkdownToKeywords
{
    public class StopWords
    {
        public HashSet<string> Words { get; set; }
        public static StopWords _stopWords = null;

        public StopWords(string wordListPath)
        {
            using (var sr = new StreamReader(wordListPath))
            {
                Words = new HashSet<string>();

                var line = sr.ReadLine();
                while (line != null)
                {
                    Words.Add(line.Trim());
                    line = sr.ReadLine();
                }
            }
        }

        public bool Has(string word)
        {
            if (Words == null)
            {
                return false;
            }

            return Words.Contains(word);
        }

        public static bool Contains(string word)
        {
            if (_stopWords == null)
            {
                _stopWords = new StopWords(Constants.DefaultStopWordsFile);
            }

            return _stopWords.Has(word);
        }
    }
}
