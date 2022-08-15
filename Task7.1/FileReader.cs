namespace Task7._1
{
    public static class FileReader
    {
        public static List<string> ReadFromFile(string fileName)
        {
            List<string> list = new();

            try
            {
                using (var stream = new StreamReader($@"{fileName}"))
                {
                    string? line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"{fileName} cannot be found", ex.Message);
            }

            return list;
        }
    }
}

