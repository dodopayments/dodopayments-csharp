using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Misc;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionCreateParamsProperties;

/// <summary>
/// Billing address information for the session
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<BillingAddress>))]
public sealed record class BillingAddress : Client::ModelBase, Client::IFromRaw<BillingAddress>
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required CountryCode Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                throw new ArgumentOutOfRangeException("country", "Missing required argument");

            return JsonSerializer.Deserialize<CountryCode>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("country");
        }
        set { this.Properties["country"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// City name
    /// </summary>
    public string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["city"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// State or province name
    /// </summary>
    public string? State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["state"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Street address including house number and unit/apartment if applicable
    /// </summary>
    public string? Street
    {
        get
        {
            if (!this.Properties.TryGetValue("street", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["street"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Postal code or ZIP code
    /// </summary>
    public string? Zipcode
    {
        get
        {
            if (!this.Properties.TryGetValue("zipcode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["zipcode"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Country.Validate();
        _ = this.City;
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

    [SetsRequiredMembers]
    public BillingAddress(CountryCode country)
        : this()
    {
        this.Country = country;
    }
}
