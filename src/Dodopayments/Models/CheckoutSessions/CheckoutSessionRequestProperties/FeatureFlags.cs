using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.CheckoutSessions.CheckoutSessionRequestProperties;

[JsonConverter(typeof(Dodopayments::ModelConverter<FeatureFlags>))]
public sealed record class FeatureFlags
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<FeatureFlags>
{
    /// <summary>
    /// if customer is allowed to change currency, set it to true
    ///
    /// Default is true
    /// </summary>
    public bool? AllowCurrencySelection
    {
        get
        {
            if (!this.Properties.TryGetValue("allow_currency_selection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["allow_currency_selection"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// If the customer is allowed to apply discount code, set it to true.
    ///
    /// Default is true
    /// </summary>
    public bool? AllowDiscountCode
    {
        get
        {
            if (!this.Properties.TryGetValue("allow_discount_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["allow_discount_code"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If phone number is collected from customer, set it to rue
    ///
    /// Default is true
    /// </summary>
    public bool? AllowPhoneNumberCollection
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "allow_phone_number_collection",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["allow_phone_number_collection"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// If the customer is allowed to add tax id, set it to true
    ///
    /// Default is true
    /// </summary>
    public bool? AllowTaxID
    {
        get
        {
            if (!this.Properties.TryGetValue("allow_tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["allow_tax_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Set to true if a new customer object should be created. By default email is
    /// used to find an existing customer to attach the session to
    ///
    /// Default is false
    /// </summary>
    public bool? AlwaysCreateNewCustomer
    {
        get
        {
            if (!this.Properties.TryGetValue("always_create_new_customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["always_create_new_customer"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        _ = this.AllowCurrencySelection;
        _ = this.AllowDiscountCode;
        _ = this.AllowPhoneNumberCollection;
        _ = this.AllowTaxID;
        _ = this.AlwaysCreateNewCustomer;
    }

    public FeatureFlags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureFlags(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FeatureFlags FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
