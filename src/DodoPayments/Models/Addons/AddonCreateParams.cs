using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;
using Misc = DodoPayments.Models.Misc;

namespace DodoPayments.Models.Addons;

public sealed record class AddonCreateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The currency of the Addon
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("currency");
        }
        set { this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<int>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Tax category applied to this Addon
    /// </summary>
    public required Misc::TaxCategory TaxCategory
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_category", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_category", "Missing required argument");

            return JsonSerializer.Deserialize<Misc::TaxCategory>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("tax_category");
        }
        set { this.BodyProperties["tax_category"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
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
