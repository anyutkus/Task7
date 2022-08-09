namespace Task7._2;

public static class Program
{
    public static async Task Main()
    {
        kNN el = new();
        await foreach (var res in GetValues())
        {
            Console.WriteLine($"{res.Item1}, {res.Item2}, {res.Item3}");
        }
        Console.ReadKey();
    }

    public static async IAsyncEnumerable<(double, double, string)> GetValues()
    {
        for (var i = 0; i < 10; i++)
        {
            var result = await Generate();
            yield return result;
            await Task.Delay(1000);
        }
    }

    public static Task<(double, double, string)> Generate()
    {
        var task = new Task<(double, double, string)>(() =>
        {
            var c1 = GetRandom();
            var c2 = GetRandom();
            var rnd = new Random();
            var k = rnd.Next(1, 6);
            return (c1, c2, kNN.Algorithm(c1, c2, k));

        });
        task.Start();
        return task;
    }

    public static double GetRandom()
    {
        Random random = new Random();
        double result = random.NextDouble();
        return Math.Round(result * 10, 2);
    }
}