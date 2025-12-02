using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<NewCustomer, NewCustomerFromRaw>))]
public sealed record class NewCustomer : ModelBase
{
    /// <summary>
    /// Email is required for creating a new customer
    /// </summary>
    public required string Email
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "email"); }
        init { ModelBase.Set(this._rawData, "email", value); }
    }

    /// <summary>
    /// Optional full name of the customer. If provided during session creation, it
    /// is persisted and becomes immutable for the session. If omitted here, it can
    /// be provided later via the confirm API.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { ModelBase.Set(this._rawData, "phone_number", value); }
    }

    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
        _ = this.PhoneNumber;
    }

    public NewCustomer() { }

    public NewCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NewCustomer(string email)
        : this()
    {
        this.Email = email;
    }
}

class NewCustomerFromRaw : IFromRaw<NewCustomer>
{
    public NewCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewCustomer.FromRawUnchecked(rawData);
}
