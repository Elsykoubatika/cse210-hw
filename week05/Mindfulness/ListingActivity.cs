using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _listfromUser;
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "his activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 100)
    {
        _listfromUser = new List<string>();
        _prompts = new List<string>();
        _count = _listfromUser.Count();
    }

    public void GetPrompt(string questions)
    {
        _prompts.Add(questions);
    }
    public void Run()
    {
        ShowSpinner();
        Console.Clear();
        Console.WriteLine($"Welcom de {GetName()}\n");
        Console.WriteLine(GetDiscription());
        
        Console.Write("\nHow long, in seconds, would you like for your session?");
        int seconds = int.Parse(Console.ReadLine());

        ShowPorcent();

        Console.WriteLine("Liste  as many responses you can of the following prompt ");
        
        Console.WriteLine($"__{GetRandomPrompt()}__");
        Console.Write($"You may begin in:");
        ShowCountDown(seconds);

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        while (DateTime.Now <= futureTime)
        {   
            Console.Write(">");
            string question = Console.ReadLine();
            GetListFromUser(question);
        }
        Console.WriteLine($"You listed {_count} items\n");
        ShowSpinner();
        Console.WriteLine($"You completed another {seconds} seconds of the listing activity");
        ShowPorcent();
        Console.Clear();

    }

    public int GetCount()
    {
        return _count;
    }
    public void GetListFromUser(string user)
    {
        _listfromUser.Add(user);
    }
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(_prompts.Count);
        return _prompts[randomIndex];
    }

}