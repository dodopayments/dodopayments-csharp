using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// PATCH /discounts/{discount_id}
/// </summary>
public sealed record class DiscountUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DiscountID { get; init; }

    /// <summary>
    /// If present, update the discount amount: - If `discount_type` is `percentage`,
    /// this represents **basis points** (e.g., `540` = `5.4%`). - Otherwise, this
    /// represents **USD cents** (e.g., `100` = `$1.00`).
    ///
    /// <para>Must be at least 1 if provided.</para>
    /// </summary>
    public int? Amount
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawBodyData, "amount"); }
        init { ModelBase.Set(this._rawBodyData, "amount", value); }
    }

    /// <summary>
    /// If present, update the discount code (uppercase).
    /// </summary>
    public string? Code
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "code"); }
        init { ModelBase.Set(this._rawBodyData, "code", value); }
    }

    public DateTimeOffset? ExpiresAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawBodyData, "expires_at"); }
        init { ModelBase.Set(this._rawBodyData, "expires_at", value); }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// If present, replaces all restricted product IDs with this new set. To remove
    /// all restrictions, send empty array
    /// </summary>
    public IReadOnlyList<string>? RestrictedTo
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "restricted_to"); }
        init { ModelBase.Set(this._rawBodyData, "restricted_to", value); }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for. If not
    /// provided, the discount will be applied indefinitely to all recurring payments
    /// related to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawBodyData, "subscription_cycles"); }
        init { ModelBase.Set(this._rawBodyData, "subscription_cycles", value); }
    }

    /// <summary>
    /// If present, update the discount type.
    /// </summary>
    public ApiEnum<string, DiscountType>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, DiscountType>>(
                this.RawBodyData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "type", value); }
    }

    public int? UsageLimit
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawBodyData, "usage_limit"); }
        init { ModelBase.Set(this._rawBodyData, "usage_limit", value); }
    }

    public DiscountUpdateParams() { }

    public DiscountUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static DiscountUpdateParams FromRawUnchecked(
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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
