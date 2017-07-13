using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace MarkdownToKeywords
{
    public class KeywordsRenderer
    {
        private readonly string _filePath;
        private readonly string _baseDir;

        public KeywordsRenderer(string filePath, string baseDir)
        {
            _filePath = filePath;
            _baseDir = baseDir;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, IMarkdownToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            var children = token.Children();

            if (children != null)
            {
                foreach (var t in children)
                {
                    content += render.Render(t);
                }
            }

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, MarkdownTextToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Content.RemoveStopWords();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, MarkdownImageInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Href.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, MarkdownLinkInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            if (token.Content != null)
            {
                foreach (var t in token.Content)
                {
                    content += render.Render(t);
                }
            }

            content += token.Href.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmIncludeInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Src.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmIncludeBlockToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Src.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmFencesToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Path.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmVideoBlockToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Link.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmXrefInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Href.NormalizeLink(_filePath, _baseDir);
            content += Constants.Separator;

            return content;
        }
    }
}
