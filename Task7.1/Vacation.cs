using System.Collections.Concurrent;

namespace Task7._1
{
    public class Vacation
    {
        private readonly ConcurrentStack<(string, DateOnly, DateOnly)> _vacationData = new();

        public Vacation(ConcurrentStack<(string, DateOnly, DateOnly)> values)
        {
            Parallel.ForEach(values, line =>
            {
                _vacationData.Push(line);
            });
        }

        public int AvgVacationDuration()
        {
            var duration = _vacationData.AsParallel().Select(x => x.Item3.DayNumber - x.Item2.DayNumber + 1);
            var amount = duration.Count();
            int sum = 0;
            foreach (var s in duration)
            {
                sum += s;
            }

            return sum / amount;
        }

        public List<Person> GetVacationDuration()
        {
            var vacation = _vacationData.AsParallel().GroupBy(x => x.Item1)
                           .Select(x => new Person
                           {
                               Name = x.Key,
                               Duration = Math.Round(_vacationData.Where(s => s.Item1 == x.Key).Average(x => (x.Item3.DayNumber - x.Item2.DayNumber + 1)), 2)
                           }
                           ).ToList();

            return vacation;
        }
    }
}

