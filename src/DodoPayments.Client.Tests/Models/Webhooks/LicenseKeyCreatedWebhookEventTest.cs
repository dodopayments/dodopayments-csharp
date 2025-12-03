using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class LicenseKeyCreatedWebhookEventTest : TestBase
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
                PayloadType =
                    LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
        };

        string expectedBusinessID = "business_id";
        LicenseKeyCreatedWebhookEventData expectedData = new()
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, LicenseKeyCreatedWebhookEventType> expectedType =
            LicenseKeyCreatedWebhookEventType.LicenseKeyCreated;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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
                PayloadType =
                    LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                PayloadType =
                    LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEvent>(json);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        LicenseKeyCreatedWebhookEventData expectedData = new()
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, LicenseKeyCreatedWebhookEventType> expectedType =
            LicenseKeyCreatedWebhookEventType.LicenseKeyCreated;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
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
                PayloadType =
                    LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = LicenseKeyCreatedWebhookEventType.LicenseKeyCreated,
        };

        model.Validate();
    }
}

public class LicenseKeyCreatedWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
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
        ApiEnum<
            string,
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey;

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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEventData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEventData>(json);
        Assert.NotNull(deserialized);

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
        ApiEnum<
            string,
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedInstancesCount, deserialized.InstancesCount);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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

            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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

            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,

            ActivationsLimit = null,
            ExpiresAt = null,
            SubscriptionID = null,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventData
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
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,

            ActivationsLimit = null,
            ExpiresAt = null,
            SubscriptionID = null,
        };

        model.Validate();
    }
}

public class LicenseKeyCreatedWebhookEventDataIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1
        {
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        ApiEnum<
            string,
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1
        {
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEventDataIntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1
        {
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LicenseKeyCreatedWebhookEventDataIntersectionMember1>(json);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType =
            LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1
        {
            PayloadType =
                LicenseKeyCreatedWebhookEventDataIntersectionMember1PayloadType.LicenseKey,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1 { };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LicenseKeyCreatedWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        model.Validate();
    }
}
