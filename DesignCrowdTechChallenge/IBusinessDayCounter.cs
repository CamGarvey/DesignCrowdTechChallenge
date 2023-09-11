namespace DesignCrowdTechChallenge;

public interface IBusinessDayCounter
{
    int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
    int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
}