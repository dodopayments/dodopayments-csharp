using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments = DodoPayments;
using RefundCreateParamsProperties = DodoPayments.Models.Refunds.RefundCreateParamsProperties;

namespace DodoPayments.Models.Refunds;

public sealed record class RefundCreateParams : DodoPayments::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The unique identifier of the payment to be refunded.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payment_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("payment_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payment_id");
        }
        set { this.BodyProperties["payment_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Partially Refund an Individual Item
    /// </summary>
    public List<RefundCreateParamsProperties::Item>? Items
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RefundCreateParamsProperties::Item>?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The reason for the refund, if any. Maximum length is 3000 characters. Optional.
    /// </summary>
    public string? Reason
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                DodoPayments::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(DodoPayments::IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/refunds")
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
