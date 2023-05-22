namespace BerlinClock.Oop;

public interface IBerlinClockFormatter
{
    void BuildSecondsRow(params BerlinClock.Lamp[] lamps);
    void BuildFiveHoursRow(params BerlinClock.Lamp[] lamps);
    void BuildSingleHoursRow(params BerlinClock.Lamp[] lamps);
    void BuildFiveMinutesRow(params BerlinClock.Lamp[] lamps);
    void BuildSingleMinutesRow(params BerlinClock.Lamp[] lamps);
}