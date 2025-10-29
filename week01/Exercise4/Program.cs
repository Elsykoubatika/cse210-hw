using System;
using System.Collections.Generic;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int Usernumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        while (Usernumber != 0)
        {
            String userAnswers = Console.ReadLine();
            Usernumber = int.Parse(userAnswers);

            if (Usernumber != 0)
            {
                numbers.Add(Usernumber);
            }
        }

        int Sum = 0;
        foreach (int number in numbers)
        {
            Sum += number;
        }
        Console.WriteLine($"The sum is: {Sum}");

        float average = 0;
        int LargestNumber = numbers[0];
        int SmallestNumber = numbers[0];

        foreach (int number in numbers)
        {
            average = ((float)Sum) / numbers.Count;
            if (number > LargestNumber)
            {
                LargestNumber = number;
            }

            if (number < SmallestNumber && number > 0)
            {
                SmallestNumber = number;
            }
        }

        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest Number is: {LargestNumber}");
        Console.WriteLine($"smallest positive number is: {SmallestNumber}");

        var sorted = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is: " + string.Join(" ", sorted));
    }
}