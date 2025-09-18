using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Refunds.RefundListPageResponseProperties;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(ModelConverter<RefundListPageResponse>))]
public sealed record class RefundListPageResponse : ModelBase, IFromRaw<RefundListPageResponse>
{
    public required List<Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Item>>(element, ModelBase.SerializerOptions)
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

    public RefundListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RefundListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public RefundListPageResponse(List<Item> items)
        : this()
    {
        this.Items = items;
    }
}
