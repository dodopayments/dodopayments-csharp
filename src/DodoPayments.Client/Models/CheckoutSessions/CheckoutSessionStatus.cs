using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(ModelConverter<CheckoutSessionStatus, CheckoutSessionStatusFromRaw>))]
public sealed record class CheckoutSessionStatus : ModelBase
{
    /// <summary>
    /// Id of the checkout session
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Customer email: prefers payment's customer, falls back to session
    /// </summary>
    public string? CustomerEmail
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "customer_email"); }
        init { ModelBase.Set(this._rawData, "customer_email", value); }
    }

    /// <summary>
    /// Customer name: prefers payment's customer, falls back to session
    /// </summary>
    public string? CustomerName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "customer_name"); }
        init { ModelBase.Set(this._rawData, "customer_name", value); }
    }

    /// <summary>
    /// Id of the payment created by the checkout sessions.
    ///
    /// <para>Null if checkout sessions is still at the details collection stage.</para>
    /// </summary>
    public string? PaymentID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// status of the payment.
    ///
    /// <para>Null if checkout sessions is still at the details collection stage.</para>
    /// </summary>
    public ApiEnum<string, IntentStatus>? PaymentStatus
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, IntentStatus>>(
                this.RawData,
                "payment_status"
            );
        }
        init { ModelBase.Set(this._rawData, "payment_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomerEmail;
        _ = this.CustomerName;
        _ = this.PaymentID;
        this.PaymentStatus?.Validate();
    }

    public CheckoutSessionStatus() { }

    public CheckoutSessionStatus(CheckoutSessionStatus checkoutSessionStatus)
        : base(checkoutSessionStatus) { }

    public CheckoutSessionStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionStatusFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionStatusFromRaw : IFromRaw<CheckoutSessionStatus>
{
    /// <inheritdoc/>
    public CheckoutSessionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionStatus.FromRawUnchecked(rawData);
}
