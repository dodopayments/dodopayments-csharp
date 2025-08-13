using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Refunds;

[JsonConverter(typeof(DodoPayments::ModelConverter<RefundListPageResponse>))]
public sealed record class RefundListPageResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<RefundListPageResponse>
{
    public required List<Refund> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Refund>>(
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
    public RefundListPageResponse(List<Refund> items)
        : this()
    {
        this.Items = items;
    }
}
