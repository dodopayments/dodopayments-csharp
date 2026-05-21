using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// Repository permission to grant on a `github` entitlement.
/// </summary>
[JsonConverter(typeof(GitHubPermissionConverter))]
public enum GitHubPermission
{
    Pull,
    Push,
    Admin,
    Maintain,
    Triage,
}

sealed class GitHubPermissionConverter : JsonConverter<GitHubPermission>
{
    public override GitHubPermission Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pull" => GitHubPermission.Pull,
            "push" => GitHubPermission.Push,
            "admin" => GitHubPermission.Admin,
            "maintain" => GitHubPermission.Maintain,
            "triage" => GitHubPermission.Triage,
            _ => (GitHubPermission)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GitHubPermission value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GitHubPermission.Pull => "pull",
                GitHubPermission.Push => "push",
                GitHubPermission.Admin => "admin",
                GitHubPermission.Maintain => "maintain",
                GitHubPermission.Triage => "triage",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
