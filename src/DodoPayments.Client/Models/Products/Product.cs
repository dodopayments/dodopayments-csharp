using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : JsonModel
{
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the product belongs.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// Timestamp when the product was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Attached credit entitlements with settings
    /// </summary>
    public required IReadOnlyList<ProductCreditEntitlement> CreditEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductCreditEntitlement>>(
                "credit_entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCreditEntitlement>>(
                "credit_entitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates if the product is recurring (e.g., subscriptions).
    /// </summary>
    public required bool IsRecurring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_recurring");
        }
        init { this._rawData.Set("is_recurring", value); }
    }

    /// <summary>
    /// Indicates whether the product requires a license key.
    /// </summary>
    public required bool LicenseKeyEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("license_key_enabled");
        }
        init { this._rawData.Set("license_key_enabled", value); }
    }

    /// <summary>
    /// Additional custom data associated with the product
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Pricing information for the product.
    /// </summary>
    public required Price Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Price>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Tax category associated with the product.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawData.Set("tax_category", value); }
    }

    /// <summary>
    /// Timestamp when the product was last updated.
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Available Addons for subscription products
    /// </summary>
    public IReadOnlyList<string>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Description of the product, optional.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public ProductDigitalProductDelivery? DigitalProductDelivery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductDigitalProductDelivery>(
                "digital_product_delivery"
            );
        }
        init { this._rawData.Set("digital_product_delivery", value); }
    }

    /// <summary>
    /// URL of the product image, optional.
    /// </summary>
    public string? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image");
        }
        init { this._rawData.Set("image", value); }
    }

    /// <summary>
    /// Message sent upon license key activation, if applicable.
    /// </summary>
    public string? LicenseKeyActivationMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_key_activation_message");
        }
        init { this._rawData.Set("license_key_activation_message", value); }
    }

    /// <summary>
    /// Limit on the number of activations for the license key, if enabled.
    /// </summary>
    public int? LicenseKeyActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("license_key_activations_limit");
        }
        init { this._rawData.Set("license_key_activations_limit", value); }
    }

    /// <summary>
    /// Duration of the license key validity, if enabled.
    /// </summary>
    public LicenseKeyDuration? LicenseKeyDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LicenseKeyDuration>("license_key_duration");
        }
        init { this._rawData.Set("license_key_duration", value); }
    }

    /// <summary>
    /// Name of the product, optional.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The product collection ID this product belongs to, if any
    /// </summary>
    public string? ProductCollectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_collection_id");
        }
        init { this._rawData.Set("product_collection_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        foreach (var item in this.CreditEntitlements)
        {
            item.Validate();
        }
        _ = this.IsRecurring;
        _ = this.LicenseKeyEnabled;
        _ = this.Metadata;
        this.Price.Validate();
        _ = this.ProductID;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        _ = this.Addons;
        _ = this.Description;
        this.DigitalProductDelivery?.Validate();
        _ = this.Image;
        _ = this.LicenseKeyActivationMessage;
        _ = this.LicenseKeyActivationsLimit;
        this.LicenseKeyDuration?.Validate();
        _ = this.Name;
        _ = this.ProductCollectionID;
    }

    public Product() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Product(Product product)
        : base(product) { }
#pragma warning restore CS8618

    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductFromRaw.FromRawUnchecked"/>
    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductFromRaw : IFromRawJson<Product>
{
    /// <inheritdoc/>
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}

/// <summary>
/// Response struct for credit entitlement mapping
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProductCreditEntitlement, ProductCreditEntitlementFromRaw>)
)]
public sealed record class ProductCreditEntitlement : JsonModel
{
    /// <summary>
    /// Unique ID of this mapping
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ID of the credit entitlement
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
    /// Name of the credit entitlement
    /// </summary>
    public required string CreditEntitlementName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_name");
        }
        init { this._rawData.Set("credit_entitlement_name", value); }
    }

    /// <summary>
    /// Unit label for the credit entitlement
    /// </summary>
    public required string CreditEntitlementUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_unit");
        }
        init { this._rawData.Set("credit_entitlement_unit", value); }
    }

    /// <summary>
    /// Number of credits granted
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
    public required bool CreditsReduceOverage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("credits_reduce_overage");
        }
        init { this._rawData.Set("credits_reduce_overage", value); }
    }

    /// <summary>
    /// Whether overage is charged at billing
    /// </summary>
    public required bool OverageChargeAtBilling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("overage_charge_at_billing");
        }
        init { this._rawData.Set("overage_charge_at_billing", value); }
    }

    /// <summary>
    /// Whether overage is enabled
    /// </summary>
    public required bool OverageEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("overage_enabled");
        }
        init { this._rawData.Set("overage_enabled", value); }
    }

    /// <summary>
    /// Whether to preserve overage balance when credits reset
    /// </summary>
    public required bool PreserveOverageAtReset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("preserve_overage_at_reset");
        }
        init { this._rawData.Set("preserve_overage_at_reset", value); }
    }

    /// <summary>
    /// Proration behavior for credit grants during plan changes
    /// </summary>
    public required ApiEnum<string, ProductCreditEntitlementProrationBehavior> ProrationBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductCreditEntitlementProrationBehavior>
            >("proration_behavior");
        }
        init { this._rawData.Set("proration_behavior", value); }
    }

    /// <summary>
    /// Whether rollover is enabled
    /// </summary>
    public required bool RolloverEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("rollover_enabled");
        }
        init { this._rawData.Set("rollover_enabled", value); }
    }

    /// <summary>
    /// Whether trial credits expire after trial
    /// </summary>
    public required bool TrialCreditsExpireAfterTrial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("trial_credits_expire_after_trial");
        }
        init { this._rawData.Set("trial_credits_expire_after_trial", value); }
    }

    /// <summary>
    /// Currency
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
    /// Days until credits expire
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
    /// Low balance threshold percentage
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
    /// Maximum rollover cycles
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
    /// Overage limit
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
    /// Price per unit
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
    /// Rollover percentage
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
    /// Rollover timeframe count
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
    /// Rollover timeframe interval
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
    /// Trial credits
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreditEntitlementID;
        _ = this.CreditEntitlementName;
        _ = this.CreditEntitlementUnit;
        _ = this.CreditsAmount;
        _ = this.CreditsReduceOverage;
        _ = this.OverageChargeAtBilling;
        _ = this.OverageEnabled;
        _ = this.PreserveOverageAtReset;
        this.ProrationBehavior.Validate();
        _ = this.RolloverEnabled;
        _ = this.TrialCreditsExpireAfterTrial;
        this.Currency?.Validate();
        _ = this.ExpiresAfterDays;
        _ = this.LowBalanceThresholdPercent;
        _ = this.MaxRolloverCount;
        _ = this.OverageLimit;
        _ = this.PricePerUnit;
        _ = this.RolloverPercentage;
        _ = this.RolloverTimeframeCount;
        this.RolloverTimeframeInterval?.Validate();
        _ = this.TrialCredits;
    }

    public ProductCreditEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCreditEntitlement(ProductCreditEntitlement productCreditEntitlement)
        : base(productCreditEntitlement) { }
