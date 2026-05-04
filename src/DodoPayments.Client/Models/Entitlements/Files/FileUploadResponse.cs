using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements.Files;

[JsonConverter(typeof(JsonModelConverter<FileUploadResponse, FileUploadResponseFromRaw>))]
public sealed record class FileUploadResponse : JsonModel
{
    /// <summary>
    /// Identifier of the attached file. Pass it to `DELETE /entitlements/{id}/files/{file_id}`
    /// to detach the file later.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
    }

    public FileUploadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadResponse(FileUploadResponse fileUploadResponse)
        : base(fileUploadResponse) { }
#pragma warning restore CS8618

    public FileUploadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadResponseFromRaw.FromRawUnchecked"/>
    public static FileUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileUploadResponse(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class FileUploadResponseFromRaw : IFromRawJson<FileUploadResponse>
{
    /// <inheritdoc/>
    public FileUploadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileUploadResponse.FromRawUnchecked(rawData);
}
