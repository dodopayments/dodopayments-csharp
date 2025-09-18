using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Discount>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("items");
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
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
