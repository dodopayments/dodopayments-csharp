using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Discounts;

[JsonConverter(typeof(ModelConverter<DiscountListPageResponse>))]
public sealed record class DiscountListPageResponse : ModelBase, IFromRaw<DiscountListPageResponse>
{
    /// <summary>
    /// Array of active (non-deleted) discounts for the current page.
    /// </summary>
    public required List<Discount> Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Discount>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public DiscountListPageResponse() { }

    public DiscountListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DiscountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscountListPageResponse(List<Discount> items)
        : this()
    {
        this.Items = items;
    }
}
