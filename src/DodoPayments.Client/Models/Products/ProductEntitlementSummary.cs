using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// Summary of an entitlement attached to a product.
///
/// <para>`integration_config` uses [`IntegrationConfigResponse`] (NOT the persisted
/// [`IntegrationConfig`]) so digital_files entitlements embed the resolved `digital_files`
/// object — matching what `GET /entitlements/{id}` returns. All other variants pass
/// through unchanged via `#[serde(untagged)]`.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProductEntitlementSummary, ProductEntitlementSummaryFromRaw>)
)]
public sealed record class ProductEntitlementSummary : JsonModel
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
    public required IntegrationConfigResponse IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationConfigResponse>("integration_config");
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, EntitlementIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntitlementIntegrationType>>(
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

    public ProductEntitlementSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductEntitlementSummary(ProductEntitlementSummary productEntitlementSummary)
        : base(productEntitlementSummary) { }
#pragma warning restore CS8618

    public ProductEntitlementSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductEntitlementSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductEntitlementSummaryFromRaw.FromRawUnchecked"/>
    public static ProductEntitlementSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductEntitlementSummaryFromRaw : IFromRawJson<ProductEntitlementSummary>
{
    /// <inheritdoc/>
    public ProductEntitlementSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductEntitlementSummary.FromRawUnchecked(rawData);
}
