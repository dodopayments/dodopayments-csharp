using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;
using Misc = DodoPayments.Models.Misc;

namespace DodoPayments.Models.Addons;

[JsonConverter(typeof(DodoPayments::ModelConverter<AddonResponse>))]
public sealed record class AddonResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<AddonResponse>
{
    /// <summary>
    /// id of the Addon
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Unique identifier for the business to which the addon belongs.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("business_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("business_id");
        }
        set { this.Properties["business_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Created time
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Currency of the Addon
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Name of the Addon
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public required int Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Tax category applied to this Addon
    /// </summary>
    public required Misc::TaxCategory TaxCategory
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_category", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_category", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::TaxCategory>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("tax_category");
        }
        set { this.Properties["tax_category"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Updated time
    /// </summary>
    public required DateTime UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("updated_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["updated_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional description of the Addon
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Image of the Addon
    /// </summary>
    public string? Image
    {
        get
        {
            if (!this.Properties.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["image"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.Name;
        _ = this.Price;
        this.TaxCategory.Validate();
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.Image;
    }

    public AddonResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddonResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
