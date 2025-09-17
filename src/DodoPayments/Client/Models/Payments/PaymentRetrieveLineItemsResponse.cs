using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;
using PaymentRetrieveLineItemsResponseProperties = DodoPayments.Client.Models.Payments.PaymentRetrieveLineItemsResponseProperties;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(Client::ModelConverter<PaymentRetrieveLineItemsResponse>))]
public sealed record class PaymentRetrieveLineItemsResponse
    : Client::ModelBase,
        Client::IFromRaw<PaymentRetrieveLineItemsResponse>
{
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<PaymentRetrieveLineItemsResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<PaymentRetrieveLineItemsResponseProperties::Item>
                >(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Currency.Validate();
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PaymentRetrieveLineItemsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentRetrieveLineItemsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PaymentRetrieveLineItemsResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
