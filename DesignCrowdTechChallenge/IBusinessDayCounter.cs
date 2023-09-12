using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge;

public interface IBusinessDayCounter
{
    /// <summary>
    /// Calculates the number of weekdays (Monday to Friday) between two given dates, excluding weekends.
    /// </summary>
    /// <param name="firstDate">The starting date (exclusive).</param>
    /// <param name="secondDate">The ending date (exclusive).</param>
    /// <returns>The count of weekdays between the two dates.</returns>
    int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
    
    /// <summary>
    /// Calculates the number of business days (weekdays excluding public holidays) between two given dates.
    /// </summary>
    /// <param name="firstDate">The starting date (exclusive).</param>
    /// <param name="secondDate">The ending date (exclusive).</param>
    /// <param name="publicHolidays">List of public holidays to exclude from the calculation.</param>
    /// <returns>The count of business days between the two dates, considering public holidays.</returns>
    int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
    
    /// <summary>
    /// Calculates the number of business days (weekdays excluding public holidays) between two given dates
    /// using custom public holiday rules.
    /// </summary>
    /// <param name="firstDate">The starting date (exclusive).</param>
    /// <param name="secondDate">The ending date (exclusive).</param>
    /// <param name="publicHolidayRules">Custom rules for public holidays to exclude from the calculation.</param>
    /// <returns>The count of business days between the two dates, considering custom public holiday rules.</returns>
    int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate,
        IList<IPublicHolidayRule> publicHolidayRules);
}