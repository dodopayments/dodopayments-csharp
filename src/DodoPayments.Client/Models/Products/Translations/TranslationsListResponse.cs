using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products.Translations;

/// <summary>
/// The translations of a product, an add-on, a product collection or a meter.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TranslationsListResponse, TranslationsListResponseFromRaw>)
)]
public sealed record class TranslationsListResponse : JsonModel
{
    public required IReadOnlyList<Translation> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Translation>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Translation>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public TranslationsListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranslationsListResponse(TranslationsListResponse translationsListResponse)
        : base(translationsListResponse) { }
#pragma warning restore CS8618

    public TranslationsListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TranslationsListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TranslationsListResponseFromRaw.FromRawUnchecked"/>
    public static TranslationsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TranslationsListResponse(IReadOnlyList<Translation> items)
        : this()
    {
        this.Items = items;
    }
}

class TranslationsListResponseFromRaw : IFromRawJson<TranslationsListResponse>
{
    /// <inheritdoc/>
    public TranslationsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TranslationsListResponse.FromRawUnchecked(rawData);
}
