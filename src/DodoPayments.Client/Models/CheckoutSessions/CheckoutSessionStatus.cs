using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<CheckoutSessionStatus, CheckoutSessionStatusFromRaw>))]
public sealed record class CheckoutSessionStatus : JsonModel
{
    /// <summary>
    /// Id of the checkout session
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
    /// Created at timestamp
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Customer email: prefers payment's customer, falls back to session
    /// </summary>
    public string? CustomerEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_email");
        }
        init { this._rawData.Set("customer_email", value); }
    }

    /// <summary>
    /// Customer name: prefers payment's customer, falls back to session
    /// </summary>
    public string? CustomerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customer_name");
        }
        init { this._rawData.Set("customer_name", value); }
    }

    /// <summary>
    /// Id of the payment created by the checkout sessions.
    ///
    /// <para>Null if checkout sessions is still at the details collection stage.</para>
    /// </summary>
    public string? PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntentStatus>>("payment_status");
        }
        init { this._rawData.Set("payment_status", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class CheckoutSessionStatusFromRaw : IFromRawJson<CheckoutSessionStatus>
{
    /// <inheritdoc/>
    public CheckoutSessionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionStatus.FromRawUnchecked(rawData);
}
