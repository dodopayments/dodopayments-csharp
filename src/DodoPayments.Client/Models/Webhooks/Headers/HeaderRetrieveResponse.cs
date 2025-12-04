using System.Collections.Frozen;
using System.Collections.Generic;
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
[JsonConverter(typeof(ModelConverter<HeaderRetrieveResponse, HeaderRetrieveResponseFromRaw>))]
public sealed record class HeaderRetrieveResponse : ModelBase
{
    /// <summary>
    /// List of headers configured
    /// </summary>
    public required IReadOnlyDictionary<string, string> Headers
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "headers");
        }
        init { ModelBase.Set(this._rawData, "headers", value); }
    }

    /// <summary>
    /// Sensitive headers without the value
    /// </summary>
    public required IReadOnlyList<string> Sensitive
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "sensitive"); }
        init { ModelBase.Set(this._rawData, "sensitive", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HeaderRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class HeaderRetrieveResponseFromRaw : IFromRaw<HeaderRetrieveResponse>
{
    /// <inheritdoc/>
    public HeaderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HeaderRetrieveResponse.FromRawUnchecked(rawData);
}
