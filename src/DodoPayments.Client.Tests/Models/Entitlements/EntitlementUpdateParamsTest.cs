using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            ID = "id",
            Description = "description",
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        IntegrationConfig expectedIntegrationConfig = new GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedIntegrationConfig, parameters.IntegrationConfig);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementUpdateParams { ID = "id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.IntegrationConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("integration_config"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            ID = "id",

            Description = null,
            IntegrationConfig = null,
            Metadata = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.IntegrationConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("integration_config"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/entitlements/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            ID = "id",
            Description = "description",
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        EntitlementUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
