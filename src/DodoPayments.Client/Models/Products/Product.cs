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
    public required IReadOnlyList<CreditEntitlementMappingResponse> CreditEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CreditEntitlementMappingResponse>>(
                "credit_entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditEntitlementMappingResponse>>(
                "credit_entitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Attached entitlements (integration-based access grants)
    /// </summary>
    public required IReadOnlyList<ProductEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductEntitlement>>(
                "entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductEntitlement>>(
                "entitlements",
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
    [System::Obsolete("deprecated")]
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

    /// <summary>
    /// Digital-product-delivery payload for a grant. Populated for grants whose entitlement
    /// has `integration_type = 'digital_files'`. `files` carries presigned download
    /// URLs; the source (EE service or legacy in-process S3 presigning) is opaque
    /// to the caller.
    /// </summary>
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
    [System::Obsolete("deprecated")]
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
    [System::Obsolete("deprecated")]
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
        foreach (var item in this.Entitlements)
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

    [System::Obsolete("Required properties are deprecated: license_key_enabled")]
    public Product() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete("Required properties are deprecated: license_key_enabled")]
    public Product(Product product)
        : base(product) { }
#pragma warning restore CS8618

    [System::Obsolete("Required properties are deprecated: license_key_enabled")]
    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: license_key_enabled")]
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
/// Summary of an entitlement attached to a product.
///
/// <para>`integration_config` uses [`IntegrationConfigResponse`] (NOT the persisted
/// [`IntegrationConfig`]) so digital_files entitlements embed the resolved `digital_files`
/// object — matching what `GET /entitlements/{id}` returns. All other variants pass
/// through unchanged via `#[serde(untagged)]`.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProductEntitlement, ProductEntitlementFromRaw>))]
public sealed record class ProductEntitlement : JsonModel
{
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
    /// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
    /// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
    /// object (resolved download URLs etc.).  The persisted JSONB stays ID-only
    /// via [`IntegrationConfig`]; this enum is response-only.
    /// </summary>
    public required IntegrationConfig IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationConfig>("integration_config");
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, IntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IntegrationType>>(
                "integration_type"
            );
        }
        init { this._rawData.Set("integration_type", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.IntegrationConfig.Validate();
        this.IntegrationType.Validate();
        _ = this.Name;
        _ = this.Description;
    }

    public ProductEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductEntitlement(ProductEntitlement productEntitlement)
        : base(productEntitlement) { }
#pragma warning restore CS8618

    public ProductEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductEntitlementFromRaw.FromRawUnchecked"/>
    public static ProductEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductEntitlementFromRaw : IFromRawJson<ProductEntitlement>
{
    /// <inheritdoc/>
    public ProductEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
/// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
/// object (resolved download URLs etc.).  The persisted JSONB stays ID-only via [`IntegrationConfig`];
/// this enum is response-only.
/// </summary>
[JsonConverter(typeof(IntegrationConfigConverter))]
public record class IntegrationConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IntegrationConfig(GitHubConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(DiscordConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(TelegramConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(FigmaConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(FramerConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(NotionConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(DigitalFilesConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(LicenseKeyConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `GitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub([NotNullWhen(true)] out GitHubConfig? value)
    {
        value = this.Value as GitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `DiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord([NotNullWhen(true)] out DiscordConfig? value)
    {
        value = this.Value as DiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `TelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram([NotNullWhen(true)] out TelegramConfig? value)
    {
        value = this.Value as TelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `FigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma([NotNullWhen(true)] out FigmaConfig? value)
    {
        value = this.Value as FigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `FramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer([NotNullWhen(true)] out FramerConfig? value)
    {
        value = this.Value as FramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `NotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion([NotNullWhen(true)] out NotionConfig? value)
    {
        value = this.Value as NotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `DigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles([NotNullWhen(true)] out DigitalFilesConfig? value)
    {
        value = this.Value as DigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `LicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey([NotNullWhen(true)] out LicenseKeyConfig? value)
    {
        value = this.Value as LicenseKeyConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (GitHubConfig value) =&gt; {...},
    ///     (DiscordConfig value) =&gt; {...},
    ///     (TelegramConfig value) =&gt; {...},
    ///     (FigmaConfig value) =&gt; {...},
    ///     (FramerConfig value) =&gt; {...},
    ///     (NotionConfig value) =&gt; {...},
    ///     (DigitalFilesConfig value) =&gt; {...},
    ///     (LicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<GitHubConfig> github,
        System::Action<DiscordConfig> discord,
        System::Action<TelegramConfig> telegram,
        System::Action<FigmaConfig> figma,
        System::Action<FramerConfig> framer,
        System::Action<NotionConfig> notion,
        System::Action<DigitalFilesConfig> digitalFiles,
        System::Action<LicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case GitHubConfig value:
                github(value);
                break;
            case DiscordConfig value:
                discord(value);
                break;
            case TelegramConfig value:
                telegram(value);
                break;
            case FigmaConfig value:
                figma(value);
                break;
            case FramerConfig value:
                framer(value);
                break;
            case NotionConfig value:
                notion(value);
                break;
            case DigitalFilesConfig value:
                digitalFiles(value);
                break;
            case LicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of IntegrationConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (GitHubConfig value) =&gt; {...},
    ///     (DiscordConfig value) =&gt; {...},
    ///     (TelegramConfig value) =&gt; {...},
    ///     (FigmaConfig value) =&gt; {...},
    ///     (FramerConfig value) =&gt; {...},
    ///     (NotionConfig value) =&gt; {...},
    ///     (DigitalFilesConfig value) =&gt; {...},
    ///     (LicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<GitHubConfig, T> github,
        System::Func<DiscordConfig, T> discord,
        System::Func<TelegramConfig, T> telegram,
        System::Func<FigmaConfig, T> figma,
        System::Func<FramerConfig, T> framer,
        System::Func<NotionConfig, T> notion,
        System::Func<DigitalFilesConfig, T> digitalFiles,
        System::Func<LicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            GitHubConfig value => github(value),
            DiscordConfig value => discord(value),
            TelegramConfig value => telegram(value),
            FigmaConfig value => figma(value),
            FramerConfig value => framer(value),
            NotionConfig value => notion(value),
            DigitalFilesConfig value => digitalFiles(value),
            LicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of IntegrationConfig"
            ),
        };
    }

    public static implicit operator IntegrationConfig(GitHubConfig value) => new(value);

    public static implicit operator IntegrationConfig(DiscordConfig value) => new(value);

    public static implicit operator IntegrationConfig(TelegramConfig value) => new(value);

    public static implicit operator IntegrationConfig(FigmaConfig value) => new(value);

    public static implicit operator IntegrationConfig(FramerConfig value) => new(value);

    public static implicit operator IntegrationConfig(NotionConfig value) => new(value);

    public static implicit operator IntegrationConfig(DigitalFilesConfig value) => new(value);

    public static implicit operator IntegrationConfig(LicenseKeyConfig value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of IntegrationConfig"
            );
        }
        this.Switch(
            (github) => github.Validate(),
            (discord) => discord.Validate(),
            (telegram) => telegram.Validate(),
            (figma) => figma.Validate(),
            (framer) => framer.Validate(),
            (notion) => notion.Validate(),
            (digitalFiles) => digitalFiles.Validate(),
            (licenseKey) => licenseKey.Validate()
        );
    }

    public virtual bool Equals(IntegrationConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            GitHubConfig _ => 0,
            DiscordConfig _ => 1,
            TelegramConfig _ => 2,
            FigmaConfig _ => 3,
            FramerConfig _ => 4,
            NotionConfig _ => 5,
            DigitalFilesConfig _ => 6,
            LicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class IntegrationConfigConverter : JsonConverter<IntegrationConfig>
{
    public override IntegrationConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<GitHubConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DiscordConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<TelegramConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FigmaConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FramerConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NotionConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DigitalFilesConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<LicenseKeyConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<GitHubConfig, GitHubConfigFromRaw>))]
public sealed record class GitHubConfig : JsonModel
{
    public required string Permission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("permission");
        }
        init { this._rawData.Set("permission", value); }
    }

    public required string TargetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target_id");
        }
        init { this._rawData.Set("target_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Permission;
        _ = this.TargetID;
    }

    public GitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GitHubConfig(GitHubConfig githubConfig)
        : base(githubConfig) { }
#pragma warning restore CS8618

    public GitHubConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GitHubConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GitHubConfigFromRaw.FromRawUnchecked"/>
    public static GitHubConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GitHubConfigFromRaw : IFromRawJson<GitHubConfig>
{
    /// <inheritdoc/>
    public GitHubConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DiscordConfig, DiscordConfigFromRaw>))]
public sealed record class DiscordConfig : JsonModel
{
    public required string GuildID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("guild_id");
        }
        init { this._rawData.Set("guild_id", value); }
    }

    public string? RoleID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role_id");
        }
        init { this._rawData.Set("role_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GuildID;
        _ = this.RoleID;
    }

    public DiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscordConfig(DiscordConfig discordConfig)
        : base(discordConfig) { }
#pragma warning restore CS8618

    public DiscordConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscordConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscordConfigFromRaw.FromRawUnchecked"/>
    public static DiscordConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class DiscordConfigFromRaw : IFromRawJson<DiscordConfig>
{
    /// <inheritdoc/>
    public DiscordConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TelegramConfig, TelegramConfigFromRaw>))]
public sealed record class TelegramConfig : JsonModel
{
    public required string ChatID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chat_id");
        }
        init { this._rawData.Set("chat_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChatID;
    }

    public TelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelegramConfig(TelegramConfig telegramConfig)
        : base(telegramConfig) { }
#pragma warning restore CS8618

    public TelegramConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TelegramConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TelegramConfigFromRaw.FromRawUnchecked"/>
    public static TelegramConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class TelegramConfigFromRaw : IFromRawJson<TelegramConfig>
{
    /// <inheritdoc/>
    public TelegramConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FigmaConfig, FigmaConfigFromRaw>))]
public sealed record class FigmaConfig : JsonModel
{
    public required string FigmaFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("figma_file_id");
        }
        init { this._rawData.Set("figma_file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FigmaFileID;
    }

    public FigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FigmaConfig(FigmaConfig figmaConfig)
        : base(figmaConfig) { }
#pragma warning restore CS8618

    public FigmaConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FigmaConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FigmaConfigFromRaw.FromRawUnchecked"/>
    public static FigmaConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class FigmaConfigFromRaw : IFromRawJson<FigmaConfig>
{
    /// <inheritdoc/>
    public FigmaConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FramerConfig, FramerConfigFromRaw>))]
public sealed record class FramerConfig : JsonModel
{
    public required string FramerTemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("framer_template_id");
        }
        init { this._rawData.Set("framer_template_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FramerTemplateID;
    }

    public FramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FramerConfig(FramerConfig framerConfig)
        : base(framerConfig) { }
#pragma warning restore CS8618

    public FramerConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FramerConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FramerConfigFromRaw.FromRawUnchecked"/>
    public static FramerConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class FramerConfigFromRaw : IFromRawJson<FramerConfig>
{
    /// <inheritdoc/>
    public FramerConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NotionConfig, NotionConfigFromRaw>))]
