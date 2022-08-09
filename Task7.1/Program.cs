namespace Task7._1;

public static class Program
{
    public static void Main()
    {
        Employees emp = new();
        Console.WriteLine($"Average : {emp.AvgVacationDuration()}");
        emp.GetVacationDuration();
    }
}