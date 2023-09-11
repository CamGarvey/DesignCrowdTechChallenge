namespace DesignCrowdTechChallenge.Tests;

public class BusinessDayCounterTests
{
    private BusinessDayCounter _businessDayCounter = new();
    
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
    public void WeekdaysBetweenTwoDates_ShouldReturnCorrectNumberOfDays(DateTime startDate, DateTime endDate, int expectedResult)
    {
        var result = _businessDayCounter.WeekdaysBetweenTwoDates(startDate, endDate);
        
        Assert.Equal(expectedResult, result);
    }
}