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
        get { return ModelBase.GetNotNullClass<List<Item>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
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
    : IFromRaw<CustomerRetrievePaymentMethodsResponse>
{
    /// <inheritdoc/>
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
            return ModelBase.GetNotNullClass<ApiEnum<string, PaymentMethod>>(
                this.RawData,
                "payment_method"
            );
        }
        init { ModelBase.Set(this._rawData, "payment_method", value); }
    }

    public required string PaymentMethodID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_method_id"); }
        init { ModelBase.Set(this._rawData, "payment_method_id", value); }
    }

    public Card? Card
    {
        get { return ModelBase.GetNullableClass<Card>(this.RawData, "card"); }
        init { ModelBase.Set(this._rawData, "card", value); }
    }

    public DateTimeOffset? LastUsedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "last_used_at"); }
        init { ModelBase.Set(this._rawData, "last_used_at", value); }
    }

    public ApiEnum<string, Payments::PaymentMethodTypes>? PaymentMethodType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Payments::PaymentMethodTypes>>(
                this.RawData,
                "payment_method_type"
            );
        }
        init { ModelBase.Set(this._rawData, "payment_method_type", value); }
    }

    public bool? RecurringEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "recurring_enabled"); }
        init { ModelBase.Set(this._rawData, "recurring_enabled", value); }
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

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    /// <inheritdoc/>
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
            return ModelBase.GetNullableClass<ApiEnum<string, CountryCode>>(
                this.RawData,
                "card_issuing_country"
            );
        }
        init { ModelBase.Set(this._rawData, "card_issuing_country", value); }
    }

    public string? CardNetwork
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "card_network"); }
        init { ModelBase.Set(this._rawData, "card_network", value); }
    }

    public string? CardType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "card_type"); }
        init { ModelBase.Set(this._rawData, "card_type", value); }
    }

    public string? ExpiryMonth
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "expiry_month"); }
        init { ModelBase.Set(this._rawData, "expiry_month", value); }
    }

    public string? ExpiryYear
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "expiry_year"); }
        init { ModelBase.Set(this._rawData, "expiry_year", value); }
    }

    public string? Last4Digits
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "last4_digits"); }
        init { ModelBase.Set(this._rawData, "last4_digits", value); }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CardFromRaw.FromRawUnchecked"/>
    public static Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFromRaw : IFromRaw<Card>
{
    /// <inheritdoc/>
    public Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Card.FromRawUnchecked(rawData);
}
