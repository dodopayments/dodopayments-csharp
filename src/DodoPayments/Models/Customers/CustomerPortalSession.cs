using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Customers;

[JsonConverter(typeof(DodoPayments::ModelConverter<CustomerPortalSession>))]
public sealed record class CustomerPortalSession
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<CustomerPortalSession>
{
    public required string Link
    {
        get
        {
            if (!this.Properties.TryGetValue("link", out JsonElement element))
                throw new ArgumentOutOfRangeException("link", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("link");
        }
        set { this.Properties["link"] = JsonSerializer.SerializeToElement(value); }
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
