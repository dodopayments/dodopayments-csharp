using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<NewCustomer, NewCustomerFromRaw>))]
public sealed record class NewCustomer : JsonModel
{
    /// <summary>
    /// Email is required for creating a new customer
    /// </summary>
    public required string Email
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
    }

    /// <summary>
    /// Optional full name of the customer. If provided during session creation, it
    /// is persisted and becomes immutable for the session. If omitted here, it can
    /// be provided later via the confirm API.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public string? PhoneNumber
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { JsonModel.Set(this._rawData, "phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
        _ = this.PhoneNumber;
    }

    public NewCustomer() { }

    public NewCustomer(NewCustomer newCustomer)
        : base(newCustomer) { }

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

    /// <inheritdoc cref="NewCustomerFromRaw.FromRawUnchecked"/>
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

class NewCustomerFromRaw : IFromRawJson<NewCustomer>
{
    /// <inheritdoc/>
    public NewCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewCustomer.FromRawUnchecked(rawData);
}
