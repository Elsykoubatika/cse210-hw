using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string description, int points) : base("Simple Goal", description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"You completed '{GetName()}' and earned {GetPointe()} points!");
        }
        else
        {
            Console.WriteLine($"The goal '{GetName()}' is already completed.");
        }
    }

    public override bool IsComplet()
    {
        return _isComplete;
    }

    public override string GetstringRepresentation()
    {
        return $"SimpleGoal|{GetName()}|{GetDiscription()}|{GetPointe()}|{_isComplete}";
    }
}