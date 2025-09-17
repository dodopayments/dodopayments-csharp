using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Webhooks.Headers;

/// <summary>
/// The value of the headers is returned in the `headers` field.
///
/// Sensitive headers that have been redacted are returned in the sensitive field.
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<HeaderRetrieveResponse>))]
public sealed record class HeaderRetrieveResponse
    : Client::ModelBase,
        Client::IFromRaw<HeaderRetrieveResponse>
{
    /// <summary>
    /// List of headers configured
    /// </summary>
    public required Dictionary<string, string> Headers
    {
        get
        {
            if (!this.Properties.TryGetValue("headers", out JsonElement element))
                throw new ArgumentOutOfRangeException("headers", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("headers");
        }
        set { this.Properties["headers"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Sensitive headers without the value
    /// </summary>
    public required List<string> Sensitive
    {
        get
        {
            if (!this.Properties.TryGetValue("sensitive", out JsonElement element))
                throw new ArgumentOutOfRangeException("sensitive", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("sensitive");
        }
        set { this.Properties["sensitive"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Headers.Values)
        {
            _ = item;
        }
        foreach (var item in this.Sensitive)
        {
            _ = item;
        }
    }

    public HeaderRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderRetrieveResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static HeaderRetrieveResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
