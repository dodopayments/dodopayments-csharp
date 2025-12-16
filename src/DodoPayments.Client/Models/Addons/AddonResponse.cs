using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(typeof(ModelConverter<AddonResponse, AddonResponseFromRaw>))]
public sealed record class AddonResponse : ModelBase
{
    /// <summary>
    /// id of the Addon
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the business to which the addon belongs.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentOutOfRangeException("business_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Created time
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Currency of the Addon
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the Addon
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public required int Price
    {
        get
        {
            if (!this._rawData.TryGetValue("price", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'price' cannot be null",
                    new ArgumentOutOfRangeException("price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax category applied to this Addon
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_category", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'tax_category' cannot be null",
                    new ArgumentOutOfRangeException("tax_category", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'tax_category' cannot be null",
                    new ArgumentNullException("tax_category")
                );
        }
        init
        {
            this._rawData["tax_category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Updated time
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updated_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentOutOfRangeException("updated_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional description of the Addon
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Image of the Addon
    /// </summary>
    public string? Image
    {
        get
        {
            if (!this._rawData.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public AddonResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddonResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonResponseFromRaw : IFromRaw<AddonResponse>
{
    public AddonResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddonResponse.FromRawUnchecked(rawData);
}
