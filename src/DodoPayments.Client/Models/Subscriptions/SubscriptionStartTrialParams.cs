using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using Invoices = DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Creates an invoice-led subscription and a paid $0 invoice for the trial. The first
/// invoice after the trial bills at `trial_ends_at`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionStartTrialParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required ApiEnum<string, Invoices::InvoiceCollectionMethod> CollectionMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, Invoices::InvoiceCollectionMethod>
            >("collection_method");
        }
        init { this._rawBodyData.Set("collection_method", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawBodyData.Set("customer_id", value); }
    }

    /// <summary>
    /// A recurring product.
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("product_id");
        }
        init { this._rawBodyData.Set("product_id", value); }
    }

    /// <summary>
    /// The billing address of an invoice request.
    /// </summary>
    public BillingAddress? BillingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingAddress>("billing_address");
        }
        init { this._rawBodyData.Set("billing_address", value); }
    }

    /// <summary>
    /// A saved card of the customer. Automatic charge needs it.
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payment_method_id");
        }
        init { this._rawBodyData.Set("payment_method_id", value); }
    }

    /// <summary>
    /// The terms of the invoices after the trial.
    /// </summary>
    public SubscriptionStartTrialParamsPaymentTerms? PaymentTerms
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionStartTrialParamsPaymentTerms>(
                "payment_terms"
            );
        }
        init { this._rawBodyData.Set("payment_terms", value); }
    }

    public int? Quantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("quantity", value);
        }
    }

    /// <summary>
    /// `true` keeps each renewal draft for review before it finalises.
    /// </summary>
    public bool? ReviewRequired
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("review_required");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("review_required", value);
        }
    }

    public string? TaxID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tax_id");
        }
        init { this._rawBodyData.Set("tax_id", value); }
    }

    /// <summary>
    /// 1 to 730 days. When this is not set, the product trial applies and the trial
    /// misuse check runs.
    /// </summary>
    public int? TrialPeriodDays
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("trial_period_days");
        }
        init { this._rawBodyData.Set("trial_period_days", value); }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public SubscriptionStartTrialParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionStartTrialParams(SubscriptionStartTrialParams subscriptionStartTrialParams)
        : base(subscriptionStartTrialParams)
    {
        this._rawBodyData = new(subscriptionStartTrialParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionStartTrialParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionStartTrialParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionStartTrialParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionStartTrialParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/billing/subscriptions")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The billing address of an invoice request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : JsonModel
{
    /// <summary>
    /// Two-letter ISO country code (ISO 3166-1 alpha-2)
    /// </summary>
    public required ApiEnum<string, CountryCode> Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CountryCode>>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    public string? Zipcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("zipcode");
        }
        init { this._rawData.Set("zipcode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Country.Validate();
        _ = this.City;
        _ = this.State;
        _ = this.Street;
        _ = this.Zipcode;
    }

    public BillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }
#pragma warning restore CS8618

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingAddressFromRaw.FromRawUnchecked"/>
    public static BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

class BillingAddressFromRaw : IFromRawJson<BillingAddress>
{
    /// <inheritdoc/>
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The terms of the invoices after the trial.
/// </summary>
[JsonConverter(typeof(SubscriptionStartTrialParamsPaymentTermsConverter))]
public record class SubscriptionStartTrialParamsPaymentTerms : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionStartTrialParamsPaymentTerms(
        SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionStartTrialParamsPaymentTerms(
        SubscriptionStartTrialParamsPaymentTermsNet value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionStartTrialParamsPaymentTerms(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionStartTrialParamsPaymentTermsDueOnReceipt"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDueOnReceipt(out var value)) {
    ///     // `value` is of type `SubscriptionStartTrialParamsPaymentTermsDueOnReceipt`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDueOnReceipt(
        [NotNullWhen(true)] out SubscriptionStartTrialParamsPaymentTermsDueOnReceipt? value
    )
    {
        value = this.Value as SubscriptionStartTrialParamsPaymentTermsDueOnReceipt;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SubscriptionStartTrialParamsPaymentTermsNet"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNet(out var value)) {
    ///     // `value` is of type `SubscriptionStartTrialParamsPaymentTermsNet`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNet(
        [NotNullWhen(true)] out SubscriptionStartTrialParamsPaymentTermsNet? value
    )
    {
        value = this.Value as SubscriptionStartTrialParamsPaymentTermsNet;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value) =&gt; {...},
    ///     (SubscriptionStartTrialParamsPaymentTermsNet value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt> dueOnReceipt,
        Action<SubscriptionStartTrialParamsPaymentTermsNet> net
    )
    {
        switch (this.Value)
        {
            case SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value:
                dueOnReceipt(value);
                break;
            case SubscriptionStartTrialParamsPaymentTermsNet value:
                net(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of SubscriptionStartTrialParamsPaymentTerms"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value) =&gt; {...},
    ///     (SubscriptionStartTrialParamsPaymentTermsNet value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt, T> dueOnReceipt,
        Func<SubscriptionStartTrialParamsPaymentTermsNet, T> net
    )
    {
        return this.Value switch
        {
            SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value => dueOnReceipt(value),
            SubscriptionStartTrialParamsPaymentTermsNet value => net(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of SubscriptionStartTrialParamsPaymentTerms"
            ),
        };
    }

    public static implicit operator SubscriptionStartTrialParamsPaymentTerms(
        SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value
    ) => new(value);

    public static implicit operator SubscriptionStartTrialParamsPaymentTerms(
        SubscriptionStartTrialParamsPaymentTermsNet value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of SubscriptionStartTrialParamsPaymentTerms"
            );
        }
        this.Switch((dueOnReceipt) => dueOnReceipt.Validate(), (net) => net.Validate());
    }

    public virtual bool Equals(SubscriptionStartTrialParamsPaymentTerms? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SubscriptionStartTrialParamsPaymentTermsDueOnReceipt _ => 0,
            SubscriptionStartTrialParamsPaymentTermsNet _ => 1,
            _ => -1,
        };
    }
}

sealed class SubscriptionStartTrialParamsPaymentTermsConverter
    : JsonConverter<SubscriptionStartTrialParamsPaymentTerms?>
{
    public override SubscriptionStartTrialParamsPaymentTerms? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "due_on_receipt":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "net":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<SubscriptionStartTrialParamsPaymentTermsNet>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new SubscriptionStartTrialParamsPaymentTerms(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStartTrialParamsPaymentTerms? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(SubscriptionStartTrialParamsPaymentTermsDueOnReceiptConverter))]
public record class SubscriptionStartTrialParamsPaymentTermsDueOnReceipt
{
    public JsonElement Element { get; private init; }

    public SubscriptionStartTrialParamsPaymentTermsDueOnReceipt()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "due_on_receipt"
            }
            """
        );
    }

    internal SubscriptionStartTrialParamsPaymentTermsDueOnReceipt(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new SubscriptionStartTrialParamsPaymentTermsDueOnReceipt())
        {
            throw new DodoPaymentsInvalidDataException(
                "Invalid value given for 'SubscriptionStartTrialParamsPaymentTermsDueOnReceipt'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(SubscriptionStartTrialParamsPaymentTermsDueOnReceipt? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class SubscriptionStartTrialParamsPaymentTermsDueOnReceiptConverter
    : JsonConverter<SubscriptionStartTrialParamsPaymentTermsDueOnReceipt>
{
    public override SubscriptionStartTrialParamsPaymentTermsDueOnReceipt? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStartTrialParamsPaymentTermsDueOnReceipt value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionStartTrialParamsPaymentTermsNet,
        SubscriptionStartTrialParamsPaymentTermsNetFromRaw
    >)
)]
public sealed record class SubscriptionStartTrialParamsPaymentTermsNet : JsonModel
{
    public required int Days
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("days");
        }
        init { this._rawData.Set("days", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Days;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("net")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public SubscriptionStartTrialParamsPaymentTermsNet()
    {
        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionStartTrialParamsPaymentTermsNet(
        SubscriptionStartTrialParamsPaymentTermsNet subscriptionStartTrialParamsPaymentTermsNet
    )
        : base(subscriptionStartTrialParamsPaymentTermsNet) { }
#pragma warning restore CS8618

    public SubscriptionStartTrialParamsPaymentTermsNet(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionStartTrialParamsPaymentTermsNet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionStartTrialParamsPaymentTermsNetFromRaw.FromRawUnchecked"/>
    public static SubscriptionStartTrialParamsPaymentTermsNet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionStartTrialParamsPaymentTermsNet(int days)
        : this()
    {
        this.Days = days;
    }
}

class SubscriptionStartTrialParamsPaymentTermsNetFromRaw
    : IFromRawJson<SubscriptionStartTrialParamsPaymentTermsNet>
{
    /// <inheritdoc/>
    public SubscriptionStartTrialParamsPaymentTermsNet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionStartTrialParamsPaymentTermsNet.FromRawUnchecked(rawData);
}
