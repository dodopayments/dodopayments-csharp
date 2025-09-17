using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using PaymentListPageResponseProperties = Dodopayments.Models.Payments.PaymentListPageResponseProperties;

namespace Dodopayments.Models.Payments;

[JsonConverter(typeof(Dodopayments::ModelConverter<PaymentListPageResponse>))]
public sealed record class PaymentListPageResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<PaymentListPageResponse>
{
    public required List<PaymentListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<PaymentListPageResponseProperties::Item>>(
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

    public PaymentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PaymentListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PaymentListPageResponse(List<PaymentListPageResponseProperties::Item> items)
        : this()
    {
        this.Items = items;
    }
}
