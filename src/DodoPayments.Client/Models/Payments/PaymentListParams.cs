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

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class PaymentListParams : ParamsBase
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
    /// Filter by currency
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("currency", value);
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
    /// Page number default is 0. Capped to bound OFFSET-based deep pagination, which
    /// forces Postgres to scan and discard every preceding row.
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
    /// Filter by product id
    /// </summary>
    public string? ProductID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("product_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("product_id", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentListParams(PaymentListParams paymentListParams)
        : base(paymentListParams) { }
#pragma warning restore CS8618

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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PaymentListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Filter by currency
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    Aed,
    All,
    Amd,
    Ang,
    Aoa,
    Ars,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bhd,
    Bif,
    Bmd,
    Bnd,
    Bob,
    Brl,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Cad,
    Chf,
    Clp,
    Cny,
    Cop,
    Crc,
    Cup,
    Cve,
    Czk,
    Djf,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Fkp,
    Gbp,
    Gel,
    Ghs,
    Gip,
    Gmd,
    Gnf,
    Gtq,
    Gyd,
    Hkd,
    Hnl,
    Hrk,
    Htg,
    Huf,
    Idr,
    Ils,
    Inr,
    Iqd,
    Jmd,
    Jod,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kwd,
    Kyd,
    Kzt,
    Lak,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Lyd,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mru,
    Mur,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nio,
    Nok,
    Npr,
    Nzd,
    Omr,
    Pab,
    Pen,
    Pgk,
    Php,
    Pkr,
    Pln,
    Pyg,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Shp,
    Sle,
    Sll,
    Sos,
    Srd,
    Ssp,
    Stn,
    Svc,
    Szl,
    Thb,
    Tnd,
    Top,
    Try,
    Ttd,
    Twd,
    Tzs,
    Uah,
    Ugx,
    Usd,
    Uyu,
    Uzs,
    Ves,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Xof,
    Xpf,
    Yer,
    Zar,
    Zmw,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AED" => Currency.Aed,
            "ALL" => Currency.All,
            "AMD" => Currency.Amd,
            "ANG" => Currency.Ang,
            "AOA" => Currency.Aoa,
            "ARS" => Currency.Ars,
            "AUD" => Currency.Aud,
            "AWG" => Currency.Awg,
            "AZN" => Currency.Azn,
            "BAM" => Currency.Bam,
            "BBD" => Currency.Bbd,
            "BDT" => Currency.Bdt,
            "BGN" => Currency.Bgn,
            "BHD" => Currency.Bhd,
            "BIF" => Currency.Bif,
            "BMD" => Currency.Bmd,
            "BND" => Currency.Bnd,
            "BOB" => Currency.Bob,
            "BRL" => Currency.Brl,
            "BSD" => Currency.Bsd,
            "BWP" => Currency.Bwp,
            "BYN" => Currency.Byn,
            "BZD" => Currency.Bzd,
            "CAD" => Currency.Cad,
            "CHF" => Currency.Chf,
            "CLP" => Currency.Clp,
            "CNY" => Currency.Cny,
            "COP" => Currency.Cop,
            "CRC" => Currency.Crc,
            "CUP" => Currency.Cup,
            "CVE" => Currency.Cve,
            "CZK" => Currency.Czk,
            "DJF" => Currency.Djf,
            "DKK" => Currency.Dkk,
            "DOP" => Currency.Dop,
            "DZD" => Currency.Dzd,
            "EGP" => Currency.Egp,
            "ETB" => Currency.Etb,
            "EUR" => Currency.Eur,
            "FJD" => Currency.Fjd,
            "FKP" => Currency.Fkp,
            "GBP" => Currency.Gbp,
            "GEL" => Currency.Gel,
            "GHS" => Currency.Ghs,
            "GIP" => Currency.Gip,
            "GMD" => Currency.Gmd,
            "GNF" => Currency.Gnf,
            "GTQ" => Currency.Gtq,
            "GYD" => Currency.Gyd,
            "HKD" => Currency.Hkd,
            "HNL" => Currency.Hnl,
            "HRK" => Currency.Hrk,
            "HTG" => Currency.Htg,
            "HUF" => Currency.Huf,
            "IDR" => Currency.Idr,
            "ILS" => Currency.Ils,
            "INR" => Currency.Inr,
            "IQD" => Currency.Iqd,
            "JMD" => Currency.Jmd,
            "JOD" => Currency.Jod,
            "JPY" => Currency.Jpy,
            "KES" => Currency.Kes,
            "KGS" => Currency.Kgs,
            "KHR" => Currency.Khr,
            "KMF" => Currency.Kmf,
            "KRW" => Currency.Krw,
            "KWD" => Currency.Kwd,
            "KYD" => Currency.Kyd,
            "KZT" => Currency.Kzt,
            "LAK" => Currency.Lak,
            "LBP" => Currency.Lbp,
            "LKR" => Currency.Lkr,
            "LRD" => Currency.Lrd,
            "LSL" => Currency.Lsl,
            "LYD" => Currency.Lyd,
            "MAD" => Currency.Mad,
            "MDL" => Currency.Mdl,
            "MGA" => Currency.Mga,
            "MKD" => Currency.Mkd,
            "MMK" => Currency.Mmk,
            "MNT" => Currency.Mnt,
            "MOP" => Currency.Mop,
            "MRU" => Currency.Mru,
            "MUR" => Currency.Mur,
            "MVR" => Currency.Mvr,
            "MWK" => Currency.Mwk,
            "MXN" => Currency.Mxn,
            "MYR" => Currency.Myr,
            "MZN" => Currency.Mzn,
            "NAD" => Currency.Nad,
            "NGN" => Currency.Ngn,
            "NIO" => Currency.Nio,
            "NOK" => Currency.Nok,
            "NPR" => Currency.Npr,
            "NZD" => Currency.Nzd,
            "OMR" => Currency.Omr,
            "PAB" => Currency.Pab,
            "PEN" => Currency.Pen,
            "PGK" => Currency.Pgk,
            "PHP" => Currency.Php,
            "PKR" => Currency.Pkr,
            "PLN" => Currency.Pln,
            "PYG" => Currency.Pyg,
            "QAR" => Currency.Qar,
            "RON" => Currency.Ron,
            "RSD" => Currency.Rsd,
            "RUB" => Currency.Rub,
            "RWF" => Currency.Rwf,
            "SAR" => Currency.Sar,
            "SBD" => Currency.Sbd,
            "SCR" => Currency.Scr,
            "SEK" => Currency.Sek,
            "SGD" => Currency.Sgd,
            "SHP" => Currency.Shp,
            "SLE" => Currency.Sle,
            "SLL" => Currency.Sll,
            "SOS" => Currency.Sos,
            "SRD" => Currency.Srd,
            "SSP" => Currency.Ssp,
            "STN" => Currency.Stn,
            "SVC" => Currency.Svc,
            "SZL" => Currency.Szl,
            "THB" => Currency.Thb,
            "TND" => Currency.Tnd,
            "TOP" => Currency.Top,
            "TRY" => Currency.Try,
            "TTD" => Currency.Ttd,
            "TWD" => Currency.Twd,
            "TZS" => Currency.Tzs,
            "UAH" => Currency.Uah,
            "UGX" => Currency.Ugx,
            "USD" => Currency.Usd,
            "UYU" => Currency.Uyu,
            "UZS" => Currency.Uzs,
            "VES" => Currency.Ves,
            "VND" => Currency.Vnd,
            "VUV" => Currency.Vuv,
            "WST" => Currency.Wst,
            "XAF" => Currency.Xaf,
            "XCD" => Currency.Xcd,
            "XOF" => Currency.Xof,
            "XPF" => Currency.Xpf,
            "YER" => Currency.Yer,
            "ZAR" => Currency.Zar,
            "ZMW" => Currency.Zmw,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Aed => "AED",
                Currency.All => "ALL",
                Currency.Amd => "AMD",
                Currency.Ang => "ANG",
                Currency.Aoa => "AOA",
                Currency.Ars => "ARS",
                Currency.Aud => "AUD",
                Currency.Awg => "AWG",
                Currency.Azn => "AZN",
                Currency.Bam => "BAM",
                Currency.Bbd => "BBD",
                Currency.Bdt => "BDT",
                Currency.Bgn => "BGN",
                Currency.Bhd => "BHD",
                Currency.Bif => "BIF",
                Currency.Bmd => "BMD",
                Currency.Bnd => "BND",
                Currency.Bob => "BOB",
                Currency.Brl => "BRL",
                Currency.Bsd => "BSD",
                Currency.Bwp => "BWP",
                Currency.Byn => "BYN",
                Currency.Bzd => "BZD",
                Currency.Cad => "CAD",
                Currency.Chf => "CHF",
                Currency.Clp => "CLP",
                Currency.Cny => "CNY",
                Currency.Cop => "COP",
                Currency.Crc => "CRC",
                Currency.Cup => "CUP",
                Currency.Cve => "CVE",
                Currency.Czk => "CZK",
                Currency.Djf => "DJF",
                Currency.Dkk => "DKK",
                Currency.Dop => "DOP",
                Currency.Dzd => "DZD",
                Currency.Egp => "EGP",
                Currency.Etb => "ETB",
                Currency.Eur => "EUR",
                Currency.Fjd => "FJD",
                Currency.Fkp => "FKP",
                Currency.Gbp => "GBP",
                Currency.Gel => "GEL",
                Currency.Ghs => "GHS",
                Currency.Gip => "GIP",
                Currency.Gmd => "GMD",
                Currency.Gnf => "GNF",
                Currency.Gtq => "GTQ",
                Currency.Gyd => "GYD",
                Currency.Hkd => "HKD",
                Currency.Hnl => "HNL",
                Currency.Hrk => "HRK",
                Currency.Htg => "HTG",
                Currency.Huf => "HUF",
                Currency.Idr => "IDR",
                Currency.Ils => "ILS",
                Currency.Inr => "INR",
                Currency.Iqd => "IQD",
                Currency.Jmd => "JMD",
                Currency.Jod => "JOD",
                Currency.Jpy => "JPY",
                Currency.Kes => "KES",
                Currency.Kgs => "KGS",
                Currency.Khr => "KHR",
                Currency.Kmf => "KMF",
                Currency.Krw => "KRW",
                Currency.Kwd => "KWD",
                Currency.Kyd => "KYD",
                Currency.Kzt => "KZT",
                Currency.Lak => "LAK",
                Currency.Lbp => "LBP",
                Currency.Lkr => "LKR",
                Currency.Lrd => "LRD",
                Currency.Lsl => "LSL",
                Currency.Lyd => "LYD",
                Currency.Mad => "MAD",
                Currency.Mdl => "MDL",
                Currency.Mga => "MGA",
                Currency.Mkd => "MKD",
                Currency.Mmk => "MMK",
                Currency.Mnt => "MNT",
                Currency.Mop => "MOP",
                Currency.Mru => "MRU",
                Currency.Mur => "MUR",
                Currency.Mvr => "MVR",
                Currency.Mwk => "MWK",
                Currency.Mxn => "MXN",
                Currency.Myr => "MYR",
                Currency.Mzn => "MZN",
                Currency.Nad => "NAD",
                Currency.Ngn => "NGN",
                Currency.Nio => "NIO",
                Currency.Nok => "NOK",
                Currency.Npr => "NPR",
                Currency.Nzd => "NZD",
                Currency.Omr => "OMR",
                Currency.Pab => "PAB",
                Currency.Pen => "PEN",
                Currency.Pgk => "PGK",
                Currency.Php => "PHP",
                Currency.Pkr => "PKR",
                Currency.Pln => "PLN",
                Currency.Pyg => "PYG",
                Currency.Qar => "QAR",
                Currency.Ron => "RON",
                Currency.Rsd => "RSD",
                Currency.Rub => "RUB",
                Currency.Rwf => "RWF",
                Currency.Sar => "SAR",
                Currency.Sbd => "SBD",
                Currency.Scr => "SCR",
                Currency.Sek => "SEK",
                Currency.Sgd => "SGD",
                Currency.Shp => "SHP",
                Currency.Sle => "SLE",
                Currency.Sll => "SLL",
                Currency.Sos => "SOS",
                Currency.Srd => "SRD",
                Currency.Ssp => "SSP",
                Currency.Stn => "STN",
                Currency.Svc => "SVC",
                Currency.Szl => "SZL",
                Currency.Thb => "THB",
                Currency.Tnd => "TND",
                Currency.Top => "TOP",
                Currency.Try => "TRY",
                Currency.Ttd => "TTD",
                Currency.Twd => "TWD",
                Currency.Tzs => "TZS",
                Currency.Uah => "UAH",
                Currency.Ugx => "UGX",
                Currency.Usd => "USD",
                Currency.Uyu => "UYU",
                Currency.Uzs => "UZS",
                Currency.Ves => "VES",
                Currency.Vnd => "VND",
                Currency.Vuv => "VUV",
                Currency.Wst => "WST",
                Currency.Xaf => "XAF",
                Currency.Xcd => "XCD",
                Currency.Xof => "XOF",
                Currency.Xpf => "XPF",
                Currency.Yer => "YER",
                Currency.Zar => "ZAR",
                Currency.Zmw => "ZMW",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
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
