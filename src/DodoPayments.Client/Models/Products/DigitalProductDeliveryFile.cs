using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Products;

[JsonConverter(
    typeof(JsonModelConverter<DigitalProductDeliveryFile, DigitalProductDeliveryFileFromRaw>)
)]
public sealed record class DigitalProductDeliveryFile : JsonModel
{
    public required string DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("download_url");
        }
        init { this._rawData.Set("download_url", value); }
    }

    /// <summary>
    /// Seconds until `download_url` expires.
    /// </summary>
    public required long ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expires_in");
        }
        init { this._rawData.Set("expires_in", value); }
    }

    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    public long? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_size");
        }
        init { this._rawData.Set("file_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadUrl;
        _ = this.ExpiresIn;
        _ = this.FileID;
        _ = this.Filename;
        _ = this.ContentType;
        _ = this.FileSize;
    }

    public DigitalProductDeliveryFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalProductDeliveryFile(DigitalProductDeliveryFile digitalProductDeliveryFile)
        : base(digitalProductDeliveryFile) { }
#pragma warning restore CS8618

    public DigitalProductDeliveryFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalProductDeliveryFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalProductDeliveryFileFromRaw.FromRawUnchecked"/>
    public static DigitalProductDeliveryFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalProductDeliveryFileFromRaw : IFromRawJson<DigitalProductDeliveryFile>
{
    /// <inheritdoc/>
    public DigitalProductDeliveryFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalProductDeliveryFile.FromRawUnchecked(rawData);
}
