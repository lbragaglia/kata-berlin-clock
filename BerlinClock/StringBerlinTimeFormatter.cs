namespace BerlinClock;

public sealed class StringBerlinTimeFormatter : IStringBerlinClockFormatter
{
    private const string FiveHoursRowLamps = "RRRR";
    private const string SingleHoursRowLamps = "RRRR";
    private const string FiveMinutesRowLamps = "YYRYYRYYRYY";
    private const string SingleMinutesRowLamps = "YYYY";
    private const string SecondsLamp = "Y";
    private const char SwitchedOffLamp = 'O';

    public StringBerlinClock Format(string decimalTime)
    {
        var time = new BerlinTime(TimeSpan.Parse(decimalTime));
        return new StringBerlinClock(
            BuildSecondsLamp(time),
            BuildFiveHoursRow(time),
            BuildSingleHoursRow(time),
            BuildFiveMinutesRow(time),
            BuildSingleMinutesRow(time)
        );
    }

    private static string BuildSecondsLamp(BerlinTime time) =>
        BuildRow(SecondsLamp, time.IsSecondsLampSwitchedOn() ? 1 : 0);

    private static string BuildFiveHoursRow(BerlinTime time) =>
        BuildRow(FiveHoursRowLamps, time.GetFiveHoursRowSwitchedOnLamps());

    private static string BuildSingleHoursRow(BerlinTime time) =>
        BuildRow(SingleHoursRowLamps, time.GetSingleHoursRowSwitchedOnLamps());

    private static string BuildFiveMinutesRow(BerlinTime time) =>
        BuildRow(FiveMinutesRowLamps, time.GetFiveMinutesRowSwitchedOnLamps());

    private static string BuildSingleMinutesRow(BerlinTime time) =>
        BuildRow(SingleMinutesRowLamps, time.GetSingleMinutesRowSwitchedOnLamps());


    private static string BuildRow(string rowLamps, int switchedOnLamps) =>
        rowLamps[..switchedOnLamps].PadRight(rowLamps.Length, SwitchedOffLamp);


    // Alternative BuildFiveMinutesRow implementations:

    // solution 1: loop through chars
    // var switchedOnLamps = _time.GetFiveMinutesRowSwitchedOnLamps();
    // var allSwitchedOnLamps = new StringBuilder(11);
    // for (var i = 0; i < switchedOnLamps; i++)
    // {
    //     allSwitchedOnLamps.Append((i + 1) % 3 == 0 ? 'R' : 'Y');
    // }
    // return allSwitchedOnLamps.ToString().PadRight(11, SwitchedOffLamp);

    // solution 2: regular expression
    // var switchedOnLamps = _time.GetFiveMinutesRowSwitchedOnLamps();
    // var yellowLamps = "".PadLeft(switchedOnLamps, 'Y');
    // var allSwitchedOnLamps = Regex.Replace(yellowLamps, "YYY", "YYR");
    // return allSwitchedOnLamps.PadRight(11, SwitchedOffLamp);

    // solution 3: pre-filled string
    // return BuildRow(FiveMinutesRowLamps, time.GetFiveMinutesRowSwitchedOnLamps());
}