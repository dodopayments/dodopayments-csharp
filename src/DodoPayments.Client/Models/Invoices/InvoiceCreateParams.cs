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
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// Creates a draft. A repeat with the same `Idempotency-Key` returns the first draft.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required ApiEnum<string, InvoiceCollectionMethod> CollectionMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, InvoiceCollectionMethod>>(
                "collection_method"
            );
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
    /// 1 to 50 items.
    /// </summary>
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <summary>
    /// The customer email is used when this is not set.
    /// </summary>
    public string? CustomerEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customer_email");
        }
        init { this._rawBodyData.Set("customer_email", value); }
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

    /// <summary>
    /// A custom due date. Do not send it with `payment_terms`.
    /// </summary>
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
    public Dunning? Dunning
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Dunning>("dunning");
        }
        init { this._rawBodyData.Set("dunning", value); }
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
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, MetadataItem>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Do not send it with `due_at`.
    /// </summary>
    public PaymentTerms? PaymentTerms
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PaymentTerms>("payment_terms");
        }
        init { this._rawBodyData.Set("payment_terms", value); }
    }

    /// <summary>
    /// `true` keeps a renewal draft for review before it finalises.
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

    public InvoiceCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceCreateParams(InvoiceCreateParams invoiceCreateParams)
        : base(invoiceCreateParams)
    {
        this._rawBodyData = new(invoiceCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvoiceCreateParams(
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
    InvoiceCreateParams(
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
    public static InvoiceCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InvoiceCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/billing/invoices")
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
/// A line that exists only on this invoice.
/// </summary>
[JsonConverter(typeof(ItemConverter))]
public record class Item : ModelBase
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

    public Item(CustomItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(ProductItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Item(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CustomItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `CustomItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom([NotNullWhen(true)] out CustomItem? value)
    {
        value = this.Value as CustomItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ProductItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProduct(out var value)) {
    ///     // `value` is of type `ProductItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickProduct([NotNullWhen(true)] out ProductItem? value)
    {
        value = this.Value as ProductItem;
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
    ///     (CustomItem value) =&gt; {...},
    ///     (ProductItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<CustomItem> custom, System::Action<ProductItem> product)
    {
        switch (this.Value)
        {
            case CustomItem value:
                custom(value);
                break;
            case ProductItem value:
                product(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Item"
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
    ///     (CustomItem value) =&gt; {...},
    ///     (ProductItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<CustomItem, T> custom, System::Func<ProductItem, T> product)
    {
        return this.Value switch
        {
            CustomItem value => custom(value),
            ProductItem value => product(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Item"
            ),
        };
    }

    public static implicit operator Item(CustomItem value) => new(value);

    public static implicit operator Item(ProductItem value) => new(value);

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
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Item");
        }
        this.Switch((custom) => custom.Validate(), (product) => product.Validate());
    }

    public virtual bool Equals(Item? other) =>
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
            CustomItem _ => 0,
            ProductItem _ => 1,
            _ => -1,
        };
    }
}

sealed class ItemConverter : JsonConverter<Item>
{
    public override Item? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CustomItem>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ProductItem>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A line that exists only on this invoice.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomItem, CustomItemFromRaw>))]
public sealed record class CustomItem : JsonModel
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

    public CustomItem()
    {
        this.Kind = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomItem(CustomItem customItem)
        : base(customItem) { }
#pragma warning restore CS8618

    public CustomItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Kind = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomItemFromRaw.FromRawUnchecked"/>
    public static CustomItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomItemFromRaw : IFromRawJson<CustomItem>
{
    /// <inheritdoc/>
    public CustomItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProductItem, ProductItemFromRaw>))]
public sealed record class ProductItem : JsonModel
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

    public IReadOnlyList<Subscriptions::AttachAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Subscriptions::AttachAddon>>(
                "addons"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscriptions::AttachAddon>?>(
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

    public ProductItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductItem(ProductItem productItem)
        : base(productItem) { }
#pragma warning restore CS8618

    public ProductItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductItemFromRaw.FromRawUnchecked"/>
    public static ProductItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductItemFromRaw : IFromRawJson<ProductItem>
{
    /// <inheritdoc/>
    public ProductItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductItem.FromRawUnchecked(rawData);
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
/// The reminder override of one invoice. The business settings fill the other dunning values.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Dunning, DunningFromRaw>))]
public sealed record class Dunning : JsonModel
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

    public Dunning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dunning(Dunning dunning)
        : base(dunning) { }
#pragma warning restore CS8618

    public Dunning(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dunning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DunningFromRaw.FromRawUnchecked"/>
    public static Dunning FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Dunning(bool remindersEnabled)
        : this()
    {
        this.RemindersEnabled = remindersEnabled;
    }
}

class DunningFromRaw : IFromRawJson<Dunning>
{
    /// <inheritdoc/>
    public Dunning FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dunning.FromRawUnchecked(rawData);
}

/// <summary>
/// Do not send it with `due_at`.
/// </summary>
[JsonConverter(typeof(PaymentTermsConverter))]
public record class PaymentTerms : ModelBase
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

    public PaymentTerms(Type value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PaymentTerms(UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PaymentTerms(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Type"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickObject(out var value)) {
    ///     // `value` is of type `Type`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickObject([NotNullWhen(true)] out Type? value)
    {
        value = this.Value as Type;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
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
    ///     (Type value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<Type> object_, System::Action<UnionMember1> unionMember1)
    {
        switch (this.Value)
        {
            case Type value:
                object_(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of PaymentTerms"
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
    ///     (Type value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Type, T> object_, System::Func<UnionMember1, T> unionMember1)
    {
        return this.Value switch
        {
            Type value => object_(value),
            UnionMember1 value => unionMember1(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of PaymentTerms"
            ),
        };
    }

    public static implicit operator PaymentTerms(Type value) => new(value);

    public static implicit operator PaymentTerms(UnionMember1 value) => new(value);

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
                "Data did not match any variant of PaymentTerms"
            );
        }
        this.Switch((object_) => object_.Validate(), (unionMember1) => unionMember1.Validate());
    }

    public virtual bool Equals(PaymentTerms? other) =>
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
            Type _ => 0,
            UnionMember1 _ => 1,
            _ => -1,
        };
    }
}

sealed class PaymentTermsConverter : JsonConverter<PaymentTerms?>
{
    public override PaymentTerms? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Type>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
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
        PaymentTerms? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(TypeConverter))]
public record class Type
{
    public JsonElement Element { get; private init; }

    public Type()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "due_on_receipt"
            }
            """
        );
    }

    internal Type(JsonElement element)
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
        if (this != new Type())
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for 'Type'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Type? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class TypeConverter : JsonConverter<Type>
{
    public override Type? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : JsonModel
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

    public UnionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember1(UnionMember1 unionMember1)
        : base(unionMember1) { }
#pragma warning restore CS8618

    public UnionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember1(int days)
        : this()
    {
        this.Days = days;
    }
}

class UnionMember1FromRaw : IFromRawJson<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember1.FromRawUnchecked(rawData);
}
