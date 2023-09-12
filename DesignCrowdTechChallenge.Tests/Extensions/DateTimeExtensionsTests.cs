using DesignCrowdTechChallenge.Extensions;
using DesignCrowdTechChallenge.PublicHolidayRules;
using Moq;

namespace DesignCrowdTechChallenge.Tests.Extensions;

public class DateTimeExtensionsTests
{
    public static TheoryData<DateTime, DayOfWeek, DateTime> NextMemberData = new()
    {
        {
            new DateTime(year: 2023, month: 9, day: 12), // Tuesday 
            DayOfWeek.Wednesday,
            new DateTime(year: 2023, month: 9, day: 13)
        },        
        {
            new DateTime(year: 2023, month: 9, day: 13), // Wednesday 
            DayOfWeek.Saturday,
            new DateTime(year: 2023, month: 9, day: 16)
        },
        {
            new DateTime(year: 2023, month: 9, day: 14), // Thursday 
            DayOfWeek.Thursday,
            new DateTime(year: 2023, month: 9, day: 21)
        },
        {
            new DateTime(year: 2023, month: 9, day: 28), // Thursday 
            DayOfWeek.Thursday,
            new DateTime(year: 2023, month: 10, day: 5)
        },
    };
    
    [Theory]
    [MemberData(nameof(NextMemberData))]
    public void Next_ShouldReturn_NextDayOfWeekDate(DateTime startDate, DayOfWeek dayOfWeek, DateTime expectedResult)
    {
        var result = startDate.Next(dayOfWeek);
        
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void IsPublicHoliday_ShouldReturn_False_If_AllRulesAre_False()
    {
        DateTime date = new(year: 2023, month: 9, day: 9);
        Mock<IPublicHolidayRule> rule1Mock = new();
        rule1Mock.Setup(r => 
                r.IsPublicHoliday(
                    It.Is<DateTime>(d => d.Equals(date))))
            .Returns(false);
        Mock<IPublicHolidayRule> rule2Mock = new();
        rule2Mock.Setup(r => 
                r.IsPublicHoliday(
                    It.Is<DateTime>(d => d.Equals(date))))
            .Returns(false);
        List<IPublicHolidayRule> rules = new()
        {
            rule1Mock.Object,
            rule2Mock.Object
        };

        var isPublicHoliday = date.IsPublicHoliday(rules);
        
        Assert.False(isPublicHoliday);
    }
    
    [Fact]
    public void IsPublicHoliday_ShouldReturn_True_If_AnyRuleIs_True()
    {
        DateTime date = new(year: 2023, month: 9, day: 9);
        Mock<IPublicHolidayRule> rule1Mock = new();
        rule1Mock.Setup(r => 
                r.IsPublicHoliday(
                    It.Is<DateTime>(d => d.Equals(date))))
            .Returns(false);
        Mock<IPublicHolidayRule> rule2Mock = new();
        rule2Mock.Setup(r => 
                r.IsPublicHoliday(
                    It.Is<DateTime>(d => d.Equals(date))))
            .Returns(true);
        List<IPublicHolidayRule> rules = new()
        {
            rule1Mock.Object,
            rule2Mock.Object
        };

        var isPublicHoliday = date.IsPublicHoliday(rules);
        
        Assert.True(isPublicHoliday);
    }
}