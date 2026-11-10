using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// Changes only the sent fields. `null` clears a field that can be empty.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvoiceID { get; init; }

    public required string IfMatch
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNotNullClass<string>("If-Match");
        }
        init { this._rawHeaderData.Set("If-Match", value); }
    }

    /// <summary>
    /// The billing address of an invoice request.
    /// </summary>
    public InvoiceUpdateParamsBillingAddress? BillingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoiceUpdateParamsBillingAddress>(
                "billing_address"
            );
        }
        init { this._rawBodyData.Set("billing_address", value); }
    }

    /// <summary>
    /// 10 addresses or fewer.
    /// </summary>
    public IReadOnlyList<string>? CcEmails
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("cc_emails");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "cc_emails",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, InvoiceCollectionMethod>? CollectionMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InvoiceCollectionMethod>>(
                "collection_method"
            );
        }
        init { this._rawBodyData.Set("collection_method", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    public string? CustomerEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_email");
        }
        init { this._rawBodyData.Set("customer_email", value); }
    }

    public string? CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_id");
        }
        init { this._rawBodyData.Set("customer_id", value); }
    }

    /// <summary>
    /// 20 codes or fewer.
    /// </summary>
    public IReadOnlyList<string>? DiscountIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("discount_ids");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "discount_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public System::DateTimeOffset? DueAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("due_at");
        }
        init { this._rawBodyData.Set("due_at", value); }
    }

    /// <summary>
    /// The reminder override of one invoice. The business settings fill the other
    /// dunning values.
    /// </summary>
    public InvoiceUpdateParamsDunning? Dunning
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoiceUpdateParamsDunning>("dunning");
        }
        init { this._rawBodyData.Set("dunning", value); }
    }

    /// <summary>
    /// 1 to 50 items.
    /// </summary>
    public IReadOnlyList<InvoiceUpdateParamsItem>? Items
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<InvoiceUpdateParamsItem>>(
                "items"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<InvoiceUpdateParamsItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Memo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("memo");
        }
        init { this._rawBodyData.Set("memo", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Values can be string, integer, number, or boolean.
    /// </summary>
    public IReadOnlyDictionary<string, MetadataItem>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, MetadataItem>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, MetadataItem>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public InvoiceUpdateParamsPaymentTerms? PaymentTerms
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoiceUpdateParamsPaymentTerms>(
                "payment_terms"
            );
        }
        init { this._rawBodyData.Set("payment_terms", value); }
    }

    public bool? ReviewRequired
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("review_required");
        }
        init { this._rawBodyData.Set("review_required", value); }
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

    public InvoiceUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParams(InvoiceUpdateParams invoiceUpdateParams)
        : base(invoiceUpdateParams)
    {
        this.InvoiceID = invoiceUpdateParams.InvoiceID;

        this._rawBodyData = new(invoiceUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvoiceUpdateParams(
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
    InvoiceUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string invoiceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InvoiceID = invoiceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InvoiceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string invoiceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            invoiceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InvoiceID"] = JsonSerializer.SerializeToElement(this.InvoiceID),
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

    public virtual bool Equals(InvoiceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InvoiceID?.Equals(other.InvoiceID) ?? other.InvoiceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/billing/invoices/{0}", this.InvoiceID)
        )
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
[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceUpdateParamsBillingAddress,
        InvoiceUpdateParamsBillingAddressFromRaw
    >)
)]
public sealed record class InvoiceUpdateParamsBillingAddress : JsonModel
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

    public InvoiceUpdateParamsBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParamsBillingAddress(
        InvoiceUpdateParamsBillingAddress invoiceUpdateParamsBillingAddress
    )
        : base(invoiceUpdateParamsBillingAddress) { }
#pragma warning restore CS8618

    public InvoiceUpdateParamsBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceUpdateParamsBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceUpdateParamsBillingAddressFromRaw.FromRawUnchecked"/>
    public static InvoiceUpdateParamsBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceUpdateParamsBillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

class InvoiceUpdateParamsBillingAddressFromRaw : IFromRawJson<InvoiceUpdateParamsBillingAddress>
{
    /// <inheritdoc/>
    public InvoiceUpdateParamsBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceUpdateParamsBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The reminder override of one invoice. The business settings fill the other dunning values.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InvoiceUpdateParamsDunning, InvoiceUpdateParamsDunningFromRaw>)
)]
public sealed record class InvoiceUpdateParamsDunning : JsonModel
{
    public required bool RemindersEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("reminders_enabled");
        }
        init { this._rawData.Set("reminders_enabled", value); }
    }

    /// <summary>
    /// Days from the due date. A negative value sends the reminder before the due date.
    /// </summary>
    public IReadOnlyList<int>? OffsetsDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<int>>("offsets_days");
        }
        init
        {
            this._rawData.Set<ImmutableArray<int>?>(
                "offsets_days",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RemindersEnabled;
        _ = this.OffsetsDays;
    }

    public InvoiceUpdateParamsDunning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParamsDunning(InvoiceUpdateParamsDunning invoiceUpdateParamsDunning)
        : base(invoiceUpdateParamsDunning) { }
#pragma warning restore CS8618

    public InvoiceUpdateParamsDunning(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceUpdateParamsDunning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceUpdateParamsDunningFromRaw.FromRawUnchecked"/>
    public static InvoiceUpdateParamsDunning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceUpdateParamsDunning(bool remindersEnabled)
        : this()
    {
        this.RemindersEnabled = remindersEnabled;
    }
}

class InvoiceUpdateParamsDunningFromRaw : IFromRawJson<InvoiceUpdateParamsDunning>
{
    /// <inheritdoc/>
    public InvoiceUpdateParamsDunning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceUpdateParamsDunning.FromRawUnchecked(rawData);
}

/// <summary>
/// A line that exists only on this invoice.
/// </summary>
[JsonConverter(typeof(InvoiceUpdateParamsItemConverter))]
public record class InvoiceUpdateParamsItem : ModelBase
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

    public int? Quantity
    {
        get { return Match<int?>(custom: (x) => x.Quantity, product: (x) => x.Quantity); }
    }

    public InvoiceUpdateParamsItem(
        InvoiceUpdateParamsItemCustomItem value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceUpdateParamsItem(
        InvoiceUpdateParamsItemProductItem value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceUpdateParamsItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoiceUpdateParamsItemCustomItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `InvoiceUpdateParamsItemCustomItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom([NotNullWhen(true)] out InvoiceUpdateParamsItemCustomItem? value)
    {
        value = this.Value as InvoiceUpdateParamsItemCustomItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoiceUpdateParamsItemProductItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProduct(out var value)) {
    ///     // `value` is of type `InvoiceUpdateParamsItemProductItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickProduct([NotNullWhen(true)] out InvoiceUpdateParamsItemProductItem? value)
    {
        value = this.Value as InvoiceUpdateParamsItemProductItem;
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
    ///     (InvoiceUpdateParamsItemCustomItem value) =&gt; {...},
    ///     (InvoiceUpdateParamsItemProductItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<InvoiceUpdateParamsItemCustomItem> custom,
        System::Action<InvoiceUpdateParamsItemProductItem> product
    )
    {
        switch (this.Value)
        {
            case InvoiceUpdateParamsItemCustomItem value:
                custom(value);
                break;
            case InvoiceUpdateParamsItemProductItem value:
                product(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of InvoiceUpdateParamsItem"
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
    ///     (InvoiceUpdateParamsItemCustomItem value) =&gt; {...},
    ///     (InvoiceUpdateParamsItemProductItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<InvoiceUpdateParamsItemCustomItem, T> custom,
        System::Func<InvoiceUpdateParamsItemProductItem, T> product
    )
    {
        return this.Value switch
        {
            InvoiceUpdateParamsItemCustomItem value => custom(value),
            InvoiceUpdateParamsItemProductItem value => product(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of InvoiceUpdateParamsItem"
            ),
        };
    }

    public static implicit operator InvoiceUpdateParamsItem(
        InvoiceUpdateParamsItemCustomItem value
    ) => new(value);

    public static implicit operator InvoiceUpdateParamsItem(
        InvoiceUpdateParamsItemProductItem value
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
                "Data did not match any variant of InvoiceUpdateParamsItem"
            );
        }
        this.Switch((custom) => custom.Validate(), (product) => product.Validate());
    }

    public virtual bool Equals(InvoiceUpdateParamsItem? other) =>
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
            InvoiceUpdateParamsItemCustomItem _ => 0,
            InvoiceUpdateParamsItemProductItem _ => 1,
            _ => -1,
        };
    }
}

