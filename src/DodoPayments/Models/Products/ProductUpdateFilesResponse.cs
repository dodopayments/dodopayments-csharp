using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;
using System = System;

namespace DodoPayments.Models.Products;

[JsonConverter(typeof(DodoPayments::ModelConverter<ProductUpdateFilesResponse>))]
public sealed record class ProductUpdateFilesResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<ProductUpdateFilesResponse>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "file_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("file_id");
        }
        set { this.Properties["file_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.FileID;
        _ = this.URL;
    }

    public ProductUpdateFilesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateFilesResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProductUpdateFilesResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
