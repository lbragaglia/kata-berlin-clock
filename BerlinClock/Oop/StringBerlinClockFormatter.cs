namespace BerlinClock.Oop;

public class StringBerlinClockFormatter : IBerlinClockFormatter
{
    private const string NotDefined = "[N/D]";

    private string _secondsRow = NotDefined;
    private string _fiveHoursRow = NotDefined;
    private string _singleHoursRow = NotDefined;
    private string _fiveMinutesRow = NotDefined;
    private string _singleMinutesRow = NotDefined;

    public StringBerlinClock Build()
    {
        return new StringBerlinClock(
            _secondsRow,
            _fiveHoursRow,
            _singleHoursRow,
            _fiveMinutesRow,
            _singleMinutesRow
        );
    }

    public void BuildSecondsRow(params BerlinClock.Lamp[] lamps)
    {
        _secondsRow = FormatLamps(lamps);
    }

    public void BuildFiveHoursRow(params BerlinClock.Lamp[] lamps)
    {
        _fiveHoursRow = FormatLamps(lamps);
    }

    public void BuildSingleHoursRow(params BerlinClock.Lamp[] lamps)
    {
        _singleHoursRow = FormatLamps(lamps);
    }

    public void BuildFiveMinutesRow(params BerlinClock.Lamp[] lamps)
    {
        _fiveMinutesRow = FormatLamps(lamps);
    }

    public void BuildSingleMinutesRow(params BerlinClock.Lamp[] lamps)
    {
        _singleMinutesRow = FormatLamps(lamps);
    }

    private static string FormatLamps(IEnumerable<BerlinClock.Lamp> lamps) =>
        string.Join("", lamps.Select(l => l switch
        {
            BerlinClock.Lamp.Yellow => "Y",
            BerlinClock.Lamp.Red => "R",
            _ => "O"
        }));
}