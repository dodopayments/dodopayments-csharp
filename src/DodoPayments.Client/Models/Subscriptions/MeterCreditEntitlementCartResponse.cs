using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing meter-credit entitlement mapping cart details for
/// a subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MeterCreditEntitlementCartResponse,
        MeterCreditEntitlementCartResponseFromRaw
    >)
)]
public sealed record class MeterCreditEntitlementCartResponse : JsonModel
{
    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string MeterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_id");
        }
        init { this._rawData.Set("meter_id", value); }
    }

    public required string MeterName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_name");
        }
        init { this._rawData.Set("meter_name", value); }
    }

    public required string MeterUnitsPerCredit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("meter_units_per_credit");
        }
        init { this._rawData.Set("meter_units_per_credit", value); }
    }

    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreditEntitlementID;
        _ = this.MeterID;
        _ = this.MeterName;
        _ = this.MeterUnitsPerCredit;
        _ = this.ProductID;
    }

    public MeterCreditEntitlementCartResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeterCreditEntitlementCartResponse(
        MeterCreditEntitlementCartResponse meterCreditEntitlementCartResponse
    )
        : base(meterCreditEntitlementCartResponse) { }
#pragma warning restore CS8618

    public MeterCreditEntitlementCartResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterCreditEntitlementCartResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterCreditEntitlementCartResponseFromRaw.FromRawUnchecked"/>
    public static MeterCreditEntitlementCartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterCreditEntitlementCartResponseFromRaw : IFromRawJson<MeterCreditEntitlementCartResponse>
{
    /// <inheritdoc/>
    public MeterCreditEntitlementCartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MeterCreditEntitlementCartResponse.FromRawUnchecked(rawData);
}
