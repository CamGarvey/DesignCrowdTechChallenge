namespace DesignCrowdTechChallenge.PublicHolidayRules;

/// <summary>
/// This PublicHolidayRule checks for public holidays that are always on the same day of the year.
/// An example is Anzac Day, which falls on April 25th every year.
/// </summary>
public class FixedDatePublicHolidayRule : IPublicHolidayRule
{
    private readonly int _month;
    private readonly int _day;
    
    public FixedDatePublicHolidayRule(int month, int day)
    {
        _month = month;
        _day = day;
    }

    public bool IsPublicHoliday(DateTime dateTime) =>
        dateTime.Month == _month && 
        dateTime.Day == _day;
}