using System.Text.Json.Nodes;

namespace JMESPath;

public static class JMESPath
{
    public static JsonNode? Search(string expression, JsonNode document) => new JsonObject();
}