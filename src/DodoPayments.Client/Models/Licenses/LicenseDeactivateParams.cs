using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Licenses;

public sealed record class LicenseDeactivateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string LicenseKey
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("license_key", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'license_key' cannot be null",
                    new ArgumentOutOfRangeException("license_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'license_key' cannot be null",
                    new ArgumentNullException("license_key")
                );
        }
        set
        {
            this.BodyProperties["license_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string LicenseKeyInstanceID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("license_key_instance_id", out JsonElement element)
            )
                throw new DodoPaymentsInvalidDataException(
                    "'license_key_instance_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "license_key_instance_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'license_key_instance_id' cannot be null",
                    new ArgumentNullException("license_key_instance_id")
                );
        }
        set
        {
            this.BodyProperties["license_key_instance_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/licenses/deactivate")
        {
            Query = this.QueryString(client),
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

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDodoPaymentsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
