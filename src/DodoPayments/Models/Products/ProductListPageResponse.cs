using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;
using ProductListPageResponseProperties = DodoPayments.Models.Products.ProductListPageResponseProperties;
using System = System;

namespace DodoPayments.Models.Products;

[JsonConverter(typeof(DodoPayments::ModelConverter<ProductListPageResponse>))]
public sealed record class ProductListPageResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<ProductListPageResponse>
{
    public required List<ProductListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<ProductListPageResponseProperties::Item>>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
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
