using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = EntitlementListResponseIntegrationType.Discord,
                    IsActive = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        List<EntitlementListResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
                IntegrationType = EntitlementListResponseIntegrationType.Discord,
                IsActive = true,
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new EntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = EntitlementListResponseIntegrationType.Discord,
                    IsActive = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = EntitlementListResponseIntegrationType.Discord,
                    IsActive = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EntitlementListResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                {
                    Permission = "permission",
                    TargetID = "target_id",
                },
                IntegrationType = EntitlementListResponseIntegrationType.Discord,
                IsActive = true,
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new EntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = EntitlementListResponseIntegrationType.Discord,
                    IsActive = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
                    {
                        Permission = "permission",
                        TargetID = "target_id",
                    },
                    IntegrationType = EntitlementListResponseIntegrationType.Discord,
                    IsActive = true,
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        EntitlementListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
