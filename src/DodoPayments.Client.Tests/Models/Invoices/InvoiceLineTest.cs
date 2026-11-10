using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
            AddonID = "addon_id",
            Description = "description",
            Name = "name",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            SubscriptionID = "subscription_id",
            TaxRate = 0,
        };

        long expectedAmount = 0;
        ApiEnum<string, Kind> expectedKind = Kind.Subscription;
        int expectedQuantity = 0;
        long expectedTax = 0;
        bool expectedTaxInclusive = true;
        long expectedUnitAmount = 0;
        string expectedAddonID = "addon_id";
        string expectedDescription = "description";
        string expectedName = "name";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProductID = "product_id";
        string expectedSubscriptionID = "subscription_id";
        int expectedTaxRate = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedTaxInclusive, model.TaxInclusive);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPeriodEnd, model.PeriodEnd);
        Assert.Equal(expectedPeriodStart, model.PeriodStart);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTaxRate, model.TaxRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
            AddonID = "addon_id",
            Description = "description",
            Name = "name",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            SubscriptionID = "subscription_id",
            TaxRate = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
            AddonID = "addon_id",
            Description = "description",
            Name = "name",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            SubscriptionID = "subscription_id",
            TaxRate = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceLine>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        ApiEnum<string, Kind> expectedKind = Kind.Subscription;
        int expectedQuantity = 0;
        long expectedTax = 0;
        bool expectedTaxInclusive = true;
        long expectedUnitAmount = 0;
        string expectedAddonID = "addon_id";
        string expectedDescription = "description";
        string expectedName = "name";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProductID = "product_id";
        string expectedSubscriptionID = "subscription_id";
        int expectedTaxRate = 0;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedTaxInclusive, deserialized.TaxInclusive);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPeriodEnd, deserialized.PeriodEnd);
        Assert.Equal(expectedPeriodStart, deserialized.PeriodStart);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
            AddonID = "addon_id",
            Description = "description",
            Name = "name",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            SubscriptionID = "subscription_id",
            TaxRate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
        };

        Assert.Null(model.AddonID);
        Assert.False(model.RawData.ContainsKey("addon_id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PeriodEnd);
        Assert.False(model.RawData.ContainsKey("period_end"));
        Assert.Null(model.PeriodStart);
        Assert.False(model.RawData.ContainsKey("period_start"));
        Assert.Null(model.ProductID);
        Assert.False(model.RawData.ContainsKey("product_id"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.TaxRate);
        Assert.False(model.RawData.ContainsKey("tax_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,

            AddonID = null,
            Description = null,
            Name = null,
            PeriodEnd = null,
            PeriodStart = null,
            ProductID = null,
            SubscriptionID = null,
            TaxRate = null,
        };

        Assert.Null(model.AddonID);
        Assert.True(model.RawData.ContainsKey("addon_id"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.PeriodEnd);
        Assert.True(model.RawData.ContainsKey("period_end"));
        Assert.Null(model.PeriodStart);
        Assert.True(model.RawData.ContainsKey("period_start"));
        Assert.Null(model.ProductID);
        Assert.True(model.RawData.ContainsKey("product_id"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.TaxRate);
        Assert.True(model.RawData.ContainsKey("tax_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,

            AddonID = null,
            Description = null,
            Name = null,
            PeriodEnd = null,
            PeriodStart = null,
            ProductID = null,
            SubscriptionID = null,
            TaxRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceLine
        {
            Amount = 0,
            Kind = Kind.Subscription,
            Quantity = 0,
            Tax = 0,
            TaxInclusive = true,
            UnitAmount = 0,
            AddonID = "addon_id",
            Description = "description",
            Name = "name",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductID = "product_id",
            SubscriptionID = "subscription_id",
            TaxRate = 0,
        };

        InvoiceLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class KindTest : TestBase
{
    [Theory]
    [InlineData(Kind.Subscription)]
    [InlineData(Kind.Addon)]
    [InlineData(Kind.Meter)]
    [InlineData(Kind.CreditOverage)]
    [InlineData(Kind.OneTime)]
    public void Validation_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Kind.Subscription)]
    [InlineData(Kind.Addon)]
    [InlineData(Kind.Meter)]
    [InlineData(Kind.CreditOverage)]
    [InlineData(Kind.OneTime)]
    public void SerializationRoundtrip_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
