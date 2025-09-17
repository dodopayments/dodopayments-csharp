using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using ProductListPageResponseProperties = Dodopayments.Models.Products.ProductListPageResponseProperties;
using System = System;

namespace Dodopayments.Models.Products;

[JsonConverter(typeof(Dodopayments::ModelConverter<ProductListPageResponse>))]
public sealed record class ProductListPageResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<ProductListPageResponse>
{
    public required List<ProductListPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<ProductListPageResponseProperties::Item>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
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
