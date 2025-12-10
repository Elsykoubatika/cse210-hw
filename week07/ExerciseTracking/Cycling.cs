using System;
using System.Collections.Generic;
using System.Globalization;

public class Cycling: Activity
{
    private double _distance;

    public Cycling (DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetDuration()) * 60;
    }

    public override double GetPace()
    {
        return GetDuration() / _distance;
    }
}