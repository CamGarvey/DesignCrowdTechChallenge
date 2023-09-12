using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge.Tests.PublicHolidayRules;

public class ObservedPublicHolidayRuleTests
{
    [Fact]
    public void IsPublicHoliday_ShouldReturn_True_If_DateTimeIsRuleDateTime_And_IsWeekday()
    {
        const int expectedMonth = 9;
        const int expectedDay = 12;
        var rule = new ObservedPublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, expectedMonth, expectedDay);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.True(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_DateTimeMonthIsNotRuleMonth_And_RuleIsWeekday()
    {
        const int expectedMonth = 9;
        const int expectedDay = 12;
        var rule = new ObservedPublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, month: 2, expectedDay);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_DateTimeDayIsNotRuleDay_And_RuleIsWeekday()
    {
        const int expectedMonth = 9;
        const int expectedDay = 12;
        var rule = new ObservedPublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, expectedMonth, expectedDay + 1);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_True_If_DateTimeDayIsMonday_And_RuleIsWeekend()
    {
        const int expectedMonth = 9;
        const int expectedDay = 10;
        var rule = new ObservedPublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year: 2023, expectedMonth, day: 11);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.True(isPublicHoliday);
    }
    
    [Theory]
    [InlineData(2022, 1, false)]
    [InlineData(2023, 1, false)]
    [InlineData(2023, 2, true)]
    [InlineData(2024, 1, true)]
    [InlineData(2025, 1, false)]
    public void IsPublicHoliday_ShouldReturn_True_If_RuleIsWeekendFromPrevYear(int year, int day, bool expectedResult)
    {
        const int expectedMonth = 12;
        const int expectedDay = 31;
        var rule = new ObservedPublicHolidayRule(expectedMonth, expectedDay);
        var date = new DateTime(year, month: 1, day: day);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.Equal(expectedResult, isPublicHoliday);
    }
}