sealed class InvoiceUpdateParamsItemConverter : JsonConverter<InvoiceUpdateParamsItem>
{
    public override InvoiceUpdateParamsItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItemCustomItem>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<InvoiceUpdateParamsItemProductItem>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceUpdateParamsItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A line that exists only on this invoice.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceUpdateParamsItemCustomItem,
        InvoiceUpdateParamsItemCustomItemFromRaw
    >)
)]
public sealed record class InvoiceUpdateParamsItemCustomItem : JsonModel
{
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public JsonElement Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// Represents the different categories of taxation applicable to various products
    /// and services.
    /// </summary>
    public required ApiEnum<string, TaxCategory> TaxCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawData.Set("tax_category", value); }
    }

    /// <summary>
    /// The price in the smallest currency unit.
    /// </summary>
    public required int UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// The default is 1.
    /// </summary>
    public int? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        if (!JsonElement.DeepEquals(this.Kind, JsonSerializer.SerializeToElement("custom")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
        this.TaxCategory.Validate();
        _ = this.UnitAmount;
        _ = this.Quantity;
    }

    public InvoiceUpdateParamsItemCustomItem()
    {
        this.Kind = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParamsItemCustomItem(
        InvoiceUpdateParamsItemCustomItem invoiceUpdateParamsItemCustomItem
    )
        : base(invoiceUpdateParamsItemCustomItem) { }
#pragma warning restore CS8618

    public InvoiceUpdateParamsItemCustomItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Kind = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceUpdateParamsItemCustomItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceUpdateParamsItemCustomItemFromRaw.FromRawUnchecked"/>
    public static InvoiceUpdateParamsItemCustomItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceUpdateParamsItemCustomItemFromRaw : IFromRawJson<InvoiceUpdateParamsItemCustomItem>
{
    /// <inheritdoc/>
    public InvoiceUpdateParamsItemCustomItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceUpdateParamsItemCustomItem.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceUpdateParamsItemProductItem,
        InvoiceUpdateParamsItemProductItemFromRaw
    >)
)]
public sealed record class InvoiceUpdateParamsItemProductItem : JsonModel
{
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    public IReadOnlyList<AttachAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AttachAddon>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttachAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductID;
        _ = this.Quantity;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
    }

    public InvoiceUpdateParamsItemProductItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParamsItemProductItem(
        InvoiceUpdateParamsItemProductItem invoiceUpdateParamsItemProductItem
    )
        : base(invoiceUpdateParamsItemProductItem) { }
