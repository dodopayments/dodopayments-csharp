using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.Brands;

public sealed record class BrandUpdateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// The UUID you got back from the presigned‐upload call
    /// </summary>
    public string? ImageID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("image_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["image_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? StatementDescriptor
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("statement_descriptor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["statement_descriptor"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public string? SupportEmail
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("support_email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["support_email"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/brands/{0}", this.ID)
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
