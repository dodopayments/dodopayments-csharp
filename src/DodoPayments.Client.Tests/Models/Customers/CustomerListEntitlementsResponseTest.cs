using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerListEntitlementsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementID = "entitlement_id",
                    EntitlementName = "entitlement_name",
                    GrantID = "grant_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementDescription = "entitlement_description",
                    RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<CustomerListEntitlementsResponseItem> expectedItems =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntitlementID = "entitlement_id",
                EntitlementName = "entitlement_name",
                GrantID = "grant_id",
                IntegrationType = EntitlementIntegrationType.Discord,
                Status = Status.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntitlementDescription = "entitlement_description",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CustomerListEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementID = "entitlement_id",
                    EntitlementName = "entitlement_name",
                    GrantID = "grant_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementDescription = "entitlement_description",
                    RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListEntitlementsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementID = "entitlement_id",
                    EntitlementName = "entitlement_name",
                    GrantID = "grant_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementDescription = "entitlement_description",
                    RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListEntitlementsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CustomerListEntitlementsResponseItem> expectedItems =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntitlementID = "entitlement_id",
                EntitlementName = "entitlement_name",
                GrantID = "grant_id",
                IntegrationType = EntitlementIntegrationType.Discord,
                Status = Status.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntitlementDescription = "entitlement_description",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CustomerListEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementID = "entitlement_id",
                    EntitlementName = "entitlement_name",
                    GrantID = "grant_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementDescription = "entitlement_description",
                    RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListEntitlementsResponse
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementID = "entitlement_id",
                    EntitlementName = "entitlement_name",
                    GrantID = "grant_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntitlementDescription = "entitlement_description",
                    RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        CustomerListEntitlementsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListEntitlementsResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementDescription = "entitlement_description",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntitlementID = "entitlement_id";
        string expectedEntitlementName = "entitlement_name";
        string expectedGrantID = "grant_id";
        ApiEnum<string, EntitlementIntegrationType> expectedIntegrationType =
            EntitlementIntegrationType.Discord;
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntitlementDescription = "entitlement_description";
        DateTimeOffset expectedRevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntitlementID, model.EntitlementID);
        Assert.Equal(expectedEntitlementName, model.EntitlementName);
        Assert.Equal(expectedGrantID, model.GrantID);
        Assert.Equal(expectedIntegrationType, model.IntegrationType);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDeliveredAt, model.DeliveredAt);
        Assert.Equal(expectedEntitlementDescription, model.EntitlementDescription);
        Assert.Equal(expectedRevokedAt, model.RevokedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementDescription = "entitlement_description",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListEntitlementsResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementDescription = "entitlement_description",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListEntitlementsResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntitlementID = "entitlement_id";
        string expectedEntitlementName = "entitlement_name";
        string expectedGrantID = "grant_id";
        ApiEnum<string, EntitlementIntegrationType> expectedIntegrationType =
            EntitlementIntegrationType.Discord;
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntitlementDescription = "entitlement_description";
        DateTimeOffset expectedRevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntitlementID, deserialized.EntitlementID);
        Assert.Equal(expectedEntitlementName, deserialized.EntitlementName);
        Assert.Equal(expectedGrantID, deserialized.GrantID);
        Assert.Equal(expectedIntegrationType, deserialized.IntegrationType);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDeliveredAt, deserialized.DeliveredAt);
        Assert.Equal(expectedEntitlementDescription, deserialized.EntitlementDescription);
        Assert.Equal(expectedRevokedAt, deserialized.RevokedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementDescription = "entitlement_description",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("delivered_at"));
        Assert.Null(model.EntitlementDescription);
        Assert.False(model.RawData.ContainsKey("entitlement_description"));
        Assert.Null(model.RevokedAt);
        Assert.False(model.RawData.ContainsKey("revoked_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            DeliveredAt = null,
            EntitlementDescription = null,
            RevokedAt = null,
        };

        Assert.Null(model.DeliveredAt);
        Assert.True(model.RawData.ContainsKey("delivered_at"));
        Assert.Null(model.EntitlementDescription);
        Assert.True(model.RawData.ContainsKey("entitlement_description"));
        Assert.Null(model.RevokedAt);
        Assert.True(model.RawData.ContainsKey("revoked_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            DeliveredAt = null,
            EntitlementDescription = null,
            RevokedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListEntitlementsResponseItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementID = "entitlement_id",
            EntitlementName = "entitlement_name",
            GrantID = "grant_id",
            IntegrationType = EntitlementIntegrationType.Discord,
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementDescription = "entitlement_description",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CustomerListEntitlementsResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Revoked)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Revoked)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
