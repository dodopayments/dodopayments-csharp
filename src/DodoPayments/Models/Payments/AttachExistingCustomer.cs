using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Payments;

[JsonConverter(typeof(DodoPayments::ModelConverter<AttachExistingCustomer>))]
public sealed record class AttachExistingCustomer
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<AttachExistingCustomer>
{
    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer_id");
        }
        set { this.Properties["customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CustomerID;
    }

    public AttachExistingCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachExistingCustomer(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AttachExistingCustomer FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AttachExistingCustomer(string customerID)
        : this()
    {
        this.CustomerID = customerID;
    }
}
