using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetDiscription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Thank you!");
    }

    // I add show pourcent spinner 
    public void ShowPorcent()
    {
        
        for (int i = 0; i <= 100; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"{i}%");
            Thread.Sleep(_duration);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void ShowSpinner()
    {
        List<string> spinner = new List<string>();
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");
        spinner.Add("|");

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(10);
        int i = 0;
        while (DateTime.Now <= futureTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(_duration);
            Console.Write("\b \b");

            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }

    }

    public void ShowCountDown(int second)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(second);
        int i = 9;
        while (DateTime.Now < futureTime)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
            if (i <= 0) break;
        }
    }

}