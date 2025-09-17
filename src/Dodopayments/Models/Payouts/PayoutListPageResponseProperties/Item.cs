using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using ItemProperties = Dodopayments.Models.Payouts.PayoutListPageResponseProperties.ItemProperties;
using Misc = Dodopayments.Models.Misc;

namespace Dodopayments.Models.Payouts.PayoutListPageResponseProperties;

[JsonConverter(typeof(Dodopayments::ModelConverter<Item>))]
public sealed record class Item : Dodopayments::ModelBase, Dodopayments::IFromRaw<Item>
{
    /// <summary>
    /// The total amount of the payout.
    /// </summary>
    public required long Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the business associated with the payout.
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
    /// The total value of chargebacks associated with the payout.
    /// </summary>
    public required long Chargebacks
    {
        get
        {
            if (!this.Properties.TryGetValue("chargebacks", out JsonElement element))
                throw new ArgumentOutOfRangeException("chargebacks", "Missing required argument");

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["chargebacks"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The timestamp when the payout was created, in UTC.
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
    /// The currency of the payout, represented as an ISO 4217 currency code.
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The fee charged for processing the payout.
    /// </summary>
    public required long Fee
    {
        get
        {
            if (!this.Properties.TryGetValue("fee", out JsonElement element))
                throw new ArgumentOutOfRangeException("fee", "Missing required argument");

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["fee"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The payment method used for the payout (e.g., bank transfer, card, etc.).
    /// </summary>
    public required string PaymentMethod
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_method", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "payment_method",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payment_method");
        }
        set { this.Properties["payment_method"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier of the payout.
    /// </summary>
    public required string PayoutID
    {
        get
        {
            if (!this.Properties.TryGetValue("payout_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("payout_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payout_id");
        }
        set { this.Properties["payout_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The total value of refunds associated with the payout.
    /// </summary>
    public required long Refunds
    {
        get
        {
            if (!this.Properties.TryGetValue("refunds", out JsonElement element))
                throw new ArgumentOutOfRangeException("refunds", "Missing required argument");

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["refunds"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The current status of the payout.
    /// </summary>
    public required ItemProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<ItemProperties::Status>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The tax applied to the payout.
    /// </summary>
    public required long Tax
    {
        get
        {
            if (!this.Properties.TryGetValue("tax", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax", "Missing required argument");

            return JsonSerializer.Deserialize<long>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["tax"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The timestamp when the payout was last updated, in UTC.
    /// </summary>
    public required DateTime UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("updated_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["updated_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the payout recipient or purpose.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The URL of the document associated with the payout.
    /// </summary>
    public string? PayoutDocumentURL
    {
        get
        {
            if (!this.Properties.TryGetValue("payout_document_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["payout_document_url"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any additional remarks or notes associated with the payout.
    /// </summary>
    public string? Remarks
    {
        get
        {
            if (!this.Properties.TryGetValue("remarks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["remarks"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.Chargebacks;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Fee;
        _ = this.PaymentMethod;
        _ = this.PayoutID;
        _ = this.Refunds;
        this.Status.Validate();
        _ = this.Tax;
        _ = this.UpdatedAt;
        _ = this.Name;
        _ = this.PayoutDocumentURL;
        _ = this.Remarks;
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
