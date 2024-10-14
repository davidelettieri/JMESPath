// <auto-generated /> 
#nullable enable

using JMESPath;

public class Escape
{

    [Theory]
    [InlineData(
"""
"foo.bar"
""",
"""
dot
""")]
    [InlineData(
"""
"foo bar"
""",
"""
space
""")]
    [InlineData(
"""
"foo\nbar"
""",
"""
newline
""")]
    [InlineData(
"""
"foo\"bar"
""",
"""
doublequote
""")]
    [InlineData(
"""
"c:\\\\windows\\path"
""",
"""
windows
""")]
    [InlineData(
"""
"/unix/path"
""",
"""
unix
""")]
    [InlineData(
"""
"\"\"\""
""",
"""
threequotes
""")]
    [InlineData(
"""
"bar"."baz"
""",
"""
qux
""")]
    public void Test_1(string expression, string expectedResult)
    {
        // Arrange 
        string? given =
"""
{
  "foo.bar": "dot",
  "foo bar": "space",
  "foo\nbar": "newline",
  "foo\u0022bar": "doublequote",
  "c:\\\\windows\\path": "windows",
  "/unix/path": "unix",
  "\u0022\u0022\u0022": "threequotes",
  "bar": {
    "baz": "qux"
  }
}
""";

        // Act 
        string? result = JMESPathSearcher.Search(expression, given);
        
        // Assert
        Assert.Equal(result, expectedResult);
    }

}