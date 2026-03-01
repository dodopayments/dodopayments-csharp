using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.CreditEntitlements;

/// <summary>
/// Credit entitlements define reusable credit templates that can be attached to products.
/// Each entitlement defines how credits behave in terms of expiration, rollover,
/// and overage.
///
/// <para># Authentication Requires an API key with `Editor` role.</para>
///
/// <para># Request Body - `name` - Human-readable name of the credit entitlement
/// (1-255 characters, required) - `description` - Optional description (max 1000
/// characters) - `precision` - Decimal precision for credit amounts (0-10 decimal
/// places) - `unit` - Unit of measurement for the credit (e.g., "API Calls", "Tokens",
/// "Credits") - `expires_after_days` - Number of days after which credits expire
/// (optional) - `rollover_enabled` - Whether unused credits can rollover to the next
/// period - `rollover_percentage` - Percentage of unused credits that rollover (0-100)
/// - `rollover_timeframe_count` - Count of timeframe periods for rollover limit -
/// `rollover_timeframe_interval` - Interval type (day, week, month, year) - `max_rollover_count`
/// - Maximum number of times credits can be rolled over - `overage_enabled` - Whether
/// overage charges apply when credits run out (requires price_per_unit) - `overage_limit`
/// - Maximum overage units allowed (optional) - `currency` - Currency for pricing
/// (required if price_per_unit is set) - `price_per_unit` - Price per credit unit (decimal)</para>
///
/// <para># Responses - `201 Created` - Credit entitlement created successfully,
/// returns the full entitlement object - `422 Unprocessable Entity` - Invalid request
/// parameters or validation failure - `500 Internal Server Error` - Database or
/// server error</para>
///
/// <para># Business Logic - A unique ID with prefix `cde_` is automatically generated
/// for the entitlement - Created and updated timestamps are automatically set - Currency
/// is required when price_per_unit is set - price_per_unit is required when overage_enabled
/// is true - rollover_timeframe_count and rollover_timeframe_interval must both
/// be set or both be null</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditEntitlementCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the credit entitlement
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Whether overage charges are enabled when credits run out
    /// </summary>
    public required bool OverageEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>("overage_enabled");
        }
        init { this._rawBodyData.Set("overage_enabled", value); }
    }

    /// <summary>
    /// Precision for credit amounts (0-10 decimal places)
    /// </summary>
    public required int Precision
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<int>("precision");
        }
        init { this._rawBodyData.Set("precision", value); }
    }

    /// <summary>
    /// Whether rollover is enabled for unused credits
    /// </summary>
    public required bool RolloverEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>("rollover_enabled");
        }
        init { this._rawBodyData.Set("rollover_enabled", value); }
    }

    /// <summary>
    /// Unit of measurement for the credit (e.g., "API Calls", "Tokens", "Credits")
    /// </summary>
    public required string Unit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("unit");
        }
        init { this._rawBodyData.Set("unit", value); }
    }

    /// <summary>
    /// Currency for pricing (required if price_per_unit is set)
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    /// <summary>
    /// Optional description of the credit entitlement
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Number of days after which credits expire (optional)
    /// </summary>
    public int? ExpiresAfterDays
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("expires_after_days");
        }
        init { this._rawBodyData.Set("expires_after_days", value); }
    }

    /// <summary>
    /// Maximum number of times credits can be rolled over
    /// </summary>
    public int? MaxRolloverCount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("max_rollover_count");
        }
        init { this._rawBodyData.Set("max_rollover_count", value); }
    }

    /// <summary>
    /// Controls how overage is handled at billing cycle end. Defaults to forgive_at_reset
    /// if not specified.
    /// </summary>
    public ApiEnum<string, CbbOverageBehavior>? OverageBehavior
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CbbOverageBehavior>>(
                "overage_behavior"
            );
        }
        init { this._rawBodyData.Set("overage_behavior", value); }
    }

    /// <summary>
    /// Maximum overage units allowed (optional)
    /// </summary>
    public long? OverageLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("overage_limit");
        }
        init { this._rawBodyData.Set("overage_limit", value); }
    }

    /// <summary>
    /// Price per credit unit
    /// </summary>
    public string? PricePerUnit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("price_per_unit");
        }
        init { this._rawBodyData.Set("price_per_unit", value); }
    }

    /// <summary>
    /// Percentage of unused credits that can rollover (0-100)
    /// </summary>
    public int? RolloverPercentage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("rollover_percentage");
        }
        init { this._rawBodyData.Set("rollover_percentage", value); }
    }

    /// <summary>
    /// Count of timeframe periods for rollover limit
    /// </summary>
    public int? RolloverTimeframeCount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("rollover_timeframe_count");
        }
        init { this._rawBodyData.Set("rollover_timeframe_count", value); }
    }

    /// <summary>
    /// Interval type for rollover timeframe
    /// </summary>
    public ApiEnum<string, TimeInterval>? RolloverTimeframeInterval
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TimeInterval>>(
                "rollover_timeframe_interval"
            );
        }
        init { this._rawBodyData.Set("rollover_timeframe_interval", value); }
    }

    public CreditEntitlementCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementCreateParams(
        CreditEntitlementCreateParams creditEntitlementCreateParams
    )
        : base(creditEntitlementCreateParams)
    {
        this._rawBodyData = new(creditEntitlementCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CreditEntitlementCreateParams(
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
    CreditEntitlementCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditEntitlementCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CreditEntitlementCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/credit-entitlements")
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
