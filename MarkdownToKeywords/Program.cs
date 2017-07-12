using System;
using System.IO;

using Microsoft.DocAsCode.Dfm;

namespace MarkdownToKeywords
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine();
                return 1;
            }

            var filePath = args[0];

            var baseDir = string.Empty;
            if (args.Length > 1)
            {
                baseDir = args[1];
            }
            var result = Transform(filePath, baseDir);
            Console.WriteLine(result);

            return 0;
        }

        public static string Transform(string filePath, string baseDir)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"{nameof(filePath)} can't null or empty.");
            }

            if (baseDir == null)
            {
                throw new ArgumentNullException(baseDir);
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file can't be found", filePath);
            }

            return TransformCore(filePath, baseDir);
        }

        private static string TransformCore(string filePath, string baseDir)
        {
            string content;
            using (var sr = new StreamReader(filePath))
            {
                content = sr.ReadToEnd();
            }

            var builder = DocfxFlavoredMarked.CreateBuilder(baseDir);
            var engine = builder.CreateDfmEngine(new KeywordsRenderer());
            var result = engine.Markup(content, filePath);

            return result;
        }
    }
}
