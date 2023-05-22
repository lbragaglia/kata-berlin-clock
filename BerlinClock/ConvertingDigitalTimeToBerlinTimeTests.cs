using BerlinClock.Oop;

namespace BerlinClock;

public class ConvertingDigitalTimeToBerlinTimeTests
{
    private IStringBerlinClockFormatter _sut = null!;

    [SetUp]
    public void SetUp()
    {
        // _sut = new StringBerlinTimeFormatter();
        _sut = new StringBerlinClockAdapter();
    }

    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "YYYY")]
    [TestCase("12:32:00", "YYOO")]
    [TestCase("12:34:00", "YYYY")]
    [TestCase("12:35:00", "OOOO")]
    public void ImplementTheSingleMinutesRow(string decimalTime, string expectedSingleMinutesRow)
    {
        AssertStringBerlinClockRow(decimalTime, c => c.SingleMinutesRow, expectedSingleMinutesRow);
    }

    [TestCase("00:00:00", "OOOOOOOOOOO")]
    [TestCase("23:59:59", "YYRYYRYYRYY")]
    [TestCase("12:04:00", "OOOOOOOOOOO")]
    [TestCase("12:23:00", "YYRYOOOOOOO")]
    [TestCase("12:35:00", "YYRYYRYOOOO")]
    public void ImplementTheFiveMinutesRow(string decimalTime, string expectedFiveMinutesRow)
    {
        AssertStringBerlinClockRow(decimalTime, c => c.FiveMinutesRow, expectedFiveMinutesRow);
    }

    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "RRRO")]
    [TestCase("02:04:00", "RROO")]
    [TestCase("08:23:00", "RRRO")]
    [TestCase("14:35:00", "RRRR")]
    public void ImplementTheSingleHoursRow(string decimalTime, string expectedSingleHoursRow)
    {
        AssertStringBerlinClockRow(decimalTime, c => c.SingleHoursRow, expectedSingleHoursRow);
    }

    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "RRRR")]
    [TestCase("02:04:00", "OOOO")]
    [TestCase("08:23:00", "ROOO")]
    [TestCase("16:35:00", "RRRO")]
    public void ImplementTheFiveHoursRow(string decimalTime, string expectedFiveHoursRow)
    {
        AssertStringBerlinClockRow(decimalTime, c => c.FiveHoursRow, expectedFiveHoursRow);
    }

    [TestCase("00:00:00", "Y")]
    [TestCase("23:59:59", "O")]
    public void ImplementTheSecondsLamp(string decimalTime, string expectedSecondsLamp)
    {
        AssertStringBerlinClockRow(decimalTime, c => c.SecondsLamp, expectedSecondsLamp);
    }

    private void AssertStringBerlinClockRow(string decimalTime, Func<StringBerlinClock, string> rowExtractor,
        string expectedRow)
    {
        var actualClock = _sut.Format(decimalTime);
        Assert.That(rowExtractor(actualClock), Is.EqualTo(expectedRow));
    }
}