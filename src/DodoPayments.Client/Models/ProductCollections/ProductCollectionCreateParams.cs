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
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Models.ProductCollections;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class ProductCollectionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Groups of products in this collection
    /// </summary>
    public required IReadOnlyList<ProductCollectionGroupDetails> Groups
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ProductCollectionGroupDetails>
            >("groups");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ProductCollectionGroupDetails>>(
                "groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the product collection
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Brand id for the collection, if not provided will default to primary brand
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
    /// Optional description of the product collection
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
    /// Default effective_at setting for subscription plan downgrades (NULL = inherit
    /// from business)
    /// </summary>
    public ApiEnum<string, EffectiveAtOnDowngrade>? EffectiveAtOnDowngrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EffectiveAtOnDowngrade>>(
                "effective_at_on_downgrade"
            );
        }
        init { this._rawBodyData.Set("effective_at_on_downgrade", value); }
    }

    /// <summary>
    /// Default effective_at setting for subscription plan upgrades (NULL = inherit
    /// from business)
    /// </summary>
    public ApiEnum<string, EffectiveAtOnUpgrade>? EffectiveAtOnUpgrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EffectiveAtOnUpgrade>>(
                "effective_at_on_upgrade"
            );
        }
        init { this._rawBodyData.Set("effective_at_on_upgrade", value); }
    }

    /// <summary>
    /// Default behavior for subscription plan changes on payment failure (NULL =
    /// inherit from business)
    /// </summary>
    public ApiEnum<string, OnPaymentFailure>? OnPaymentFailure
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OnPaymentFailure>>(
                "on_payment_failure"
            );
        }
        init { this._rawBodyData.Set("on_payment_failure", value); }
    }

    /// <summary>
    /// Default proration billing mode for subscription plan downgrades (NULL = inherit
    /// from business)
    /// </summary>
    public ApiEnum<string, ProrationBillingModeOnDowngrade>? ProrationBillingModeOnDowngrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProrationBillingModeOnDowngrade>
            >("proration_billing_mode_on_downgrade");
        }
        init { this._rawBodyData.Set("proration_billing_mode_on_downgrade", value); }
    }

    /// <summary>
    /// Default proration billing mode for subscription plan upgrades (NULL = inherit
    /// from business)
    /// </summary>
    public ApiEnum<string, ProrationBillingModeOnUpgrade>? ProrationBillingModeOnUpgrade
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ProrationBillingModeOnUpgrade>
            >("proration_billing_mode_on_upgrade");
        }
        init { this._rawBodyData.Set("proration_billing_mode_on_upgrade", value); }
    }

    public ProductCollectionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollectionCreateParams(
        ProductCollectionCreateParams productCollectionCreateParams
    )
        : base(productCollectionCreateParams)
    {
        this._rawBodyData = new(productCollectionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProductCollectionCreateParams(
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
    ProductCollectionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProductCollectionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ProductCollectionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/product-collections")
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
/// Default effective_at setting for subscription plan downgrades (NULL = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(EffectiveAtOnDowngradeConverter))]
public enum EffectiveAtOnDowngrade
{
    Immediately,
    NextBillingDate,
}

sealed class EffectiveAtOnDowngradeConverter : JsonConverter<EffectiveAtOnDowngrade>
{
    public override EffectiveAtOnDowngrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => EffectiveAtOnDowngrade.Immediately,
            "next_billing_date" => EffectiveAtOnDowngrade.NextBillingDate,
            _ => (EffectiveAtOnDowngrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EffectiveAtOnDowngrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EffectiveAtOnDowngrade.Immediately => "immediately",
                EffectiveAtOnDowngrade.NextBillingDate => "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default effective_at setting for subscription plan upgrades (NULL = inherit from business)
/// </summary>
[JsonConverter(typeof(EffectiveAtOnUpgradeConverter))]
public enum EffectiveAtOnUpgrade
{
    Immediately,
    NextBillingDate,
}

sealed class EffectiveAtOnUpgradeConverter : JsonConverter<EffectiveAtOnUpgrade>
{
    public override EffectiveAtOnUpgrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => EffectiveAtOnUpgrade.Immediately,
            "next_billing_date" => EffectiveAtOnUpgrade.NextBillingDate,
            _ => (EffectiveAtOnUpgrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EffectiveAtOnUpgrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EffectiveAtOnUpgrade.Immediately => "immediately",
                EffectiveAtOnUpgrade.NextBillingDate => "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default behavior for subscription plan changes on payment failure (NULL = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(OnPaymentFailureConverter))]
public enum OnPaymentFailure
{
    PreventChange,
    ApplyChange,
}

sealed class OnPaymentFailureConverter : JsonConverter<OnPaymentFailure>
{
    public override OnPaymentFailure Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prevent_change" => OnPaymentFailure.PreventChange,
            "apply_change" => OnPaymentFailure.ApplyChange,
            _ => (OnPaymentFailure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OnPaymentFailure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OnPaymentFailure.PreventChange => "prevent_change",
                OnPaymentFailure.ApplyChange => "apply_change",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default proration billing mode for subscription plan downgrades (NULL = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(ProrationBillingModeOnDowngradeConverter))]
public enum ProrationBillingModeOnDowngrade
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class ProrationBillingModeOnDowngradeConverter
    : JsonConverter<ProrationBillingModeOnDowngrade>
{
    public override ProrationBillingModeOnDowngrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" => ProrationBillingModeOnDowngrade.ProratedImmediately,
            "full_immediately" => ProrationBillingModeOnDowngrade.FullImmediately,
            "difference_immediately" => ProrationBillingModeOnDowngrade.DifferenceImmediately,
            "do_not_bill" => ProrationBillingModeOnDowngrade.DoNotBill,
            _ => (ProrationBillingModeOnDowngrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProrationBillingModeOnDowngrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProrationBillingModeOnDowngrade.ProratedImmediately => "prorated_immediately",
                ProrationBillingModeOnDowngrade.FullImmediately => "full_immediately",
                ProrationBillingModeOnDowngrade.DifferenceImmediately => "difference_immediately",
                ProrationBillingModeOnDowngrade.DoNotBill => "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default proration billing mode for subscription plan upgrades (NULL = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(ProrationBillingModeOnUpgradeConverter))]
public enum ProrationBillingModeOnUpgrade
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class ProrationBillingModeOnUpgradeConverter : JsonConverter<ProrationBillingModeOnUpgrade>
{
    public override ProrationBillingModeOnUpgrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" => ProrationBillingModeOnUpgrade.ProratedImmediately,
            "full_immediately" => ProrationBillingModeOnUpgrade.FullImmediately,
            "difference_immediately" => ProrationBillingModeOnUpgrade.DifferenceImmediately,
            "do_not_bill" => ProrationBillingModeOnUpgrade.DoNotBill,
            _ => (ProrationBillingModeOnUpgrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProrationBillingModeOnUpgrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProrationBillingModeOnUpgrade.ProratedImmediately => "prorated_immediately",
                ProrationBillingModeOnUpgrade.FullImmediately => "full_immediately",
                ProrationBillingModeOnUpgrade.DifferenceImmediately => "difference_immediately",
                ProrationBillingModeOnUpgrade.DoNotBill => "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
