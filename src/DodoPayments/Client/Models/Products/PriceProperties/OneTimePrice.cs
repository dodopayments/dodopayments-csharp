using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using Misc = DodoPayments.Client.Models.Misc;
using OneTimePriceProperties = DodoPayments.Client.Models.Products.PriceProperties.OneTimePriceProperties;
using System = System;

namespace DodoPayments.Client.Models.Products.PriceProperties;

/// <summary>
/// One-time price details.
/// </summary>
[JsonConverter(typeof(Client::ModelConverter<OneTimePrice>))]
public sealed record class OneTimePrice : Client::ModelBase, Client::IFromRaw<OneTimePrice>
{
    /// <summary>
    /// The currency in which the payment is made.
    /// </summary>
    public required Misc::Currency Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Misc::Currency>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Discount applied to the price, represented as a percentage (0 to 100).
    /// </summary>
    public required long Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["discount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The payment amount, in the smallest denomination of the currency (e.g., cents
    /// for USD). For example, to charge $1.00, pass `100`.
    ///
    /// If [`pay_what_you_want`](Self::pay_what_you_want) is set to `true`, this
    /// field represents the **minimum** amount the customer must pay.
    /// </summary>
    public required int Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates if purchasing power parity adjustments are applied to the price.
    /// Purchasing power parity feature is not available as of now.
    /// </summary>
    public required bool PurchasingPowerParity
    {
        get
        {
            if (!this.Properties.TryGetValue("purchasing_power_parity", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "purchasing_power_parity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, Client::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["purchasing_power_parity"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public required OneTimePriceProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<OneTimePriceProperties::Type>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates whether the customer can pay any amount they choose. If set to
    /// `true`, the [`price`](Self::price) field is the minimum amount.
    /// </summary>
    public bool? PayWhatYouWant
    {
        get
        {
            if (!this.Properties.TryGetValue("pay_what_you_want", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["pay_what_you_want"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A suggested price for the user to pay. This value is only considered if [`pay_what_you_want`](Self::pay_what_you_want)
    /// is `true`. Otherwise, it is ignored.
    /// </summary>
    public int? SuggestedPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("suggested_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["suggested_price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates if the price is tax inclusive.
    /// </summary>
    public bool? TaxInclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_inclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["tax_inclusive"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Currency.Validate();
        _ = this.Discount;
        _ = this.Price;
        _ = this.PurchasingPowerParity;
        this.Type.Validate();
        _ = this.PayWhatYouWant;
        _ = this.SuggestedPrice;
        _ = this.TaxInclusive;
    }

    public OneTimePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OneTimePrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OneTimePrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
