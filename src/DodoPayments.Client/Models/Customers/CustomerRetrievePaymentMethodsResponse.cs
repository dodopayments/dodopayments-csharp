using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(
    typeof(ModelConverter<
        CustomerRetrievePaymentMethodsResponse,
        CustomerRetrievePaymentMethodsResponseFromRaw
    >)
)]
public sealed record class CustomerRetrievePaymentMethodsResponse : ModelBase
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Item>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public CustomerRetrievePaymentMethodsResponse() { }

    public CustomerRetrievePaymentMethodsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerRetrievePaymentMethodsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CustomerRetrievePaymentMethodsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerRetrievePaymentMethodsResponse(List<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class CustomerRetrievePaymentMethodsResponseFromRaw
    : IFromRaw<CustomerRetrievePaymentMethodsResponse>
{
    public CustomerRetrievePaymentMethodsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerRetrievePaymentMethodsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    /// <summary>
    /// PaymentMethod enum from hyperswitch
    ///
    /// <para>https://github.com/juspay/hyperswitch/blob/ecd05d53c99ae701ac94893ec632a3988afe3238/crates/common_enums/src/enums.rs#L2097</para>
    /// </summary>
    public required ApiEnum<string, PaymentMethod> PaymentMethod
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_method", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_method' cannot be null",
                    new ArgumentOutOfRangeException("payment_method", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PaymentMethod>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_method' cannot be null",
                    new ArgumentNullException("payment_method")
                );
        }
        init
        {
            this._rawData["payment_method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string PaymentMethodID
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_method_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_method_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "payment_method_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_method_id' cannot be null",
                    new ArgumentNullException("payment_method_id")
                );
        }
        init
        {
            this._rawData["payment_method_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Card? Card
    {
        get
        {
            if (!this._rawData.TryGetValue("card", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Card?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["card"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? LastUsedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("last_used_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["last_used_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Payments::PaymentMethodTypes>? PaymentMethodType
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_method_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Payments::PaymentMethodTypes>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["payment_method_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? RecurringEnabled
    {
        get
        {
            if (!this._rawData.TryGetValue("recurring_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["recurring_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.PaymentMethod.Validate();
        _ = this.PaymentMethodID;
        this.Card?.Validate();
        _ = this.LastUsedAt;
        this.PaymentMethodType?.Validate();
        _ = this.RecurringEnabled;
    }

    public Item() { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

/// <summary>
/// PaymentMethod enum from hyperswitch
///
/// <para>https://github.com/juspay/hyperswitch/blob/ecd05d53c99ae701ac94893ec632a3988afe3238/crates/common_enums/src/enums.rs#L2097</para>
/// </summary>
[JsonConverter(typeof(PaymentMethodConverter))]
public enum PaymentMethod
{
    Card,
    CardRedirect,
    PayLater,
    Wallet,
    BankRedirect,
    BankTransfer,
    Crypto,
    BankDebit,
    Reward,
    RealTimePayment,
    Upi,
    Voucher,
    GiftCard,
    OpenBanking,
    MobilePayment,
}

sealed class PaymentMethodConverter : JsonConverter<PaymentMethod>
{
    public override PaymentMethod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card" => PaymentMethod.Card,
            "card_redirect" => PaymentMethod.CardRedirect,
            "pay_later" => PaymentMethod.PayLater,
            "wallet" => PaymentMethod.Wallet,
            "bank_redirect" => PaymentMethod.BankRedirect,
            "bank_transfer" => PaymentMethod.BankTransfer,
            "crypto" => PaymentMethod.Crypto,
            "bank_debit" => PaymentMethod.BankDebit,
            "reward" => PaymentMethod.Reward,
            "real_time_payment" => PaymentMethod.RealTimePayment,
            "upi" => PaymentMethod.Upi,
            "voucher" => PaymentMethod.Voucher,
            "gift_card" => PaymentMethod.GiftCard,
            "open_banking" => PaymentMethod.OpenBanking,
            "mobile_payment" => PaymentMethod.MobilePayment,
            _ => (PaymentMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentMethod.Card => "card",
                PaymentMethod.CardRedirect => "card_redirect",
                PaymentMethod.PayLater => "pay_later",
                PaymentMethod.Wallet => "wallet",
                PaymentMethod.BankRedirect => "bank_redirect",
                PaymentMethod.BankTransfer => "bank_transfer",
                PaymentMethod.Crypto => "crypto",
                PaymentMethod.BankDebit => "bank_debit",
                PaymentMethod.Reward => "reward",
                PaymentMethod.RealTimePayment => "real_time_payment",
                PaymentMethod.Upi => "upi",
                PaymentMethod.Voucher => "voucher",
                PaymentMethod.GiftCard => "gift_card",
                PaymentMethod.OpenBanking => "open_banking",
                PaymentMethod.MobilePayment => "mobile_payment",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Card, CardFromRaw>))]
public sealed record class Card : ModelBase
{
    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            if (!this._rawData.TryGetValue("card_issuing_country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, CountryCode>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["card_issuing_country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CardNetwork
    {
        get
        {
            if (!this._rawData.TryGetValue("card_network", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["card_network"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CardType
    {
        get
        {
            if (!this._rawData.TryGetValue("card_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["card_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ExpiryMonth
    {
        get
        {
            if (!this._rawData.TryGetValue("expiry_month", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["expiry_month"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ExpiryYear
    {
        get
        {
            if (!this._rawData.TryGetValue("expiry_year", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["expiry_year"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Last4Digits
    {
        get
        {
            if (!this._rawData.TryGetValue("last4_digits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["last4_digits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.CardIssuingCountry?.Validate();
        _ = this.CardNetwork;
        _ = this.CardType;
        _ = this.ExpiryMonth;
        _ = this.ExpiryYear;
        _ = this.Last4Digits;
    }

    public Card() { }

    public Card(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Card(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFromRaw : IFromRaw<Card>
{
    public Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Card.FromRawUnchecked(rawData);
}
