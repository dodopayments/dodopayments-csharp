using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Blocklist.Customers;

[JsonConverter(typeof(JsonModelConverter<BlockByEmail, BlockByEmailFromRaw>))]
public sealed record class BlockByEmail : JsonModel
{
    /// <summary>
    /// Email to block. It must belong to an existing customer of this business.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
    }

    public BlockByEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockByEmail(BlockByEmail blockByEmail)
        : base(blockByEmail) { }
#pragma warning restore CS8618

    public BlockByEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockByEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockByEmailFromRaw.FromRawUnchecked"/>
    public static BlockByEmail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BlockByEmail(string email)
        : this()
    {
        this.Email = email;
    }
}

class BlockByEmailFromRaw : IFromRawJson<BlockByEmail>
{
    /// <inheritdoc/>
    public BlockByEmail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BlockByEmail.FromRawUnchecked(rawData);
}
