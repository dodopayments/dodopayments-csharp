using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using System = System;

namespace DodoPayments.Client.Models.Customers.Wallets.LedgerEntries;

[JsonConverter(typeof(ModelConverter<CustomerWalletTransaction>))]
public sealed record class CustomerWalletTransaction
    : ModelBase,
        IFromRaw<CustomerWalletTransaction>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long AfterBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("after_balance", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'after_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "after_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["after_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long BeforeBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("before_balance", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'before_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "before_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["before_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string BusinessID
    {
        get
        {
            if (!this.Properties.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        set
        {
            this.Properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "customer_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer_id' cannot be null",
                    new System::ArgumentNullException("customer_id")
                );
        }
        set
        {
            this.Properties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, EventType> EventType
    {
        get
        {
            if (!this.Properties.TryGetValue("event_type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'event_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["event_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool IsCredit
    {
        get
        {
            if (!this.Properties.TryGetValue("is_credit", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'is_credit' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "is_credit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_credit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ReferenceObjectID
    {
        get
        {
            if (!this.Properties.TryGetValue("reference_object_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reference_object_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.AfterBalance;
        _ = this.Amount;
        _ = this.BeforeBalance;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.Currency.Validate();
        _ = this.CustomerID;
        this.EventType.Validate();
        _ = this.IsCredit;
        _ = this.Reason;
        _ = this.ReferenceObjectID;
    }

    public CustomerWalletTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerWalletTransaction(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerWalletTransaction FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    Payment,
    PaymentReversal,
    Refund,
    RefundReversal,
    Dispute,
    DisputeReversal,
    MerchantAdjustment,
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment" => EventType.Payment,
            "payment_reversal" => EventType.PaymentReversal,
            "refund" => EventType.Refund,
            "refund_reversal" => EventType.RefundReversal,
            "dispute" => EventType.Dispute,
            "dispute_reversal" => EventType.DisputeReversal,
            "merchant_adjustment" => EventType.MerchantAdjustment,
            _ => (EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventType.Payment => "payment",
                EventType.PaymentReversal => "payment_reversal",
                EventType.Refund => "refund",
                EventType.RefundReversal => "refund_reversal",
                EventType.Dispute => "dispute",
                EventType.DisputeReversal => "dispute_reversal",
                EventType.MerchantAdjustment => "merchant_adjustment",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
