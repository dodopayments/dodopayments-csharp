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
/// Prices the body as a draft and returns it. No row is saved.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoicePreviewParams : ParamsBase
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
    public required IReadOnlyList<InvoicePreviewParamsItem> Items
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<InvoicePreviewParamsItem>>(
                "items"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<InvoicePreviewParamsItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The preview body. `json` returns the invoice JSON. `pdf` returns the PDF
    /// with a draft mark. `email` returns the HTML of the invoice email. A preview
    /// saves no row.
    /// </summary>
    public ApiEnum<string, Format>? Format
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Format>>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("format", value);
        }
    }

    /// <summary>
    /// The billing address of an invoice request.
    /// </summary>
    public InvoicePreviewParamsBillingAddress? BillingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoicePreviewParamsBillingAddress>(
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
    public InvoicePreviewParamsDunning? Dunning
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoicePreviewParamsDunning>("dunning");
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
    public InvoicePreviewParamsPaymentTerms? PaymentTerms
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoicePreviewParamsPaymentTerms>(
                "payment_terms"
            );
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

    public InvoicePreviewParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoicePreviewParams(InvoicePreviewParams invoicePreviewParams)
        : base(invoicePreviewParams)
    {
        this._rawBodyData = new(invoicePreviewParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvoicePreviewParams(
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
    InvoicePreviewParams(
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
    public static InvoicePreviewParams FromRawUnchecked(
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

    public virtual bool Equals(InvoicePreviewParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/billing/invoices/preview"
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
/// A line that exists only on this invoice.
/// </summary>
[JsonConverter(typeof(InvoicePreviewParamsItemConverter))]
public record class InvoicePreviewParamsItem : ModelBase
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

    public InvoicePreviewParamsItem(
        InvoicePreviewParamsItemCustomItem value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoicePreviewParamsItem(
        InvoicePreviewParamsItemProductItem value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoicePreviewParamsItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoicePreviewParamsItemCustomItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `InvoicePreviewParamsItemCustomItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom([NotNullWhen(true)] out InvoicePreviewParamsItemCustomItem? value)
    {
        value = this.Value as InvoicePreviewParamsItemCustomItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoicePreviewParamsItemProductItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProduct(out var value)) {
    ///     // `value` is of type `InvoicePreviewParamsItemProductItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickProduct([NotNullWhen(true)] out InvoicePreviewParamsItemProductItem? value)
    {
        value = this.Value as InvoicePreviewParamsItemProductItem;
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
    ///     (InvoicePreviewParamsItemCustomItem value) =&gt; {...},
    ///     (InvoicePreviewParamsItemProductItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<InvoicePreviewParamsItemCustomItem> custom,
        System::Action<InvoicePreviewParamsItemProductItem> product
    )
    {
        switch (this.Value)
        {
            case InvoicePreviewParamsItemCustomItem value:
                custom(value);
                break;
            case InvoicePreviewParamsItemProductItem value:
                product(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of InvoicePreviewParamsItem"
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
    ///     (InvoicePreviewParamsItemCustomItem value) =&gt; {...},
    ///     (InvoicePreviewParamsItemProductItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<InvoicePreviewParamsItemCustomItem, T> custom,
        System::Func<InvoicePreviewParamsItemProductItem, T> product
    )
    {
        return this.Value switch
        {
            InvoicePreviewParamsItemCustomItem value => custom(value),
            InvoicePreviewParamsItemProductItem value => product(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of InvoicePreviewParamsItem"
            ),
        };
    }

    public static implicit operator InvoicePreviewParamsItem(
        InvoicePreviewParamsItemCustomItem value
    ) => new(value);

    public static implicit operator InvoicePreviewParamsItem(
        InvoicePreviewParamsItemProductItem value
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
                "Data did not match any variant of InvoicePreviewParamsItem"
            );
        }
        this.Switch((custom) => custom.Validate(), (product) => product.Validate());
    }

    public virtual bool Equals(InvoicePreviewParamsItem? other) =>
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
            InvoicePreviewParamsItemCustomItem _ => 0,
            InvoicePreviewParamsItemProductItem _ => 1,
            _ => -1,
        };
    }
}

sealed class InvoicePreviewParamsItemConverter : JsonConverter<InvoicePreviewParamsItem>
{
    public override InvoicePreviewParamsItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<InvoicePreviewParamsItemCustomItem>(
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
            var deserialized = JsonSerializer.Deserialize<InvoicePreviewParamsItemProductItem>(
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
        InvoicePreviewParamsItem value,
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
        InvoicePreviewParamsItemCustomItem,
        InvoicePreviewParamsItemCustomItemFromRaw
    >)
)]
public sealed record class InvoicePreviewParamsItemCustomItem : JsonModel
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

    public InvoicePreviewParamsItemCustomItem()
    {
        this.Kind = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoicePreviewParamsItemCustomItem(
        InvoicePreviewParamsItemCustomItem invoicePreviewParamsItemCustomItem
    )
        : base(invoicePreviewParamsItemCustomItem) { }
#pragma warning restore CS8618

    public InvoicePreviewParamsItemCustomItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Kind = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoicePreviewParamsItemCustomItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoicePreviewParamsItemCustomItemFromRaw.FromRawUnchecked"/>
    public static InvoicePreviewParamsItemCustomItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoicePreviewParamsItemCustomItemFromRaw : IFromRawJson<InvoicePreviewParamsItemCustomItem>
{
    /// <inheritdoc/>
    public InvoicePreviewParamsItemCustomItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoicePreviewParamsItemCustomItem.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoicePreviewParamsItemProductItem,
        InvoicePreviewParamsItemProductItemFromRaw
    >)
)]
public sealed record class InvoicePreviewParamsItemProductItem : JsonModel
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

    public InvoicePreviewParamsItemProductItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoicePreviewParamsItemProductItem(
        InvoicePreviewParamsItemProductItem invoicePreviewParamsItemProductItem
    )
        : base(invoicePreviewParamsItemProductItem) { }
#pragma warning restore CS8618

    public InvoicePreviewParamsItemProductItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoicePreviewParamsItemProductItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoicePreviewParamsItemProductItemFromRaw.FromRawUnchecked"/>
    public static InvoicePreviewParamsItemProductItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoicePreviewParamsItemProductItemFromRaw : IFromRawJson<InvoicePreviewParamsItemProductItem>
{
    /// <inheritdoc/>
    public InvoicePreviewParamsItemProductItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoicePreviewParamsItemProductItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The preview body. `json` returns the invoice JSON. `pdf` returns the PDF with
/// a draft mark. `email` returns the HTML of the invoice email. A preview saves no row.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Json,
    Pdf,
    Email,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => Format.Json,
            "pdf" => Format.Pdf,
            "email" => Format.Email,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Json => "json",
                Format.Pdf => "pdf",
                Format.Email => "email",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The billing address of an invoice request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InvoicePreviewParamsBillingAddress,
        InvoicePreviewParamsBillingAddressFromRaw
    >)
)]
public sealed record class InvoicePreviewParamsBillingAddress : JsonModel
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

    public InvoicePreviewParamsBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoicePreviewParamsBillingAddress(
        InvoicePreviewParamsBillingAddress invoicePreviewParamsBillingAddress
    )
        : base(invoicePreviewParamsBillingAddress) { }
#pragma warning restore CS8618

    public InvoicePreviewParamsBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoicePreviewParamsBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoicePreviewParamsBillingAddressFromRaw.FromRawUnchecked"/>
    public static InvoicePreviewParamsBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoicePreviewParamsBillingAddress(ApiEnum<string, CountryCode> country)
        : this()
    {
        this.Country = country;
    }
}

class InvoicePreviewParamsBillingAddressFromRaw : IFromRawJson<InvoicePreviewParamsBillingAddress>
{
    /// <inheritdoc/>
    public InvoicePreviewParamsBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoicePreviewParamsBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The reminder override of one invoice. The business settings fill the other dunning values.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InvoicePreviewParamsDunning, InvoicePreviewParamsDunningFromRaw>)
)]
public sealed record class InvoicePreviewParamsDunning : JsonModel
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

    public InvoicePreviewParamsDunning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoicePreviewParamsDunning(InvoicePreviewParamsDunning invoicePreviewParamsDunning)
        : base(invoicePreviewParamsDunning) { }
