namespace MyBookingApp.Domain.Bookings;


public sealed record DateRange
{
    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }
    public int LengthInDays => End.DayNumber - Start.DayNumber;

    private DateRange() { }

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start >= end)
        {
            throw new ApplicationException("End date precedes start date");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }

}