using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using RefundListPageResponseProperties = DodoPayments.Client.Models.Refunds.RefundListPageResponseProperties;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(Client::ModelConverter<RefundListPageResponse>))]
public sealed record class RefundListPageResponse
    : Client::ModelBase,
        Client::IFromRaw<RefundListPageResponse>
{
    public required List<RefundListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<RefundListPageResponseProperties::Item>>(
                    element,
                    Client::ModelBase.SerializerOptions
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
    public RefundListPageResponse(List<RefundListPageResponseProperties::Item> items)
        : this()
    {
        this.Items = items;
    }
}
