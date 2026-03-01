using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionRetrieveCreditUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionRetrieveCreditUsageResponse
        {
            Items =
            [
                new()
                {
                    Balance = "250.00",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    LimitReached = true,
                    Overage = "15.50",
                    OverageEnabled = true,
                    Unit = "unit",
                    OverageLimit = "100.00",
                    RemainingHeadroom = "84.50",
                },
            ],
            SubscriptionID = "subscription_id",
        };

        List<Item> expectedItems =
        [
            new()
            {
                Balance = "250.00",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                LimitReached = true,
                Overage = "15.50",
                OverageEnabled = true,
                Unit = "unit",
                OverageLimit = "100.00",
                RemainingHeadroom = "84.50",
            },
        ];
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionRetrieveCreditUsageResponse
        {
            Items =
            [
                new()
                {
                    Balance = "250.00",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    LimitReached = true,
                    Overage = "15.50",
                    OverageEnabled = true,
                    Unit = "unit",
                    OverageLimit = "100.00",
                    RemainingHeadroom = "84.50",
                },
            ],
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveCreditUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionRetrieveCreditUsageResponse
        {
            Items =
            [
                new()
                {
                    Balance = "250.00",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    LimitReached = true,
                    Overage = "15.50",
                    OverageEnabled = true,
                    Unit = "unit",
                    OverageLimit = "100.00",
                    RemainingHeadroom = "84.50",
                },
            ],
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveCreditUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                Balance = "250.00",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                LimitReached = true,
                Overage = "15.50",
                OverageEnabled = true,
                Unit = "unit",
                OverageLimit = "100.00",
                RemainingHeadroom = "84.50",
            },
        ];
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionRetrieveCreditUsageResponse
        {
            Items =
            [
                new()
                {
                    Balance = "250.00",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    LimitReached = true,
                    Overage = "15.50",
                    OverageEnabled = true,
                    Unit = "unit",
                    OverageLimit = "100.00",
                    RemainingHeadroom = "84.50",
                },
            ],
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionRetrieveCreditUsageResponse
        {
            Items =
            [
                new()
                {
                    Balance = "250.00",
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditEntitlementName = "credit_entitlement_name",
                    LimitReached = true,
                    Overage = "15.50",
                    OverageEnabled = true,
                    Unit = "unit",
                    OverageLimit = "100.00",
                    RemainingHeadroom = "84.50",
                },
            ],
            SubscriptionID = "subscription_id",
        };

        SubscriptionRetrieveCreditUsageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
            OverageLimit = "100.00",
            RemainingHeadroom = "84.50",
        };

        string expectedBalance = "250.00";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        bool expectedLimitReached = true;
        string expectedOverage = "15.50";
        bool expectedOverageEnabled = true;
        string expectedUnit = "unit";
        string expectedOverageLimit = "100.00";
        string expectedRemainingHeadroom = "84.50";

        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, model.CreditEntitlementName);
        Assert.Equal(expectedLimitReached, model.LimitReached);
        Assert.Equal(expectedOverage, model.Overage);
        Assert.Equal(expectedOverageEnabled, model.OverageEnabled);
        Assert.Equal(expectedUnit, model.Unit);
        Assert.Equal(expectedOverageLimit, model.OverageLimit);
        Assert.Equal(expectedRemainingHeadroom, model.RemainingHeadroom);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
            OverageLimit = "100.00",
            RemainingHeadroom = "84.50",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
            OverageLimit = "100.00",
            RemainingHeadroom = "84.50",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBalance = "250.00";
        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditEntitlementName = "credit_entitlement_name";
        bool expectedLimitReached = true;
        string expectedOverage = "15.50";
        bool expectedOverageEnabled = true;
        string expectedUnit = "unit";
        string expectedOverageLimit = "100.00";
        string expectedRemainingHeadroom = "84.50";

        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditEntitlementName, deserialized.CreditEntitlementName);
        Assert.Equal(expectedLimitReached, deserialized.LimitReached);
        Assert.Equal(expectedOverage, deserialized.Overage);
        Assert.Equal(expectedOverageEnabled, deserialized.OverageEnabled);
        Assert.Equal(expectedUnit, deserialized.Unit);
        Assert.Equal(expectedOverageLimit, deserialized.OverageLimit);
        Assert.Equal(expectedRemainingHeadroom, deserialized.RemainingHeadroom);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
            OverageLimit = "100.00",
            RemainingHeadroom = "84.50",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
        };

        Assert.Null(model.OverageLimit);
        Assert.False(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.RemainingHeadroom);
        Assert.False(model.RawData.ContainsKey("remaining_headroom"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",

            OverageLimit = null,
            RemainingHeadroom = null,
        };

        Assert.Null(model.OverageLimit);
        Assert.True(model.RawData.ContainsKey("overage_limit"));
        Assert.Null(model.RemainingHeadroom);
        Assert.True(model.RawData.ContainsKey("remaining_headroom"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",

            OverageLimit = null,
            RemainingHeadroom = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            Balance = "250.00",
            CreditEntitlementID = "credit_entitlement_id",
            CreditEntitlementName = "credit_entitlement_name",
            LimitReached = true,
            Overage = "15.50",
            OverageEnabled = true,
            Unit = "unit",
            OverageLimit = "100.00",
            RemainingHeadroom = "84.50",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
