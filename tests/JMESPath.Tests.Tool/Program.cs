using System.Text.Json;
using System.Text.Json.Nodes;
using Fluid;
using Humanizer;

var assetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "assets");
var testFiles = Directory.GetFiles(assetDirectory);

var parser = new FluidParser();
var templateSource = File.ReadAllText("TestClass.template.txt");
if (parser.TryParse(templateSource, out var template, out var error))
{
    foreach (var testFile in testFiles)
    {
        if (testFile.EndsWith("benchmarks.json"))
        {
            continue;
        }
        
        var fileInfo = new FileInfo(testFile);
        
        var source = File.ReadAllText(testFile);
        var tests = JsonSerializer.Deserialize<Test[]>(source,
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        var name = fileInfo.Name[..^5].Dehumanize();
        var testClass = new TestClass(name, tests);
        var context = new TemplateContext(testClass,
            new TemplateOptions() { MemberAccessStrategy = new UnsafeMemberAccessStrategy() });
        var result = template.Render(context);
        Console.WriteLine(result);
        File.WriteAllText("/home/davide/repos/JMESPath/tests/JMESPath.Tests/" + name + ".cs", result);
    }
}
else
{
    Console.WriteLine($"Error: {error}");
}

record TestClass(string Name, Test[] Tests);

record Test(JsonValue Given, TestCase[] Cases);

record TestCase(string Expression, JsonValue Result);