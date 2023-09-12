using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge.Tests.PublicHolidayRules;

public class FixedDatePublicHolidayRuleTests
{
    [Fact]
    public void IsPublicHoliday_ShouldReturn_True_If_DateTimeMonthIsRuleMonth_And_DateTimeDayIsRuleDay()
    {
        const int expectedMonth = 3;
        const int expectedDay = 3;
        var rule = new FixedDatePublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, expectedMonth, expectedDay);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.True(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_DateTimeMonthIsRuleMonth_And_DateTimeDayIsNotRuleDay()
    {
        const int expectedMonth = 3;
        const int expectedDay = 3;
        var rule = new FixedDatePublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, expectedMonth, expectedDay + 1);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_DateTimeMonthIsNotRuleMonth_And_DateTimeDayIsRuleDay()
    {
        const int expectedMonth = 3;
        const int expectedDay = 3;
        var rule = new FixedDatePublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, expectedMonth + 1, expectedDay);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
}