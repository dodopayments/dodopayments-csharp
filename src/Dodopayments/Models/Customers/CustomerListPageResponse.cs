using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Customers;

[JsonConverter(typeof(Dodopayments::ModelConverter<CustomerListPageResponse>))]
public sealed record class CustomerListPageResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<CustomerListPageResponse>
{
    public required List<Customer> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Customer>>(
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
