using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        IntegrationConfig expectedIntegrationConfig = new GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        ApiEnum<string, EntitlementIntegrationType> expectedIntegrationType =
            EntitlementIntegrationType.Discord;
        string expectedName = "name";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

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
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",

            Description = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementCreateParams parameters = new()
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
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
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementIntegrationType.Discord,
            Name = "name",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        EntitlementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
