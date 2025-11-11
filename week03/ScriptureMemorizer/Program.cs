using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Library library = new Library();
        Scripture scripture = library.GetRandomScripture();
        if (scripture == null)
        {
            Console.WriteLine("No scripture found in the library.");
            return;
        }

        string input;

        do
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            
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