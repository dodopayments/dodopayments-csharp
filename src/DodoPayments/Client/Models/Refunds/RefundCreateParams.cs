using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Client = DodoPayments.Client;
using RefundCreateParamsProperties = DodoPayments.Client.Models.Refunds.RefundCreateParamsProperties;

namespace DodoPayments.Client.Models.Refunds;

public sealed record class RefundCreateParams : Client::ParamsBase
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

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("payment_id");
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
                Client::ModelBase.SerializerOptions
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
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Client::IDodoPaymentsClient client)
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

    public void AddHeadersToRequest(HttpRequestMessage request, Client::IDodoPaymentsClient client)
    {
        Client::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Client::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
