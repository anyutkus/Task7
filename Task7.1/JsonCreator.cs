namespace Task7._1
{
    public static class JsonCreator
    {
        public static void Create(string fileName, string json)
        {
            File.WriteAllText($"{fileName}.json", json);
        }
    }
}

