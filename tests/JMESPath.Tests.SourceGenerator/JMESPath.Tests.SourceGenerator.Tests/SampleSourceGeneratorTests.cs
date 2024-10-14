using System.IO;
using System.Linq;
using JMESPath.Tests.SourceGenerator.Tests.Utils;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace JMESPath.Tests.SourceGenerator.Tests;

public class SampleSourceGeneratorTests
{
    private const string TestSource = 
"""
[
  {
      "given": {
          "foo": [{"name": "a"}, {"name": "b"}],
          "bar": {"baz": "qux"}
      },
      "cases": [
          {
              "expression": "@",
              "result": {
                  "foo": [{"name": "a"}, {"name": "b"}],
                  "bar": {"baz": "qux"}
              }
          },
          {
              "expression": "@.bar",
              "result": {"baz": "qux"}
          },
          {
              "expression": "@.foo[0]",
              "result": {"name": "a"}
          }
      ]
  }
]
""";

    [Fact]
    public void GenerateClassesBasedOnDDDRegistry()
    {
        // Create an instance of the source generator.
        var generator = new TestsSourceGenerator();

        // Source generators should be tested using 'GeneratorDriver'.
        var driver = CSharpGeneratorDriver.Create(new[] { generator },
            new[]
            {
                // Add the additional file separately from the compilation.
                new TestAdditionalFile("./assets/test.json", TestSource)
            });

        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(SampleSourceGeneratorTests));

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation, out _);

        // Retrieve all files in the compilation.
        var generatedFiles = newCompilation.SyntaxTrees
            .Select(t => Path.GetFileName(t.FilePath))
            .ToArray();

        // In this case, it is enough to check the file name.
        Assert.Equivalent(new[]
        {
            "test.g.cs",
        }, generatedFiles);
    }
}