namespace BerlinClock;

public sealed class BerlinTime
{
    private readonly int _minutes;
    private readonly int _hours;
    private readonly int _seconds;

    public BerlinTime(TimeSpan time)
    {
        _hours = time.Hours;
        _minutes = time.Minutes;
        _seconds = time.Seconds;
    }

    public int GetSingleMinutesRowSwitchedOnLamps() => _minutes % 5;

    public int GetFiveMinutesRowSwitchedOnLamps() => _minutes / 5;

    public int GetSingleHoursRowSwitchedOnLamps() => _hours % 5;

    public int GetFiveHoursRowSwitchedOnLamps() => _hours / 5;

    public bool IsSecondsLampSwitchedOn() => _seconds % 2 == 0;
}