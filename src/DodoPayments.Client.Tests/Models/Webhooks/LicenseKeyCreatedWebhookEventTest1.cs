using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class LicenseKeyCreatedWebhookEventTest1 : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "lic_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                CustomerID = "cus_123",
                InstancesCount = 0,
                Key = "key",
                PaymentID = "payment_id",
                ProductID = "product_id",
                Status = LicenseKeyStatus.Active,
                ActivationsLimit = 5,
                ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
                SubscriptionID = "subscription_id",
                PayloadType = Data6IntersectionMember1PayloadType.LicenseKey,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Type6.LicenseKeyCreated,
        };

        string expectedBusinessID = "business_id";
        Data6 expectedData = new()
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = Data6IntersectionMember1PayloadType.LicenseKey,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Type6> expectedType = Type6.LicenseKeyCreated;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }
}

public class Data6Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data6
        {
            ID = "lic_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomerID = "cus_123",
            InstancesCount = 0,
            Key = "key",
            PaymentID = "payment_id",
            ProductID = "product_id",
            Status = LicenseKeyStatus.Active,
            ActivationsLimit = 5,
            ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
            SubscriptionID = "subscription_id",
            PayloadType = Data6IntersectionMember1PayloadType.LicenseKey,
        };

        string expectedID = "lic_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedCustomerID = "cus_123";
        int expectedInstancesCount = 0;
        string expectedKey = "key";
        string expectedPaymentID = "payment_id";
        string expectedProductID = "product_id";
        ApiEnum<string, LicenseKeyStatus> expectedStatus = LicenseKeyStatus.Active;
        int expectedActivationsLimit = 5;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z");
        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, Data6IntersectionMember1PayloadType> expectedPayloadType =
            Data6IntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedInstancesCount, model.InstancesCount);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedPayloadType, model.PayloadType);
    }
}

public class Data6IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data6IntersectionMember1
        {
            PayloadType = Data6IntersectionMember1PayloadType.LicenseKey,
        };

        ApiEnum<string, Data6IntersectionMember1PayloadType> expectedPayloadType =
            Data6IntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }
}
