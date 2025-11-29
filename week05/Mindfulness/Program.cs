using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity("", "", 100);

        BreathingActivity breathingActivity = new BreathingActivity();
        
        ReflectingActivity reflecting = new ReflectingActivity();
        reflecting.GetPrompts("Think of a time when you stood up for someone else.");
        reflecting.GetPrompts("Think of a time when you did something really difficult.");
        reflecting.GetPrompts("Think of a time when you helped someone in need.");
        reflecting.GetPrompts("Think of a time when you did something truly selfless.");
    
        reflecting.GetQuestions("Why was this experience meaningful to you?");
        reflecting.GetQuestions("Have you ever done anything like this before?");
        reflecting.GetQuestions("How did you get started?");
        reflecting.GetQuestions("How did you feel when it was complete?");
        reflecting.GetQuestions("What made this time different than other times when you were not as successful?");
        reflecting.GetQuestions("What is your favorite thing about this experience?");
        reflecting.GetQuestions("What could you learn from this experience that applies to other situations?");
        reflecting.GetQuestions("What did you learn about yourself through this experience?");

        ListingActivity listingActivity = new ListingActivity();
        listingActivity.GetPrompt("Who are people that you appreciate?");
        listingActivity.GetPrompt("What are personal strengths of yours?");
        listingActivity.GetPrompt("Who are people that you have helped this week?");
        listingActivity.GetPrompt("When have you felt the Holy Ghost this month?");
        listingActivity.GetPrompt("Who are some of your personal heroes?");

        activity.ShowPorcent();
        bool choix = true;
        while (choix!)
        {
            Console.WriteLine($"Menu Options:\n 1. Staet Breathing activity\n 2. Start Reflecting activity\n 3. Start Listing Activity\n 4. Quit");
            Console.Write("Select a choice from the menu:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                breathingActivity.Run();
            }

            else if (choice == 2) 
            {
                reflecting.Run();
            }

            else if ( choice == 3)
            {
                listingActivity.Run();
            }

            else if (choice == 4)
            {
                choix = false;
            }

        }
    }
}