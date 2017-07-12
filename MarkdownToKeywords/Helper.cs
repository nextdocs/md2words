using Microsoft.DocAsCode.MarkdownLite;

namespace MarkdownToKeywords
{
    public static class Helper
    {
        public static string RemoveStopWords(this string content)
        {
            // TODO
            return content.Trim(' ', '.');
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
