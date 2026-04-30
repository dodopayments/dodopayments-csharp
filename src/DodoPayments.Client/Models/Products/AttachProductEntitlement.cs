using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

/// <summary>
/// Request struct for attaching an entitlement to a product.
///
/// <para>Mirrors the `credit_entitlements` attach shape — every "attach something
/// to a product" array takes objects, not bare IDs. Uniform shape leaves room for
/// per-attachment settings later without another API break.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AttachProductEntitlement, AttachProductEntitlementFromRaw>)
)]
public sealed record class AttachProductEntitlement : JsonModel
{
    /// <summary>
    /// ID of the entitlement to attach to the product
    /// </summary>
    public required string EntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlement_id");
        }
        init { this._rawData.Set("entitlement_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EntitlementID;
    }

    public AttachProductEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachProductEntitlement(AttachProductEntitlement attachProductEntitlement)
        : base(attachProductEntitlement) { }
#pragma warning restore CS8618

    public AttachProductEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachProductEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachProductEntitlementFromRaw.FromRawUnchecked"/>
    public static AttachProductEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AttachProductEntitlement(string entitlementID)
        : this()
    {
        this.EntitlementID = entitlementID;
    }
}

class AttachProductEntitlementFromRaw : IFromRawJson<AttachProductEntitlement>
{
    /// <inheritdoc/>
    public AttachProductEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttachProductEntitlement.FromRawUnchecked(rawData);
}
