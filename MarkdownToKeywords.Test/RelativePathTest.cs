﻿using Xunit;


namespace MarkdownToKeywords.Test
{
    public class RelativePathTest
    {
        [Fact]
        public void TestSimpleRelativePath()
        {
            var content = @"# This is a [link](../d.md).";
            var filePath = "a/b/c.md";
            var baseDir = "a/";

            Helper.WriteToFile(filePath, content);
            var result = Program.Transform(filePath, baseDir);
            var expect = "link d.md";

            Assert.Equal(result.Trim(), expect);
        }

        [Fact]
        public void TestRelativePathWithTilde()
        {
            var content = @"# This is a [link](~/b/d.md).";
            var filePath = "a/b/c.md";
            var baseDir = "a/";

            Helper.WriteToFile(filePath, content);
            var result = Program.Transform(filePath, baseDir);
            var expect = "link b/d.md";

            Assert.Equal(result.Trim(), expect);
        }
    }
}
