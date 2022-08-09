using System.Collections.Concurrent;
using System.Text.Json;

namespace Task7._1
{
	public class Employees
	{
		private ConcurrentStack<(string, DateOnly, DateOnly)> _employees= new();

		public Employees()
		{
			using var stream = new StreamReader(@"data.csv");
            int lineNumber = 0;
            while (!stream.EndOfStream)
            {
				string[] line = new string[3];
                try
                {
                    lineNumber++;
                    line = stream.ReadLine().Split(",");
                    _employees.Push((line[0], DateOnly.Parse(line[1]), DateOnly.Parse(line[2])));
                }
				catch(Exception ex)
                {
					Console.WriteLine(ex.Message);
					Console.WriteLine($"Something went wrong in line number {lineNumber}");
                }
            }
			stream.Dispose();
		}

		public int AvgVacationDuration()
        {
			var duration = _employees.AsParallel().Select(x => (x.Item3.DayNumber - x.Item2.DayNumber));
			var amount = duration.Count();
			int sum = 0;
			foreach(var s in duration)
            {
				sum += s;
            }
			return sum / amount;
        }

		public void GetVacationDuration()
		{
			var vacation = _employees.AsParallel().GroupBy(x=>x.Item1)
						   .Select(x => new
						   {
							   Name = x.Key,
							   Duration = Math.Round(_employees.Where(s => s.Item1 == x.Key).Average(x => (x.Item3.DayNumber - x.Item2.DayNumber)), 2)
						   }
						   );

			Parallel.ForEach(vacation, v => Console.WriteLine($"{v.Name} - {v.Duration}"));

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(vacation, options);
            File.WriteAllText("Vacation.json", json);
        }
	}
}

