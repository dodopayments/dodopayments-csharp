using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Payments.PaymentRetrieveLineItemsResponseProperties;

[JsonConverter(typeof(ModelConverter<Item>))]
public sealed record class Item : ModelBase, IFromRaw<Item>
{
    public required int Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ItemsID
    {
        get
        {
            if (!this.Properties.TryGetValue("items_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("items_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("items_id");
        }
        set
        {
            this.Properties["items_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int RefundableAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("refundable_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "refundable_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["refundable_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int Tax
    {
        get
        {
            if (!this.Properties.TryGetValue("tax", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.ItemsID;
        _ = this.RefundableAmount;
        _ = this.Tax;
        _ = this.Description;
        _ = this.Name;
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
}
