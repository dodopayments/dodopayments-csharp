using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

public sealed record class LedgerEntryCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CustomerID { get; init; }

    public required long Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// Currency of the wallet to adjust
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    /// <summary>
    /// Type of ledger entry - credit or debit
    /// </summary>
    public required ApiEnum<string, EntryType> EntryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, EntryType>>("entry_type");
        }
        init { this._rawBodyData.Set("entry_type", value); }
    }

    /// <summary>
    /// Optional idempotency key to prevent duplicate entries
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawBodyData.Set("idempotency_key", value); }
    }

    public string? Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reason");
        }
        init { this._rawBodyData.Set("reason", value); }
    }

    public LedgerEntryCreateParams() { }

    public LedgerEntryCreateParams(LedgerEntryCreateParams ledgerEntryCreateParams)
        : base(ledgerEntryCreateParams)
    {
        this.CustomerID = ledgerEntryCreateParams.CustomerID;

        this._rawBodyData = new(ledgerEntryCreateParams._rawBodyData);
    }

    public LedgerEntryCreateParams(
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
    LedgerEntryCreateParams(
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
    public static LedgerEntryCreateParams FromRawUnchecked(
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
                + string.Format("/customers/{0}/wallets/ledger-entries", this.CustomerID)
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
}

/// <summary>
/// Type of ledger entry - credit or debit
/// </summary>
[JsonConverter(typeof(EntryTypeConverter))]
public enum EntryType
{
    Credit,
    Debit,
}

sealed class EntryTypeConverter : JsonConverter<EntryType>
{
    public override EntryType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => EntryType.Credit,
            "debit" => EntryType.Debit,
            _ => (EntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryType.Credit => "credit",
                EntryType.Debit => "debit",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
