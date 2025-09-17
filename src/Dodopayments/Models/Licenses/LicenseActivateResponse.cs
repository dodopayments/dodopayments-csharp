using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments.Models.Payments;
using Dodopayments = Dodopayments;
using LicenseActivateResponseProperties = Dodopayments.Models.Licenses.LicenseActivateResponseProperties;

namespace Dodopayments.Models.Licenses;

[JsonConverter(typeof(Dodopayments::ModelConverter<LicenseActivateResponse>))]
public sealed record class LicenseActivateResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<LicenseActivateResponse>
{
    /// <summary>
    /// License key instance ID
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Business ID
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Limited customer details associated with the license key.
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new ArgumentOutOfRangeException("customer", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Associated license key ID
    /// </summary>
    public required string LicenseKeyID
    {
        get
        {
            if (!this.Properties.TryGetValue("license_key_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "license_key_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("license_key_id");
        }
        set { this.Properties["license_key_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Instance name
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

    /// <summary>
    /// Related product info. Present if the license key is tied to a product.
    /// </summary>
    public required LicenseActivateResponseProperties::Product Product
    {
        get
        {
            if (!this.Properties.TryGetValue("product", out JsonElement element))
                throw new ArgumentOutOfRangeException("product", "Missing required argument");

            return JsonSerializer.Deserialize<LicenseActivateResponseProperties::Product>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("product");
        }
        set { this.Properties["product"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Customer.Validate();
        _ = this.LicenseKeyID;
        _ = this.Name;
        this.Product.Validate();
    }

    public LicenseActivateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseActivateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LicenseActivateResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