#pragma warning restore CS8618

    public InvoiceUpdateParamsItemProductItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceUpdateParamsItemProductItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceUpdateParamsItemProductItemFromRaw.FromRawUnchecked"/>
    public static InvoiceUpdateParamsItemProductItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceUpdateParamsItemProductItemFromRaw : IFromRawJson<InvoiceUpdateParamsItemProductItem>
{
    /// <inheritdoc/>
    public InvoiceUpdateParamsItemProductItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceUpdateParamsItemProductItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InvoiceUpdateParamsPaymentTermsConverter))]
public record class InvoiceUpdateParamsPaymentTerms : ModelBase
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

    public InvoiceUpdateParamsPaymentTerms(
        InvoiceUpdateParamsPaymentTermsDueOnReceipt value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceUpdateParamsPaymentTerms(
        InvoiceUpdateParamsPaymentTermsNet value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceUpdateParamsPaymentTerms(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoiceUpdateParamsPaymentTermsDueOnReceipt"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDueOnReceipt(out var value)) {
    ///     // `value` is of type `InvoiceUpdateParamsPaymentTermsDueOnReceipt`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDueOnReceipt(
        [NotNullWhen(true)] out InvoiceUpdateParamsPaymentTermsDueOnReceipt? value
    )
    {
        value = this.Value as InvoiceUpdateParamsPaymentTermsDueOnReceipt;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoiceUpdateParamsPaymentTermsNet"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNet(out var value)) {
    ///     // `value` is of type `InvoiceUpdateParamsPaymentTermsNet`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNet([NotNullWhen(true)] out InvoiceUpdateParamsPaymentTermsNet? value)
    {
        value = this.Value as InvoiceUpdateParamsPaymentTermsNet;
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
    ///     (InvoiceUpdateParamsPaymentTermsDueOnReceipt value) =&gt; {...},
    ///     (InvoiceUpdateParamsPaymentTermsNet value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<InvoiceUpdateParamsPaymentTermsDueOnReceipt> dueOnReceipt,
        System::Action<InvoiceUpdateParamsPaymentTermsNet> net
    )
    {
        switch (this.Value)
        {
            case InvoiceUpdateParamsPaymentTermsDueOnReceipt value:
                dueOnReceipt(value);
                break;
            case InvoiceUpdateParamsPaymentTermsNet value:
                net(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of InvoiceUpdateParamsPaymentTerms"
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
    ///     (InvoiceUpdateParamsPaymentTermsDueOnReceipt value) =&gt; {...},
    ///     (InvoiceUpdateParamsPaymentTermsNet value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<InvoiceUpdateParamsPaymentTermsDueOnReceipt, T> dueOnReceipt,
        System::Func<InvoiceUpdateParamsPaymentTermsNet, T> net
    )
    {
        return this.Value switch
        {
            InvoiceUpdateParamsPaymentTermsDueOnReceipt value => dueOnReceipt(value),
            InvoiceUpdateParamsPaymentTermsNet value => net(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of InvoiceUpdateParamsPaymentTerms"
            ),
        };
    }

    public static implicit operator InvoiceUpdateParamsPaymentTerms(
        InvoiceUpdateParamsPaymentTermsDueOnReceipt value
    ) => new(value);

    public static implicit operator InvoiceUpdateParamsPaymentTerms(
        InvoiceUpdateParamsPaymentTermsNet value
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
                "Data did not match any variant of InvoiceUpdateParamsPaymentTerms"
            );
        }
        this.Switch((dueOnReceipt) => dueOnReceipt.Validate(), (net) => net.Validate());
    }

    public virtual bool Equals(InvoiceUpdateParamsPaymentTerms? other) =>
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
            InvoiceUpdateParamsPaymentTermsDueOnReceipt _ => 0,
            InvoiceUpdateParamsPaymentTermsNet _ => 1,
            _ => -1,
        };
    }
}

