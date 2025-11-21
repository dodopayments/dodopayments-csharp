using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Discounts;

[JsonConverter(typeof(ModelConverter<Discount>))]
public sealed record class Discount : ModelBase, IFromRaw<Discount>
{
    /// <summary>
    /// The discount amount.
    ///
    /// <para>- If `discount_type` is `percentage`, this is in **basis points**
    ///  (e.g., 540 => 5.4%). - Otherwise, this is **USD cents** (e.g., 100 => `$1.00`).</para>
    /// </summary>
    public required int Amount
    {
        get
        {
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The business this discount belongs to.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentOutOfRangeException("business_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The discount code (up to 16 chars).
    /// </summary>
    public required string Code
    {
        get
        {
            if (!this._rawData.TryGetValue("code", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'code' cannot be null",
                    new ArgumentOutOfRangeException("code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'code' cannot be null",
                    new ArgumentNullException("code")
                );
        }
        init
        {
            this._rawData["code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the discount is created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique discount ID
    /// </summary>
    public required string DiscountID
    {
        get
        {
            if (!this._rawData.TryGetValue("discount_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'discount_id' cannot be null",
                    new ArgumentOutOfRangeException("discount_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'discount_id' cannot be null",
                    new ArgumentNullException("discount_id")
                );
        }
        init
        {
            this._rawData["discount_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of product IDs to which this discount is restricted.
    /// </summary>
    public required List<string> RestrictedTo
    {
        get
        {
            if (!this._rawData.TryGetValue("restricted_to", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'restricted_to' cannot be null",
                    new ArgumentOutOfRangeException("restricted_to", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'restricted_to' cannot be null",
                    new ArgumentNullException("restricted_to")
                );
        }
        init
        {
            this._rawData["restricted_to"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// How many times this discount has been used.
    /// </summary>
    public required int TimesUsed
    {
        get
        {
            if (!this._rawData.TryGetValue("times_used", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'times_used' cannot be null",
                    new ArgumentOutOfRangeException("times_used", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["times_used"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of discount, e.g. `percentage`, `flat`, or `flat_per_unit`.
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional date/time after which discount is expired.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            if (!this._rawData.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name for the Discount
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for. If not
    /// provided, the discount will be applied indefinitely to all recurring payments
    /// related to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get
        {
            if (!this._rawData.TryGetValue("subscription_cycles", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["subscription_cycles"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Usage limit for this discount, if any.
    /// </summary>
    public int? UsageLimit
    {
        get
        {
            if (!this._rawData.TryGetValue("usage_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["usage_limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.Code;
        _ = this.CreatedAt;
        _ = this.DiscountID;
        _ = this.RestrictedTo;
        _ = this.TimesUsed;
        this.Type.Validate();
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.SubscriptionCycles;
        _ = this.UsageLimit;
    }

    public Discount() { }

    public Discount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
