using System;

class Program
{
    static void Main(string[] args)
    {
        
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int square = SquareNumber(userNumber);

        DisplayResult(userName, square);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Programe");
    }

    static string PromptUserName()
    {
        DisplayWelcome();
        Console.WriteLine("Enter your name");
        string Username = Console.ReadLine();

        return Username;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Enter your number");
        int UserNumber = int.Parse(Console.ReadLine());

        return UserNumber;

    }

    static int SquareNumber(int userNumber)
    {
        int Square = userNumber * userNumber;

        return Square;
    }

    static void DisplayResult(string username, int square)
    {
        Console.WriteLine($"{username}, the square of your number is {square}");
    }
    
}