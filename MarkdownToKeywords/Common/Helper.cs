using Microsoft.DocAsCode.MarkdownLite;
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
                             let w = word.Trim(new[] { ',', '.', ';', '(', '[', ']', ')', '"', '\'', '\r', '\n' })
                             where !string.IsNullOrEmpty(w) && !StopWords.Contains(w)
                             select w;
            return string.Join(Constants.Separator, collection);
        }

        /// <summary>
        /// if link is path, then call ResolveRelativePath
        /// if link is href, then call NormalizeHref
        /// </summary>
        public static string NormalizeLink(this string link)
        {
            // TODO
            return link;
        }

        public static string NormalizeHref(this string href)
        {
            // TODO
            return href;
        }

        public static string ResolveRelativePath(this string path)
        {
            // TODO
            return path;
        }
    }
}
