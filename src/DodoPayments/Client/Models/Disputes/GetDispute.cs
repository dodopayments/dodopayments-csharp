using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Payments;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Disputes;

[JsonConverter(typeof(Client::ModelConverter<GetDispute>))]
public sealed record class GetDispute : Client::ModelBase, Client::IFromRaw<GetDispute>
{
    /// <summary>
    /// The amount involved in the dispute, represented as a string to accommodate precision.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the business involved in the dispute.
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
    /// The timestamp of when the dispute was created, in UTC.
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

    /// <summary>
    /// The currency of the disputed amount, represented as an ISO 4217 currency code.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The customer who filed the dispute
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the dispute.
    /// </summary>
    public required string DisputeID
    {
        get
        {
            if (!this.Properties.TryGetValue("dispute_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("dispute_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("dispute_id");
        }
        set { this.Properties["dispute_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The current stage of the dispute process.
    /// </summary>
    public required DisputeStage DisputeStage
    {
        get
        {
            if (!this.Properties.TryGetValue("dispute_stage", out JsonElement element))
                throw new ArgumentOutOfRangeException("dispute_stage", "Missing required argument");

            return JsonSerializer.Deserialize<DisputeStage>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("dispute_stage");
        }
        set { this.Properties["dispute_stage"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The current status of the dispute.
    /// </summary>
    public required DisputeStatus DisputeStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("dispute_status", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "dispute_status",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DisputeStatus>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("dispute_status");
        }
        set { this.Properties["dispute_status"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the dispute.
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
    /// Reason for the dispute
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

    /// <summary>
    /// Remarks
    /// </summary>
    public string? Remarks
    {
        get
        {
            if (!this.Properties.TryGetValue("remarks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["remarks"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Currency;
        this.Customer.Validate();
        _ = this.DisputeID;
        this.DisputeStage.Validate();
        this.DisputeStatus.Validate();
        _ = this.PaymentID;
        _ = this.Reason;
        _ = this.Remarks;
    }

    public GetDispute() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GetDispute(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GetDispute FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
