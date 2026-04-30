using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// Digital-product-delivery payload for a grant. Populated for grants whose entitlement
/// has `integration_type = 'digital_files'`. `files` carries presigned download
/// URLs; the source (EE service or legacy in-process S3 presigning) is opaque to
/// the caller.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProductDigitalProductDelivery, ProductDigitalProductDeliveryFromRaw>)
)]
public sealed record class ProductDigitalProductDelivery : JsonModel
{
    public required IReadOnlyList<DigitalProductDeliveryFile> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DigitalProductDeliveryFile>>(
                "files"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DigitalProductDeliveryFile>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Files)
        {
            item.Validate();
        }
        _ = this.ExternalUrl;
        _ = this.Instructions;
    }

    public ProductDigitalProductDelivery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductDigitalProductDelivery(
        ProductDigitalProductDelivery productDigitalProductDelivery
    )
        : base(productDigitalProductDelivery) { }
#pragma warning restore CS8618

    public ProductDigitalProductDelivery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductDigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductDigitalProductDeliveryFromRaw.FromRawUnchecked"/>
    public static ProductDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductDigitalProductDelivery(IReadOnlyList<DigitalProductDeliveryFile> files)
        : this()
    {
        this.Files = files;
    }
}

class ProductDigitalProductDeliveryFromRaw : IFromRawJson<ProductDigitalProductDelivery>
{
    /// <inheritdoc/>
    public ProductDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDigitalProductDelivery.FromRawUnchecked(rawData);
}
