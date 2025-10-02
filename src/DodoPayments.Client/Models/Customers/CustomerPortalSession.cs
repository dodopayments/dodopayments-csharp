using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(typeof(ModelConverter<CustomerPortalSession>))]
public sealed record class CustomerPortalSession : ModelBase, IFromRaw<CustomerPortalSession>
{
    public required string Link
    {
        get
        {
            if (!this.Properties.TryGetValue("link", out JsonElement element))
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
        set
        {
            this.Properties["link"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerPortalSession(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerPortalSession FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public CustomerPortalSession(string link)
        : this()
    {
        this.Link = link;
    }
}
