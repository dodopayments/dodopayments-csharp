using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<CustomerLimitedDetails, CustomerLimitedDetailsFromRaw>))]
public sealed record class CustomerLimitedDetails : JsonModel
{
    /// <summary>
    /// Unique identifier for the customer
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

    /// <summary>
    /// Email address of the customer
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

    /// <summary>
    /// Full name of the customer
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Additional metadata associated with the customer
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Phone number of the customer
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerID;
        _ = this.Email;
        _ = this.Name;
        _ = this.Metadata;
        _ = this.PhoneNumber;
    }

    public CustomerLimitedDetails() { }

    public CustomerLimitedDetails(CustomerLimitedDetails customerLimitedDetails)
        : base(customerLimitedDetails) { }

    public CustomerLimitedDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerLimitedDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerLimitedDetailsFromRaw.FromRawUnchecked"/>
    public static CustomerLimitedDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerLimitedDetailsFromRaw : IFromRawJson<CustomerLimitedDetails>
{
    /// <inheritdoc/>
    public CustomerLimitedDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerLimitedDetails.FromRawUnchecked(rawData);
}
