using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Blocklist.Customers;

[JsonConverter(typeof(JsonModelConverter<BlockByCustomerID, BlockByCustomerIDFromRaw>))]
public sealed record class BlockByCustomerID : JsonModel
{
    /// <summary>
    /// Customer to block. The block still applies to that customer's email.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerID;
    }

    public BlockByCustomerID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockByCustomerID(BlockByCustomerID blockByCustomerID)
        : base(blockByCustomerID) { }
#pragma warning restore CS8618

    public BlockByCustomerID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockByCustomerID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockByCustomerIDFromRaw.FromRawUnchecked"/>
    public static BlockByCustomerID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BlockByCustomerID(string customerID)
        : this()
    {
        this.CustomerID = customerID;
    }
}

class BlockByCustomerIDFromRaw : IFromRawJson<BlockByCustomerID>
{
    /// <inheritdoc/>
    public BlockByCustomerID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BlockByCustomerID.FromRawUnchecked(rawData);
}
