namespace BerlinClock.Oop;

public class StringBerlinClockAdapter : IStringBerlinClockFormatter
{
    public StringBerlinClock Format(string decimalTime)
    {
        var clock = new BerlinClock(TimeSpan.Parse(decimalTime));
        var formatter = new StringBerlinClockFormatter();
        clock.Apply(formatter);
        return formatter.Build();
    }
}