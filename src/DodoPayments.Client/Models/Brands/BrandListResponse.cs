using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandListResponse>))]
public sealed record class BrandListResponse : ModelBase, IFromRaw<BrandListResponse>
{
    /// <summary>
    /// List of brands for this business
    /// </summary>
    public required List<Brand> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Brand>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public BrandListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandListResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BrandListResponse(List<Brand> items)
        : this()
    {
        this.Items = items;
    }
}
