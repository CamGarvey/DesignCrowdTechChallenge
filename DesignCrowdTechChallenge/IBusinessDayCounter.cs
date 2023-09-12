using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge;

public interface IBusinessDayCounter
{
    int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
    int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
    int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate,
        IList<IPublicHolidayRule> publicHolidayRules);
}