using Xunit;

namespace MarkdownToKeywords.Test
{
    public class StopWordsTest
    {
        [Fact]
        public void TestIgnoreStopWords()
        {
            var content = @"# This is a test for stop words.";
            var filePath = "a.md";

            Helper.WriteToFile(filePath, content);
            var result = Program.Transform(filePath);
            var expect = "test stop words";

            Assert.Equal(result.Trim(), expect);
        }
    }
}
