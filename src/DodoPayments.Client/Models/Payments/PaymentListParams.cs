using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

public sealed record class PaymentListParams : ParamsBase
{
    /// <summary>
    /// filter by Brand id
    /// </summary>
    public string? BrandID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "brand_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "brand_id", value);
        }
    }

    /// <summary>
    /// Get events after this created time
    /// </summary>
    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "created_at_gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "created_at_gte", value);
        }
    }

    /// <summary>
    /// Get events created before this time
    /// </summary>
    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "created_at_lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "created_at_lte", value);
        }
    }

    /// <summary>
    /// Filter by customer id
    /// </summary>
    public string? CustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "customer_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "customer_id", value);
        }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawQueryData, "page_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "page_number", value);
        }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawQueryData, "page_size"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "page_size", value);
        }
    }

    /// <summary>
    /// Filter by status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Status>>(this.RawQueryData, "status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "status", value);
        }
    }

    /// <summary>
    /// Filter by subscription id
    /// </summary>
    public string? SubscriptionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "subscription_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "subscription_id", value);
        }
    }

    public PaymentListParams() { }

    public PaymentListParams(PaymentListParams paymentListParams)
        : base(paymentListParams) { }

    public PaymentListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static PaymentListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/payments")
        {
            Query = this.QueryString(options),
        }.Uri;
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
/// Filter by status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Succeeded,
    Failed,
    Cancelled,
    Processing,
    RequiresCustomerAction,
    RequiresMerchantAction,
    RequiresPaymentMethod,
    RequiresConfirmation,
    RequiresCapture,
    PartiallyCaptured,
    PartiallyCapturedAndCapturable,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "succeeded" => Status.Succeeded,
            "failed" => Status.Failed,
            "cancelled" => Status.Cancelled,
            "processing" => Status.Processing,
            "requires_customer_action" => Status.RequiresCustomerAction,
            "requires_merchant_action" => Status.RequiresMerchantAction,
            "requires_payment_method" => Status.RequiresPaymentMethod,
            "requires_confirmation" => Status.RequiresConfirmation,
            "requires_capture" => Status.RequiresCapture,
            "partially_captured" => Status.PartiallyCaptured,
            "partially_captured_and_capturable" => Status.PartiallyCapturedAndCapturable,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Succeeded => "succeeded",
                Status.Failed => "failed",
                Status.Cancelled => "cancelled",
                Status.Processing => "processing",
                Status.RequiresCustomerAction => "requires_customer_action",
                Status.RequiresMerchantAction => "requires_merchant_action",
                Status.RequiresPaymentMethod => "requires_payment_method",
                Status.RequiresConfirmation => "requires_confirmation",
                Status.RequiresCapture => "requires_capture",
                Status.PartiallyCaptured => "partially_captured",
                Status.PartiallyCapturedAndCapturable => "partially_captured_and_capturable",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
