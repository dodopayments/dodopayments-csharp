using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(JsonModelConverter<CheckoutSessionFlags, CheckoutSessionFlagsFromRaw>))]
public sealed record class CheckoutSessionFlags : JsonModel
{
    /// <summary>
    /// if customer is allowed to change currency, set it to true
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowCurrencySelection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_currency_selection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_currency_selection", value);
        }
    }

    public bool? AllowCustomerEditingCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_city", value);
        }
    }

    public bool? AllowCustomerEditingCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_country", value);
        }
    }

    public bool? AllowCustomerEditingEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_email", value);
        }
    }

    public bool? AllowCustomerEditingName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_name", value);
        }
    }

    public bool? AllowCustomerEditingState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_state", value);
        }
    }

    public bool? AllowCustomerEditingStreet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_street");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_street", value);
        }
    }

    public bool? AllowCustomerEditingZipcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_customer_editing_zipcode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_customer_editing_zipcode", value);
        }
    }

    /// <summary>
    /// If the customer is allowed to apply discount code, set it to true.
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowDiscountCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_discount_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_discount_code", value);
        }
    }

    /// <summary>
    /// If phone number is collected from customer, set it to rue
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowPhoneNumberCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_phone_number_collection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_phone_number_collection", value);
        }
    }

    /// <summary>
    /// If the customer is allowed to add tax id, set it to true
    ///
    /// <para>Default is true</para>
    /// </summary>
    public bool? AllowTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_tax_id", value);
        }
    }

    /// <summary>
    /// Set to true if a new customer object should be created. By default email
    /// is used to find an existing customer to attach the session to
    ///
    /// <para>Default is false</para>
    /// </summary>
    public bool? AlwaysCreateNewCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("always_create_new_customer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("always_create_new_customer", value);
        }
    }

    /// <summary>
    /// If true, redirects the customer immediately after payment completion
    ///
    /// <para>Default is false</para>
    /// </summary>
    public bool? RedirectImmediately
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("redirect_immediately");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("redirect_immediately", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowCurrencySelection;
        _ = this.AllowCustomerEditingCity;
        _ = this.AllowCustomerEditingCountry;
        _ = this.AllowCustomerEditingEmail;
        _ = this.AllowCustomerEditingName;
        _ = this.AllowCustomerEditingState;
        _ = this.AllowCustomerEditingStreet;
        _ = this.AllowCustomerEditingZipcode;
        _ = this.AllowDiscountCode;
        _ = this.AllowPhoneNumberCollection;
        _ = this.AllowTaxID;
        _ = this.AlwaysCreateNewCustomer;
        _ = this.RedirectImmediately;
    }

    public CheckoutSessionFlags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutSessionFlags(CheckoutSessionFlags checkoutSessionFlags)
        : base(checkoutSessionFlags) { }
#pragma warning restore CS8618

    public CheckoutSessionFlags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionFlags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutSessionFlagsFromRaw.FromRawUnchecked"/>
    public static CheckoutSessionFlags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutSessionFlagsFromRaw : IFromRawJson<CheckoutSessionFlags>
{
    /// <inheritdoc/>
    public CheckoutSessionFlags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckoutSessionFlags.FromRawUnchecked(rawData);
}
