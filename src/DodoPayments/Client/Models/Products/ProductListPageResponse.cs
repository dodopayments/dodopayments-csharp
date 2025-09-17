using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using ProductListPageResponseProperties = DodoPayments.Client.Models.Products.ProductListPageResponseProperties;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(Client::ModelConverter<ProductListPageResponse>))]
public sealed record class ProductListPageResponse
    : Client::ModelBase,
        Client::IFromRaw<ProductListPageResponse>
{
    public required List<ProductListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<ProductListPageResponseProperties::Item>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("items");
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

    public ProductListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProductListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ProductListPageResponse(List<ProductListPageResponseProperties::Item> items)
        : this()
    {
        this.Items = items;
    }
}
