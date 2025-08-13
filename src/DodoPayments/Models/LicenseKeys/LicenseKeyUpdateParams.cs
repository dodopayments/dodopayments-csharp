using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.LicenseKeys;

public sealed record class LicenseKeyUpdateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// The updated activation limit for the license key. Use `null` to remove the
    /// limit, or omit this field to leave it unchanged.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("activations_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["activations_limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates whether the license key should be disabled. A value of `true` disables
    /// the key, while `false` enables it. Omit this field to leave it unchanged.
    /// </summary>
    public bool? Disabled
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("disabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["disabled"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The updated expiration timestamp for the license key in UTC. Use `null` to
    /// remove the expiration date, or omit this field to leave it unchanged.
    /// </summary>
    public DateTime? ExpiresAt
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["expires_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/license_keys/{0}", this.ID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(
        HttpRequestMessage request,
        DodoPayments::IDodoPaymentsClient client
    )
    {
        DodoPayments::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            DodoPayments::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
