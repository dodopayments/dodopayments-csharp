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
/// PATCH /discounts/{discount_id}
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DiscountUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DiscountID { get; init; }

    /// <summary>
    /// If present, update the discount amount in **basis points** (e.g., `540` =
    /// `5.4%`, `10000` = `100%`).
    ///
    /// <para>Must be at least 1 if provided.</para>
    /// </summary>
    public int? Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// If present, update the discount code (uppercase).
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
    /// If present, fully replaces the discount's currency options (replace-set semantics,
    /// like `restricted_to`). Send an empty array to clear them.
    /// </summary>
    public IReadOnlyList<DiscountUpdateParamsCurrencyOption>? CurrencyOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<DiscountUpdateParamsCurrencyOption>
            >("currency_options");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<DiscountUpdateParamsCurrencyOption>?>(
                "currency_options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If present, update who may redeem this discount. Plain field (not double-option):
    /// the DB column is `NOT NULL`, so it can never be cleared back to unset, only
    /// changed to another `CustomerEligibility` value.
    /// </summary>
    public ApiEnum<string, DiscountUpdateParamsCustomerEligibility>? CustomerEligibility
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, DiscountUpdateParamsCustomerEligibility>
            >("customer_eligibility");
        }
        init { this._rawBodyData.Set("customer_eligibility", value); }
    }

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
    /// If present, update the per-customer usage limit (double-option: send `null`
    /// to clear it back to unlimited). Must be `&lt;= usage_limit` (the value in
    /// effect after this patch) when both are set.
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
    /// If not provided, the existing value is kept.
    /// </summary>
    public bool? PreserveOnPlanChange
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("preserve_on_plan_change");
        }
        init { this._rawBodyData.Set("preserve_on_plan_change", value); }
    }

    /// <summary>
    /// If present, replaces all restricted product IDs with this new set. To remove
    /// all restrictions, send empty array
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
    /// If present, update `starts_at` (double-option: send `null` to clear it).
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
    /// If present, update the discount type (`percentage` or `flat`).
    /// </summary>
    public ApiEnum<string, DiscountType>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DiscountType>>("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    public int? UsageLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("usage_limit");
        }
        init { this._rawBodyData.Set("usage_limit", value); }
    }

    public DiscountUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountUpdateParams(DiscountUpdateParams discountUpdateParams)
        : base(discountUpdateParams)
    {
        this.DiscountID = discountUpdateParams.DiscountID;

        this._rawBodyData = new(discountUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DiscountUpdateParams(
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
    DiscountUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string discountID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DiscountID = discountID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DiscountUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string discountID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            discountID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DiscountID"] = JsonSerializer.SerializeToElement(this.DiscountID),
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

    public virtual bool Equals(DiscountUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DiscountID?.Equals(other.DiscountID) ?? other.DiscountID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/discounts/{0}", this.DiscountID)
        )
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
[JsonConverter(
    typeof(JsonModelConverter<
        DiscountUpdateParamsCurrencyOption,
        DiscountUpdateParamsCurrencyOptionFromRaw
    >)
)]
public sealed record class DiscountUpdateParamsCurrencyOption : JsonModel
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

    public DiscountUpdateParamsCurrencyOption() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountUpdateParamsCurrencyOption(
        DiscountUpdateParamsCurrencyOption discountUpdateParamsCurrencyOption
    )
        : base(discountUpdateParamsCurrencyOption) { }
#pragma warning restore CS8618

    public DiscountUpdateParamsCurrencyOption(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountUpdateParamsCurrencyOption(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountUpdateParamsCurrencyOptionFromRaw.FromRawUnchecked"/>
    public static DiscountUpdateParamsCurrencyOption FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscountUpdateParamsCurrencyOption(ApiEnum<string, Currency> currency)
        : this()
    {
        this.Currency = currency;
    }
}

class DiscountUpdateParamsCurrencyOptionFromRaw : IFromRawJson<DiscountUpdateParamsCurrencyOption>
{
    /// <inheritdoc/>
    public DiscountUpdateParamsCurrencyOption FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DiscountUpdateParamsCurrencyOption.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, update who may redeem this discount. Plain field (not double-option):
/// the DB column is `NOT NULL`, so it can never be cleared back to unset, only changed
/// to another `CustomerEligibility` value.
/// </summary>
[JsonConverter(typeof(DiscountUpdateParamsCustomerEligibilityConverter))]
public enum DiscountUpdateParamsCustomerEligibility
{
    Any,
    FirstTime,
    Existing,
    Specific,
}

sealed class DiscountUpdateParamsCustomerEligibilityConverter
    : JsonConverter<DiscountUpdateParamsCustomerEligibility>
{
    public override DiscountUpdateParamsCustomerEligibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "any" => DiscountUpdateParamsCustomerEligibility.Any,
            "first_time" => DiscountUpdateParamsCustomerEligibility.FirstTime,
            "existing" => DiscountUpdateParamsCustomerEligibility.Existing,
            "specific" => DiscountUpdateParamsCustomerEligibility.Specific,
            _ => (DiscountUpdateParamsCustomerEligibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountUpdateParamsCustomerEligibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountUpdateParamsCustomerEligibility.Any => "any",
                DiscountUpdateParamsCustomerEligibility.FirstTime => "first_time",
                DiscountUpdateParamsCustomerEligibility.Existing => "existing",
                DiscountUpdateParamsCustomerEligibility.Specific => "specific",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
