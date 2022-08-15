namespace Task7._1;

public static class Program
{
    public static void Main()
    {
        var data = LineReader.LineConvertion("data.csv");
        Vacation v = new(data);

        Console.WriteLine($"Average : {v.AvgVacationDuration()}");

        foreach (var vacation in v.GetVacationDuration())
        {
            Console.WriteLine($"{vacation.Name} - {vacation.Duration}");
        }

        JsonGenerator.Generate("Vacation", v.GetVacationDuration());
    }
}