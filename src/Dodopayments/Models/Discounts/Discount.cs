using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Discounts;

[JsonConverter(typeof(Dodopayments::ModelConverter<Discount>))]
public sealed record class Discount : Dodopayments::ModelBase, Dodopayments::IFromRaw<Discount>
{
    /// <summary>
    /// The discount amount.
    ///
    /// - If `discount_type` is `percentage`, this is in **basis points**   (e.g.,
    /// 540 => 5.4%). - Otherwise, this is **USD cents** (e.g., 100 => `$1.00`).
    /// </summary>
    public required int Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The business this discount belongs to.
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
    /// The discount code (up to 16 chars).
    /// </summary>
    public required string Code
    {
        get
        {
            if (!this.Properties.TryGetValue("code", out JsonElement element))
                throw new ArgumentOutOfRangeException("code", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("code");
        }
        set { this.Properties["code"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Timestamp when the discount is created
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
    /// The unique discount ID
    /// </summary>
    public required string DiscountID
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("discount_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("discount_id");
        }
        set { this.Properties["discount_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// List of product IDs to which this discount is restricted.
    /// </summary>
    public required List<string> RestrictedTo
    {
        get
        {
            if (!this.Properties.TryGetValue("restricted_to", out JsonElement element))
                throw new ArgumentOutOfRangeException("restricted_to", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("restricted_to");
        }
        set { this.Properties["restricted_to"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// How many times this discount has been used.
    /// </summary>
    public required int TimesUsed
    {
        get
        {
            if (!this.Properties.TryGetValue("times_used", out JsonElement element))
                throw new ArgumentOutOfRangeException("times_used", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["times_used"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The type of discount, e.g. `percentage`, `flat`, or `flat_per_unit`.
    /// </summary>
    public required DiscountType Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<DiscountType>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional date/time after which discount is expired.
    /// </summary>
    public DateTime? ExpiresAt
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["expires_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Name for the Discount
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
    /// Number of subscription billing cycles this discount is valid for. If not provided,
    /// the discount will be applied indefinitely to all recurring payments related
    /// to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_cycles", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["subscription_cycles"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Usage limit for this discount, if any.
    /// </summary>
    public int? UsageLimit
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["usage_limit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.Code;
        _ = this.CreatedAt;
        _ = this.DiscountID;
        foreach (var item in this.RestrictedTo)
        {
            _ = item;
        }
        _ = this.TimesUsed;
        this.Type.Validate();
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.SubscriptionCycles;
        _ = this.UsageLimit;
    }

    public Discount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Discount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
