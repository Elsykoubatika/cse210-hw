using System;

public class Program
{
    public static void Main()
    {
        var activities = new List<Activity>
        {
            new Running(DateTime.Today, 45, 20.0),      
            new Cycling(DateTime.Today, 60, 30.0),      
            new Swimming(DateTime.Today, 30, 20, 50.0),
            new Swimming(DateTime.Today, 25, 15),
            new Running(DateTime.Today, 30, 10.0),
        };

        Console.WriteLine("================== SUMMARY OF ACTIVITY ==========================");
        Console.WriteLine();
        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
