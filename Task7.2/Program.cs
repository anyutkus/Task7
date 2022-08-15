namespace Task7._2;

public static class Program
{
    public static async Task Main()
    {
        var list = LineReader.LineConversion("data.txt");
        Searcher values = new(list);
        var loop1 = new Loop(values);

        await foreach (var res in loop1.Start())
        {
            Console.WriteLine($"{res.Item1}, {res.Item2}, {res.Item3}");
        }
        Console.ReadKey();
    }
}