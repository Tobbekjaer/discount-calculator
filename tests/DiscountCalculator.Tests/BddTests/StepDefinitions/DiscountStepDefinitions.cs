using System;
using DiscountCalculator.Core.Enums;
using DiscountCalculator.Tests.Fakes;
using Reqnroll;
using Xunit;

namespace DiscountCalculator.Tests.BddTests.StepDefinitions;

[Binding]
public class DiscountStepDefinitions
{
    private CustomerType _customerType;
    private decimal _orderAmount;
    private decimal _result;
    private Exception? _exception;
    private Season _season;

    [Given("a {string} customer")]
    public void GivenACustomer(string customerType)
    {
        _customerType = Enum.Parse<CustomerType>(customerType);
    }

    [Given("the current season is {string}")]
    public void GivenTheCurrentSeasonIs(string season)
    {
        _season = Enum.Parse<Season>(season);
    }

    [When("the order amount is {decimal}")]
    public void WhenTheOrderAmountIs(decimal orderAmount)
    {
        _orderAmount = orderAmount;
        var dateService = new FakeDateService(_season);
        var calculator = new DiscountCalculator.Core.Services.DiscountCalculator(dateService);

        try
        {
            _result = calculator.CalculateDiscount(_customerType, _orderAmount);
        }
        catch (Exception exception)
        {
            _exception = exception;
        }
    }

    [Then("the discount should be {decimal}")]
    public void ThenTheDiscountShouldBe(decimal expected)
    {
        Assert.Equal(expected, _result);
    }

    [Then("an exception should be thrown")]
    public void ThenAnExceptionShouldBeThrown()
    {
        Assert.NotNull(_exception);
        Assert.IsType<ArgumentException>(_exception);
    }
}