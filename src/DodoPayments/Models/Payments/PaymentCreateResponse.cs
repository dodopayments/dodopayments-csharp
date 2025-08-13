using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Payments;

[JsonConverter(typeof(DodoPayments::ModelConverter<PaymentCreateResponse>))]
public sealed record class PaymentCreateResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<PaymentCreateResponse>
{
    /// <summary>
    /// Client secret used to load Dodo checkout SDK NOTE : Dodo checkout SDK will
    /// be coming soon
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            if (!this.Properties.TryGetValue("client_secret", out JsonElement element))
                throw new ArgumentOutOfRangeException("client_secret", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("client_secret");
        }
        set { this.Properties["client_secret"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Limited details about the customer making the payment
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional metadata associated with the payment
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new ArgumentOutOfRangeException("metadata", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Unique identifier for the payment
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("payment_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payment_id");
        }
        set { this.Properties["payment_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total amount of the payment in smallest currency unit (e.g. cents)
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("total_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("total_amount", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["total_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["discount_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Expiry timestamp of the payment link
    /// </summary>
    public DateTime? ExpiresOn
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_on", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["expires_on"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional URL to a hosted payment page
    /// </summary>
    public string? PaymentLink
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_link", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["payment_link"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional list of products included in the payment
    /// </summary>
    public List<OneTimeProductCartItem>? ProductCart
    {
        get
        {
            if (!this.Properties.TryGetValue("product_cart", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<OneTimeProductCartItem>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["product_cart"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ClientSecret;
        this.Customer.Validate();
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        _ = this.PaymentID;
        _ = this.TotalAmount;
        _ = this.DiscountID;
        _ = this.ExpiresOn;
        _ = this.PaymentLink;
        foreach (var item in this.ProductCart ?? [])
        {
            item.Validate();
        }
    }

    public PaymentCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentCreateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PaymentCreateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
