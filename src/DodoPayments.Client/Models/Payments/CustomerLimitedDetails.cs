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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "customer_id"); }
        init { JsonModel.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// Email address of the customer
    /// </summary>
    public required string Email
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
    }

    /// <summary>
    /// Full name of the customer
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Additional metadata associated with the customer
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "metadata", value);
        }
    }

    /// <summary>
    /// Phone number of the customer
    /// </summary>
    public string? PhoneNumber
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { JsonModel.Set(this._rawData, "phone_number", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerLimitedDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
