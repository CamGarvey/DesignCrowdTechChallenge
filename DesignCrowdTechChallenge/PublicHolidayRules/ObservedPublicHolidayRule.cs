using DesignCrowdTechChallenge.Extensions;

namespace DesignCrowdTechChallenge.PublicHolidayRules;

/// <summary>
/// This PublicHolidayRule checks for public holidays that are designated to be on a specific date,
/// but if that date falls on a weekend (usually Saturday or Sunday),
/// the holiday is observed on the nearest working day (typically Monday and only Monday in this case).
/// An example is New Year's Day, which is on January 1st every year but may be observed on the next
/// Monday if it falls on a weekend.
/// </summary>
public class ObservedPublicHolidayRule : IPublicHolidayRule
{
    private readonly int _month;
    private readonly int _day;
    public ObservedPublicHolidayRule(int month, int day)
    {
        _month = month;
        _day = day;
    }

    public bool IsPublicHoliday(DateTime dateTime)
    {
        if (IsPublicHolidayFromPreviousYear(dateTime))
        {
            return true;
        }

        var expectedDate = new DateTime(dateTime.Year, _month, _day);

        // Check if the expected date falls on a weekday
        if (expectedDate.DayOfWeek.IsWeekday())
        {
            return expectedDate == dateTime.Date;
        }

        // Check if the given date is the next Monday after the expected date
        return dateTime.DayOfWeek == DayOfWeek.Monday && expectedDate.Next(DayOfWeek.Monday) == dateTime.Date;
    }

    /// <summary>
    /// Checks whether the given datetime is a holiday observed by the previous year
    /// </summary>
    private bool IsPublicHolidayFromPreviousYear(DateTime dateTime)
    {
        var expectedDate = new DateTime(dateTime.Year - 1, _month, _day);

        // Check if the given date is the next Monday after the expected date
        return dateTime.DayOfWeek == DayOfWeek.Monday && 
               (dateTime.Month == 1 || _month == 12) &&
               expectedDate.Next(DayOfWeek.Monday) == dateTime.Date;
    }
}