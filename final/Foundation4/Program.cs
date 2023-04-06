using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 4), 45, 20),
            new Swimming(new DateTime(2022, 11, 5), 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

public abstract class Activity
{
    protected DateTime _activityDate;
    protected int _durationInMinutes;

    public Activity(DateTime activityDate, int durationInMinutes)
    {
        _activityDate = activityDate;
        _durationInMinutes = durationInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_activityDate.ToString("dd MMM yyyy")} {GetType().Name} ({_durationInMinutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

public class Running : Activity
{
    private double _distanceInKm;

    public Running(DateTime activityDate, int durationInMinutes, double distanceInKm)
        : base(activityDate, durationInMinutes)
    {
        _distanceInKm = distanceInKm;
    }

    public override double GetDistance()
    {
        return _distanceInKm;
    }

    public override double GetSpeed()
    {
        return (_distanceInKm / _durationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _durationInMinutes / _distanceInKm;
    }
}

public class Cycling : Activity
{
    private double _speedInKph;

    public Cycling(DateTime activityDate, int durationInMinutes, double speedInKph)
        : base(activityDate, durationInMinutes)
    {
        _speedInKph = speedInKph;
    }

    public override double GetDistance()
    {
        return (_speedInKph / 60) * _durationInMinutes;
    }

    public override double GetSpeed()
    {
        return _speedInKph;
    }

    public override double GetPace()
    {
        return 60 / _speedInKph;
    }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime activityDate, int durationInMinutes, int laps)
        : base(activityDate, durationInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _durationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _durationInMinutes / GetDistance();
    }
}
