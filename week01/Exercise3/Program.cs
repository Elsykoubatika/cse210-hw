using System;

class Program
{
    static void Main(string[] args)
    {
        bool replay = true;

        while (replay)
        {
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1, 100);

            int number = 0;

            bool hope = false;

            while (!hope)
            {
                Console.WriteLine("What is the magic number?");

                string guess = Console.ReadLine();

                int guessNumber = int.Parse(guess);
                number += 1;

                if (guessNumber < randomNumber)
                {
                    Console.WriteLine("Higher");
                }

                else if (guessNumber > randomNumber)
                {
                    Console.WriteLine("Lower");
                }

                else
                {
                    Console.WriteLine($"You guessed it? The number is {randomNumber}! It took you {number} trials!");
                    hope = true;
                }
            }

            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgain = Console.ReadLine();

            if (playAgain.ToLower() != "yes")
            {
                replay = false;
            }
        }

    }
}