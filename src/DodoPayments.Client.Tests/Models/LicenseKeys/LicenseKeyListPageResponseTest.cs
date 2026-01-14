using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        List<LicenseKey> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseKeyListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<LicenseKey> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseKeyListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }
}
