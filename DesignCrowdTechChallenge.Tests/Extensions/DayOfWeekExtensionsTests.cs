using DesignCrowdTechChallenge.Extensions;

namespace DesignCrowdTechChallenge.Tests.Extensions;

public class DayOfWeekExtensionsTests
{
    [Theory]
    [InlineData(DayOfWeek.Monday, true)]
    [InlineData(DayOfWeek.Tuesday, true)]
    [InlineData(DayOfWeek.Wednesday, true)]
    [InlineData(DayOfWeek.Thursday, true)]
    [InlineData(DayOfWeek.Friday, true)]
    [InlineData(DayOfWeek.Saturday, false)]
    [InlineData(DayOfWeek.Sunday, false)]
    public void IsWeekday_ShouldReturnBool_IfTheGivenDayOfWeekIsOnAWeekDay(DayOfWeek dayOfWeek, bool expectedResult)
    {
        var result = dayOfWeek.IsWeekday();
        
        Assert.Equal(expectedResult, result);
    }
}