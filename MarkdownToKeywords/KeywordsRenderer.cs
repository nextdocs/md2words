using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace MarkdownToKeywords
{
    public class KeywordsRenderer
    {
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
            content += token.Href.NormalizeLink();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, MarkdownLinkInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Href.NormalizeLink();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmIncludeInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Src.NormalizeLink();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmIncludeBlockToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Src.NormalizeLink();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmFencesToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Path.NormalizeLink();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmVideoBlockToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Link.NormalizeLink();
            content += Constants.Separator;

            return content;
        }

        public virtual StringBuffer Render(IMarkdownRenderer render, DfmXrefInlineToken token, IMarkdownContext context)
        {
            var content = StringBuffer.Empty;
            content += token.Href.NormalizeLink();
            content += Constants.Separator;

            return content;
        }
    }
}
