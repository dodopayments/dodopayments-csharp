using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class GitHubPermissionTest : TestBase
{
    [Theory]
    [InlineData(GitHubPermission.Pull)]
    [InlineData(GitHubPermission.Push)]
    [InlineData(GitHubPermission.Admin)]
    [InlineData(GitHubPermission.Maintain)]
    [InlineData(GitHubPermission.Triage)]
    public void Validation_Works(GitHubPermission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitHubPermission> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitHubPermission>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GitHubPermission.Pull)]
    [InlineData(GitHubPermission.Push)]
    [InlineData(GitHubPermission.Admin)]
    [InlineData(GitHubPermission.Maintain)]
    [InlineData(GitHubPermission.Triage)]
    public void SerializationRoundtrip_Works(GitHubPermission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitHubPermission> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GitHubPermission>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitHubPermission>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GitHubPermission>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
