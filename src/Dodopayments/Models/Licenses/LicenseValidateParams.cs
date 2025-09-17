using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Licenses;

public sealed record class LicenseValidateParams : Dodopayments::ParamsBase
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
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("license_key");
        }
        set { this.BodyProperties["license_key"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? LicenseKeyInstanceID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("license_key_instance_id", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["license_key_instance_id"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/licenses/validate")
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
        Dodopayments::IDodoPaymentsClient client
    )
    {
        Dodopayments::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Dodopayments::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
