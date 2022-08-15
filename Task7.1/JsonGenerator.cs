using System.Text.Json;

namespace Task7._1
{
    public class JsonGenerator
    {
        public JsonGenerator(string fileName, object @object)
        {
            ArgumentNullException.ThrowIfNull(@object, nameof(@object));

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(@object, options);

            new JsonCreator(fileName, json);
        }
    }
}

