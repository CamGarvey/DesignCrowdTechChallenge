namespace DesignCrowdTechChallenge.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// Calculates the next occurrence of a specified day of the week, starting from a given date.
    /// </summary>
    /// <param name="from">The starting date.</param>
    /// <param name="dayOfWeek">The target day of the week to find.</param>
    /// <returns>The next occurrence of the specified day of the week.</returns>
    public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
    {
        var date = from.Date.AddDays(1);
        var days = ((int) dayOfWeek - (int) date.DayOfWeek + 7) % 7;
        return date.AddDays(days);
    } 
}