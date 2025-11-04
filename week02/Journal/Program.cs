using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select one of the following choices: \n1-Write\n2-Display\n3-Load\n4-Save\n5-Quit");
        Console.WriteLine("What would you like to do?");

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        string answer;

        PromptGenerator prompt = new PromptGenerator();
        Journal journal = new Journal();
        Entry answerEntry = new Entry();

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 5 )
            {
                Console.WriteLine("Please enter a number between 1 and 5.");
                continue;
            }

            if (choice == 1) // add the text
            {
                prompt.GetRandomPrompt();
                Console.WriteLine(prompt.GetRandomPrompt());

                answer = Console.ReadLine();

                answerEntry._date = dateText;
                answerEntry._entryText = answer;
                answerEntry._promptText = prompt.GetRandomPrompt();

                journal.AddEntry(answerEntry);

                Console.WriteLine("Entry added successfully");

            }
        
            else if (choice == 2) // display
            {
                journal.DisplayAll();
            }

            else if (choice == 4) // Save the file
            {   
                Console.WriteLine("Enter file's name to save: ");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }

            else if (choice == 3)// Load the file
            {
                Console.WriteLine("Enter file's name to lad: ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            
            else if (choice == 5) // Break the wool
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}