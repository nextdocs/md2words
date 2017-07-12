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

        public static string NormalizeLink(this string link, string baseDir)
        {
            if (Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute))
            {
                return NormalizeHref(link);
            }
            return ResolveRelativePath(link, baseDir);
        }

        public static string NormalizeHref(this string href)
        {
            // TODO
            return href;
        }

        public static string ResolveRelativePath(this string path, string baseDir)
        {
            if (string.IsNullOrEmpty(baseDir))
            {
                return path;
            }

            if (!baseDir.EndsWith("/") || !baseDir.EndsWith("\\"))
            {
                baseDir += "/";
            }

            var pathUri = new Uri(path);
            var baseDirUri = new Uri(baseDir);
            var resovedUri = baseDirUri.MakeRelativeUri(pathUri);

            return resovedUri.ToString();
        }
    }
}
