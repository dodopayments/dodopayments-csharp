using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Invoices;

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceCreateHostedLinkResponse,
        InvoiceCreateHostedLinkResponseFromRaw
    >)
)]
public sealed record class InvoiceCreateHostedLinkResponse : JsonModel
{
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    public required string HostedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("hosted_url");
        }
        init { this._rawData.Set("hosted_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.HostedUrl;
    }

    public InvoiceCreateHostedLinkResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceCreateHostedLinkResponse(
        InvoiceCreateHostedLinkResponse invoiceCreateHostedLinkResponse
    )
        : base(invoiceCreateHostedLinkResponse) { }
#pragma warning restore CS8618

    public InvoiceCreateHostedLinkResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceCreateHostedLinkResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceCreateHostedLinkResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceCreateHostedLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceCreateHostedLinkResponseFromRaw : IFromRawJson<InvoiceCreateHostedLinkResponse>
{
    /// <inheritdoc/>
    public InvoiceCreateHostedLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceCreateHostedLinkResponse.FromRawUnchecked(rawData);
}
