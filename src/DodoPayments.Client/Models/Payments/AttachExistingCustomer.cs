using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<AttachExistingCustomer, AttachExistingCustomerFromRaw>))]
public sealed record class AttachExistingCustomer : JsonModel
{
    public required string CustomerID
    {
        get { return this._rawData.GetNotNullClass<string>("customer_id"); }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerID;
    }

    public AttachExistingCustomer() { }

    public AttachExistingCustomer(AttachExistingCustomer attachExistingCustomer)
        : base(attachExistingCustomer) { }

    public AttachExistingCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachExistingCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachExistingCustomerFromRaw.FromRawUnchecked"/>
    public static AttachExistingCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AttachExistingCustomer(string customerID)
        : this()
    {
        this.CustomerID = customerID;
    }
}

class AttachExistingCustomerFromRaw : IFromRawJson<AttachExistingCustomer>
{
    /// <inheritdoc/>
    public AttachExistingCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttachExistingCustomer.FromRawUnchecked(rawData);
}
