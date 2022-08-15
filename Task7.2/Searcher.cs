namespace Task7._2
{
    public class Searcher
    {
        private readonly List<(string, double, double)> _data = new();

        public Searcher(List<(string, double, double)> data)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("Parameter cannot be null or empty", nameof(data));
            }

            foreach (var line in data)
            {
                _data.Add(line);
            }
        }

        public string GetPointName(double coord1, double coord2, int k)
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
                .OrderByDescending(x => x.Amount).First().Title;
        }
    }
}

