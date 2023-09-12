using DesignCrowdTechChallenge.PublicHolidayRules;
using Moq;

namespace DesignCrowdTechChallenge.Tests;

public class BusinessDayCounterTests
{
    private readonly BusinessDayCounter _businessDayCounter = new();
    
    public static TheoryData<DateTime, DateTime, int> WeekdaysBetweenTwoDatesMemberData = new()
    {
        {
            new DateTime(year: 2013, month: 10, day: 7), 
            new DateTime(year: 2013, month: 10, day: 9), 
            1
        },
        {
            new DateTime(year: 2013, month: 10, day: 5), 
            new DateTime(year: 2013, month: 10, day: 14), 
            5
        },
        {
            new DateTime(year: 2013, month: 10, day: 7), 
            new DateTime(year: 2014, month: 1, day: 1), 
            61
        },
        {
            new DateTime(year: 2013, month: 10, day: 7), 
            new DateTime(year: 2013, month: 10, day: 5), 
            0
        }
    };
    
    [Theory]
    [MemberData(nameof(WeekdaysBetweenTwoDatesMemberData))]
    public void WeekdaysBetweenTwoDates_ShouldReturn_ExpectedNumberOfDays(DateTime startDate, DateTime endDate, int expectedResult)
    {
        var result = _businessDayCounter.WeekdaysBetweenTwoDates(startDate, endDate);
        
        Assert.Equal(expectedResult, result);
    }
    
    public static TheoryData<DateTime, DateTime, int> BusinessDaysBetweenTwoDatesMemberData = new()
    {
        {
            new DateTime(year: 2013, month: 10, day: 7), 
            new DateTime(year: 2013, month: 10, day: 9), 
            1
        },
        {
            new DateTime(year: 2013, month: 10, day: 7), 
            new DateTime(year: 2013, month: 10, day: 8), 
            0
        },
        {
            new DateTime(year: 2013, month: 12, day: 24), 
            new DateTime(year: 2013, month: 12, day: 27), 
            0
        },
        {
            new DateTime(year: 2013, month: 10, day: 7), 
            new DateTime(year: 2014, month: 1, day: 1), 
            59
        },
    };
    
    [Theory]
    [MemberData(nameof(BusinessDaysBetweenTwoDatesMemberData))]
    public void BusinessDaysBetweenTwoDates_ShouldReturn_ExpectedNumberOfDays(DateTime startDate, DateTime endDate, int expectedResult)
    {
        List<DateTime> publicHolidays = new()
        {
            new DateTime(year: 2013, month: 12, day: 25),
            new DateTime(year: 2013, month: 12, day: 26),
            new DateTime(year: 2014, month: 1, day: 1),
        };
        
        var result = _businessDayCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void BusinessDaysBetweenTwoDates_Should_OnlyUseDateOnPublicHolidays()
    {
        const int expectedResult = 0;
        DateTime startDate = new(year: 2023, month: 9, day: 12); // Tuesday
        DateTime endDate = new(year: 2023, month: 9, day: 14); // Thursday
        List<DateTime> publicHolidays = new()
        {
            new DateTime(year: 2023, month: 9, day: 13, hour: 17, minute: 10, second: 10) // Wednesday
        };
        
        var result = _businessDayCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);
        
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void BusinessDaysBetweenTwoDates_ShouldReturn_DaysThatAre_NotOnHolidays_Or_NotOnWeekends()
    {
        // Days in between are Thursday, Friday, & Saturday 
        var startDate = new DateTime(year: 2023, month: 9, day: 13);
        var endDate = new DateTime(year: 2023, month: 9, day: 17);
        const int expectedResult = 1; // Should be Thursday
        Mock<IPublicHolidayRule> ruleMock = new();
        ruleMock.Setup(r =>
                r.IsPublicHoliday(It.Is<DateTime>(d => d.DayOfWeek == DayOfWeek.Friday)))
            .Returns(true);
        Mock<IPublicHolidayRule> alwaysFalseRuleMock = new();
        alwaysFalseRuleMock.Setup(r =>
                r.IsPublicHoliday(It.IsAny<DateTime>()))
            .Returns(false);
        
        List<IPublicHolidayRule> rules = new()
        {
            ruleMock.Object,
            alwaysFalseRuleMock.Object
        };

        var result = _businessDayCounter.BusinessDaysBetweenTwoDates(startDate, endDate, rules);
        
        Assert.Equal(expectedResult, result);
    }
}