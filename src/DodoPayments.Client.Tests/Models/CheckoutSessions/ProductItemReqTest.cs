using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CheckoutSessions;

public class ProductItemReqTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                },
            ],
        };

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        int expectedAmount = 0;
        List<CreditEntitlement> expectedCreditEntitlements =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                CreditsAmount = "credits_amount",
            },
        ];

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedAmount, model.Amount);
        Assert.NotNull(model.CreditEntitlements);
        Assert.Equal(expectedCreditEntitlements.Count, model.CreditEntitlements.Count);
        for (int i = 0; i < expectedCreditEntitlements.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlements[i], model.CreditEntitlements[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductItemReq>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductItemReq>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductID = "product_id";
        int expectedQuantity = 0;
        List<AttachAddon> expectedAddons = [new() { AddonID = "addon_id", Quantity = 0 }];
        int expectedAmount = 0;
        List<CreditEntitlement> expectedCreditEntitlements =
        [
            new()
            {
                CreditEntitlementID = "credit_entitlement_id",
                CreditsAmount = "credits_amount",
            },
        ];

        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.NotNull(deserialized.CreditEntitlements);
        Assert.Equal(expectedCreditEntitlements.Count, deserialized.CreditEntitlements.Count);
        for (int i = 0; i < expectedCreditEntitlements.Count; i++)
        {
            Assert.Equal(expectedCreditEntitlements[i], deserialized.CreditEntitlements[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductItemReq { ProductID = "product_id", Quantity = 0 };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.CreditEntitlements);
        Assert.False(model.RawData.ContainsKey("credit_entitlements"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductItemReq { ProductID = "product_id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,

            Addons = null,
            Amount = null,
            CreditEntitlements = null,
        };

        Assert.Null(model.Addons);
        Assert.True(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
        Assert.Null(model.CreditEntitlements);
        Assert.True(model.RawData.ContainsKey("credit_entitlements"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,

            Addons = null,
            Amount = null,
            CreditEntitlements = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductItemReq
        {
            ProductID = "product_id",
            Quantity = 0,
            Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
            Amount = 0,
            CreditEntitlements =
            [
                new()
                {
                    CreditEntitlementID = "credit_entitlement_id",
                    CreditsAmount = "credits_amount",
                },
            ],
        };

        ProductItemReq copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, model.CreditsAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCreditsAmount = "credits_amount";

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedCreditsAmount, deserialized.CreditsAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditEntitlement
        {
            CreditEntitlementID = "credit_entitlement_id",
            CreditsAmount = "credits_amount",
        };

        CreditEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}
