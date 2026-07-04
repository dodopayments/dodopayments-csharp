using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
        };

        IntegrationConfig expectedIntegrationConfig = new FeatureFlagConfig("feature_id");
        ApiEnum<string, EntitlementIntegrationType> expectedIntegrationType =
            EntitlementIntegrationType.Discord;
        string expectedName = "name";
        string expectedDescription = "description";
        Dictionary<string, MetadataItem> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedIntegrationConfig, parameters.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, parameters.IntegrationType);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementCreateParams parameters = new()
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://live.dodopayments.com/entitlements"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new FeatureFlagConfig("feature_id"),
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
            Metadata = new Dictionary<string, MetadataItem>() { { "foo", "string" } },
        };

        EntitlementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
