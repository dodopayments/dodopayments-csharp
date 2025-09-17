using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Products.ProductCreateParamsProperties;

/// <summary>
/// Choose how you would like you digital product delivered
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<DigitalProductDelivery>))]
public sealed record class DigitalProductDelivery
    : Client::ModelBase,
        Client::IFromRaw<DigitalProductDelivery>
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
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["external_url"] = JsonSerializer.SerializeToElement(value); }
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
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["instructions"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ExternalURL;
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
