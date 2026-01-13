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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("brand_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("brand_id", value);
        }
    }

    /// <summary>
    /// Get events after this created time
    /// </summary>
    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at_gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at_gte", value);
        }
    }

    /// <summary>
    /// Get events created before this time
    /// </summary>
    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at_lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at_lte", value);
        }
    }

    /// <summary>
    /// Filter by customer id
    /// </summary>
    public string? CustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("customer_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("customer_id", value);
        }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_number", value);
        }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Filter by status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    /// <summary>
    /// Filter by subscription id
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("subscription_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("subscription_id", value);
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
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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
