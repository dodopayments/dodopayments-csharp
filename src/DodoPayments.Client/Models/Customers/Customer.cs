using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(typeof(ModelConverter<Customer, CustomerFromRaw>))]
public sealed record class Customer : ModelBase
{
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required string CustomerID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { ModelBase.Set(this._rawData, "customer_id", value); }
    }

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
    /// Additional metadata for the customer
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "metadata", value);
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
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.Email;
        _ = this.Name;
        _ = this.Metadata;
        _ = this.PhoneNumber;
    }

    public Customer() { }

    public Customer(Customer customer)
        : base(customer) { }

    public Customer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerFromRaw.FromRawUnchecked"/>
    public static Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerFromRaw : IFromRaw<Customer>
{
    /// <inheritdoc/>
    public Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Customer.FromRawUnchecked(rawData);
}
