using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Brands;

public sealed record class BrandCreateParams : Client::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["support_email"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? URL
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/brands")
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

    public void AddHeadersToRequest(HttpRequestMessage request, Client::IDodoPaymentsClient client)
    {
        Client::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Client::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
