using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<CreateNewCustomer, CreateNewCustomerFromRaw>))]
public sealed record class CreateNewCustomer : JsonModel
{
    public required string Email
    {
        get { return this._rawData.GetNotNullClass<string>("email"); }
        init { this._rawData.Set("email", value); }
    }

    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// When false, the most recently created customer object with the given email
    /// is used if exists. When true, a new customer object is always created False
    /// by default
    /// </summary>
    public bool? CreateNewCustomerValue
    {
        get { return this._rawData.GetNullableStruct<bool>("create_new_customer"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("create_new_customer", value);
        }
    }

    public string? PhoneNumber
    {
        get { return this._rawData.GetNullableClass<string>("phone_number"); }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
        _ = this.CreateNewCustomerValue;
        _ = this.PhoneNumber;
    }

    public CreateNewCustomer() { }

    public CreateNewCustomer(CreateNewCustomer createNewCustomer)
        : base(createNewCustomer) { }

    public CreateNewCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateNewCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateNewCustomerFromRaw.FromRawUnchecked"/>
    public static CreateNewCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateNewCustomerFromRaw : IFromRawJson<CreateNewCustomer>
{
    /// <inheritdoc/>
    public CreateNewCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreateNewCustomer.FromRawUnchecked(rawData);
}
