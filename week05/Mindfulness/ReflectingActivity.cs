using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 100)
    {
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public void GetQuestions(string questions)
    {
        _questions.Add(questions);
    }
    public void GetPrompts(string prompts)
    {
        _prompts.Add(prompts);
    }
    public void Run()
    {
        ShowSpinner();
        Console.Clear();
        Console.WriteLine("Welcome to the Reflecting Activity.\n");
        Console.WriteLine(GetDiscription());

        Console.WriteLine();
        Console.Write("\nHow long, in seconds, would you like for your session?");

        int seconds = int.Parse(Console.ReadLine());

        ShowPorcent();
        Console.WriteLine("Consider the following prompt:");
        DisplayPrompts();

        
        Console.WriteLine("\nWhen you have something in mind press enter to continue");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in:");
        ShowCountDown(seconds);

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        while (DateTime.Now <= futureTime)
        {
            DisplayQuestion();
            ShowSpinner();
        }
        Console.WriteLine("Well done !!");
        ShowPorcent();
        Console.Clear();
    }

    public string GetRandomPrompts()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(_prompts.Count);
        return _prompts[randomIndex];
    }

    public string GetRandomQuestions()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(_questions.Count);
        return _questions[randomIndex];
    }
    public void DisplayPrompts()
    {
        Console.WriteLine($"__{GetRandomPrompts()}__");
    }

    public void DisplayQuestion()
    {
        Console.WriteLine($">{GetRandomQuestions()}");
    }

}