sealed class InvoiceUpdateParamsPaymentTermsConverter
    : JsonConverter<InvoiceUpdateParamsPaymentTerms?>
{
    public override InvoiceUpdateParamsPaymentTerms? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                        JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsDueOnReceipt>(
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
                        JsonSerializer.Deserialize<InvoiceUpdateParamsPaymentTermsNet>(
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
                return new InvoiceUpdateParamsPaymentTerms(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceUpdateParamsPaymentTerms? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(InvoiceUpdateParamsPaymentTermsDueOnReceiptConverter))]
public record class InvoiceUpdateParamsPaymentTermsDueOnReceipt
{
    public JsonElement Element { get; private init; }

    public InvoiceUpdateParamsPaymentTermsDueOnReceipt()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "due_on_receipt"
            }
            """
        );
    }

    internal InvoiceUpdateParamsPaymentTermsDueOnReceipt(JsonElement element)
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
        if (this != new InvoiceUpdateParamsPaymentTermsDueOnReceipt())
        {
            throw new DodoPaymentsInvalidDataException(
                "Invalid value given for 'InvoiceUpdateParamsPaymentTermsDueOnReceipt'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(InvoiceUpdateParamsPaymentTermsDueOnReceipt? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class InvoiceUpdateParamsPaymentTermsDueOnReceiptConverter
    : JsonConverter<InvoiceUpdateParamsPaymentTermsDueOnReceipt>
{
    public override InvoiceUpdateParamsPaymentTermsDueOnReceipt? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceUpdateParamsPaymentTermsDueOnReceipt value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceUpdateParamsPaymentTermsNet,
        InvoiceUpdateParamsPaymentTermsNetFromRaw
    >)
)]
public sealed record class InvoiceUpdateParamsPaymentTermsNet : JsonModel
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

    public InvoiceUpdateParamsPaymentTermsNet()
    {
        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParamsPaymentTermsNet(
        InvoiceUpdateParamsPaymentTermsNet invoiceUpdateParamsPaymentTermsNet
    )
        : base(invoiceUpdateParamsPaymentTermsNet) { }
#pragma warning restore CS8618

    public InvoiceUpdateParamsPaymentTermsNet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceUpdateParamsPaymentTermsNet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceUpdateParamsPaymentTermsNetFromRaw.FromRawUnchecked"/>
    public static InvoiceUpdateParamsPaymentTermsNet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceUpdateParamsPaymentTermsNet(int days)
        : this()
    {
        this.Days = days;
    }
}

class InvoiceUpdateParamsPaymentTermsNetFromRaw : IFromRawJson<InvoiceUpdateParamsPaymentTermsNet>
{
    /// <inheritdoc/>
    public InvoiceUpdateParamsPaymentTermsNet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceUpdateParamsPaymentTermsNet.FromRawUnchecked(rawData);
}
