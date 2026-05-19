using DiscountCalculator.Core.Enums;
using DiscountCalculator.Core.Interfaces;

namespace DiscountCalculator.Core.Services;

public class DiscountCalculator
{
    private readonly IDateService _dateService;

    public DiscountCalculator(IDateService dateService)
    {
        _dateService = dateService;
    }

    public decimal CalculateDiscount(CustomerType customerType, decimal orderAmount)
    {
        if(orderAmount < 0)
            throw new ArgumentException("Order amount cannot be negative.");

        Season season = _dateService.GetCurrentSeason();

        bool isPeakSeason = season == Season.Summer || season == Season.Winter;

        if (customerType == CustomerType.Standard)
        {
            if (orderAmount < 100) return 0m;
            if (orderAmount < 500) return isPeakSeason ? 10m : 5m;
            return isPeakSeason ? 15m : 10m; 
        }
        else // Premium
        {
            if (orderAmount < 100) return 5m;
            if (orderAmount < 500) return isPeakSeason ? 20m : 15m;
            return isPeakSeason ? 25m : 20m;
        }
        
    }
}