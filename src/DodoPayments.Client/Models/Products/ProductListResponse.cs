using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using System = System;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(typeof(JsonModelConverter<ProductListResponse, ProductListResponseFromRaw>))]
public sealed record class ProductListResponse : JsonModel
{
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
    /// Entitlements linked to this product
    /// </summary>
    public required IReadOnlyList<ProductListResponseEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductListResponseEntitlement>>(
                "entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductListResponseEntitlement>>(
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
    /// Currency of the price
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
    /// Price of the product, optional.
    ///
    /// <para>The price is represented in the lowest denomination of the currency.
    /// For example: - In USD, a price of `$12.34` would be represented as `1234`
    /// (cents). - In JPY, a price of `¥1500` would be represented as `1500` (yen).
    /// - In INR, a price of `₹1234.56` would be represented as `123456` (paise).</para>
    ///
    /// <para>This ensures precision and avoids floating-point rounding errors.</para>
    /// </summary>
    public int? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Details of the price
    /// </summary>
    public Price? PriceDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Price>("price_detail");
        }
        init { this._rawData.Set("price_detail", value); }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive
    /// </summary>
    public bool? TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        foreach (var item in this.Entitlements)
        {
            item.Validate();
        }
        _ = this.IsRecurring;
        _ = this.Metadata;
        _ = this.ProductID;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        this.Currency?.Validate();
        _ = this.Description;
        _ = this.Image;
        _ = this.Name;
        _ = this.Price;
        this.PriceDetail?.Validate();
        _ = this.TaxInclusive;
    }

    public ProductListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponse(ProductListResponse productListResponse)
        : base(productListResponse) { }
