using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionCreateResponse>))]
public sealed record class SubscriptionCreateResponse
    : ModelBase,
        IFromRaw<SubscriptionCreateResponse>
{
    /// <summary>
    /// Addons associated with this subscription
    /// </summary>
    public required List<AddonCartResponseItem> Addons
    {
        get
        {
            if (!this._rawData.TryGetValue("addons", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'addons' cannot be null",
                    new ArgumentOutOfRangeException("addons", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<AddonCartResponseItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'addons' cannot be null",
                    new ArgumentNullException("addons")
                );
        }
        init
        {
            this._rawData["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Customer details associated with this subscription
    /// </summary>
    public required CustomerLimitedDetails Customer
    {
        get
        {
            if (!this._rawData.TryGetValue("customer", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerLimitedDetails>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
                );
        }
        init
        {
            this._rawData["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata associated with the subscription
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new DodoPaymentsInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// First payment id for the subscription
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_id", out JsonElement element))
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
        init
        {
            this._rawData["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax will be added to the amount and charged to the customer on each billing cycle
    /// </summary>
    public required int RecurringPreTaxAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("recurring_pre_tax_amount", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'recurring_pre_tax_amount' cannot be null",
                    new ArgumentOutOfRangeException(
                        "recurring_pre_tax_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["recurring_pre_tax_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            if (!this._rawData.TryGetValue("subscription_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'subscription_id' cannot be null",
                    new ArgumentOutOfRangeException("subscription_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'subscription_id' cannot be null",
                    new ArgumentNullException("subscription_id")
                );
        }
        init
        {
            this._rawData["subscription_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Client secret used to load Dodo checkout SDK NOTE : Dodo checkout SDK will
    /// be coming soon
    /// </summary>
    public string? ClientSecret
    {
        get
        {
            if (!this._rawData.TryGetValue("client_secret", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["client_secret"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The discount id if discount is applied
    /// </summary>
    public string? DiscountID
    {
        get
        {
            if (!this._rawData.TryGetValue("discount_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["discount_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Expiry timestamp of the payment link
    /// </summary>
    public DateTimeOffset? ExpiresOn
    {
        get
        {
            if (!this._rawData.TryGetValue("expires_on", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["expires_on"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to checkout page
    /// </summary>
    public string? PaymentLink
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_link", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["payment_link"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Addons)
        {
            item.Validate();
        }
        this.Customer.Validate();
        _ = this.Metadata;
        _ = this.PaymentID;
        _ = this.RecurringPreTaxAmount;
        _ = this.SubscriptionID;
        _ = this.ClientSecret;
        _ = this.DiscountID;
        _ = this.ExpiresOn;
        _ = this.PaymentLink;
    }

    public SubscriptionCreateResponse() { }

    public SubscriptionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SubscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
