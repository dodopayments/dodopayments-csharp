using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Addons;

public sealed record class AddonCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The currency of the Addon
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the Addon
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set
        {
            this.BodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public required int Price
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price", out JsonElement element))
                throw new ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax category applied to this Addon
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_category", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_category", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, TaxCategory>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["tax_category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional description of the Addon
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/addons")
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

    public void AddHeadersToRequest(HttpRequestMessage request, IDodoPaymentsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
