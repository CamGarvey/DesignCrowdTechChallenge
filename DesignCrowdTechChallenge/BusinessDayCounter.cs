using DesignCrowdTechChallenge.Extensions;

namespace DesignCrowdTechChallenge;

public class BusinessDayCounter : IBusinessDayCounter
{
    public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
    {
        return DaysBetweenTwoDates(firstDate, secondDate,
            date => date.DayOfWeek.IsWeekday());
    }
    
    public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
    {
        return DaysBetweenTwoDates(firstDate, secondDate,
            date => date.DayOfWeek.IsWeekday() && !publicHolidays.Contains(date));
    }

    private int DaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, Predicate<DateTime> condition)
    {
        if (firstDate.Date >= secondDate.Date)
        {
            return 0;
        }
        
        var daysBetween = secondDate.Subtract(firstDate).Days - 1;
        return Enumerable.Range(1, daysBetween)
            .Select(day => firstDate.AddDays(day))
            .Count(datetime => condition(datetime));
    }
}