using System;

public class Goal
{
    private string _Name;
    private string _description;
    private int _points;
    private int _totalScore;

    public Goal(string name, string description, int points)
    {
        _Name = name;
        _points = points;
        _description = description;
        _totalScore = 0;
    }
    public string GetName()
    {
        return _Name;
    }
    public int GetPointe()
    {
        return _points;
    }
    public string GetDiscription()
    {
        return _description;
    }
    public int GetScore()
    {
        return _totalScore;
    }
    public virtual void RecordEvent()
    {
        _totalScore += _points;

        Console.WriteLine("Which goal did you achieve?");
        int obje = int.Parse(Console.ReadLine());
        Console.WriteLine($"The event has been recorded for the goal: {_Name}");
    }

    public virtual bool IsComplet()
    {
        return true;
    }

    public virtual string GetDetailsString()
    {
        string status;
        if (IsComplet())
        {
            status = "X";
        }
        else
        {
            status = " ";
        }
        return $"[{status}] {_Name} - {_description}";
    }
    public virtual string GetstringRepresentation()
    {
        return $"{_Name}|{_description}|{_points}|";
    }

}