using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.Discounts;

/// <summary>
/// POST /discounts If `code` is omitted or empty, a random 16-char uppercase code
/// is generated.
/// </summary>
public sealed record class DiscountCreateParams : Dodopayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The discount amount.
    ///
    /// - If `discount_type` is **not** `percentage`, `amount` is in **USD cents**.
    /// For example, `100` means `$1.00`.   Only USD is allowed. - If `discount_type`
    /// **is** `percentage`, `amount` is in **basis points**. For example, `540`
    /// means `5.4%`.
    ///
    /// Must be at least 1.
    /// </summary>
    public required int Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<int>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The discount type (e.g. `percentage`, `flat`, or `flat_per_unit`).
    /// </summary>
    public required DiscountType Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<DiscountType>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("type");
        }
        set { this.BodyProperties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optionally supply a code (will be uppercased). - Must be at least 3 characters
    /// if provided. - If omitted, a random 16-character code is generated.
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

    /// <summary>
    /// When the discount expires, if ever.
    /// </summary>
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
    /// List of product IDs to restrict usage (if any).
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
    /// How many times this discount can be used (if any). Must be >= 1 if provided.
    /// </summary>
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
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/discounts")
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
