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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CustomerID { get; init; }

    public required long Amount
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawBodyData, "amount"); }
        init { ModelBase.Set(this._rawBodyData, "amount", value); }
    }

    /// <summary>
    /// Currency of the wallet to adjust
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Currency>>(
                this.RawBodyData,
                "currency"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "currency", value); }
    }

    /// <summary>
    /// Type of ledger entry - credit or debit
    /// </summary>
    public required ApiEnum<string, EntryType> EntryType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, EntryType>>(
                this.RawBodyData,
                "entry_type"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "entry_type", value); }
    }

    /// <summary>
    /// Optional idempotency key to prevent duplicate entries
    /// </summary>
    public string? IdempotencyKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "idempotency_key"); }
        init { ModelBase.Set(this._rawBodyData, "idempotency_key", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "reason"); }
        init { ModelBase.Set(this._rawBodyData, "reason", value); }
    }

    public LedgerEntryCreateParams() { }

    public LedgerEntryCreateParams(LedgerEntryCreateParams ledgerEntryCreateParams)
        : base(ledgerEntryCreateParams)
    {
        this._rawBodyData = [.. ledgerEntryCreateParams._rawBodyData];
    }

    public LedgerEntryCreateParams(
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
    LedgerEntryCreateParams(
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
