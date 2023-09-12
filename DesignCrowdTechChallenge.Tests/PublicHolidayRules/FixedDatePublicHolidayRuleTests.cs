using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge.Tests.PublicHolidayRules;

public class FixedDatePublicHolidayRuleTests
{
    [Fact]
    public void IsPublicHoliday_ShouldReturn_True_If_DateTimeMonthIsRuleMonth_And_DateTimeDayIsRuleDay()
    {
        const MonthOfYear expectedMonth = MonthOfYear.March;
        const int expectedDay = 3;
        var rule = new FixedDatePublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, (int)expectedMonth, expectedDay, hour: 16, minute: 12, second: 10);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.True(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_DateTimeMonthIsRuleMonth_And_DateTimeDayIsNotRuleDay()
    {
        const MonthOfYear expectedMonth = MonthOfYear.March;
        const int expectedDay = 3;
        var rule = new FixedDatePublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, (int)expectedMonth, expectedDay + 1);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_DateTimeMonthIsNotRuleMonth_And_DateTimeDayIsRuleDay()
    {
        const MonthOfYear expectedMonth = MonthOfYear.March;
        const int expectedDay = 3;
        var rule = new FixedDatePublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, (int)expectedMonth + 1, expectedDay);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
}