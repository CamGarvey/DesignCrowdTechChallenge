namespace DesignCrowdTechChallenge.Extensions;

public static class DayOfWeekExtensions
{
    public static bool IsWeekday(this DayOfWeek dayOfWeek)
    {
        return (dayOfWeek != DayOfWeek.Saturday) && (dayOfWeek != DayOfWeek.Sunday);
    }
}