﻿using DesignCrowdTechChallenge.Extensions;
using DesignCrowdTechChallenge.PublicHolidayRules;

namespace DesignCrowdTechChallenge;

public class BusinessDayCounter : IBusinessDayCounter
{
    public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
    {
        return DaysBetweenTwoDates(firstDate, secondDate,
            date => date.DayOfWeek.IsWeekday());
    }
    
    public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
    {
        var dateOnlyPublicHolidays = publicHolidays.Select(date => date.Date);
        return DaysBetweenTwoDates(firstDate, secondDate,
            date => date.DayOfWeek.IsWeekday() && !dateOnlyPublicHolidays.Contains(date.Date));
    }

    public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IPublicHolidayRule> publicHolidayRules)
    {
        return DaysBetweenTwoDates(firstDate, secondDate,
            date => date.DayOfWeek.IsWeekday() && !date.IsPublicHoliday(publicHolidayRules));
    }

    private int DaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, Predicate<DateTime> condition)
    {
        if (firstDate.Date >= secondDate.Date)
        {
            return 0;
        }
        
        var daysBetween = secondDate.Subtract(firstDate).Days - 1;
        return Enumerable.Range(1, daysBetween)
            .Select(day => firstDate.AddDays(day))
            .Count(datetime => condition(datetime));
    }
}