#pragma warning restore CS8618

    public ProductListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseFromRaw.FromRawUnchecked"/>
    public static ProductListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListResponseFromRaw : IFromRawJson<ProductListResponse>
{
    /// <inheritdoc/>
    public ProductListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Summary of an entitlement attached to a product
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlement,
        ProductListResponseEntitlementFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlement : JsonModel
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
    /// Platform-specific configuration for an entitlement. Each variant uses unique
    /// field names so `#[serde(untagged)]` can disambiguate correctly.
    /// </summary>
    public required ProductListResponseEntitlementIntegrationConfig IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProductListResponseEntitlementIntegrationConfig>(
                "integration_config"
            );
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, ProductListResponseEntitlementIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductListResponseEntitlementIntegrationType>
            >("integration_type");
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

    public ProductListResponseEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlement(
        ProductListResponseEntitlement productListResponseEntitlement
    )
        : base(productListResponseEntitlement) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListResponseEntitlementFromRaw : IFromRawJson<ProductListResponseEntitlement>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Platform-specific configuration for an entitlement. Each variant uses unique field
/// names so `#[serde(untagged)]` can disambiguate correctly.
/// </summary>
[JsonConverter(typeof(ProductListResponseEntitlementIntegrationConfigConverter))]
public record class ProductListResponseEntitlementIntegrationConfig : ModelBase
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

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ProductListResponseEntitlementIntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub(
        [NotNullWhen(true)] out ProductListResponseEntitlementIntegrationConfigGitHubConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord(
        [NotNullWhen(true)] out ProductListResponseEntitlementIntegrationConfigDiscordConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram(
        [NotNullWhen(true)] out ProductListResponseEntitlementIntegrationConfigTelegramConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma(
        [NotNullWhen(true)] out ProductListResponseEntitlementIntegrationConfigFigmaConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer(
        [NotNullWhen(true)] out ProductListResponseEntitlementIntegrationConfigFramerConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion(
        [NotNullWhen(true)] out ProductListResponseEntitlementIntegrationConfigNotionConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles(
        [NotNullWhen(true)]
            out ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey(
        [NotNullWhen(true)]
            out ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig? value
    )
    {
        value = this.Value as ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig;
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
    ///     (ProductListResponseEntitlementIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ProductListResponseEntitlementIntegrationConfigGitHubConfig> github,
        System::Action<ProductListResponseEntitlementIntegrationConfigDiscordConfig> discord,
        System::Action<ProductListResponseEntitlementIntegrationConfigTelegramConfig> telegram,
        System::Action<ProductListResponseEntitlementIntegrationConfigFigmaConfig> figma,
        System::Action<ProductListResponseEntitlementIntegrationConfigFramerConfig> framer,
        System::Action<ProductListResponseEntitlementIntegrationConfigNotionConfig> notion,
        System::Action<ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig> digitalFiles,
        System::Action<ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case ProductListResponseEntitlementIntegrationConfigGitHubConfig value:
                github(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigDiscordConfig value:
                discord(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigTelegramConfig value:
                telegram(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigFigmaConfig value:
                figma(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigFramerConfig value:
                framer(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigNotionConfig value:
                notion(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig value:
                digitalFiles(value);
                break;
            case ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ProductListResponseEntitlementIntegrationConfig"
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
    ///     (ProductListResponseEntitlementIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ProductListResponseEntitlementIntegrationConfigGitHubConfig, T> github,
        System::Func<ProductListResponseEntitlementIntegrationConfigDiscordConfig, T> discord,
        System::Func<ProductListResponseEntitlementIntegrationConfigTelegramConfig, T> telegram,
        System::Func<ProductListResponseEntitlementIntegrationConfigFigmaConfig, T> figma,
        System::Func<ProductListResponseEntitlementIntegrationConfigFramerConfig, T> framer,
        System::Func<ProductListResponseEntitlementIntegrationConfigNotionConfig, T> notion,
        System::Func<
            ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig,
            T
        > digitalFiles,
        System::Func<ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            ProductListResponseEntitlementIntegrationConfigGitHubConfig value => github(value),
            ProductListResponseEntitlementIntegrationConfigDiscordConfig value => discord(value),
            ProductListResponseEntitlementIntegrationConfigTelegramConfig value => telegram(value),
            ProductListResponseEntitlementIntegrationConfigFigmaConfig value => figma(value),
            ProductListResponseEntitlementIntegrationConfigFramerConfig value => framer(value),
            ProductListResponseEntitlementIntegrationConfigNotionConfig value => notion(value),
            ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig value => digitalFiles(
                value
            ),
            ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig value => licenseKey(
                value
            ),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ProductListResponseEntitlementIntegrationConfig"
            ),
        };
    }

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigGitHubConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigDiscordConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigTelegramConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigFigmaConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigFramerConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigNotionConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig value
    ) => new(value);

    public static implicit operator ProductListResponseEntitlementIntegrationConfig(
        ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig value
    ) => new(value);

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
                "Data did not match any variant of ProductListResponseEntitlementIntegrationConfig"
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

    public virtual bool Equals(ProductListResponseEntitlementIntegrationConfig? other) =>
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
            ProductListResponseEntitlementIntegrationConfigGitHubConfig _ => 0,
            ProductListResponseEntitlementIntegrationConfigDiscordConfig _ => 1,
            ProductListResponseEntitlementIntegrationConfigTelegramConfig _ => 2,
            ProductListResponseEntitlementIntegrationConfigFigmaConfig _ => 3,
            ProductListResponseEntitlementIntegrationConfigFramerConfig _ => 4,
            ProductListResponseEntitlementIntegrationConfigNotionConfig _ => 5,
            ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig _ => 6,
            ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class ProductListResponseEntitlementIntegrationConfigConverter
    : JsonConverter<ProductListResponseEntitlementIntegrationConfig>
{
    public override ProductListResponseEntitlementIntegrationConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigGitHubConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigDiscordConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigTelegramConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigFigmaConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigFramerConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigNotionConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig>(
                    element,
                    options
                );
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
        ProductListResponseEntitlementIntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigGitHubConfig,
        ProductListResponseEntitlementIntegrationConfigGitHubConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigGitHubConfig : JsonModel
{
    /// <summary>
    /// One of: pull, push, admin, maintain, triage
    /// </summary>
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

    public ProductListResponseEntitlementIntegrationConfigGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigGitHubConfig(
        ProductListResponseEntitlementIntegrationConfigGitHubConfig productListResponseEntitlementIntegrationConfigGitHubConfig
    )
        : base(productListResponseEntitlementIntegrationConfigGitHubConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigGitHubConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigGitHubConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigGitHubConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListResponseEntitlementIntegrationConfigGitHubConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigGitHubConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigDiscordConfig,
        ProductListResponseEntitlementIntegrationConfigDiscordConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigDiscordConfig : JsonModel
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

    public ProductListResponseEntitlementIntegrationConfigDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigDiscordConfig(
        ProductListResponseEntitlementIntegrationConfigDiscordConfig productListResponseEntitlementIntegrationConfigDiscordConfig
    )
        : base(productListResponseEntitlementIntegrationConfigDiscordConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigDiscordConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigDiscordConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigDiscordConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class ProductListResponseEntitlementIntegrationConfigDiscordConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigDiscordConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigTelegramConfig,
        ProductListResponseEntitlementIntegrationConfigTelegramConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigTelegramConfig : JsonModel
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

    public ProductListResponseEntitlementIntegrationConfigTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigTelegramConfig(
        ProductListResponseEntitlementIntegrationConfigTelegramConfig productListResponseEntitlementIntegrationConfigTelegramConfig
    )
        : base(productListResponseEntitlementIntegrationConfigTelegramConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigTelegramConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigTelegramConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigTelegramConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class ProductListResponseEntitlementIntegrationConfigTelegramConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigTelegramConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigFigmaConfig,
        ProductListResponseEntitlementIntegrationConfigFigmaConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigFigmaConfig : JsonModel
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

    public ProductListResponseEntitlementIntegrationConfigFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigFigmaConfig(
        ProductListResponseEntitlementIntegrationConfigFigmaConfig productListResponseEntitlementIntegrationConfigFigmaConfig
    )
        : base(productListResponseEntitlementIntegrationConfigFigmaConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigFigmaConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigFigmaConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigFigmaConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class ProductListResponseEntitlementIntegrationConfigFigmaConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigFigmaConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigFramerConfig,
        ProductListResponseEntitlementIntegrationConfigFramerConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigFramerConfig : JsonModel
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

    public ProductListResponseEntitlementIntegrationConfigFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigFramerConfig(
        ProductListResponseEntitlementIntegrationConfigFramerConfig productListResponseEntitlementIntegrationConfigFramerConfig
    )
        : base(productListResponseEntitlementIntegrationConfigFramerConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigFramerConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigFramerConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigFramerConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class ProductListResponseEntitlementIntegrationConfigFramerConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigFramerConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigNotionConfig,
        ProductListResponseEntitlementIntegrationConfigNotionConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigNotionConfig : JsonModel
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

    public ProductListResponseEntitlementIntegrationConfigNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigNotionConfig(
        ProductListResponseEntitlementIntegrationConfigNotionConfig productListResponseEntitlementIntegrationConfigNotionConfig
    )
        : base(productListResponseEntitlementIntegrationConfigNotionConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigNotionConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigNotionConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigNotionConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class ProductListResponseEntitlementIntegrationConfigNotionConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigNotionConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig,
        ProductListResponseEntitlementIntegrationConfigDigitalFilesConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig
    : JsonModel
{
    public required IReadOnlyList<string> DigitalFileIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("digital_file_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "digital_file_ids",
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
        _ = this.DigitalFileIds;
        _ = this.ExternalUrl;
        _ = this.Instructions;
    }

    public ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig(
        ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig productListResponseEntitlementIntegrationConfigDigitalFilesConfig
    )
        : base(productListResponseEntitlementIntegrationConfigDigitalFilesConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig(
        IReadOnlyList<string> digitalFileIds
    )
        : this()
    {
        this.DigitalFileIds = digitalFileIds;
    }
}

class ProductListResponseEntitlementIntegrationConfigDigitalFilesConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ProductListResponseEntitlementIntegrationConfigDigitalFilesConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig,
        ProductListResponseEntitlementIntegrationConfigLicenseKeyConfigFromRaw
    >)
)]
public sealed record class ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig
    : JsonModel
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

    public string? DurationInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("duration_interval");
        }
        init { this._rawData.Set("duration_interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActivationMessage;
        _ = this.ActivationsLimit;
        _ = this.DurationCount;
        _ = this.DurationInterval;
    }

    public ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig(
        ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig productListResponseEntitlementIntegrationConfigLicenseKeyConfig
    )
        : base(productListResponseEntitlementIntegrationConfigLicenseKeyConfig) { }
#pragma warning restore CS8618

    public ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListResponseEntitlementIntegrationConfigLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListResponseEntitlementIntegrationConfigLicenseKeyConfigFromRaw
    : IFromRawJson<ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig>
{
    /// <inheritdoc/>
    public ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListResponseEntitlementIntegrationConfigLicenseKeyConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProductListResponseEntitlementIntegrationTypeConverter))]
public enum ProductListResponseEntitlementIntegrationType
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

sealed class ProductListResponseEntitlementIntegrationTypeConverter
    : JsonConverter<ProductListResponseEntitlementIntegrationType>
{
    public override ProductListResponseEntitlementIntegrationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => ProductListResponseEntitlementIntegrationType.Discord,
            "telegram" => ProductListResponseEntitlementIntegrationType.Telegram,
            "github" => ProductListResponseEntitlementIntegrationType.GitHub,
            "figma" => ProductListResponseEntitlementIntegrationType.Figma,
            "framer" => ProductListResponseEntitlementIntegrationType.Framer,
            "notion" => ProductListResponseEntitlementIntegrationType.Notion,
            "digital_files" => ProductListResponseEntitlementIntegrationType.DigitalFiles,
            "license_key" => ProductListResponseEntitlementIntegrationType.LicenseKey,
            _ => (ProductListResponseEntitlementIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductListResponseEntitlementIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductListResponseEntitlementIntegrationType.Discord => "discord",
                ProductListResponseEntitlementIntegrationType.Telegram => "telegram",
                ProductListResponseEntitlementIntegrationType.GitHub => "github",
                ProductListResponseEntitlementIntegrationType.Figma => "figma",
                ProductListResponseEntitlementIntegrationType.Framer => "framer",
                ProductListResponseEntitlementIntegrationType.Notion => "notion",
                ProductListResponseEntitlementIntegrationType.DigitalFiles => "digital_files",
                ProductListResponseEntitlementIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
