using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Customers;

/// <summary>
/// List all of a customer's entitlement grants across every entitlement. One row
/// per grant.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerListEntitlementGrantsParams : ParamsBase
{
    public string? CustomerID { get; init; }

    /// <summary>
    /// Filter by integration type (e.g. `feature_flag`)
    /// </summary>
    public ApiEnum<string, IntegrationType>? IntegrationType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, IntegrationType>>(
                "integration_type"
            );
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

    /// <summary>
    /// Filter by grant status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    public CustomerListEntitlementGrantsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListEntitlementGrantsParams(
        CustomerListEntitlementGrantsParams customerListEntitlementGrantsParams
    )
        : base(customerListEntitlementGrantsParams)
    {
        this.CustomerID = customerListEntitlementGrantsParams.CustomerID;
    }
#pragma warning restore CS8618

    public CustomerListEntitlementGrantsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListEntitlementGrantsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string customerID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CustomerID = customerID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CustomerListEntitlementGrantsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string customerID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            customerID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CustomerID"] = JsonSerializer.SerializeToElement(this.CustomerID),
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

    public virtual bool Equals(CustomerListEntitlementGrantsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CustomerID?.Equals(other.CustomerID) ?? other.CustomerID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/entitlement-grants", this.CustomerID)
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

/// <summary>
/// Filter by integration type (e.g. `feature_flag`)
/// </summary>
[JsonConverter(typeof(IntegrationTypeConverter))]
public enum IntegrationType
{
    Discord,
    Telegram,
    GitHub,
    Figma,
    Framer,
    Notion,
    DigitalFiles,
    LicenseKey,
    FeatureFlag,
}

sealed class IntegrationTypeConverter : JsonConverter<IntegrationType>
{
    public override IntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => IntegrationType.Discord,
            "telegram" => IntegrationType.Telegram,
            "github" => IntegrationType.GitHub,
            "figma" => IntegrationType.Figma,
            "framer" => IntegrationType.Framer,
            "notion" => IntegrationType.Notion,
            "digital_files" => IntegrationType.DigitalFiles,
            "license_key" => IntegrationType.LicenseKey,
            "feature_flag" => IntegrationType.FeatureFlag,
            _ => (IntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationType.Discord => "discord",
                IntegrationType.Telegram => "telegram",
                IntegrationType.GitHub => "github",
                IntegrationType.Figma => "figma",
                IntegrationType.Framer => "framer",
                IntegrationType.Notion => "notion",
                IntegrationType.DigitalFiles => "digital_files",
                IntegrationType.LicenseKey => "license_key",
                IntegrationType.FeatureFlag => "feature_flag",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by grant status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => Status.Pending,
            "Delivered" => Status.Delivered,
            "Failed" => Status.Failed,
            "Revoked" => Status.Revoked,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "Pending",
                Status.Delivered => "Delivered",
                Status.Failed => "Failed",
                Status.Revoked => "Revoked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
