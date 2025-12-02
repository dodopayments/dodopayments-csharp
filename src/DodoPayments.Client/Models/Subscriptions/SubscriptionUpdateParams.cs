using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    public BillingAddress? Billing
    {
        get { return ModelBase.GetNullableClass<BillingAddress>(this.RawBodyData, "billing"); }
        init { ModelBase.Set(this._rawBodyData, "billing", value); }
    }

    /// <summary>
    /// When set, the subscription will remain active until the end of billing period
    /// </summary>
    public bool? CancelAtNextBillingDate
    {
        get
        {
            return ModelBase.GetNullableStruct<bool>(
                this.RawBodyData,
                "cancel_at_next_billing_date"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "cancel_at_next_billing_date", value); }
    }

    public string? CustomerName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "customer_name"); }
        init { ModelBase.Set(this._rawBodyData, "customer_name", value); }
    }

    public DisableOnDemand? DisableOnDemand
    {
        get
        {
            return ModelBase.GetNullableClass<DisableOnDemand>(
                this.RawBodyData,
                "disable_on_demand"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "disable_on_demand", value); }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "metadata", value); }
    }

    public DateTimeOffset? NextBillingDate
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(
                this.RawBodyData,
                "next_billing_date"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "next_billing_date", value); }
    }

    public ApiEnum<string, SubscriptionStatus>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SubscriptionStatus>>(
                this.RawBodyData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "status", value); }
    }

    public string? TaxID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "tax_id"); }
        init { ModelBase.Set(this._rawBodyData, "tax_id", value); }
    }

    public SubscriptionUpdateParams() { }

    public SubscriptionUpdateParams(
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
    SubscriptionUpdateParams(
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

    public static SubscriptionUpdateParams FromRawUnchecked(
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
                + string.Format("/subscriptions/{0}", this.SubscriptionID)
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

[JsonConverter(typeof(ModelConverter<DisableOnDemand, DisableOnDemandFromRaw>))]
public sealed record class DisableOnDemand : ModelBase
{
    public required DateTimeOffset NextBillingDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "next_billing_date");
        }
        init { ModelBase.Set(this._rawData, "next_billing_date", value); }
    }

    public override void Validate()
    {
        _ = this.NextBillingDate;
    }

    public DisableOnDemand() { }

    public DisableOnDemand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisableOnDemand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DisableOnDemand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DisableOnDemand(DateTimeOffset nextBillingDate)
        : this()
    {
        this.NextBillingDate = nextBillingDate;
    }
}

class DisableOnDemandFromRaw : IFromRaw<DisableOnDemand>
{
    public DisableOnDemand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DisableOnDemand.FromRawUnchecked(rawData);
}
