using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal (string name, string description, int points, int target, int bonus) : base (name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = 0;
    }

    public override void  RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            int totalScore =+ GetPointe();

            if (_amountCompleted == _target)
            {
                totalScore += _bonus;
                Console.WriteLine($"You completed '{GetName()}' and earned a bonus of {_bonus} points!");
            }
            else
            {
                Console.WriteLine($"You progressed on '{GetName()}' ({_amountCompleted}/{_target}) and earned {GetPointe()} points.");
            }
        }
        else
        {
            Console.WriteLine($"The goal '{GetName()}' is already fully completed.");
        }
    }

    public int GetamountCompleted()
    {
        return _amountCompleted;
    }
    public override bool IsComplet()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return$"[{(IsComplet() ? "X" : " ")}] {GetName()} ({GetDiscription()}) - Accomplished {_amountCompleted}/{_target} times";
    }

    public override string GetstringRepresentation()
    {
        return$"[{(IsComplet() ? "X" : " ")}] {GetName()}|{GetDiscription()}|{GetPointe()}|{_target}/{_amountCompleted}|{_bonus}";
    }
}