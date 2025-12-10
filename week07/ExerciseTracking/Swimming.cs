using System;
using System.Collections.Generic;
using System.Globalization;

public class Swimming: Activity
{
    private int _laps;
    private double  _poolLength;

    public Swimming(DateTime date, int duration, int laps, double poolLengthMeters = 50.0) : base(date, duration)
    {
        _laps = laps;
        _poolLength = poolLengthMeters;
    }

    public override double GetDistance()
    {
        return (_laps * _poolLength) / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDuration()) * 60;
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }
}