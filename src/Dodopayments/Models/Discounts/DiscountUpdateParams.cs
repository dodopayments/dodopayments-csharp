using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Discounts;

/// <summary>
/// PATCH /discounts/{discount_id}
/// </summary>
public sealed record class DiscountUpdateParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string DiscountID;

    /// <summary>
    /// If present, update the discount amount: - If `discount_type` is `percentage`,
    /// this represents **basis points** (e.g., `540` = `5.4%`). - Otherwise, this
    /// represents **USD cents** (e.g., `100` = `$1.00`).
    ///
    /// Must be at least 1 if provided.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If present, update the discount code (uppercase).
    /// </summary>
    public string? Code
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["code"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? ExpiresAt
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["expires_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If present, replaces all restricted product IDs with this new set. To remove
    /// all restrictions, send empty array
    /// </summary>
    public List<string>? RestrictedTo
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("restricted_to", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["restricted_to"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of subscription billing cycles this discount is valid for. If not provided,
    /// the discount will be applied indefinitely to all recurring payments related
    /// to the subscription.
    /// </summary>
    public int? SubscriptionCycles
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("subscription_cycles", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["subscription_cycles"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// If present, update the discount type.
    /// </summary>
    public DiscountType? Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DiscountType?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public int? UsageLimit
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("usage_limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["usage_limit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Dodopayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/discounts/{0}", this.DiscountID)
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
