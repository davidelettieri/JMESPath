using System.Text.Json;
using System.Text.Json.Nodes;

namespace JMESPath.Tests;

public class Tests
{
    [Theory]
    [InlineData("assets/filters.json")]
    [InlineData("assets/basic.json")]
    [InlineData("assets/boolean.json")]
    [InlineData("assets/escape.json")]
    [InlineData("assets/functions.json")]
    [InlineData("assets/identifiers.json")]
    [InlineData("assets/current.json")]
    [InlineData("assets/indices.json")]
    [InlineData("assets/literal.json")]
    [InlineData("assets/multiselect.json")]
    [InlineData("assets/pipe.json")]
    [InlineData("assets/slice.json")]
    [InlineData("assets/syntax.json")]
    [InlineData("assets/unicode.json")]
    [InlineData("assets/wildcard.json")]
    public async Task Compliance(string testFile)
    {
        var source = File.ReadAllText(testFile);

        var tests = JsonSerializer.Deserialize<Test[]>(source,
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;

        foreach (var test in tests)
        {
            foreach (var testCase in test.Cases)
            {
                JsonNode? result = JMESPath.Search(testCase.Expression, test.Given);
                Assert.Equal(testCase.Result?.ToString(), result?.ToString());
            }
        }
    }
}

record Test(JsonValue Given, TestCase[] Cases);

record TestCase(string Expression, JsonValue Result);