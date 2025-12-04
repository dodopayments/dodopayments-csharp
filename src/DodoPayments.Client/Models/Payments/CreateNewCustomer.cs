using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(ModelConverter<CreateNewCustomer, CreateNewCustomerFromRaw>))]
public sealed record class CreateNewCustomer : ModelBase
{
    public required string Email
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "email"); }
        init { ModelBase.Set(this._rawData, "email", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// When false, the most recently created customer object with the given email
    /// is used if exists. When true, a new customer object is always created False
    /// by default
    /// </summary>
    public bool? CreateNewCustomerValue
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "create_new_customer"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "create_new_customer", value);
        }
    }

    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { ModelBase.Set(this._rawData, "phone_number", value); }
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

    public CreateNewCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateNewCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class CreateNewCustomerFromRaw : IFromRaw<CreateNewCustomer>
{
    /// <inheritdoc/>
    public CreateNewCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreateNewCustomer.FromRawUnchecked(rawData);
}
