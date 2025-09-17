using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Payments;

[JsonConverter(typeof(Dodopayments::ModelConverter<CustomerLimitedDetails>))]
public sealed record class CustomerLimitedDetails
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<CustomerLimitedDetails>
{
    /// <summary>
    /// Unique identifier for the customer
    /// </summary>
    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer_id");
        }
        set { this.Properties["customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Email address of the customer
    /// </summary>
    public required string Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                throw new ArgumentOutOfRangeException("email", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("email");
        }
        set { this.Properties["email"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Full name of the customer
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CustomerID;
        _ = this.Email;
        _ = this.Name;
    }

    public CustomerLimitedDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerLimitedDetails(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerLimitedDetails FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
