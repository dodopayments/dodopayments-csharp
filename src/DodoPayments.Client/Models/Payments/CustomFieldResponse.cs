using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

/// <summary>
/// Customer's response to a custom field
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomFieldResponse, CustomFieldResponseFromRaw>))]
public sealed record class CustomFieldResponse : JsonModel
{
    /// <summary>
    /// Key matching the custom field definition
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// Value provided by customer
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public CustomFieldResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomFieldResponse(CustomFieldResponse customFieldResponse)
        : base(customFieldResponse) { }
#pragma warning restore CS8618

    public CustomFieldResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomFieldResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomFieldResponseFromRaw.FromRawUnchecked"/>
    public static CustomFieldResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomFieldResponseFromRaw : IFromRawJson<CustomFieldResponse>
{
    /// <inheritdoc/>
    public CustomFieldResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomFieldResponse.FromRawUnchecked(rawData);
}
