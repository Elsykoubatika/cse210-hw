using System;
using System.Security.Cryptography.X509Certificates;

public class BreathingActivity: Activity
{
    public BreathingActivity() : base(" Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 80)
    {
        
    }

    public void Run()
    {
        ShowSpinner();
        Console.Clear();
        Console.WriteLine($"Welcome to the {GetName()}.\n");
        DisplayStartingMessage();
        Console.Write("\nHow long, in seconds, would you like for your session?");

        int seconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...!");
        ShowPorcent();

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        while (DateTime.Now <= futureTime)
        {
            Console.Write("\nNow breathing in...");
            ShowCountDown(seconds);

            Console.Write("\nbreathing Out...");
            ShowCountDown(seconds);
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Well done !!");
        ShowPorcent();
        Console.Clear();
    }
}