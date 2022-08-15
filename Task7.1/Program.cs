namespace Task7._1;

public static class Program
{
    public static void Main()
    {
        var data = LineReader.LineConvertion("data.csv");
        Vacation emp = new(data);

        Console.WriteLine($"Average : {emp.AvgVacationDuration()}");

        foreach (var vacation in emp.GetVacationDuration())
        {
            Console.WriteLine($"{vacation.Name} - {vacation.Duration}");
        }

        new JsonGenerator("Vacation", emp.GetVacationDuration());
    }
}