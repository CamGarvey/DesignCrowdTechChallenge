using DesignCrowdTechChallenge.Extensions;

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
}