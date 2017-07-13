using System.IO;

namespace MarkdownToKeywords.Test
{
    public static class Helper
    {
        public static void WriteToFile(string file, string content)
        {
            var dir = Path.GetDirectoryName(file);
            if (!string.IsNullOrEmpty(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(file, content);
        }
    }
}
