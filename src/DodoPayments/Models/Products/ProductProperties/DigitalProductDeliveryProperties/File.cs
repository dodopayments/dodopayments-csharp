using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Products.ProductProperties.DigitalProductDeliveryProperties;

[JsonConverter(typeof(DodoPayments::ModelConverter<File>))]
public sealed record class File : DodoPayments::ModelBase, DodoPayments::IFromRaw<File>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("file_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("file_id");
        }
        set { this.Properties["file_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string FileName
    {
        get
        {
            if (!this.Properties.TryGetValue("file_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("file_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("file_name");
        }
        set { this.Properties["file_name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
        _ = this.URL;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static File FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
