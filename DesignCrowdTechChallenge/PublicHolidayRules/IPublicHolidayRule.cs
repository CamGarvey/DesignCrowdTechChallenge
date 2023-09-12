namespace DesignCrowdTechChallenge.PublicHolidayRules;

public interface IPublicHolidayRule
{
    /// <summary>
    /// Checks whether the given datetime is a public holiday
    /// </summary>
    bool IsPublicHoliday(DateTime dateTime);
}