#pragma warning restore CS8618

    public InvoicePreviewParamsDunning(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoicePreviewParamsDunning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoicePreviewParamsDunningFromRaw.FromRawUnchecked"/>
    public static InvoicePreviewParamsDunning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoicePreviewParamsDunning(bool remindersEnabled)
        : this()
    {
        this.RemindersEnabled = remindersEnabled;
    }
}

class InvoicePreviewParamsDunningFromRaw : IFromRawJson<InvoicePreviewParamsDunning>
{
    /// <inheritdoc/>
    public InvoicePreviewParamsDunning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoicePreviewParamsDunning.FromRawUnchecked(rawData);
}

/// <summary>
/// Do not send it with `due_at`.
/// </summary>
[JsonConverter(typeof(InvoicePreviewParamsPaymentTermsConverter))]
public record class InvoicePreviewParamsPaymentTerms : ModelBase
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

    public InvoicePreviewParamsPaymentTerms(
        InvoicePreviewParamsPaymentTermsType value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoicePreviewParamsPaymentTerms(
        InvoicePreviewParamsPaymentTermsUnionMember1 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoicePreviewParamsPaymentTerms(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoicePreviewParamsPaymentTermsType"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickObject(out var value)) {
    ///     // `value` is of type `InvoicePreviewParamsPaymentTermsType`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickObject([NotNullWhen(true)] out InvoicePreviewParamsPaymentTermsType? value)
    {
        value = this.Value as InvoicePreviewParamsPaymentTermsType;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoicePreviewParamsPaymentTermsUnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInvoicePreviewParamsPaymentTermsUnionMember1(out var value)) {
    ///     // `value` is of type `InvoicePreviewParamsPaymentTermsUnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInvoicePreviewParamsPaymentTermsUnionMember1(
        [NotNullWhen(true)] out InvoicePreviewParamsPaymentTermsUnionMember1? value
    )
    {
        value = this.Value as InvoicePreviewParamsPaymentTermsUnionMember1;
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
    ///     (InvoicePreviewParamsPaymentTermsType value) =&gt; {...},
    ///     (InvoicePreviewParamsPaymentTermsUnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<InvoicePreviewParamsPaymentTermsType> object_,
        System::Action<InvoicePreviewParamsPaymentTermsUnionMember1> invoicePreviewParamsPaymentTermsUnionMember1
    )
    {
        switch (this.Value)
        {
            case InvoicePreviewParamsPaymentTermsType value:
                object_(value);
                break;
            case InvoicePreviewParamsPaymentTermsUnionMember1 value:
                invoicePreviewParamsPaymentTermsUnionMember1(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of InvoicePreviewParamsPaymentTerms"
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
    ///     (InvoicePreviewParamsPaymentTermsType value) =&gt; {...},
    ///     (InvoicePreviewParamsPaymentTermsUnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<InvoicePreviewParamsPaymentTermsType, T> object_,
        System::Func<
            InvoicePreviewParamsPaymentTermsUnionMember1,
            T
        > invoicePreviewParamsPaymentTermsUnionMember1
    )
    {
        return this.Value switch
        {
            InvoicePreviewParamsPaymentTermsType value => object_(value),
            InvoicePreviewParamsPaymentTermsUnionMember1 value =>
                invoicePreviewParamsPaymentTermsUnionMember1(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of InvoicePreviewParamsPaymentTerms"
            ),
        };
    }

    public static implicit operator InvoicePreviewParamsPaymentTerms(
        InvoicePreviewParamsPaymentTermsType value
    ) => new(value);

    public static implicit operator InvoicePreviewParamsPaymentTerms(
        InvoicePreviewParamsPaymentTermsUnionMember1 value
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
                "Data did not match any variant of InvoicePreviewParamsPaymentTerms"
            );
        }
        this.Switch(
            (object_) => object_.Validate(),
            (invoicePreviewParamsPaymentTermsUnionMember1) =>
                invoicePreviewParamsPaymentTermsUnionMember1.Validate()
        );
    }

    public virtual bool Equals(InvoicePreviewParamsPaymentTerms? other) =>
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
            InvoicePreviewParamsPaymentTermsType _ => 0,
            InvoicePreviewParamsPaymentTermsUnionMember1 _ => 1,
            _ => -1,
        };
    }
}

