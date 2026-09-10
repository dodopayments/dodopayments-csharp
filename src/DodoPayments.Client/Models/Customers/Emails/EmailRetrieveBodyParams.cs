using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Emails;

/// <summary>
/// Returns the email exactly as it was sent, plus the reason it failed when it did.
/// Some emails have no body to show: an authentication email carries a live login
/// token, a blocked email never reached the provider, and the provider clears bodies
/// at 180 days.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailRetrieveBodyParams : ParamsBase
{
    public required string CustomerID { get; init; }

    public string? EmailLogID { get; init; }

    public EmailRetrieveBodyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailRetrieveBodyParams(EmailRetrieveBodyParams emailRetrieveBodyParams)
        : base(emailRetrieveBodyParams)
    {
        this.CustomerID = emailRetrieveBodyParams.CustomerID;
        this.EmailLogID = emailRetrieveBodyParams.EmailLogID;
    }
#pragma warning restore CS8618

    public EmailRetrieveBodyParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailRetrieveBodyParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string customerID,
        string emailLogID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CustomerID = customerID;
        this.EmailLogID = emailLogID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailRetrieveBodyParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string customerID,
        string emailLogID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            customerID,
            emailLogID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CustomerID"] = JsonSerializer.SerializeToElement(this.CustomerID),
                    ["EmailLogID"] = JsonSerializer.SerializeToElement(this.EmailLogID),
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

    public virtual bool Equals(EmailRetrieveBodyParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CustomerID.Equals(other.CustomerID)
            && (this.EmailLogID?.Equals(other.EmailLogID) ?? other.EmailLogID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/emails/{1}/body", this.CustomerID, this.EmailLogID)
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
