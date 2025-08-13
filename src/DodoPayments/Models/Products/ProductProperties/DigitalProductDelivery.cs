using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DigitalProductDeliveryProperties = DodoPayments.Models.Products.ProductProperties.DigitalProductDeliveryProperties;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Products.ProductProperties;

[JsonConverter(typeof(DodoPayments::ModelConverter<DigitalProductDelivery>))]
public sealed record class DigitalProductDelivery
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<DigitalProductDelivery>
{
    /// <summary>
    /// External URL to digital product
    /// </summary>
    public string? ExternalURL
    {
        get
        {
            if (!this.Properties.TryGetValue("external_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["external_url"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Uploaded files ids of digital product
    /// </summary>
    public List<DigitalProductDeliveryProperties::File>? Files
    {
        get
        {
            if (!this.Properties.TryGetValue("files", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DigitalProductDeliveryProperties::File>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["files"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Instructions to download and use the digital product
    /// </summary>
    public string? Instructions
    {
        get
        {
            if (!this.Properties.TryGetValue("instructions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["instructions"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ExternalURL;
        foreach (var item in this.Files ?? [])
        {
            item.Validate();
        }
        _ = this.Instructions;
    }

    public DigitalProductDelivery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDelivery(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DigitalProductDelivery FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
