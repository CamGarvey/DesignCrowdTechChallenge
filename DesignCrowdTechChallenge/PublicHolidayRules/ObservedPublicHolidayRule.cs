using DesignCrowdTechChallenge.Extensions;

namespace DesignCrowdTechChallenge.PublicHolidayRules;

/// <summary>
/// This PublicHolidayRule checks for public holidays that are designated to be on a specific date,
/// but if that date falls on a weekend (usually Saturday or Sunday),
/// the holiday is observed on the nearest working day (typically Monday).
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

        if (expectedDate.DayOfWeek.IsWeekday())
        {
            return expectedDate == dateTime.Date;
        }

        if (dateTime.DayOfWeek != DayOfWeek.Monday)
        {
            return false;
        }

        var nextMonday = expectedDate.NextDayOfWeek(DayOfWeek.Monday);

        return nextMonday == dateTime.Date;
    }

    /// <summary>
    /// Checks whether the given datetime is a holiday observed by the previous year
    /// </summary>
    private bool IsPublicHolidayFromPreviousYear(DateTime dateTime)
    {
        if (dateTime.DayOfWeek != DayOfWeek.Monday)
        {
            return false;
        }
        if (dateTime.Month != 1 && _month != 12)
        {
            return false;
        }
        var expectedDate = new DateTime(dateTime.Year - 1, _month, _day);
        var nextMonday = expectedDate.NextDayOfWeek(DayOfWeek.Monday);

        return nextMonday == dateTime.Date;
    }
}