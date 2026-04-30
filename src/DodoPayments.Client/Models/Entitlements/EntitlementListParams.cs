using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// GET /entitlements
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntitlementListParams : ParamsBase
{
    /// <summary>
    /// Filter by integration type
    /// </summary>
    public ApiEnum<string, EntitlementListParamsIntegrationType>? IntegrationType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, EntitlementListParamsIntegrationType>
            >("integration_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("integration_type", value);
        }
    }

    /// <summary>
    /// Page number (default 0)
    /// </summary>
    public int? PageNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_number", value);
        }
    }

    /// <summary>
    /// Page size (default 10, max 100)
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    public EntitlementListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListParams(EntitlementListParams entitlementListParams)
        : base(entitlementListParams) { }
#pragma warning restore CS8618

    public EntitlementListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntitlementListParams FromRawUnchecked(
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
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(EntitlementListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/entitlements")
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

/// <summary>
/// Filter by integration type
/// </summary>
[JsonConverter(typeof(EntitlementListParamsIntegrationTypeConverter))]
public enum EntitlementListParamsIntegrationType
{
    Discord,
    Telegram,
    GitHub,
    Figma,
    Framer,
    Notion,
    DigitalFiles,
    LicenseKey,
}

sealed class EntitlementListParamsIntegrationTypeConverter
    : JsonConverter<EntitlementListParamsIntegrationType>
{
    public override EntitlementListParamsIntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => EntitlementListParamsIntegrationType.Discord,
            "telegram" => EntitlementListParamsIntegrationType.Telegram,
            "github" => EntitlementListParamsIntegrationType.GitHub,
            "figma" => EntitlementListParamsIntegrationType.Figma,
            "framer" => EntitlementListParamsIntegrationType.Framer,
            "notion" => EntitlementListParamsIntegrationType.Notion,
            "digital_files" => EntitlementListParamsIntegrationType.DigitalFiles,
            "license_key" => EntitlementListParamsIntegrationType.LicenseKey,
            _ => (EntitlementListParamsIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListParamsIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListParamsIntegrationType.Discord => "discord",
                EntitlementListParamsIntegrationType.Telegram => "telegram",
                EntitlementListParamsIntegrationType.GitHub => "github",
                EntitlementListParamsIntegrationType.Figma => "figma",
                EntitlementListParamsIntegrationType.Framer => "framer",
                EntitlementListParamsIntegrationType.Notion => "notion",
                EntitlementListParamsIntegrationType.DigitalFiles => "digital_files",
                EntitlementListParamsIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
