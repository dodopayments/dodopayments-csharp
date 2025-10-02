using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<AttachExistingCustomer>))]
public sealed record class AttachExistingCustomer : ModelBase, IFromRaw<AttachExistingCustomer>
{
    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new ArgumentOutOfRangeException("customer_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new ArgumentNullException("customer_id")
                );
        }
        set
        {
            this.Properties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
