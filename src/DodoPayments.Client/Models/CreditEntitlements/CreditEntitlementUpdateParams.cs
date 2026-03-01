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
/// Allows partial updates to a credit entitlement's configuration. Only the fields
/// provided in the request body will be updated; all other fields remain unchanged.
/// This endpoint supports nullable fields using the double option pattern.
///
/// <para># Authentication Requires an API key with `Editor` role.</para>
///
/// <para># Path Parameters - `id` - The unique identifier of the credit entitlement
/// to update (format: `cde_...`)</para>
///
/// <para># Request Body (all fields optional) - `name` - Human-readable name of
/// the credit entitlement (1-255 characters) - `description` - Optional description
/// (max 1000 characters) - `unit` - Unit of measurement for the credit (1-50 characters)</para>
///
/// <para>Note: `precision` cannot be modified after creation as it would invalidate
/// existing grants. - `expires_after_days` - Number of days after which credits
/// expire (use `null` to remove expiration) - `rollover_enabled` - Whether unused
/// credits can rollover to the next period - `rollover_percentage` - Percentage
/// of unused credits that rollover (0-100, nullable) - `rollover_timeframe_count`
/// - Count of timeframe periods for rollover limit (nullable) - `rollover_timeframe_interval`
/// - Interval type (day, week, month, year, nullable) - `max_rollover_count` - Maximum
/// number of times credits can be rolled over (nullable) - `overage_enabled` - Whether
/// overage charges apply when credits run out - `overage_limit` - Maximum overage
/// units allowed (nullable) - `currency` - Currency for pricing (nullable) - `price_per_unit`
/// - Price per credit unit (decimal, nullable)</para>
///
/// <para># Responses - `200 OK` - Credit entitlement updated successfully - `404
/// Not Found` - Credit entitlement does not exist or does not belong to the authenticated
/// business - `422 Unprocessable Entity` - Invalid request parameters or validation
/// failure - `500 Internal Server Error` - Database or server error</para>
///
/// <para># Business Logic - Only non-deleted credit entitlements can be updated -
/// Fields set to `null` explicitly will clear the database value (using double option
/// pattern) - The `updated_at` timestamp is automatically updated on successful modification
/// - Changes take effect immediately but do not retroactively affect existing credit
/// grants - The merged state is validated: currency required with price, rollover
/// timeframe fields together, price required for overage</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditEntitlementUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Currency for pricing
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
    /// Number of days after which credits expire
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
    /// Name of the credit entitlement
    /// </summary>
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
    /// Controls how overage is handled at billing cycle end.
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
    /// Whether overage charges are enabled when credits run out
    /// </summary>
    public bool? OverageEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("overage_enabled");
        }
        init { this._rawBodyData.Set("overage_enabled", value); }
    }

    /// <summary>
    /// Maximum overage units allowed
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
    /// Whether rollover is enabled for unused credits
    /// </summary>
    public bool? RolloverEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("rollover_enabled");
        }
        init { this._rawBodyData.Set("rollover_enabled", value); }
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

    /// <summary>
    /// Unit of measurement for the credit (e.g., "API Calls", "Tokens", "Credits")
    /// </summary>
    public string? Unit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("unit");
        }
        init { this._rawBodyData.Set("unit", value); }
    }

    public CreditEntitlementUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlementUpdateParams(
        CreditEntitlementUpdateParams creditEntitlementUpdateParams
    )
        : base(creditEntitlementUpdateParams)
    {
        this.ID = creditEntitlementUpdateParams.ID;

        this._rawBodyData = new(creditEntitlementUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CreditEntitlementUpdateParams(
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
    CreditEntitlementUpdateParams(
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
    public static CreditEntitlementUpdateParams FromRawUnchecked(
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
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(CreditEntitlementUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/credit-entitlements/{0}", this.ID)
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
