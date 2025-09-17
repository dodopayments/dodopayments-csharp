using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(Client::ModelConverter<BrandUpdateImagesResponse>))]
public sealed record class BrandUpdateImagesResponse
    : Client::ModelBase,
        Client::IFromRaw<BrandUpdateImagesResponse>
{
    /// <summary>
    /// UUID that will be used as the image identifier/key suffix
    /// </summary>
    public required string ImageID
    {
        get
        {
            if (!this.Properties.TryGetValue("image_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("image_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("image_id");
        }
        set { this.Properties["image_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Presigned URL to upload the image
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ImageID;
        _ = this.URL;
    }

    public BrandUpdateImagesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateImagesResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandUpdateImagesResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
