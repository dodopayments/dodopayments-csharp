using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Payments = DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerRetrievePaymentMethodsResponse,
        CustomerRetrievePaymentMethodsResponseFromRaw
    >)
)]
public sealed record class CustomerRetrievePaymentMethodsResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public CustomerRetrievePaymentMethodsResponse() { }

    public CustomerRetrievePaymentMethodsResponse(
        CustomerRetrievePaymentMethodsResponse customerRetrievePaymentMethodsResponse
    )
        : base(customerRetrievePaymentMethodsResponse) { }

    public CustomerRetrievePaymentMethodsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerRetrievePaymentMethodsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerRetrievePaymentMethodsResponseFromRaw.FromRawUnchecked"/>
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
    : IFromRawJson<CustomerRetrievePaymentMethodsResponse>
{
    /// <inheritdoc/>
    public CustomerRetrievePaymentMethodsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerRetrievePaymentMethodsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required ApiEnum<string, PaymentMethod> PaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentMethod>>("payment_method");
        }
        init { this._rawData.Set("payment_method", value); }
    }

    public required string PaymentMethodID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_method_id");
        }
        init { this._rawData.Set("payment_method_id", value); }
    }

    public Card? Card
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Card>("card");
        }
        init { this._rawData.Set("card", value); }
    }

    public DateTimeOffset? LastUsedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_used_at");
        }
        init { this._rawData.Set("last_used_at", value); }
    }

    public ApiEnum<string, Payments::PaymentMethodTypes>? PaymentMethodType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Payments::PaymentMethodTypes>>(
                "payment_method_type"
            );
        }
        init { this._rawData.Set("payment_method_type", value); }
    }

    public bool? RecurringEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("recurring_enabled");
        }
        init { this._rawData.Set("recurring_enabled", value); }
    }

    /// <inheritdoc/>
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

    public Item(Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

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

[JsonConverter(typeof(JsonModelConverter<Card, CardFromRaw>))]
public sealed record class Card : JsonModel
{
    public string? CardHolderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_holder_name");
        }
        init { this._rawData.Set("card_holder_name", value); }
    }

    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? CardIssuingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CountryCode>>(
                "card_issuing_country"
            );
        }
        init { this._rawData.Set("card_issuing_country", value); }
    }

    public string? CardNetwork
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_network");
        }
        init { this._rawData.Set("card_network", value); }
    }

    public string? CardType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_type");
        }
        init { this._rawData.Set("card_type", value); }
    }

    public string? ExpiryMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiry_month");
        }
        init { this._rawData.Set("expiry_month", value); }
    }

    public string? ExpiryYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiry_year");
        }
        init { this._rawData.Set("expiry_year", value); }
    }

    public string? Last4Digits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last4_digits");
        }
        init { this._rawData.Set("last4_digits", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardHolderName;
        this.CardIssuingCountry?.Validate();
        _ = this.CardNetwork;
        _ = this.CardType;
        _ = this.ExpiryMonth;
        _ = this.ExpiryYear;
        _ = this.Last4Digits;
    }

    public Card() { }

    public Card(Card card)
        : base(card) { }

    public Card(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Card(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFromRaw.FromRawUnchecked"/>
    public static Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFromRaw : IFromRawJson<Card>
{
    /// <inheritdoc/>
    public Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Card.FromRawUnchecked(rawData);
}
