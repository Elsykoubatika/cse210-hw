using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        var reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his only begotten Son";
        var scripture = new Scripture(reference, text);

        string input;

        do
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to finish.");
            input = Console.ReadLine();

            if (input?.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }

        } while (input?.ToLower() != "quit" && !scripture.IsCompletelyHidden());

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}