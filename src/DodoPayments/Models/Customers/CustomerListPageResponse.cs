using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Customers;

[JsonConverter(typeof(DodoPayments::ModelConverter<CustomerListPageResponse>))]
public sealed record class CustomerListPageResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<CustomerListPageResponse>
{
    public required List<Customer> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Customer>>(
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

    public CustomerListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public CustomerListPageResponse(List<Customer> items)
        : this()
    {
        this.Items = items;
    }
}
