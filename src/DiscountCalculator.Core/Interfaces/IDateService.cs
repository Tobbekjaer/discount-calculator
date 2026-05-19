using DiscountCalculator.Core.Enums;

namespace DiscountCalculator.Core.Interfaces;

public interface IDateService
{
    Season GetCurrentSeason();
}