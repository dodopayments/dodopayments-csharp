using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Webhooks.Headers;

/// <summary>
/// The value of the headers is returned in the `headers` field.
///
/// <para>Sensitive headers that have been redacted are returned in the sensitive field.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<HeaderRetrieveResponse, HeaderRetrieveResponseFromRaw>))]
public sealed record class HeaderRetrieveResponse : JsonModel
{
    /// <summary>
    /// List of headers configured
    /// </summary>
    public required IReadOnlyDictionary<string, string> Headers
    {
        get { return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("headers"); }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "headers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Sensitive headers without the value
    /// </summary>
    public required IReadOnlyList<string> Sensitive
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("sensitive"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "sensitive",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Headers;
        _ = this.Sensitive;
    }

    public HeaderRetrieveResponse() { }

    public HeaderRetrieveResponse(HeaderRetrieveResponse headerRetrieveResponse)
        : base(headerRetrieveResponse) { }

    public HeaderRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeaderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static HeaderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeaderRetrieveResponseFromRaw : IFromRawJson<HeaderRetrieveResponse>
{
    /// <inheritdoc/>
    public HeaderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HeaderRetrieveResponse.FromRawUnchecked(rawData);
}
