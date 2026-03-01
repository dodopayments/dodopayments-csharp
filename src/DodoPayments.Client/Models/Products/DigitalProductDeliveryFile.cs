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
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_name");
        }
        init { this._rawData.Set("file_name", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.FileName;
        _ = this.Url;
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
