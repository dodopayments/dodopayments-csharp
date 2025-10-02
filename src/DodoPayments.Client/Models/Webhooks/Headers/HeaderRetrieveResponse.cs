using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Webhooks.Headers;

/// <summary>
/// The value of the headers is returned in the `headers` field.
///
/// Sensitive headers that have been redacted are returned in the sensitive field.
/// </summary>
[JsonConverter(typeof(ModelConverter<HeaderRetrieveResponse>))]
public sealed record class HeaderRetrieveResponse : ModelBase, IFromRaw<HeaderRetrieveResponse>
{
    /// <summary>
    /// List of headers configured
    /// </summary>
    public required Dictionary<string, string> Headers
    {
        get
        {
            if (!this.Properties.TryGetValue("headers", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'headers' cannot be null",
                    new ArgumentOutOfRangeException("headers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'headers' cannot be null",
                    new ArgumentNullException("headers")
                );
        }
        set
        {
            this.Properties["headers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sensitive headers without the value
    /// </summary>
    public required List<string> Sensitive
    {
        get
        {
            if (!this.Properties.TryGetValue("sensitive", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'sensitive' cannot be null",
                    new ArgumentOutOfRangeException("sensitive", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'sensitive' cannot be null",
                    new ArgumentNullException("sensitive")
                );
        }
        set
        {
            this.Properties["sensitive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
