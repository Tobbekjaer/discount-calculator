using DiscountCalculator.Core.Enums;
using DiscountCalculator.Core.Interfaces;

namespace DiscountCalculator.Core.Infrastructure;

public class SystemDateService : IDateService
{
    public Season GetCurrentSeason()
    {
        int month = DateTime.Now.Month;

        return month switch
        {
            6 or 7 or 8 => Season.Summer,
            12 or 1 or 2 => Season.Winter,
            _ => Season.Other
        };
    }
}