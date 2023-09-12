namespace DesignCrowdTechChallenge.Extensions;

public static class DayOfWeekExtensions
{
    /// <summary>
    /// Determines if a given day of the week is a weekday (Monday to Friday).
    /// </summary>
    /// <param name="dayOfWeek">The day of the week to check.</param>
    /// <returns>True if the day is a weekday; otherwise, false.</returns>
    public static bool IsWeekday(this DayOfWeek dayOfWeek)
    {
        return (dayOfWeek != DayOfWeek.Saturday) && (dayOfWeek != DayOfWeek.Sunday);
    }
}