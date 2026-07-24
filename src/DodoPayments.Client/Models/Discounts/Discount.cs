using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Discounts;

[JsonConverter(typeof(JsonModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : JsonModel
{
    /// <summary>
    /// The discount amount in **basis points** (e.g., 540 =&gt; 5.4%).
    /// </summary>
    public required int Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The business this discount belongs to.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    /// <summary>
    /// The discount code (up to 16 chars).
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Timestamp when the discount is created
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
    /// Who may redeem this discount code.
    /// </summary>
    public required ApiEnum<string, DiscountCustomerEligibility> CustomerEligibility
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DiscountCustomerEligibility>>(
                "customer_eligibility"
            );
        }
        init { this._rawData.Set("customer_eligibility", value); }
    }

    /// <summary>
    /// The unique discount ID
    /// </summary>
    public required string DiscountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("discount_id");
        }
        init { this._rawData.Set("discount_id", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Values can be string, integer, number, or boolean.
    /// </summary>
    public required IReadOnlyDictionary<string, MetadataItem> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, MetadataItem>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, MetadataItem>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether this discount should be preserved when a subscription changes plans.
    /// Default: false (discount is removed on plan change)
    /// </summary>
    public required bool PreserveOnPlanChange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("preserve_on_plan_change");
        }
        init { this._rawData.Set("preserve_on_plan_change", value); }
    }

    /// <summary>
    /// List of product IDs to which this discount is restricted.
    /// </summary>
    public required IReadOnlyList<string> RestrictedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("restricted_to");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "restricted_to",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("times_used");
        }
        init { this._rawData.Set("times_used", value); }
    }

    /// <summary>
    /// The type of discount (`percentage` or `flat`).
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DiscountType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Per-currency options (flat deduction / percentage cap + minimum subtotal).
    /// Empty for discounts without any configured currency options.
    /// </summary>
    public IReadOnlyList<DiscountCurrencyOption>? CurrencyOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DiscountCurrencyOption>>(
                "currency_options"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DiscountCurrencyOption>?>(
                "currency_options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Name for the Discount
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Maximum number of times a single customer may redeem this discount, if any.
    /// </summary>
    public int? PerCustomerUsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("per_customer_usage_limit");
        }
        init { this._rawData.Set("per_customer_usage_limit", value); }
    }

    /// <summary>
    /// Optional date/time before which the discount is not yet active. NULL = active immediately.
    /// </summary>
    public DateTimeOffset? StartsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("starts_at");
        }
        init { this._rawData.Set("starts_at", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("subscription_cycles");
        }
        init { this._rawData.Set("subscription_cycles", value); }
    }

    /// <summary>
    /// Usage limit for this discount, if any.
    /// </summary>
    public int? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("usage_limit");
        }
        init { this._rawData.Set("usage_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BusinessID;
        _ = this.Code;
        _ = this.CreatedAt;
        this.CustomerEligibility.Validate();
        _ = this.DiscountID;
        foreach (var item in this.Metadata.Values)
        {
            item.Validate();
        }
        _ = this.PreserveOnPlanChange;
        _ = this.RestrictedTo;
        _ = this.TimesUsed;
        this.Type.Validate();
        foreach (var item in this.CurrencyOptions ?? [])
        {
            item.Validate();
        }
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.PerCustomerUsageLimit;
        _ = this.StartsAt;
        _ = this.SubscriptionCycles;
        _ = this.UsageLimit;
    }

    public Discount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Discount(Discount discount)
        : base(discount) { }
#pragma warning restore CS8618

    public Discount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountFromRaw.FromRawUnchecked"/>
    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountFromRaw : IFromRawJson<Discount>
{
    /// <inheritdoc/>
    public Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Discount.FromRawUnchecked(rawData);
}

/// <summary>
/// Who may redeem this discount code.
/// </summary>
[JsonConverter(typeof(DiscountCustomerEligibilityConverter))]
public enum DiscountCustomerEligibility
{
    Any,
    FirstTime,
    Existing,
    Specific,
}

sealed class DiscountCustomerEligibilityConverter : JsonConverter<DiscountCustomerEligibility>
{
    public override DiscountCustomerEligibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "any" => DiscountCustomerEligibility.Any,
            "first_time" => DiscountCustomerEligibility.FirstTime,
            "existing" => DiscountCustomerEligibility.Existing,
            "specific" => DiscountCustomerEligibility.Specific,
            _ => (DiscountCustomerEligibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountCustomerEligibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountCustomerEligibility.Any => "any",
                DiscountCustomerEligibility.FirstTime => "first_time",
                DiscountCustomerEligibility.Existing => "existing",
                DiscountCustomerEligibility.Specific => "specific",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A per-currency discount option (response shape). `max_amount_possible` mirrors
/// the DB column of the same name.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DiscountCurrencyOption, DiscountCurrencyOptionFromRaw>))]
public sealed record class DiscountCurrencyOption : JsonModel
{
    /// <summary>
    /// The currency this option applies to.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Whether this is the default row FX conversions pivot from.
    /// </summary>
    public required bool IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_default");
        }
        init { this._rawData.Set("is_default", value); }
    }

    /// <summary>
    /// Eligible-cart threshold in this currency's subunits (0 = no minimum).
    /// </summary>
    public required int MinimumSubtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("minimum_subtotal");
        }
        init { this._rawData.Set("minimum_subtotal", value); }
    }

    /// <summary>
    /// The most this code discounts in this currency's subunits (flat deduction or
    /// percentage cap).
    /// </summary>
    public int? MaxAmountPossible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_amount_possible");
        }
        init { this._rawData.Set("max_amount_possible", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.IsDefault;
        _ = this.MinimumSubtotal;
        _ = this.MaxAmountPossible;
    }

    public DiscountCurrencyOption() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountCurrencyOption(DiscountCurrencyOption discountCurrencyOption)
        : base(discountCurrencyOption) { }
#pragma warning restore CS8618

    public DiscountCurrencyOption(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountCurrencyOption(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountCurrencyOptionFromRaw.FromRawUnchecked"/>
    public static DiscountCurrencyOption FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountCurrencyOptionFromRaw : IFromRawJson<DiscountCurrencyOption>
{
    /// <inheritdoc/>
    public DiscountCurrencyOption FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DiscountCurrencyOption.FromRawUnchecked(rawData);
}
