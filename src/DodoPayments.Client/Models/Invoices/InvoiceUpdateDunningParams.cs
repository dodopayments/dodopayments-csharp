using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// Pauses, resumes or moves the reminders of an open or past-due invoice.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceUpdateDunningParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvoiceID { get; init; }

    public required ApiEnum<string, global::DodoPayments.Client.Models.Invoices.Action> Action
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::DodoPayments.Client.Models.Invoices.Action>
            >("action");
        }
        init { this._rawBodyData.Set("action", value); }
    }

    public required string IfMatch
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNotNullClass<string>("If-Match");
        }
        init { this._rawHeaderData.Set("If-Match", value); }
    }

    /// <summary>
    /// Needed for `reschedule`. Days from the due date.
    /// </summary>
    public IReadOnlyList<int>? OffsetsDays
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<int>>("offsets_days");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<int>?>(
                "offsets_days",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public InvoiceUpdateDunningParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateDunningParams(InvoiceUpdateDunningParams invoiceUpdateDunningParams)
        : base(invoiceUpdateDunningParams)
    {
        this.InvoiceID = invoiceUpdateDunningParams.InvoiceID;

        this._rawBodyData = new(invoiceUpdateDunningParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvoiceUpdateDunningParams(
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
    InvoiceUpdateDunningParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string invoiceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InvoiceID = invoiceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InvoiceUpdateDunningParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string invoiceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            invoiceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InvoiceID"] = JsonSerializer.SerializeToElement(this.InvoiceID),
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

    public virtual bool Equals(InvoiceUpdateDunningParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InvoiceID?.Equals(other.InvoiceID) ?? other.InvoiceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/billing/invoices/{0}/dunning", this.InvoiceID)
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

[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    Pause,
    Resume,
    Reschedule,
}

sealed class ActionConverter : JsonConverter<global::DodoPayments.Client.Models.Invoices.Action>
{
    public override global::DodoPayments.Client.Models.Invoices.Action Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pause" => global::DodoPayments.Client.Models.Invoices.Action.Pause,
            "resume" => global::DodoPayments.Client.Models.Invoices.Action.Resume,
            "reschedule" => global::DodoPayments.Client.Models.Invoices.Action.Reschedule,
            _ => (global::DodoPayments.Client.Models.Invoices.Action)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Invoices.Action value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Invoices.Action.Pause => "pause",
                global::DodoPayments.Client.Models.Invoices.Action.Resume => "resume",
                global::DodoPayments.Client.Models.Invoices.Action.Reschedule => "reschedule",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
