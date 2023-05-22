namespace BerlinClock.Oop;

public class BerlinClock
{
    private const int SecondsRowSize = 1;
    private const int FiveHoursRowSize = 4;
    private const int SingleHoursRowSize = 4;
    private const int FiveMinutesRowSize = 11;
    private const int SingleMinutesRowSize = 4;

    public enum Lamp
    {
        Yellow = 1,
        Red = 2,
        Off = 0
    }

    private readonly Lamp[] _secondsRow = new Lamp[SecondsRowSize];
    private readonly Lamp[] _fiveHoursRow = new Lamp[FiveHoursRowSize];
    private readonly Lamp[] _singleHoursRow = new Lamp[SingleHoursRowSize];
    private readonly Lamp[] _fiveMinutesRow = new Lamp[FiveMinutesRowSize];
    private readonly Lamp[] _singleMinutesRow = new Lamp[SingleMinutesRowSize];

    public BerlinClock(TimeSpan time)
    {
        var berlinTime = new BerlinTime(time);
        _secondsRow[0] = berlinTime.IsSecondsLampSwitchedOn() ? Lamp.Yellow : Lamp.Off;
        for (var i = 0; i < FiveHoursRowSize; i++)
        {
            _fiveHoursRow[i] = i < berlinTime.GetFiveHoursRowSwitchedOnLamps()
                ? Lamp.Red
                : Lamp.Off;
        }

        for (var i = 0; i < SingleHoursRowSize; i++)
        {
            _singleHoursRow[i] = i < berlinTime.GetSingleHoursRowSwitchedOnLamps()
                ? Lamp.Red
                : Lamp.Off;
        }

        for (var i = 0; i < FiveMinutesRowSize; i++)
        {
            _fiveMinutesRow[i] = i < berlinTime.GetFiveMinutesRowSwitchedOnLamps()
                ? (i + 1) % 3 == 0 ? Lamp.Red : Lamp.Yellow
                : Lamp.Off;
        }

        for (var i = 0; i < SingleMinutesRowSize; i++)
        {
            _singleMinutesRow[i] = i < berlinTime.GetSingleMinutesRowSwitchedOnLamps()
                ? Lamp.Yellow
                : Lamp.Off;
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