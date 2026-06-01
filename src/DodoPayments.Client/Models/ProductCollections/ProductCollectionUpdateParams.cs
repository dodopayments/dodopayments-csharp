using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.ProductCollections;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class ProductCollectionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Optional brand_id update
    /// </summary>
    public string? BrandID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand_id");
        }
        init { this._rawBodyData.Set("brand_id", value); }
    }

    /// <summary>
    /// Optional description update - pass null to remove, omit to keep unchanged
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Effective_at setting for downgrades: Some(Some(val)) = set, Some(None) = clear
    /// (inherit), None = no change
    /// </summary>
    public ApiEnum<
        string,
        ProductCollectionUpdateParamsEffectiveAtOnDowngrade
    >? EffectiveAtOnDowngrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnDowngrade>
            >("effective_at_on_downgrade");
        }
        init { this._rawBodyData.Set("effective_at_on_downgrade", value); }
    }

    /// <summary>
    /// Effective_at setting for upgrades: Some(Some(val)) = set, Some(None) = clear
    /// (inherit), None = no change
    /// </summary>
    public ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>? EffectiveAtOnUpgrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProductCollectionUpdateParamsEffectiveAtOnUpgrade>
            >("effective_at_on_upgrade");
        }
        init { this._rawBodyData.Set("effective_at_on_upgrade", value); }
    }

    /// <summary>
    /// Optional new order for groups (array of group UUIDs in desired order)
    /// </summary>
    public IReadOnlyList<string>? GroupOrder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("group_order");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "group_order",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional image update - pass null to remove, omit to keep unchanged
    /// </summary>
    public string? ImageID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("image_id");
        }
        init { this._rawBodyData.Set("image_id", value); }
    }

    /// <summary>
    /// Optional new name for the collection
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// On payment failure behavior: Some(Some(val)) = set, Some(None) = clear (inherit),
    /// None = no change
    /// </summary>
    public ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure>? OnPaymentFailure
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProductCollectionUpdateParamsOnPaymentFailure>
            >("on_payment_failure");
        }
        init { this._rawBodyData.Set("on_payment_failure", value); }
    }

    /// <summary>
    /// Proration billing mode for downgrades: Some(Some(val)) = set, Some(None) =
    /// clear (inherit), None = no change
    /// </summary>
    public ApiEnum<
        string,
        ProductCollectionUpdateParamsProrationBillingModeOnDowngrade
    >? ProrationBillingModeOnDowngrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnDowngrade>
            >("proration_billing_mode_on_downgrade");
        }
        init { this._rawBodyData.Set("proration_billing_mode_on_downgrade", value); }
    }

    /// <summary>
    /// Proration billing mode for upgrades: Some(Some(val)) = set, Some(None) =
    /// clear (inherit), None = no change
    /// </summary>
    public ApiEnum<
        string,
        ProductCollectionUpdateParamsProrationBillingModeOnUpgrade
    >? ProrationBillingModeOnUpgrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProductCollectionUpdateParamsProrationBillingModeOnUpgrade>
            >("proration_billing_mode_on_upgrade");
        }
        init { this._rawBodyData.Set("proration_billing_mode_on_upgrade", value); }
    }

    public ProductCollectionUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionUpdateParams(
        ProductCollectionUpdateParams productCollectionUpdateParams
    )
        : base(productCollectionUpdateParams)
    {
        this.ID = productCollectionUpdateParams.ID;

        this._rawBodyData = new(productCollectionUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProductCollectionUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollectionUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProductCollectionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ProductCollectionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/product-collections/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Effective_at setting for downgrades: Some(Some(val)) = set, Some(None) = clear
/// (inherit), None = no change
/// </summary>
[JsonConverter(typeof(ProductCollectionUpdateParamsEffectiveAtOnDowngradeConverter))]
public enum ProductCollectionUpdateParamsEffectiveAtOnDowngrade
{
    Immediately,
    NextBillingDate,
}

sealed class ProductCollectionUpdateParamsEffectiveAtOnDowngradeConverter
    : JsonConverter<ProductCollectionUpdateParamsEffectiveAtOnDowngrade>
{
    public override ProductCollectionUpdateParamsEffectiveAtOnDowngrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately,
            "next_billing_date" =>
                ProductCollectionUpdateParamsEffectiveAtOnDowngrade.NextBillingDate,
            _ => (ProductCollectionUpdateParamsEffectiveAtOnDowngrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionUpdateParamsEffectiveAtOnDowngrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionUpdateParamsEffectiveAtOnDowngrade.Immediately => "immediately",
                ProductCollectionUpdateParamsEffectiveAtOnDowngrade.NextBillingDate =>
                    "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Effective_at setting for upgrades: Some(Some(val)) = set, Some(None) = clear
/// (inherit), None = no change
/// </summary>
[JsonConverter(typeof(ProductCollectionUpdateParamsEffectiveAtOnUpgradeConverter))]
public enum ProductCollectionUpdateParamsEffectiveAtOnUpgrade
{
    Immediately,
    NextBillingDate,
}

sealed class ProductCollectionUpdateParamsEffectiveAtOnUpgradeConverter
    : JsonConverter<ProductCollectionUpdateParamsEffectiveAtOnUpgrade>
{
    public override ProductCollectionUpdateParamsEffectiveAtOnUpgrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately,
            "next_billing_date" =>
                ProductCollectionUpdateParamsEffectiveAtOnUpgrade.NextBillingDate,
            _ => (ProductCollectionUpdateParamsEffectiveAtOnUpgrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionUpdateParamsEffectiveAtOnUpgrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionUpdateParamsEffectiveAtOnUpgrade.Immediately => "immediately",
                ProductCollectionUpdateParamsEffectiveAtOnUpgrade.NextBillingDate =>
                    "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// On payment failure behavior: Some(Some(val)) = set, Some(None) = clear (inherit),
/// None = no change
/// </summary>
[JsonConverter(typeof(ProductCollectionUpdateParamsOnPaymentFailureConverter))]
public enum ProductCollectionUpdateParamsOnPaymentFailure
{
    PreventChange,
    ApplyChange,
}

sealed class ProductCollectionUpdateParamsOnPaymentFailureConverter
    : JsonConverter<ProductCollectionUpdateParamsOnPaymentFailure>
{
    public override ProductCollectionUpdateParamsOnPaymentFailure Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prevent_change" => ProductCollectionUpdateParamsOnPaymentFailure.PreventChange,
            "apply_change" => ProductCollectionUpdateParamsOnPaymentFailure.ApplyChange,
            _ => (ProductCollectionUpdateParamsOnPaymentFailure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionUpdateParamsOnPaymentFailure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionUpdateParamsOnPaymentFailure.PreventChange => "prevent_change",
                ProductCollectionUpdateParamsOnPaymentFailure.ApplyChange => "apply_change",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Proration billing mode for downgrades: Some(Some(val)) = set, Some(None) = clear
/// (inherit), None = no change
/// </summary>
[JsonConverter(typeof(ProductCollectionUpdateParamsProrationBillingModeOnDowngradeConverter))]
public enum ProductCollectionUpdateParamsProrationBillingModeOnDowngrade
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class ProductCollectionUpdateParamsProrationBillingModeOnDowngradeConverter
    : JsonConverter<ProductCollectionUpdateParamsProrationBillingModeOnDowngrade>
{
    public override ProductCollectionUpdateParamsProrationBillingModeOnDowngrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" =>
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately,
            "full_immediately" =>
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.FullImmediately,
            "difference_immediately" =>
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DifferenceImmediately,
            "do_not_bill" => ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DoNotBill,
            _ => (ProductCollectionUpdateParamsProrationBillingModeOnDowngrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionUpdateParamsProrationBillingModeOnDowngrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.ProratedImmediately =>
                    "prorated_immediately",
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.FullImmediately =>
                    "full_immediately",
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DifferenceImmediately =>
                    "difference_immediately",
                ProductCollectionUpdateParamsProrationBillingModeOnDowngrade.DoNotBill =>
                    "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Proration billing mode for upgrades: Some(Some(val)) = set, Some(None) = clear
/// (inherit), None = no change
/// </summary>
[JsonConverter(typeof(ProductCollectionUpdateParamsProrationBillingModeOnUpgradeConverter))]
public enum ProductCollectionUpdateParamsProrationBillingModeOnUpgrade
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class ProductCollectionUpdateParamsProrationBillingModeOnUpgradeConverter
    : JsonConverter<ProductCollectionUpdateParamsProrationBillingModeOnUpgrade>
{
    public override ProductCollectionUpdateParamsProrationBillingModeOnUpgrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" =>
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately,
            "full_immediately" =>
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.FullImmediately,
            "difference_immediately" =>
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DifferenceImmediately,
            "do_not_bill" => ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DoNotBill,
            _ => (ProductCollectionUpdateParamsProrationBillingModeOnUpgrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionUpdateParamsProrationBillingModeOnUpgrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.ProratedImmediately =>
                    "prorated_immediately",
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.FullImmediately =>
                    "full_immediately",
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DifferenceImmediately =>
                    "difference_immediately",
                ProductCollectionUpdateParamsProrationBillingModeOnUpgrade.DoNotBill =>
                    "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
