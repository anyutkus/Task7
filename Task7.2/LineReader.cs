namespace Task7._2
{
    public static class LineReader
    {
        public static List<(string, double, double)> LineConversion(string fileName)
        {
            var list = FileReader.Read(fileName);
            var values = new List<(string, double, double)>();

            foreach (var line in list)
            {
                try
                {
                    var temp = line.Split(",");
                    values.Add((temp[0], double.Parse(temp[1]), double.Parse(temp[2])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return values;
        }
    }
}

