using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class MeterCreditEntitlementCartResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeterCreditEntitlementCartResponse
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedMeterID = "meter_id";
        string expectedMeterName = "meter_name";
        string expectedMeterUnitsPerCredit = "meter_units_per_credit";
        string expectedProductID = "product_id";

        Assert.Equal(expectedCreditEntitlementID, model.CreditEntitlementID);
        Assert.Equal(expectedMeterID, model.MeterID);
        Assert.Equal(expectedMeterName, model.MeterName);
        Assert.Equal(expectedMeterUnitsPerCredit, model.MeterUnitsPerCredit);
        Assert.Equal(expectedProductID, model.ProductID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeterCreditEntitlementCartResponse
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterCreditEntitlementCartResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeterCreditEntitlementCartResponse
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeterCreditEntitlementCartResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedMeterID = "meter_id";
        string expectedMeterName = "meter_name";
        string expectedMeterUnitsPerCredit = "meter_units_per_credit";
        string expectedProductID = "product_id";

        Assert.Equal(expectedCreditEntitlementID, deserialized.CreditEntitlementID);
        Assert.Equal(expectedMeterID, deserialized.MeterID);
        Assert.Equal(expectedMeterName, deserialized.MeterName);
        Assert.Equal(expectedMeterUnitsPerCredit, deserialized.MeterUnitsPerCredit);
        Assert.Equal(expectedProductID, deserialized.ProductID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeterCreditEntitlementCartResponse
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeterCreditEntitlementCartResponse
        {
            CreditEntitlementID = "credit_entitlement_id",
            MeterID = "meter_id",
            MeterName = "meter_name",
            MeterUnitsPerCredit = "meter_units_per_credit",
            ProductID = "product_id",
        };

        MeterCreditEntitlementCartResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
