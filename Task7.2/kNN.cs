namespace Task7._2
{
	public class kNN
	{
        private static readonly List<(string,double,double)> _data = new();

		public kNN()
		{
            using var stream = new StreamReader(@"data.txt");
            while (!stream.EndOfStream)
            {
                string[] line = new string[3];
                try
                {
                    line = stream.ReadLine().Split(",");
                    _data.Add((line[0], double.Parse(line[1]), double.Parse(line[2])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            stream.Dispose();
        }

		public static string Algorithm(double coord1, double coord2, int k)
        {
            var distance = _data.AsParallel()
                .Select(x => new
                {
                    Name = x.Item1,
                    Value = (coord1 - x.Item2) * (coord1 - x.Item2) + (coord2 - x.Item3) * (coord2 - x.Item3)
                }
                ).OrderBy(s => s.Value).Take(k);

            return distance.GroupBy(x => x.Name)
                .Select(x => new
                {
                    Title = x.Key,
                    Amount = x.Count()
                })
                .OrderByDescending(x=>x.Amount).First().Title;
        }
    }
}

