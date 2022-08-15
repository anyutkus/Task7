using System.Collections.Concurrent;

namespace Task7._1
{
    public static class LineReader
    {
        public static ConcurrentStack<(string, DateOnly, DateOnly)> LineConvertion(string fileName)
        {
            var list = FileReader.ReadFromFile(fileName);
            var values = new ConcurrentStack<(string, DateOnly, DateOnly)>();
            var lineNumber = 0;

            foreach (var line in list)
            {
                try
                {
                    lineNumber++;
                    var temp = line.Split(",");
                    values.Push((temp[0], DateOnly.Parse(temp[1]), DateOnly.Parse(temp[2])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Something went wrong in line number {lineNumber}");
                }
            }

            return values;
        }
    }
}

