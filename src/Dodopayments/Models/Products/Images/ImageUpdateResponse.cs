using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Products.Images;

[JsonConverter(typeof(Dodopayments::ModelConverter<ImageUpdateResponse>))]
public sealed record class ImageUpdateResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<ImageUpdateResponse>
{
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? ImageID
    {
        get
        {
            if (!this.Properties.TryGetValue("image_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["image_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.URL;
        _ = this.ImageID;
    }

    public ImageUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageUpdateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ImageUpdateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ImageUpdateResponse(string url)
        : this()
    {
        this.URL = url;
    }
}
