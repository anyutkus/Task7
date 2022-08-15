namespace Task7._1
{
    public class JsonCreator
    {
        public JsonCreator(string fileName, string json)
        {
            File.WriteAllText($"{fileName}.json", json);
        }
    }
}

