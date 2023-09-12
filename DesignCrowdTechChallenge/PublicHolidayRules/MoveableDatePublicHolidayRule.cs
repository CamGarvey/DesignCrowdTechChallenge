using DesignCrowdTechChallenge.Extensions;

namespace DesignCrowdTechChallenge.PublicHolidayRules;

/// <summary>
/// This PublicHolidayRule checks for public holidays that are based on a
/// certain occurrence of a particular day within a month or week.
/// An example is Queen's Birthday, which is observed on the second Monday in June every year.
/// The exact date varies from year to year, but the day of the week remains constant.
/// </summary>
public class MoveableDatePublicHolidayRule : IPublicHolidayRule
{
    private readonly Occurence _occurence;
    private readonly DayOfWeek _dayOfWeek;
    private readonly MonthOfYear _monthOfYear;
    
    public MoveableDatePublicHolidayRule(Occurence occurence, DayOfWeek dayOfWeek, MonthOfYear monthOfYear)
    {
        _occurence = occurence;
        _dayOfWeek = dayOfWeek;
        _monthOfYear = monthOfYear;
    }
    
    public bool IsPublicHoliday(DateTime dateTime)
    {
        if ((int)_monthOfYear != dateTime.Month)
        {
            return false;
        }
        
        var expectedDate = new DateTime(dateTime.Year, (int)_monthOfYear, 1);
        
        if (expectedDate.DayOfWeek != _dayOfWeek)
        {
            expectedDate = expectedDate.Next(_dayOfWeek);
        }

        return expectedDate
            .AddDays((int)_occurence * 7) == dateTime.Date;
    }
}