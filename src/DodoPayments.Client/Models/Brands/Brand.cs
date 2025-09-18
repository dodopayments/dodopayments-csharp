using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Models.Brands.BrandProperties;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<Brand>))]
public sealed record class Brand : ModelBase, IFromRaw<Brand>
{
    public required string BrandID
    {
        get
        {
            if (!this.Properties.TryGetValue("brand_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("brand_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("brand_id");
        }
        set
        {
            this.Properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("business_id");
        }
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                throw new ArgumentOutOfRangeException("enabled", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string StatementDescriptor
    {
        get
        {
            if (!this.Properties.TryGetValue("statement_descriptor", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "statement_descriptor",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("statement_descriptor");
        }
        set
        {
            this.Properties["statement_descriptor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool VerificationEnabled
    {
        get
        {
            if (!this.Properties.TryGetValue("verification_enabled", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "verification_enabled",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["verification_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, VerificationStatus> VerificationStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("verification_status", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "verification_status",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ApiEnum<string, VerificationStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["verification_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Image
    {
        get
        {
            if (!this.Properties.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Incase the brand verification fails or is put on hold
    /// </summary>
    public string? ReasonForHold
    {
        get
        {
            if (!this.Properties.TryGetValue("reason_for_hold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason_for_hold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? SupportEmail
    {
        get
        {
            if (!this.Properties.TryGetValue("support_email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["support_email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.Enabled;
        _ = this.StatementDescriptor;
        _ = this.VerificationEnabled;
        this.VerificationStatus.Validate();
        _ = this.Description;
        _ = this.Image;
        _ = this.Name;
        _ = this.ReasonForHold;
        _ = this.SupportEmail;
        _ = this.URL;
    }

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Brand FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
