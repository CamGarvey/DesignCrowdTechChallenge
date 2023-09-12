namespace DesignCrowdTechChallenge.Extensions;

public static class DateTimeExtensions
{
    public static DateTime NextDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
    {
        var daysUntilNextDayOfWeek = ((int)dayOfWeek - (int)dateTime.DayOfWeek + 7) % 7;
        return dateTime.AddDays(daysUntilNextDayOfWeek);
    } 
}