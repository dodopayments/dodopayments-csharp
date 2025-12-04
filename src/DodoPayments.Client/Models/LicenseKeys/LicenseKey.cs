using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeys;

[JsonConverter(typeof(ModelConverter<LicenseKey, LicenseKeyFromRaw>))]
public sealed record class LicenseKey : ModelBase
{
    /// <summary>
    /// The unique identifier of the license key.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the license key.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key was created, in UTC.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The unique identifier of the customer associated with the license key.
    /// </summary>
    public required string CustomerID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { ModelBase.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// The current number of instances activated for this license key.
    /// </summary>
    public required int InstancesCount
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawData, "instances_count"); }
        init { ModelBase.Set(this._rawData, "instances_count", value); }
    }

    /// <summary>
    /// The license key string.
    /// </summary>
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the license key.
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the product associated with the license key.
    /// </summary>
    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "product_id"); }
        init { ModelBase.Set(this._rawData, "product_id", value); }
    }

    /// <summary>
    /// The current status of the license key (e.g., active, inactive, expired).
    /// </summary>
    public required ApiEnum<string, LicenseKeyStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, LicenseKeyStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The maximum number of activations allowed for this license key.
    /// </summary>
    public int? ActivationsLimit
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "activations_limit"); }
        init { ModelBase.Set(this._rawData, "activations_limit", value); }
    }

    /// <summary>
    /// The timestamp indicating when the license key expires, in UTC.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "expires_at"); }
        init { ModelBase.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// The unique identifier of the subscription associated with the license key,
    /// if any.
    /// </summary>
    public string? SubscriptionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subscription_id"); }
        init { ModelBase.Set(this._rawData, "subscription_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.InstancesCount;
        _ = this.Key;
        _ = this.PaymentID;
        _ = this.ProductID;
        this.Status.Validate();
        _ = this.ActivationsLimit;
        _ = this.ExpiresAt;
        _ = this.SubscriptionID;
    }

    public LicenseKey() { }

    public LicenseKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyFromRaw.FromRawUnchecked"/>
    public static LicenseKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyFromRaw : IFromRaw<LicenseKey>
{
    /// <inheritdoc/>
    public LicenseKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKey.FromRawUnchecked(rawData);
}
