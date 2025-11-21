using System;
using System.Collections.Frozen;
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
/// <para>Sensitive headers that have been redacted are returned in the sensitive field.</para>
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
            if (!this._rawData.TryGetValue("headers", out JsonElement element))
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
        init
        {
            this._rawData["headers"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("sensitive", out JsonElement element))
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
        init
        {
            this._rawData["sensitive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Headers;
        _ = this.Sensitive;
    }

    public HeaderRetrieveResponse() { }

    public HeaderRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static HeaderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
