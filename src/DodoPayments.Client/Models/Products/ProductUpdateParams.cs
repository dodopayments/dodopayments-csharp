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
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class ProductUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("addons");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Credit entitlements to update (replaces all existing when present) Send empty
    /// array to remove all, omit field to leave unchanged
    /// </summary>
    public IReadOnlyList<ProductUpdateParamsCreditEntitlement>? CreditEntitlements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ProductUpdateParamsCreditEntitlement>
            >("credit_entitlements");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ProductUpdateParamsCreditEntitlement>?>(
                "credit_entitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Description of the product, optional and must be at most 1000 characters.
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
    /// Choose how you would like you digital product delivered
    /// </summary>
    public ProductUpdateParamsDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProductUpdateParamsDigitalProductDelivery>(
                "digital_product_delivery"
            );
        }
        init { this._rawBodyData.Set("digital_product_delivery", value); }
    }

    /// <summary>
    /// Product image id after its uploaded to S3
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
    /// Message sent to the customer upon license key activation.
    ///
    /// <para>Only applicable if `license_key_enabled` is `true`. This message contains
    /// instructions for activating the license key.</para>
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("license_key_activation_message");
        }
        init { this._rawBodyData.Set("license_key_activation_message", value); }
    }

    /// <summary>
    /// Limit for the number of activations for the license key.
    ///
    /// <para>Only applicable if `license_key_enabled` is `true`. Represents the
    /// maximum number of times the license key can be activated.</para>
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("license_key_activations_limit");
        }
        init { this._rawBodyData.Set("license_key_activations_limit", value); }
    }

    /// <summary>
    /// Duration of the license key if enabled.
    ///
    /// <para>Only applicable if `license_key_enabled` is `true`. Represents the
    /// duration in days for which the license key is valid.</para>
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<LicenseKeyDuration>("license_key_duration");
        }
        init { this._rawBodyData.Set("license_key_duration", value); }
    }

    /// <summary>
    /// Whether the product requires a license key.
    ///
    /// <para>If `true`, additional fields related to license key (duration, activations
    /// limit, activation message) become applicable.</para>
    /// </summary>
    public bool? LicenseKeyEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("license_key_enabled");
        }
        init { this._rawBodyData.Set("license_key_enabled", value); }
    }

    /// <summary>
    /// Additional metadata for the product
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Name of the product, optional and must be at most 100 characters.
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
    /// Price details of the product.
    /// </summary>
    public Price? Price
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Price>("price");
        }
        init { this._rawBodyData.Set("price", value); }
    }

    /// <summary>
    /// Tax category of the product.
    /// </summary>
    public ApiEnum<string, TaxCategory>? TaxCategory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawBodyData.Set("tax_category", value); }
    }

    public ProductUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateParams(ProductUpdateParams productUpdateParams)
        : base(productUpdateParams)
    {
        this.ID = productUpdateParams.ID;

        this._rawBodyData = new(productUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProductUpdateParams(
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
    ProductUpdateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ProductUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(ProductUpdateParams? other)
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/products/{0}", this.ID)
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
/// Request struct for attaching a credit entitlement to a product
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductUpdateParamsCreditEntitlement,
        ProductUpdateParamsCreditEntitlementFromRaw
    >)
)]
public sealed record class ProductUpdateParamsCreditEntitlement : JsonModel
{
    /// <summary>
    /// ID of the credit entitlement to attach
    /// </summary>
    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    /// <summary>
    /// Number of credits to grant when this product is purchased
    /// </summary>
    public required string CreditsAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits_amount");
        }
        init { this._rawData.Set("credits_amount", value); }
    }

    /// <summary>
    /// Whether new credit grants reduce existing overage
    /// </summary>
    public bool? CreditsReduceOverage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("credits_reduce_overage");
        }
        init { this._rawData.Set("credits_reduce_overage", value); }
    }

    /// <summary>
    /// Currency for credit-related pricing
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Number of days after which credits expire
    /// </summary>
    public int? ExpiresAfterDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("expires_after_days");
        }
        init { this._rawData.Set("expires_after_days", value); }
    }

    /// <summary>
    /// Balance threshold percentage for low balance notifications (0-100)
    /// </summary>
    public int? LowBalanceThresholdPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("low_balance_threshold_percent");
        }
        init { this._rawData.Set("low_balance_threshold_percent", value); }
    }

    /// <summary>
    /// Maximum number of rollover cycles allowed
    /// </summary>
    public int? MaxRolloverCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_rollover_count");
        }
        init { this._rawData.Set("max_rollover_count", value); }
    }

    /// <summary>
    /// Whether overage charges are applied at billing time
    /// </summary>
    public bool? OverageChargeAtBilling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("overage_charge_at_billing");
        }
        init { this._rawData.Set("overage_charge_at_billing", value); }
    }

    /// <summary>
    /// Whether overage usage is allowed beyond credit balance
    /// </summary>
    public bool? OverageEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("overage_enabled");
        }
        init { this._rawData.Set("overage_enabled", value); }
    }

    /// <summary>
    /// Maximum amount of overage allowed
    /// </summary>
    public string? OverageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("overage_limit");
        }
        init { this._rawData.Set("overage_limit", value); }
    }

    /// <summary>
    /// Whether to preserve overage balance when credits reset
    /// </summary>
    public bool? PreserveOverageAtReset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_overage_at_reset");
        }
        init { this._rawData.Set("preserve_overage_at_reset", value); }
    }

    /// <summary>
    /// Price per credit unit for purchasing additional credits
    /// </summary>
    public string? PricePerUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price_per_unit");
        }
        init { this._rawData.Set("price_per_unit", value); }
    }

    /// <summary>
    /// Proration behavior for credit grants during plan changes
    /// </summary>
    public ApiEnum<string, ProductUpdateParamsCreditEntitlementProrationBehavior>? ProrationBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProductUpdateParamsCreditEntitlementProrationBehavior>
            >("proration_behavior");
        }
        init { this._rawData.Set("proration_behavior", value); }
    }

    /// <summary>
    /// Whether unused credits can roll over to the next billing period
    /// </summary>
    public bool? RolloverEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("rollover_enabled");
        }
        init { this._rawData.Set("rollover_enabled", value); }
    }

    /// <summary>
    /// Percentage of unused credits that can roll over (0-100)
    /// </summary>
    public int? RolloverPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_percentage");
        }
        init { this._rawData.Set("rollover_percentage", value); }
    }

    /// <summary>
    /// Number of timeframe units for rollover window
    /// </summary>
    public int? RolloverTimeframeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rollover_timeframe_count");
        }
        init { this._rawData.Set("rollover_timeframe_count", value); }
    }

    /// <summary>
    /// Time interval for rollover window (day, week, month, year)
    /// </summary>
    public ApiEnum<string, TimeInterval>? RolloverTimeframeInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TimeInterval>>(
                "rollover_timeframe_interval"
            );
        }
        init { this._rawData.Set("rollover_timeframe_interval", value); }
    }

    /// <summary>
    /// Credits granted during trial period
    /// </summary>
    public string? TrialCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trial_credits");
        }
        init { this._rawData.Set("trial_credits", value); }
    }

    /// <summary>
    /// Whether trial credits expire when trial ends
    /// </summary>
    public bool? TrialCreditsExpireAfterTrial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("trial_credits_expire_after_trial");
        }
        init { this._rawData.Set("trial_credits_expire_after_trial", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.CreditsAmount;
        _ = this.CreditsReduceOverage;
        this.Currency?.Validate();
        _ = this.ExpiresAfterDays;
        _ = this.LowBalanceThresholdPercent;
        _ = this.MaxRolloverCount;
        _ = this.OverageChargeAtBilling;
        _ = this.OverageEnabled;
        _ = this.OverageLimit;
        _ = this.PreserveOverageAtReset;
        _ = this.PricePerUnit;
        this.ProrationBehavior?.Validate();
        _ = this.RolloverEnabled;
        _ = this.RolloverPercentage;
        _ = this.RolloverTimeframeCount;
        this.RolloverTimeframeInterval?.Validate();
        _ = this.TrialCredits;
        _ = this.TrialCreditsExpireAfterTrial;
    }

    public ProductUpdateParamsCreditEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateParamsCreditEntitlement(
        ProductUpdateParamsCreditEntitlement productUpdateParamsCreditEntitlement
    )
        : base(productUpdateParamsCreditEntitlement) { }
#pragma warning restore CS8618

    public ProductUpdateParamsCreditEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParamsCreditEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateParamsCreditEntitlementFromRaw.FromRawUnchecked"/>
    public static ProductUpdateParamsCreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateParamsCreditEntitlementFromRaw
    : IFromRawJson<ProductUpdateParamsCreditEntitlement>
{
    /// <inheritdoc/>
    public ProductUpdateParamsCreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateParamsCreditEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Proration behavior for credit grants during plan changes
/// </summary>
[JsonConverter(typeof(ProductUpdateParamsCreditEntitlementProrationBehaviorConverter))]
public enum ProductUpdateParamsCreditEntitlementProrationBehavior
{
    Prorate,
    NoProrate,
}

sealed class ProductUpdateParamsCreditEntitlementProrationBehaviorConverter
    : JsonConverter<ProductUpdateParamsCreditEntitlementProrationBehavior>
{
    public override ProductUpdateParamsCreditEntitlementProrationBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorate" => ProductUpdateParamsCreditEntitlementProrationBehavior.Prorate,
            "no_prorate" => ProductUpdateParamsCreditEntitlementProrationBehavior.NoProrate,
            _ => (ProductUpdateParamsCreditEntitlementProrationBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUpdateParamsCreditEntitlementProrationBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUpdateParamsCreditEntitlementProrationBehavior.Prorate => "prorate",
                ProductUpdateParamsCreditEntitlementProrationBehavior.NoProrate => "no_prorate",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Choose how you would like you digital product delivered
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductUpdateParamsDigitalProductDelivery,
        ProductUpdateParamsDigitalProductDeliveryFromRaw
    >)
)]
public sealed record class ProductUpdateParamsDigitalProductDelivery : JsonModel
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public IReadOnlyList<string>? Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
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
        _ = this.ExternalUrl;
        _ = this.Files;
        _ = this.Instructions;
    }

    public ProductUpdateParamsDigitalProductDelivery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateParamsDigitalProductDelivery(
        ProductUpdateParamsDigitalProductDelivery productUpdateParamsDigitalProductDelivery
    )
        : base(productUpdateParamsDigitalProductDelivery) { }
#pragma warning restore CS8618

    public ProductUpdateParamsDigitalProductDelivery(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateParamsDigitalProductDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateParamsDigitalProductDeliveryFromRaw.FromRawUnchecked"/>
    public static ProductUpdateParamsDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateParamsDigitalProductDeliveryFromRaw
    : IFromRawJson<ProductUpdateParamsDigitalProductDelivery>
{
    /// <inheritdoc/>
    public ProductUpdateParamsDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateParamsDigitalProductDelivery.FromRawUnchecked(rawData);
}
