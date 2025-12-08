using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionPreviewChangePlanParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Unique identifier of the product to subscribe to
    /// </summary>
    public required string ProductID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "product_id"); }
        init { ModelBase.Set(this._rawBodyData, "product_id", value); }
    }

    /// <summary>
    /// Proration Billing Mode
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionPreviewChangePlanParamsProrationBillingMode
    > ProrationBillingMode
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, SubscriptionPreviewChangePlanParamsProrationBillingMode>
            >(this.RawBodyData, "proration_billing_mode");
        }
        init { ModelBase.Set(this._rawBodyData, "proration_billing_mode", value); }
    }

    /// <summary>
    /// Number of units to subscribe for. Must be at least 1.
    /// </summary>
    public required int Quantity
    {
        get { return ModelBase.GetNotNullStruct<int>(this.RawBodyData, "quantity"); }
        init { ModelBase.Set(this._rawBodyData, "quantity", value); }
    }

    /// <summary>
    /// Addons for the new plan. Note : Leaving this empty would remove any existing addons
    /// </summary>
    public IReadOnlyList<AttachAddon>? Addons
    {
        get { return ModelBase.GetNullableClass<List<AttachAddon>>(this.RawBodyData, "addons"); }
        init { ModelBase.Set(this._rawBodyData, "addons", value); }
    }

    public SubscriptionPreviewChangePlanParams() { }

    public SubscriptionPreviewChangePlanParams(
        SubscriptionPreviewChangePlanParams subscriptionPreviewChangePlanParams
    )
        : base(subscriptionPreviewChangePlanParams)
    {
        this._rawBodyData = [.. subscriptionPreviewChangePlanParams._rawBodyData];
    }

    public SubscriptionPreviewChangePlanParams(
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
    SubscriptionPreviewChangePlanParams(
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
    public static SubscriptionPreviewChangePlanParams FromRawUnchecked(
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/change-plan/preview", this.SubscriptionID)
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

/// <summary>
/// Proration Billing Mode
/// </summary>
[JsonConverter(typeof(SubscriptionPreviewChangePlanParamsProrationBillingModeConverter))]
public enum SubscriptionPreviewChangePlanParamsProrationBillingMode
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
}

sealed class SubscriptionPreviewChangePlanParamsProrationBillingModeConverter
    : JsonConverter<SubscriptionPreviewChangePlanParamsProrationBillingMode>
{
    public override SubscriptionPreviewChangePlanParamsProrationBillingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" =>
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately,
            "full_immediately" =>
                SubscriptionPreviewChangePlanParamsProrationBillingMode.FullImmediately,
            "difference_immediately" =>
                SubscriptionPreviewChangePlanParamsProrationBillingMode.DifferenceImmediately,
            _ => (SubscriptionPreviewChangePlanParamsProrationBillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPreviewChangePlanParamsProrationBillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPreviewChangePlanParamsProrationBillingMode.ProratedImmediately =>
                    "prorated_immediately",
                SubscriptionPreviewChangePlanParamsProrationBillingMode.FullImmediately =>
                    "full_immediately",
                SubscriptionPreviewChangePlanParamsProrationBillingMode.DifferenceImmediately =>
                    "difference_immediately",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
