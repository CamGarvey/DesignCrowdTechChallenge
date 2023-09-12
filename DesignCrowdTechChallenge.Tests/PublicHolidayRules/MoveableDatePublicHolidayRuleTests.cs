using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge.Tests.PublicHolidayRules;

public class MoveableDatePublicHolidayRuleTests
{
    public static TheoryData<Occurence, DayOfWeek, MonthOfYear, DateTime, bool> IsPublicHolidayMemberData = new()
    {
        {
            Occurence.Second,
            DayOfWeek.Monday,
            MonthOfYear.June,
            new DateTime(year: 2023, month: 6, 12, hour: 17, minute: 0, second: 10), // 2nd Monday
            true
        },
        {
            Occurence.Second,
            DayOfWeek.Monday,
            MonthOfYear.June,
            new DateTime(year: 2024, month: 6, 10, hour: 17, minute: 0, second: 10), // 2nd Monday
            true
        },
        {
            Occurence.Second,
            DayOfWeek.Monday,
            MonthOfYear.June,
            new DateTime(year: 2024, month: 6, 11, hour: 17, minute: 0, second: 10), // Tuesday
            false
        },
        {
            Occurence.First,
            DayOfWeek.Monday,
            MonthOfYear.October,
            new DateTime(year: 2023, month: 10, 2, hour: 17, minute: 0, second: 10), // 1st Monday
            true
        },
        {
            Occurence.Third,
            DayOfWeek.Tuesday,
            MonthOfYear.February,
            new DateTime(year: 2023, month: 2, 21, hour: 17, minute: 0, second: 10), // 3rd Tuesday
            true
        },
        {
            Occurence.Third,
            DayOfWeek.Tuesday,
            MonthOfYear.February,
            new DateTime(year: 2023, month: 2, 14, hour: 17, minute: 0, second: 10), // 2nd Tuesday
            false
        },        
        {
            Occurence.First,
            DayOfWeek.Friday,
            MonthOfYear.September,
            new DateTime(year: 2023, month: 9, 1, hour: 17, minute: 0, second: 10), // 1st Friday
            true
        },
        {
            Occurence.Fifth,
            DayOfWeek.Tuesday,
            MonthOfYear.October,
            new DateTime(year: 2023, month: 10, 31, hour: 17, minute: 0, second: 10), // 5th Tuesday October
            true
        }
    };

    [Theory]
    [MemberData(nameof(IsPublicHolidayMemberData))]
    public void IsPublicHoliday_ShouldReturn_ExpectedResult(Occurence occurence, DayOfWeek dayOfWeek, MonthOfYear monthOfYear, DateTime dateTime, bool expectedResult)
    {
        var rule = new MoveableDatePublicHolidayRule(occurence, dayOfWeek, monthOfYear);
        
        var isPublicHoliday = rule.IsPublicHoliday(dateTime);
        
        Assert.Equal(expectedResult, isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_IfMonthIsDifferent()
    {
        var date = new DateTime(year: 2023, month: 1, day: 1);
        var rule = new MoveableDatePublicHolidayRule(Occurence.First, DayOfWeek.Monday, MonthOfYear.July);
        
        var isPublicHoliday = rule.IsPublicHoliday(date);
        
        Assert.False(isPublicHoliday);
    }
}