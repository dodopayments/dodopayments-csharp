using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeys;

public sealed record class LicenseKeyUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string ID { get; init; }

    /// <summary>
    /// The updated activation limit for the license key. Use `null` to remove the
    /// limit, or omit this field to leave it unchanged.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("activations_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["activations_limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the license key should be disabled. A value of `true` disables
    /// the key, while `false` enables it. Omit this field to leave it unchanged.
    /// </summary>
    public bool? Disabled
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("disabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["disabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated expiration timestamp for the license key in UTC. Use `null` to
    /// remove the expiration date, or omit this field to leave it unchanged.
    /// </summary>
    public DateTime? ExpiresAt
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public LicenseKeyUpdateParams() { }

    public LicenseKeyUpdateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyUpdateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static LicenseKeyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/license_keys/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