#pragma warning restore CS8618

    public ProductCreditEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCreditEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCreditEntitlementFromRaw.FromRawUnchecked"/>
    public static ProductCreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCreditEntitlementFromRaw : IFromRawJson<ProductCreditEntitlement>
{
    /// <inheritdoc/>
    public ProductCreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCreditEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Proration behavior for credit grants during plan changes
/// </summary>
[JsonConverter(typeof(ProductCreditEntitlementProrationBehaviorConverter))]
public enum ProductCreditEntitlementProrationBehavior
{
    Prorate,
    NoProrate,
}

sealed class ProductCreditEntitlementProrationBehaviorConverter
    : JsonConverter<ProductCreditEntitlementProrationBehavior>
{
    public override ProductCreditEntitlementProrationBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorate" => ProductCreditEntitlementProrationBehavior.Prorate,
            "no_prorate" => ProductCreditEntitlementProrationBehavior.NoProrate,
            _ => (ProductCreditEntitlementProrationBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCreditEntitlementProrationBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCreditEntitlementProrationBehavior.Prorate => "prorate",
                ProductCreditEntitlementProrationBehavior.NoProrate => "no_prorate",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ProductDigitalProductDelivery, ProductDigitalProductDeliveryFromRaw>)
)]
public sealed record class ProductDigitalProductDelivery : JsonModel
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
    public IReadOnlyList<File>? Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>?>(
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
        foreach (var item in this.Files ?? [])
        {
            item.Validate();
        }
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
}

class ProductDigitalProductDeliveryFromRaw : IFromRawJson<ProductDigitalProductDelivery>
{
    /// <inheritdoc/>
    public ProductDigitalProductDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDigitalProductDelivery.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_name");
        }
        init { this._rawData.Set("file_name", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
        _ = this.Url;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public File(File file)
        : base(file) { }
#pragma warning restore CS8618

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}
