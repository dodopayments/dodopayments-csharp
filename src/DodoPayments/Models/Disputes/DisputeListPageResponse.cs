using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DisputeListPageResponseProperties = DodoPayments.Models.Disputes.DisputeListPageResponseProperties;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Disputes;

[JsonConverter(typeof(DodoPayments::ModelConverter<DisputeListPageResponse>))]
public sealed record class DisputeListPageResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<DisputeListPageResponse>
{
    public required List<DisputeListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<DisputeListPageResponseProperties::Item>>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
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
    public DisputeListPageResponse(List<DisputeListPageResponseProperties::Item> items)
        : this()
    {
        this.Items = items;
    }
}
