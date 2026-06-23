using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements.Grants;

/// <summary>
/// For entitlements whose license-key config uses `manual` fulfillment, grants are
/// created in the `pending` state without a key. Call this endpoint to deliver the
/// key: the grant moves to `delivered`, the customer is emailed the key, and the
/// `license_key.created` and `entitlement_grant.delivered` webhook events are sent.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GrantFulfillLicenseKeyParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? GrantID { get; init; }

    /// <summary>
    /// The license key value to deliver to the customer.
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("key");
        }
        init { this._rawBodyData.Set("key", value); }
    }

    /// <summary>
    /// Per-key activation limit. Defaults to the entitlement's license-key configuration.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawBodyData.Set("activations_limit", value); }
    }

    /// <summary>
    /// When the key expires. Defaults to the duration in the entitlement's license-key configuration.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawBodyData.Set("expires_at", value); }
    }

    public GrantFulfillLicenseKeyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantFulfillLicenseKeyParams(GrantFulfillLicenseKeyParams grantFulfillLicenseKeyParams)
        : base(grantFulfillLicenseKeyParams)
    {
        this.GrantID = grantFulfillLicenseKeyParams.GrantID;

        this._rawBodyData = new(grantFulfillLicenseKeyParams._rawBodyData);
    }
#pragma warning restore CS8618

    public GrantFulfillLicenseKeyParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantFulfillLicenseKeyParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string grantID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.GrantID = grantID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static GrantFulfillLicenseKeyParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string grantID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            grantID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["GrantID"] = JsonSerializer.SerializeToElement(this.GrantID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(GrantFulfillLicenseKeyParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.GrantID?.Equals(other.GrantID) ?? other.GrantID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/grants/{0}/license-key", this.GrantID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
