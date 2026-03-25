using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public record class CustomerDeletePaymentMethodParams : ParamsBase
{
    public required string CustomerID { get; init; }

    public string? PaymentMethodID { get; init; }

    public CustomerDeletePaymentMethodParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerDeletePaymentMethodParams(
        CustomerDeletePaymentMethodParams customerDeletePaymentMethodParams
    )
        : base(customerDeletePaymentMethodParams)
    {
        this.CustomerID = customerDeletePaymentMethodParams.CustomerID;
        this.PaymentMethodID = customerDeletePaymentMethodParams.PaymentMethodID;
    }
#pragma warning restore CS8618

    public CustomerDeletePaymentMethodParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerDeletePaymentMethodParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string customerID,
        string paymentMethodID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CustomerID = customerID;
        this.PaymentMethodID = paymentMethodID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CustomerDeletePaymentMethodParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string customerID,
        string paymentMethodID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            customerID,
            paymentMethodID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CustomerID"] = JsonSerializer.SerializeToElement(this.CustomerID),
                    ["PaymentMethodID"] = JsonSerializer.SerializeToElement(this.PaymentMethodID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CustomerDeletePaymentMethodParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CustomerID.Equals(other.CustomerID)
            && (
                this.PaymentMethodID?.Equals(other.PaymentMethodID) ?? other.PaymentMethodID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/{0}/payment-methods/{1}",
                    this.CustomerID,
                    this.PaymentMethodID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
