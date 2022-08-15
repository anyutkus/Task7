using System.Text.Json;

namespace Task7._1
{
    public static class JsonGenerator
    {
        public static void Generate(string fileName, object data)
        {
            ArgumentNullException.ThrowIfNull(data, nameof(data));

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(data, options);

            JsonCreator.Create(fileName, json);
        }
    }
}

