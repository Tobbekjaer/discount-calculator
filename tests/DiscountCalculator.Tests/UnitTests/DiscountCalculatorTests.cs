using DiscountCalculator.Core.Enums;
using DiscountCalculator.Tests.Fakes;
using Xunit;

namespace DiscountCalculator.Tests.UnitTests;

public class DiscountCalculatorTests
{
    private DiscountCalculator.Core.Services.DiscountCalculator CreateCalculator(Season season)
        => new(new FakeDateService(season));

    public static IEnumerable<object[]> DiscountTestCases() =>
    [
        // Standard - out of peak season
        [CustomerType.Standard, 99m, Season.Other, 0m],
        [CustomerType.Standard, 100m, Season.Other, 5m],
        [CustomerType.Standard, 500m, Season.Other, 5m],
        [CustomerType.Standard, 501m, Season.Other, 10m],
        // Standard - peak season
        [CustomerType.Standard, 100m, Season.Summer, 10m],
        [CustomerType.Standard, 501m, Season.Winter, 15m],
        // Premium - out of peak season
        [CustomerType.Premium, 99m, Season.Other, 5m],
        [CustomerType.Premium, 100m, Season.Other, 15m],
        [CustomerType.Premium, 501m, Season.Other, 20m],
        // Premium - peak season
        [CustomerType.Premium, 500m, Season.Summer, 20m],
        [CustomerType.Premium, 501m, Season.Winter, 25m],
    ];

    [Theory]
    [MemberData(nameof(DiscountTestCases))]
    public void CalculateDiscount_WithValidInputs_ReturnsExpectedDiscount(
        CustomerType customerType, decimal amount, Season season, decimal expected)
    {
        var calculator = CreateCalculator(season);
        var result = calculator.CalculateDiscount(customerType, amount);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateDiscount_WithNegativeAmount_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            CreateCalculator(Season.Other).CalculateDiscount(CustomerType.Standard, -1));
    }
}