public sealed record class NotionConfig : JsonModel
{
    public required string NotionTemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("notion_template_id");
        }
        init { this._rawData.Set("notion_template_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NotionTemplateID;
    }

    public NotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotionConfig(NotionConfig notionConfig)
        : base(notionConfig) { }
#pragma warning restore CS8618

    public NotionConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotionConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotionConfigFromRaw.FromRawUnchecked"/>
    public static NotionConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class NotionConfigFromRaw : IFromRawJson<NotionConfig>
{
    /// <inheritdoc/>
    public NotionConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DigitalFilesConfig, DigitalFilesConfigFromRaw>))]
public sealed record class DigitalFilesConfig : JsonModel
{
    /// <summary>
    /// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
    /// but is sourced from an entitlement's `integration_config` (not a grant) and
    /// tags each file with its origin (`legacy` vs `ee`).
    /// </summary>
    public required DigitalFiles DigitalFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DigitalFiles>("digital_files");
        }
        init { this._rawData.Set("digital_files", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DigitalFiles.Validate();
    }

    public DigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalFilesConfig(DigitalFilesConfig digitalFilesConfig)
        : base(digitalFilesConfig) { }
#pragma warning restore CS8618

    public DigitalFilesConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalFilesConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static DigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalFilesConfig(DigitalFiles digitalFiles)
        : this()
    {
        this.DigitalFiles = digitalFiles;
    }
}

