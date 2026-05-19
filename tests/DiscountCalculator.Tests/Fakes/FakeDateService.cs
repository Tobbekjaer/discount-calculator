using DiscountCalculator.Core.Enums;
using DiscountCalculator.Core.Interfaces;

namespace DiscountCalculator.Tests.Fakes;

public class FakeDateService : IDateService
{
    private readonly Season _season;

    public FakeDateService(Season season)
    {
        _season = season;
    }

    public Season GetCurrentSeason() => _season;
}