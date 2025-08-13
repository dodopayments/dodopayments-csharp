using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Licenses;

public sealed record class LicenseDeactivateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string LicenseKey
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("license_key", out JsonElement element))
                throw new ArgumentOutOfRangeException("license_key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("license_key");
        }
        set { this.BodyProperties["license_key"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string LicenseKeyInstanceID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("license_key_instance_id", out JsonElement element)
            )
                throw new ArgumentOutOfRangeException(
                    "license_key_instance_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("license_key_instance_id");
        }
        set
        {
            this.BodyProperties["license_key_instance_id"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/licenses/deactivate")
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
