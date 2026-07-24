using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// POST /discounts If `code` is omitted or empty, a random 16-char uppercase code
/// is generated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DiscountCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The discount amount in **basis points** (e.g. `540` means `5.4%`, `10000`
    /// means `100%`).
    ///
    /// <para>Must be at least 1.</para>
    /// </summary>
    public required int Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<int>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// The discount type: `percentage` or `flat` (`flat_per_unit` stays blocked).
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, DiscountType>>("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Optionally supply a code (will be uppercased). - Must be at least 3 characters
    /// if provided. - If omitted, a random 16-character code is generated.
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("code");
        }
        init { this._rawBodyData.Set("code", value); }
    }

    /// <summary>
    /// Per-currency options (flat deduction / percentage cap + minimum subtotal).
    /// Required for `flat` codes (must include a resolvable default); optional per-currency
    /// caps for `percentage` codes. Per-row invariants are checked in `normalize_currency_options`,
    /// not via `#[validate(nested)]`.
    /// </summary>
    public IReadOnlyList<CurrencyOption>? CurrencyOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<CurrencyOption>>(
                "currency_options"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<CurrencyOption>?>(
                "currency_options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Who may redeem this discount code. Defaults to `any` (unrestricted). `specific`
    /// starts with zero attached customers (fails closed) until customers are attached
    /// via `POST /discounts/{id}/customers`.
    /// </summary>
    public ApiEnum<string, CustomerEligibility>? CustomerEligibility
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CustomerEligibility>>(
                "customer_eligibility"
            );
        }
        init { this._rawBodyData.Set("customer_eligibility", value); }
    }

    /// <summary>
    /// When the discount expires, if ever.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawBodyData.Set("expires_at", value); }
    }

    /// <summary>
    /// Additional metadata for the discount
    /// </summary>
    public IReadOnlyDictionary<string, MetadataItem>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, MetadataItem>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, MetadataItem>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Maximum number of times a single customer may redeem this discount. Must
    /// be `&lt;= usage_limit` when both are set.
    /// </summary>
    public int? PerCustomerUsageLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("per_customer_usage_limit");
        }
        init { this._rawBodyData.Set("per_customer_usage_limit", value); }
    }

    /// <summary>
    /// Whether this discount should be preserved when a subscription changes plans.
    /// Default: false (discount is removed on plan change)
    /// </summary>
    public bool? PreserveOnPlanChange
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("preserve_on_plan_change");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("preserve_on_plan_change", value);
        }
    }

    /// <summary>
    /// List of product IDs to restrict usage (if any).
    /// </summary>
    public IReadOnlyList<string>? RestrictedTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("restricted_to");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "restricted_to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When the discount becomes active, if scheduled for the future. NULL = active
    /// immediately. Must be strictly before `expires_at` when both are set.
    /// </summary>
    public DateTimeOffset? StartsAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("starts_at");
        }
        init { this._rawBodyData.Set("starts_at", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("subscription_cycles");
        }
        init { this._rawBodyData.Set("subscription_cycles", value); }
    }

    /// <summary>
    /// How many times this discount can be used (if any). Must be &gt;= 1 if provided.
    /// </summary>
    public int? UsageLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("usage_limit");
        }
        init { this._rawBodyData.Set("usage_limit", value); }
    }

    public DiscountCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountCreateParams(DiscountCreateParams discountCreateParams)
        : base(discountCreateParams)
    {
        this._rawBodyData = new(discountCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DiscountCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DiscountCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DiscountCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/discounts")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// A per-currency discount option (request shape).
///
/// <para>`max_amount_possible` is the most this code discounts in this currency
/// — the flat deduction for `flat` codes, or the max-discount cap for `percentage`
/// codes. Maps to the DB column of the same name.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CurrencyOption, CurrencyOptionFromRaw>))]
public sealed record class CurrencyOption : JsonModel
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
    /// Whether this row is the default to convert from for unconfigured currencies.
    /// At most one row per discount may be default.
    /// </summary>
    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_default");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_default", value);
        }
    }

    /// <summary>
    /// The most this code discounts in this currency's subunits. For `flat` codes
    /// this is the deduction; for `percentage` codes it is the max-discount cap.
    /// Must be &gt; 0 if provided.
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

    /// <summary>
    /// Eligible-cart threshold in this currency's subunits (0 = no minimum).
    /// </summary>
    public int? MinimumSubtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("minimum_subtotal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minimum_subtotal", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.IsDefault;
        _ = this.MaxAmountPossible;
        _ = this.MinimumSubtotal;
    }

    public CurrencyOption() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyOption(CurrencyOption currencyOption)
        : base(currencyOption) { }
#pragma warning restore CS8618

    public CurrencyOption(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyOption(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyOptionFromRaw.FromRawUnchecked"/>
    public static CurrencyOption FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CurrencyOption(ApiEnum<string, Currency> currency)
        : this()
    {
        this.Currency = currency;
    }
}

class CurrencyOptionFromRaw : IFromRawJson<CurrencyOption>
{
    /// <inheritdoc/>
    public CurrencyOption FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CurrencyOption.FromRawUnchecked(rawData);
}

/// <summary>
/// Who may redeem this discount code. Defaults to `any` (unrestricted). `specific`
/// starts with zero attached customers (fails closed) until customers are attached
/// via `POST /discounts/{id}/customers`.
/// </summary>
[JsonConverter(typeof(CustomerEligibilityConverter))]
public enum CustomerEligibility
{
    Any,
    FirstTime,
    Existing,
    Specific,
}

sealed class CustomerEligibilityConverter : JsonConverter<CustomerEligibility>
{
    public override CustomerEligibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "any" => CustomerEligibility.Any,
            "first_time" => CustomerEligibility.FirstTime,
            "existing" => CustomerEligibility.Existing,
            "specific" => CustomerEligibility.Specific,
            _ => (CustomerEligibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerEligibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerEligibility.Any => "any",
                CustomerEligibility.FirstTime => "first_time",
                CustomerEligibility.Existing => "existing",
                CustomerEligibility.Specific => "specific",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
