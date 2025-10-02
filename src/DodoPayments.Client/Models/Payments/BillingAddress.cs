using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<BillingAddress>))]
public sealed record class BillingAddress : ModelBase, IFromRaw<BillingAddress>
{
    /// <summary>
    /// City name
    /// </summary>
    public required string City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'city' cannot be null",
                    new ArgumentOutOfRangeException("city", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'city' cannot be null",
                    new ArgumentNullException("city")
                );
        }
        set
        {
            this.Properties["city"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'country' cannot be null",
                    new ArgumentOutOfRangeException("country", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// State or province name
    /// </summary>
    public required string State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'state' cannot be null",
                    new ArgumentOutOfRangeException("state", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'state' cannot be null",
                    new ArgumentNullException("state")
                );
        }
        set
        {
            this.Properties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Street address including house number and unit/apartment if applicable
    /// </summary>
    public required string Street
    {
        get
        {
            if (!this.Properties.TryGetValue("street", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'street' cannot be null",
                    new ArgumentOutOfRangeException("street", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'street' cannot be null",
                    new ArgumentNullException("street")
                );
        }
        set
        {
            this.Properties["street"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Postal code or ZIP code
    /// </summary>
    public required string Zipcode
    {
        get
        {
            if (!this.Properties.TryGetValue("zipcode", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'zipcode' cannot be null",
                    new ArgumentOutOfRangeException("zipcode", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'zipcode' cannot be null",
                    new ArgumentNullException("zipcode")
                );
        }
        set
        {
            this.Properties["zipcode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.City;
        this.Country.Validate();
        _ = this.State;
        _ = this.Street;
        _ = this.Zipcode;
    }

    public BillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillingAddress FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
