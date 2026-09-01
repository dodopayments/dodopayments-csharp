using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Blocklist.Customers.Notes;

[JsonConverter(typeof(JsonModelConverter<NoteRequest, NoteRequestFromRaw>))]
public sealed record class NoteRequest : JsonModel
{
    public required string Note
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("note");
        }
        init { this._rawData.Set("note", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Note;
    }

    public NoteRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoteRequest(NoteRequest noteRequest)
        : base(noteRequest) { }
#pragma warning restore CS8618

    public NoteRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoteRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoteRequestFromRaw.FromRawUnchecked"/>
    public static NoteRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NoteRequest(string note)
        : this()
    {
        this.Note = note;
    }
}

class NoteRequestFromRaw : IFromRawJson<NoteRequest>
{
    /// <inheritdoc/>
    public NoteRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NoteRequest.FromRawUnchecked(rawData);
}
