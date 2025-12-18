using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<CustomerPortalSession, CustomerPortalSessionFromRaw>))]
public sealed record class CustomerPortalSession : JsonModel
{
    public required string Link
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "link"); }
        init { JsonModel.Set(this._rawData, "link", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Link;
    }

    public CustomerPortalSession() { }

    public CustomerPortalSession(CustomerPortalSession customerPortalSession)
        : base(customerPortalSession) { }

    public CustomerPortalSession(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerPortalSession(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerPortalSessionFromRaw.FromRawUnchecked"/>
    public static CustomerPortalSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerPortalSession(string link)
        : this()
    {
        this.Link = link;
    }
}

class CustomerPortalSessionFromRaw : IFromRawJson<CustomerPortalSession>
{
    /// <inheritdoc/>
    public CustomerPortalSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerPortalSession.FromRawUnchecked(rawData);
}
