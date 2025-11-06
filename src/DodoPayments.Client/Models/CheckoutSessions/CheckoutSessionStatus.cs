using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(ModelConverter<CheckoutSessionStatus>))]
public sealed record class CheckoutSessionStatus : ModelBase, IFromRaw<CheckoutSessionStatus>
{
    /// <summary>
    /// Id of the checkout session
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customer email: prefers payment's customer, falls back to session
    /// </summary>
    public string? CustomerEmail
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["customer_email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customer name: prefers payment's customer, falls back to session
    /// </summary>
    public string? CustomerName
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["customer_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Id of the payment created by the checkout sessions.
    ///
    /// Null if checkout sessions is still at the details collection stage.
    /// </summary>
    public string? PaymentID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// status of the payment.
    ///
    /// Null if checkout sessions is still at the details collection stage.
    /// </summary>
    public ApiEnum<string, Payments::IntentStatus>? PaymentStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Payments::IntentStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["payment_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionStatus(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CheckoutSessionStatus FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
