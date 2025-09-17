using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using Misc = Dodopayments.Models.Misc;
using Refunds = Dodopayments.Models.Refunds;

namespace Dodopayments.Models.Refunds.RefundListPageResponseProperties;

[JsonConverter(typeof(Dodopayments::ModelConverter<Item>))]
public sealed record class Item : Dodopayments::ModelBase, Dodopayments::IFromRaw<Item>
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

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("business_id");
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
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<bool>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
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

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payment_id");
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

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("refund_id");
        }
        set { this.Properties["refund_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The current status of the refund.
    /// </summary>
    public required Refunds::RefundStatus Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<Refunds::RefundStatus>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
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

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The currency of the refund, represented as an ISO 4217 currency code.
    /// </summary>
    public Misc::Currency? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Misc::Currency?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
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
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsPartial;
        _ = this.PaymentID;
        _ = this.RefundID;
        this.Status.Validate();
        _ = this.Amount;
        this.Currency?.Validate();
        _ = this.Reason;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
