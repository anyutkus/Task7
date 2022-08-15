namespace Task7._2
{
    public class Loop
    {
        private readonly Searcher _searcher;

        public Loop(Searcher searcher)
        {
            if (searcher == null)
            {
                throw new ArgumentNullException(nameof(searcher), "cannot be null");
            }

            _searcher = searcher;
        }

        public async IAsyncEnumerable<(double, double, string)> Start()
        {
            for (var i = 0; i < 10; i++)
            {
                var result = await Calculate();
                yield return result;
                await Task.Delay(1000);
            }
        }

        private Task<(double, double, string)> Calculate()
        {
            var task = new Task<(double, double, string)>(() =>
            {
                var coord = PointGenerator.GetPoint();

                return (coord.Item1, coord.Item2, _searcher.GetPointName(coord.Item1, coord.Item2, coord.Item3));

            });
            task.Start();

            return task;
        }
    }
}

