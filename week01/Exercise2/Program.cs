using System;

class Program
{
    static void Main(string[] args)
    {
        String grade;
        float operation;
        String percentage;

        Console.WriteLine("What is your grade percentage?");
        percentage = Console.ReadLine();

        operation = (float.Parse(percentage) % 10);

        if (float.Parse(percentage) >= 90)
        {
            grade = "A";
        }
        else if (float.Parse(percentage) >= 80)
        {
            grade = "B";
        }
        else if (float.Parse(percentage) >= 70)
        {
            grade = "C";
        }
        else if (float.Parse(percentage) >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        if (operation >= 7 && grade != "A" && grade != "F")
        {
            grade = grade.ToString() + "+";
        }
        else if (operation <= 3 && grade != "F")
        {
            grade = grade.ToString() + "-";
        }

        Console.WriteLine($"Your grade is {grade}");

        if (float.Parse(percentage) >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you have not passed the course. Better luck next time!");
        }
    }
}