sealed class InvoicePreviewParamsPaymentTermsConverter
    : JsonConverter<InvoicePreviewParamsPaymentTerms?>
{
    public override InvoicePreviewParamsPaymentTerms? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<InvoicePreviewParamsPaymentTermsType>(
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
            var deserialized =
                JsonSerializer.Deserialize<InvoicePreviewParamsPaymentTermsUnionMember1>(
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
        InvoicePreviewParamsPaymentTerms? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(InvoicePreviewParamsPaymentTermsTypeConverter))]
public record class InvoicePreviewParamsPaymentTermsType
{
    public JsonElement Element { get; private init; }

    public InvoicePreviewParamsPaymentTermsType()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "due_on_receipt"
            }
            """
        );
    }

    internal InvoicePreviewParamsPaymentTermsType(JsonElement element)
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
        if (this != new InvoicePreviewParamsPaymentTermsType())
        {
            throw new DodoPaymentsInvalidDataException(
                "Invalid value given for 'InvoicePreviewParamsPaymentTermsType'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(InvoicePreviewParamsPaymentTermsType? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class InvoicePreviewParamsPaymentTermsTypeConverter
    : JsonConverter<InvoicePreviewParamsPaymentTermsType>
{
    public override InvoicePreviewParamsPaymentTermsType? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoicePreviewParamsPaymentTermsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoicePreviewParamsPaymentTermsUnionMember1,
        InvoicePreviewParamsPaymentTermsUnionMember1FromRaw
    >)
)]
public sealed record class InvoicePreviewParamsPaymentTermsUnionMember1 : JsonModel
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

    public InvoicePreviewParamsPaymentTermsUnionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoicePreviewParamsPaymentTermsUnionMember1(
        InvoicePreviewParamsPaymentTermsUnionMember1 invoicePreviewParamsPaymentTermsUnionMember1
    )
        : base(invoicePreviewParamsPaymentTermsUnionMember1) { }
#pragma warning restore CS8618

    public InvoicePreviewParamsPaymentTermsUnionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("net");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoicePreviewParamsPaymentTermsUnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoicePreviewParamsPaymentTermsUnionMember1FromRaw.FromRawUnchecked"/>
    public static InvoicePreviewParamsPaymentTermsUnionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoicePreviewParamsPaymentTermsUnionMember1(int days)
        : this()
    {
        this.Days = days;
    }
}

class InvoicePreviewParamsPaymentTermsUnionMember1FromRaw
    : IFromRawJson<InvoicePreviewParamsPaymentTermsUnionMember1>
{
    /// <inheritdoc/>
    public InvoicePreviewParamsPaymentTermsUnionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoicePreviewParamsPaymentTermsUnionMember1.FromRawUnchecked(rawData);
}
