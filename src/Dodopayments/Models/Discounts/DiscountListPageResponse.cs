using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Discounts;

[JsonConverter(typeof(Dodopayments::ModelConverter<DiscountListPageResponse>))]
public sealed record class DiscountListPageResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<DiscountListPageResponse>
{
    /// <summary>
    /// Array of active (non-deleted) discounts for the current page.
    /// </summary>
    public required List<Discount> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Discount>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public DiscountListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DiscountListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public DiscountListPageResponse(List<Discount> items)
        : this()
    {
        this.Items = items;
    }
}
