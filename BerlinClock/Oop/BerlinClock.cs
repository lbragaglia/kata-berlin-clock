using static BerlinClock.Oop.BerlinClock.Lamp;

namespace BerlinClock.Oop;

public class BerlinClock
{
    public enum Lamp
    {
        Yellow = 1,
        Red = 2,
        Off = 0
    }

    private readonly Lamp[] _secondsRow = { Yellow };
    private readonly Lamp[] _fiveHoursRow = { Red, Red, Red, Red };
    private readonly Lamp[] _singleHoursRow = { Red, Red, Red, Red };

    private readonly Lamp[] _fiveMinutesRow =
        { Yellow, Yellow, Red, Yellow, Yellow, Red, Yellow, Yellow, Red, Yellow, Yellow };

    private readonly Lamp[] _singleMinutesRow = { Yellow, Yellow, Yellow, Yellow };

    public BerlinClock(TimeSpan time)
    {
        var berlinTime = new BerlinTime(time);
        SwitchOff(_secondsRow, berlinTime.IsSecondsLampSwitchedOn() ? 1 : 0);
        SwitchOff(_fiveHoursRow, berlinTime.GetFiveHoursRowSwitchedOnLamps());
        SwitchOff(_singleHoursRow, berlinTime.GetSingleHoursRowSwitchedOnLamps());
        SwitchOff(_fiveMinutesRow, berlinTime.GetFiveMinutesRowSwitchedOnLamps());
        SwitchOff(_singleMinutesRow, berlinTime.GetSingleMinutesRowSwitchedOnLamps());
    }

    private static void SwitchOff(IList<Lamp> lamps, int switchedOn)
    {
        for (var i = switchedOn; i < lamps.Count; i++)
        {
            lamps[i] = Off;
        }
    }

    public void Apply(IBerlinClockFormatter formatter)
    {
        formatter.BuildSecondsRow(_secondsRow);
        formatter.BuildFiveHoursRow(_fiveHoursRow);
        formatter.BuildSingleHoursRow(_singleHoursRow);
        formatter.BuildFiveMinutesRow(_fiveMinutesRow);
        formatter.BuildSingleMinutesRow(_singleMinutesRow);
    }
}