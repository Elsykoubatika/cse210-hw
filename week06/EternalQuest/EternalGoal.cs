using System;
using System.ComponentModel;

public class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base("Eternal Goal", description, points)
    {}

    public override void RecordEvent()
    {
        
        Console.WriteLine($"You recorded an event for '{GetName()}' and earned {GetPointe()} points!");
    }
    public override bool IsComplet()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }
    public override string GetstringRepresentation()
    {
        return base.GetstringRepresentation();
    }
}