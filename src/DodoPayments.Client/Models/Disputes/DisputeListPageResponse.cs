using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Disputes.DisputeListPageResponseProperties;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(ModelConverter<DisputeListPageResponse>))]
public sealed record class DisputeListPageResponse : ModelBase, IFromRaw<DisputeListPageResponse>
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

    public DisputeListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DisputeListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public DisputeListPageResponse(List<Item> items)
        : this()
    {
        this.Items = items;
    }
}
