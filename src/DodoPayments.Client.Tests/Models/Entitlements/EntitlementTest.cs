using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        IntegrationConfigResponse expectedIntegrationConfig =
            new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementIntegrationType> expectedIntegrationType =
            EntitlementIntegrationType.Discord;
        bool expectedIsActive = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIntegrationConfig, model.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, model.IntegrationType);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        IntegrationConfigResponse expectedIntegrationConfig =
            new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementIntegrationType> expectedIntegrationType =
            EntitlementIntegrationType.Discord;
        bool expectedIsActive = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIntegrationConfig, deserialized.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, deserialized.IntegrationType);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlement
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new IntegrationConfigResponseGitHubConfig()
            {
                Permission = IntegrationConfigResponseGitHubConfigPermission.Pull,
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            IsActive = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        Entitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}
