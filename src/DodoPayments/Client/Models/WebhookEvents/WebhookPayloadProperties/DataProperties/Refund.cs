using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using IntersectionMember1Properties = DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties.RefundProperties.IntersectionMember1Properties;
using Misc = DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;
using Refunds = DodoPayments.Client.Models.Refunds;

namespace DodoPayments.Client.Models.WebhookEvents.WebhookPayloadProperties.DataProperties;

[JsonConverter(typeof(Client::ModelConverter<Refund>))]
public sealed record class Refund : Client::ModelBase, Client::IFromRaw<Refund>
{
    /// <summary>
    /// The unique identifier of the business issuing the refund.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The timestamp of when the refund was created in UTC.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Payments::CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<Payments::CustomerLimitedDetails>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get
        {
            if (!this.Properties.TryGetValue("is_partial", out JsonElement element))
                throw new ArgumentOutOfRangeException("is_partial", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["is_partial"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the refund.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("payment_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("payment_id");
        }
        set { this.Properties["payment_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get
        {
            if (!this.Properties.TryGetValue("refund_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("refund_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("refund_id");
        }
        set { this.Properties["refund_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Refunds::RefundStatus Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<Refunds::RefundStatus>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public Misc::Currency? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Misc::Currency?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public required IntersectionMember1Properties::PayloadType PayloadType
    {
        get
        {
            if (!this.Properties.TryGetValue("payload_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("payload_type", "Missing required argument");

            return JsonSerializer.Deserialize<IntersectionMember1Properties::PayloadType>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payload_type");
        }
        set { this.Properties["payload_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public Refunds::Refund toRefund()
    {
        return new()
        {
            BusinessID = BusinessID,
            CreatedAt = CreatedAt,
            Customer = Customer,
            IsPartial = IsPartial,
            PaymentID = PaymentID,
            RefundID = RefundID,
            Status = Status,
            Amount = Amount,
            Currency = Currency,
            Reason = Reason,
        };
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Customer.Validate();
        _ = this.IsPartial;
        _ = this.PaymentID;
        _ = this.RefundID;
        this.Status.Validate();
        _ = this.Amount;
        this.Currency?.Validate();
        _ = this.Reason;
        this.PayloadType.Validate();
    }

    public Refund() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Refund(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Refund FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
