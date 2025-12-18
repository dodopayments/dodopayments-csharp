using System.Text.Json;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class CustomerBalanceConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        bool expectedAllowCustomerCreditsPurchase = true;
        bool expectedAllowCustomerCreditsUsage = true;

        Assert.Equal(expectedAllowCustomerCreditsPurchase, model.AllowCustomerCreditsPurchase);
        Assert.Equal(expectedAllowCustomerCreditsUsage, model.AllowCustomerCreditsUsage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerBalanceConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerBalanceConfig>(element);
        Assert.NotNull(deserialized);

        bool expectedAllowCustomerCreditsPurchase = true;
        bool expectedAllowCustomerCreditsUsage = true;

        Assert.Equal(
            expectedAllowCustomerCreditsPurchase,
            deserialized.AllowCustomerCreditsPurchase
        );
        Assert.Equal(expectedAllowCustomerCreditsUsage, deserialized.AllowCustomerCreditsUsage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = true,
            AllowCustomerCreditsUsage = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerBalanceConfig { };

        Assert.Null(model.AllowCustomerCreditsPurchase);
        Assert.False(model.RawData.ContainsKey("allow_customer_credits_purchase"));
        Assert.Null(model.AllowCustomerCreditsUsage);
        Assert.False(model.RawData.ContainsKey("allow_customer_credits_usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerBalanceConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = null,
            AllowCustomerCreditsUsage = null,
        };

        Assert.Null(model.AllowCustomerCreditsPurchase);
        Assert.True(model.RawData.ContainsKey("allow_customer_credits_purchase"));
        Assert.Null(model.AllowCustomerCreditsUsage);
        Assert.True(model.RawData.ContainsKey("allow_customer_credits_usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerBalanceConfig
        {
            AllowCustomerCreditsPurchase = null,
            AllowCustomerCreditsUsage = null,
        };

        model.Validate();
    }
}
