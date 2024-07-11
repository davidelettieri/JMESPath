using System.Text.Json;
using HandlebarsDotNet;
using Humanizer;

var assetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "assets");
var testFiles = Directory.GetFiles(assetDirectory);

var handleBars = Handlebars.Create(new HandlebarsConfiguration { NoEscape = true, TextEncoder = null,  });
var template = handleBars.Compile(File.ReadAllText("TestClass.template.txt"));

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
    var name = fileInfo.Name[0..^5].Dehumanize();
    var testClass = new TestClass(name, tests);
    File.WriteAllText("test.txt", source);
    var result = template(testClass);

    File.WriteAllText(name + ".cs", result);
}

record TestClass(string Name, Test[] Tests);

record Test(JsonDocument Given, TestCase[] Cases);

record TestCase(string Expression, JsonDocument Result);