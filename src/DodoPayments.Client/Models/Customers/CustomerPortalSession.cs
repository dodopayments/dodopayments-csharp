using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(typeof(ModelConverter<CustomerPortalSession, CustomerPortalSessionFromRaw>))]
public sealed record class CustomerPortalSession : ModelBase
{
    public required string Link
    {
        get
        {
            if (!this._rawData.TryGetValue("link", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'link' cannot be null",
                    new ArgumentOutOfRangeException("link", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'link' cannot be null",
                    new ArgumentNullException("link")
                );
        }
        init
        {
            this._rawData["link"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Link;
    }

    public CustomerPortalSession() { }

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

class CustomerPortalSessionFromRaw : IFromRaw<CustomerPortalSession>
{
    public CustomerPortalSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerPortalSession.FromRawUnchecked(rawData);
}
