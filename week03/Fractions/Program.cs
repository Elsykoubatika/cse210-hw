using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction(3, 4);
        fraction.SetBottom(4);
        fraction.SetTop(3);

        Console.WriteLine(fraction.GetBottom());
        Console.WriteLine(fraction.GetTop());

        Console.WriteLine(fraction.GetDecimalValue());
        Console.WriteLine(fraction.GetFractionString());
    }
}