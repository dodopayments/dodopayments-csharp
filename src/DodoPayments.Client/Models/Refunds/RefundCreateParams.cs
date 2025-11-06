using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Refunds;

public sealed record class RefundCreateParams : ParamsBase
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
                throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentOutOfRangeException("payment_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentNullException("payment_id")
                );
        }
        set
        {
            this.BodyProperties["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Partially Refund an Individual Item
    /// </summary>
    public List<Item>? Items
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Item>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata associated with the refund.
    /// </summary>
    public Dictionary<string, string>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDodoPaymentsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/refunds")
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

[JsonConverter(typeof(ModelConverter<Item>))]
public sealed record class Item : ModelBase, IFromRaw<Item>
{
    /// <summary>
    /// The id of the item (i.e. `product_id` or `addon_id`)
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'item_id' cannot be null",
                    new ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'item_id' cannot be null",
                    new ArgumentNullException("item_id")
                );
        }
        set
        {
            this.Properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to refund. if None the whole item is refunded
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specify if tax is inclusive of the refund. Default true.
    /// </summary>
    public bool? TaxInclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_inclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax_inclusive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ItemID;
        _ = this.Amount;
        _ = this.TaxInclusive;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Item(string itemID)
        : this()
    {
        this.ItemID = itemID;
    }
}
