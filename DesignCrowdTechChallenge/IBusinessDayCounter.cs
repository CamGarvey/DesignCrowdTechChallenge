namespace DesignCrowdTechChallenge;

public interface IBusinessDayCounter
{
    int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
}