class DigitalFilesConfigFromRaw : IFromRawJson<DigitalFilesConfig>
{
    /// <inheritdoc/>
    public DigitalFilesConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalFilesConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
/// but is sourced from an entitlement's `integration_config` (not a grant) and tags
/// each file with its origin (`legacy` vs `ee`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalFiles, DigitalFilesFromRaw>))]
public sealed record class DigitalFiles : JsonModel
{
    public required IReadOnlyList<File> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>>(
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

    public DigitalFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalFiles(DigitalFiles digitalFiles)
        : base(digitalFiles) { }
#pragma warning restore CS8618

    public DigitalFiles(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalFiles(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalFilesFromRaw.FromRawUnchecked"/>
    public static DigitalFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalFiles(IReadOnlyList<File> files)
        : this()
    {
        this.Files = files;
    }
}

class DigitalFilesFromRaw : IFromRawJson<DigitalFiles>
{
    /// <inheritdoc/>
    public DigitalFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalFiles.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    public required string DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("download_url");
        }
        init { this._rawData.Set("download_url", value); }
    }

    /// <summary>
    /// Seconds until `download_url` expires.
    /// </summary>
    public required long ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expires_in");
        }
        init { this._rawData.Set("expires_in", value); }
    }

    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// `"legacy"` for files in `product_files`, `"ee"` for files managed by the Entitlements Engine.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    public long? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_size");
        }
        init { this._rawData.Set("file_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadUrl;
        _ = this.ExpiresIn;
        _ = this.FileID;
        _ = this.Filename;
        _ = this.Source;
        _ = this.ContentType;
        _ = this.FileSize;
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

[JsonConverter(typeof(JsonModelConverter<LicenseKeyConfig, LicenseKeyConfigFromRaw>))]
public sealed record class LicenseKeyConfig : JsonModel
{
    public string? ActivationMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("activation_message");
        }
        init { this._rawData.Set("activation_message", value); }
    }

    public int? ActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawData.Set("activations_limit", value); }
    }

    public int? DurationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_count");
        }
        init { this._rawData.Set("duration_count", value); }
    }

    public ApiEnum<string, TimeInterval>? DurationInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TimeInterval>>(
                "duration_interval"
            );
        }
        init { this._rawData.Set("duration_interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActivationMessage;
        _ = this.ActivationsLimit;
        _ = this.DurationCount;
        this.DurationInterval?.Validate();
    }

    public LicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKeyConfig(LicenseKeyConfig licenseKeyConfig)
        : base(licenseKeyConfig) { }
#pragma warning restore CS8618

    public LicenseKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static LicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyConfigFromRaw : IFromRawJson<LicenseKeyConfig>
{
    /// <inheritdoc/>
    public LicenseKeyConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKeyConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IntegrationTypeConverter))]
public enum IntegrationType
{
    Discord,
    Telegram,
    GitHub,
    Figma,
    Framer,
    Notion,
    DigitalFiles,
    LicenseKey,
}

sealed class IntegrationTypeConverter : JsonConverter<IntegrationType>
{
    public override IntegrationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => IntegrationType.Discord,
            "telegram" => IntegrationType.Telegram,
            "github" => IntegrationType.GitHub,
            "figma" => IntegrationType.Figma,
            "framer" => IntegrationType.Framer,
            "notion" => IntegrationType.Notion,
            "digital_files" => IntegrationType.DigitalFiles,
            "license_key" => IntegrationType.LicenseKey,
            _ => (IntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationType.Discord => "discord",
                IntegrationType.Telegram => "telegram",
                IntegrationType.GitHub => "github",
                IntegrationType.Figma => "figma",
                IntegrationType.Framer => "framer",
                IntegrationType.Notion => "notion",
                IntegrationType.DigitalFiles => "digital_files",
                IntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
