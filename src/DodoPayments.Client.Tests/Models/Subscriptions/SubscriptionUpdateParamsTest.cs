using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",
            Billing = new()
            {
                Country = CountryCode.Af,
                City = "city",
                State = "state",
                Street = "street",
                Zipcode = "zipcode",
            },
            CancelAtNextBillingDate = true,
            CustomerName = "customer_name",
            DisableOnDemand = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.Pending,
            TaxID = "tax_id",
        };

        string expectedSubscriptionID = "subscription_id";
        BillingAddress expectedBilling = new()
        {
            Country = CountryCode.Af,
            City = "city",
            State = "state",
            Street = "street",
            Zipcode = "zipcode",
        };
        bool expectedCancelAtNextBillingDate = true;
        string expectedCustomerName = "customer_name";
        DisableOnDemand expectedDisableOnDemand = new(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.Pending;
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedBilling, parameters.Billing);
        Assert.Equal(expectedCancelAtNextBillingDate, parameters.CancelAtNextBillingDate);
        Assert.Equal(expectedCustomerName, parameters.CustomerName);
        Assert.Equal(expectedDisableOnDemand, parameters.DisableOnDemand);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedNextBillingDate, parameters.NextBillingDate);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTaxID, parameters.TaxID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams { SubscriptionID = "subscription_id" };

        Assert.Null(parameters.Billing);
        Assert.False(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.CancelAtNextBillingDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_at_next_billing_date"));
        Assert.Null(parameters.CustomerName);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_name"));
        Assert.Null(parameters.DisableOnDemand);
        Assert.False(parameters.RawBodyData.ContainsKey("disable_on_demand"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NextBillingDate);
        Assert.False(parameters.RawBodyData.ContainsKey("next_billing_date"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",

            Billing = null,
            CancelAtNextBillingDate = null,
            CustomerName = null,
            DisableOnDemand = null,
            Metadata = null,
            NextBillingDate = null,
            Status = null,
            TaxID = null,
        };

        Assert.Null(parameters.Billing);
        Assert.False(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.CancelAtNextBillingDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancel_at_next_billing_date"));
        Assert.Null(parameters.CustomerName);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_name"));
        Assert.Null(parameters.DisableOnDemand);
        Assert.False(parameters.RawBodyData.ContainsKey("disable_on_demand"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NextBillingDate);
        Assert.False(parameters.RawBodyData.ContainsKey("next_billing_date"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.TaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_id"));
    }
}

public class DisableOnDemandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedNextBillingDate, model.NextBillingDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisableOnDemand>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DisableOnDemand>(element);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedNextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedNextBillingDate, deserialized.NextBillingDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DisableOnDemand
        {
            NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}
