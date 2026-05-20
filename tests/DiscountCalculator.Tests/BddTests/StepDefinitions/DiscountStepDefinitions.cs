using DiscountCalculator.Core.Enums;
using DiscountCalculator.Tests.Fakes;
using Reqnroll;

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
        Assert.That(_result, Is.EqualTo(expected));
    }

    [Then("an exception should be thrown")]
    public void ThenAnExceptionShouldBeThrown()
    {
        Assert.That(_exception, Is.Not.Null);
        Assert.That(_exception, Is.InstanceOf<ArgumentException>());
    }

}