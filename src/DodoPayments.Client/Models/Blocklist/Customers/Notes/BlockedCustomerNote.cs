using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Blocklist.Customers.Notes;

[JsonConverter(typeof(JsonModelConverter<BlockedCustomerNote, BlockedCustomerNoteFromRaw>))]
public sealed record class BlockedCustomerNote : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Note
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("note");
        }
        init { this._rawData.Set("note", value); }
    }

    public string? AuthorEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("author_email");
        }
        init { this._rawData.Set("author_email", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Note;
        _ = this.AuthorEmail;
        _ = this.UpdatedAt;
    }

    public BlockedCustomerNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockedCustomerNote(BlockedCustomerNote blockedCustomerNote)
        : base(blockedCustomerNote) { }
#pragma warning restore CS8618

    public BlockedCustomerNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockedCustomerNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockedCustomerNoteFromRaw.FromRawUnchecked"/>
    public static BlockedCustomerNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockedCustomerNoteFromRaw : IFromRawJson<BlockedCustomerNote>
{
    /// <inheritdoc/>
    public BlockedCustomerNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BlockedCustomerNote.FromRawUnchecked(rawData);
}
