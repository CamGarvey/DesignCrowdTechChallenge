using DesignCrowdTechChallenge.PublicHolidayRules;

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
    
    /// <summary>
    /// Checks if a given DateTime falls on a public holiday based on a collection of public holiday rules.
    /// </summary>
    /// <param name="date">The DateTime to be checked for being a public holiday.</param>
    /// <param name="rules">A collection of IPublicHolidayRule objects representing the rules for public holidays.</param>
    /// <returns>True if the DateTime is a public holiday according to any of the provided rules, otherwise false.</returns>
    public static bool IsPublicHoliday(this DateTime date, IEnumerable<IPublicHolidayRule> rules) =>
        rules.Any(rule => rule.IsPublicHoliday(date));
}