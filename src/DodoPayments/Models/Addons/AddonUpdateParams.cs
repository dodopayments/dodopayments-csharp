using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;
using Misc = DodoPayments.Models.Misc;

namespace DodoPayments.Models.Addons;

public sealed record class AddonUpdateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// The currency of the Addon
    /// </summary>
    public Misc::Currency? Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Misc::Currency?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Description of the Addon, optional and must be at most 1000 characters.
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

    /// <summary>
    /// Addon image id after its uploaded to S3
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

    /// <summary>
    /// Name of the Addon, optional and must be at most 100 characters.
    /// </summary>
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

    /// <summary>
    /// Amount of the addon
    /// </summary>
    public int? Price
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Tax category of the Addon.
    /// </summary>
    public Misc::TaxCategory? TaxCategory
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Misc::TaxCategory?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["tax_category"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/addons/{0}", this.ID)
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
