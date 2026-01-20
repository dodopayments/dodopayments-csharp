using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Discounts;

/// <summary>
/// Validate and fetch a discount by its code name (e.g., "SAVE20"). This allows real-time
/// validation directly against the API using the human-readable discount code instead
/// of requiring the internal discount_id.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DiscountRetrieveByCodeParams : ParamsBase
{
    public string? Code { get; init; }

    public DiscountRetrieveByCodeParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountRetrieveByCodeParams(DiscountRetrieveByCodeParams discountRetrieveByCodeParams)
        : base(discountRetrieveByCodeParams)
    {
        this.Code = discountRetrieveByCodeParams.Code;
    }
#pragma warning restore CS8618

    public DiscountRetrieveByCodeParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountRetrieveByCodeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static DiscountRetrieveByCodeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["Code"] = this.Code,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DiscountRetrieveByCodeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Code?.Equals(other.Code) ?? other.Code == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/discounts/code/{0}", this.Code)
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
