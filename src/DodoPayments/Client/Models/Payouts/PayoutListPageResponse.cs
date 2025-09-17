using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using PayoutListPageResponseProperties = DodoPayments.Client.Models.Payouts.PayoutListPageResponseProperties;

namespace DodoPayments.Client.Models.Payouts;

[JsonConverter(typeof(Client::ModelConverter<PayoutListPageResponse>))]
public sealed record class PayoutListPageResponse
    : Client::ModelBase,
        Client::IFromRaw<PayoutListPageResponse>
{
    public required List<PayoutListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<PayoutListPageResponseProperties::Item>>(
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

    public PayoutListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayoutListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PayoutListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PayoutListPageResponse(List<PayoutListPageResponseProperties::Item> items)
        : this()
    {
        this.Items = items;
    }
}
