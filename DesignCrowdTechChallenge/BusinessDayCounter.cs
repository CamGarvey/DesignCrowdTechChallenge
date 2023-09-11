using DesignCrowdTechChallenge.Extensions;

namespace DesignCrowdTechChallenge;

public class BusinessDayCounter : IBusinessDayCounter
{
    public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
    {
        if (firstDate.Date >= secondDate.Date)
        {
            return 0;
        }
        
        var daysBetween = secondDate.Subtract(firstDate.AddDays(1)).Days;
        return Enumerable.Range(0, daysBetween)
            .Select(day => firstDate.AddDays(day))
            .Count(datetime => datetime.DayOfWeek.IsWeekday());
    }
}