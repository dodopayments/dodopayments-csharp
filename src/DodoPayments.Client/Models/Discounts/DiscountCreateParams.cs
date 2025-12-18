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
/// POST /discounts If `code` is omitted or empty, a random 16-char uppercase code
/// is generated.
/// </summary>
public sealed record class DiscountCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The discount amount.
    ///
    /// <para>- If `discount_type` is **not** `percentage`, `amount` is in **USD
    /// cents**. For example, `100` means `$1.00`.   Only USD is allowed. - If `discount_type`
    /// **is** `percentage`, `amount` is in **basis points**. For example, `540` means `5.4%`.</para>
    ///
    /// <para>Must be at least 1.</para>
    /// </summary>
    public required int Amount
    {
        get { return JsonModel.GetNotNullStruct<int>(this.RawBodyData, "amount"); }
        init { JsonModel.Set(this._rawBodyData, "amount", value); }
    }

    /// <summary>
    /// The discount type (e.g. `percentage`, `flat`, or `flat_per_unit`).
    /// </summary>
    public required ApiEnum<string, DiscountType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, DiscountType>>(
                this.RawBodyData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "type", value); }
    }

    /// <summary>
    /// Optionally supply a code (will be uppercased). - Must be at least 3 characters
    /// if provided. - If omitted, a random 16-character code is generated.
    /// </summary>
    public string? Code
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "code"); }
        init { JsonModel.Set(this._rawBodyData, "code", value); }
    }

    /// <summary>
    /// When the discount expires, if ever.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawBodyData, "expires_at"); }
        init { JsonModel.Set(this._rawBodyData, "expires_at", value); }
    }

    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { JsonModel.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// List of product IDs to restrict usage (if any).
    /// </summary>
    public IReadOnlyList<string>? RestrictedTo
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "restricted_to"); }
        init { JsonModel.Set(this._rawBodyData, "restricted_to", value); }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for. If not
    /// provided, the discount will be applied indefinitely to all recurring payments
    /// related to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawBodyData, "subscription_cycles"); }
        init { JsonModel.Set(this._rawBodyData, "subscription_cycles", value); }
    }

    /// <summary>
    /// How many times this discount can be used (if any). Must be >= 1 if provided.
    /// </summary>
    public int? UsageLimit
    {
        get { return JsonModel.GetNullableStruct<int>(this.RawBodyData, "usage_limit"); }
        init { JsonModel.Set(this._rawBodyData, "usage_limit", value); }
    }

    public DiscountCreateParams() { }

    public DiscountCreateParams(DiscountCreateParams discountCreateParams)
        : base(discountCreateParams)
    {
        this._rawBodyData = [.. discountCreateParams._rawBodyData];
    }

    public DiscountCreateParams(
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
    DiscountCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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
            JsonSerializer.Serialize(this.RawBodyData),
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
}
