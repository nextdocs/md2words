using Microsoft.DocAsCode.MarkdownLite;
using System;
using System.IO;
using System.Linq;

namespace MarkdownToKeywords
{
    public static class Helper
    {
        public static string RemoveStopWords(this string content)
        {
            // TODO
            var words = content.ToLower().Split(' ', '\n');

            var collection = from word in words
                             let w = word.Trim(new[] { ' ', ',', '.', ';', '(', '[', ']', '*', ')', '"', '\'', '\r', '\n' })
                             where !string.IsNullOrEmpty(w) && !StopWords.Contains(w)
                             select w;
            return string.Join(Constants.Separator, collection);
        }

        public static string NormalizeLink(this string link, string filePath, string baseDir)
        {
            if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                return NormalizeHref(link);
            }
            return ResolveRelativePath(link, filePath, baseDir);
        }

        public static string NormalizeHref(this string href)
        {
            // TODO
            return href;
        }

        public static string ResolveRelativePath(this string path, string filePath, string baseDir)
        {
            if (string.IsNullOrEmpty(baseDir))
            {
                return path;
            }

            var dir = Path.GetDirectoryName(filePath);
            var fullPath = Path.GetFullPath(Path.Combine(dir, path));

            if (!baseDir.EndsWith("/") && !baseDir.EndsWith("\\"))
            {
                baseDir += "/";
            }

            var pathUri = new Uri(fullPath);
            var baseDirUri = new Uri(Path.GetFullPath(baseDir));
            var resovedUri = baseDirUri.MakeRelativeUri(pathUri);

            return resovedUri.ToString();
        }
    }
}
