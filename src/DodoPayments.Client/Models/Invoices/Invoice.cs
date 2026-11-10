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
using Subscriptions = DodoPayments.Client.Models.Subscriptions;
using System = System;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// An invoice-led invoice. Every read and every `invoice.*` webhook uses this schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Invoice, InvoiceFromRaw>))]
public sealed record class Invoice : JsonModel
{
    /// <summary>
    /// The actions that the current status accepts.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, AllowedAction>> AllowedActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, AllowedAction>>>(
                "allowed_actions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, AllowedAction>>>(
                "allowed_actions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The amount that the customer must pay. Zero unless the invoice is open or
    /// past due.
    /// </summary>
    public required long AmountDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount_due");
        }
        init { this._rawData.Set("amount_due", value); }
    }

    /// <summary>
    /// The sum of the succeeded payments, in the smallest currency unit. A late payment
    /// is not included after its late refund.
    /// </summary>
    public required long AmountPaid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount_paid");
        }
        init { this._rawData.Set("amount_paid", value); }
    }

    /// <summary>
    /// The sum of the succeeded refunds, in the currency of each payment. The late
    /// refund of a late payment is not included.
    /// </summary>
    public required long AmountRefunded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount_refunded");
        }
        init { this._rawData.Set("amount_refunded", value); }
    }

    public required ApiEnum<string, BillingMode> BillingMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BillingMode>>("billing_mode");
        }
        init { this._rawData.Set("billing_mode", value); }
    }

    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Customer credits applied at finalise, in the smallest currency unit. Zero
    /// or less.
    /// </summary>
    public required long Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required Customer Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Customer>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// The discount codes of the invoice.
    /// </summary>
    public required IReadOnlyList<string> DiscountIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("discount_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "discount_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The fields that `PATCH` can change in the current status.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EditableField>> EditableFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, EditableField>>>(
                "editable_fields"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, EditableField>>>(
                "editable_fields",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How often the invoice lines bill. `mixed` covers several intervals, or one-time
    /// lines next to a plan.
    /// </summary>
    public required Frequency Frequency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Frequency>("frequency");
        }
        init { this._rawData.Set("frequency", value); }
    }

    public required string InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_id");
        }
        init { this._rawData.Set("invoice_id", value); }
    }

    public required JsonElement Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    public required IReadOnlyList<string> RefundIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("refund_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "refund_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of failed automatic charges.
    /// </summary>
    public required int RetryCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("retry_count");
        }
        init { this._rawData.Set("retry_count", value); }
    }

    /// <summary>
    /// Goes up by one on each change. Use it to ignore an older webhook delivery.
    /// </summary>
    public required long RowVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("row_version");
        }
        init { this._rawData.Set("row_version", value); }
    }

    /// <summary>
    /// The `message` of each variant is the label of the invoice document.
    /// </summary>
    public required ApiEnum<string, InvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvoiceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required IReadOnlyList<string> SubscriptionIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("subscription_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "subscription_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<ApiEnum<string, InvoiceTag>> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, InvoiceTag>>>(
                "tags"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, InvoiceTag>>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tax in the smallest currency unit.
    /// </summary>
    public required int Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// Total with tax, before credits, in the smallest currency unit.
    /// </summary>
    public required int TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    public ApiEnum<string, InvoiceCollectionMethod>? CollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InvoiceCollectionMethod>>(
                "collection_method"
            );
        }
        init { this._rawData.Set("collection_method", value); }
    }

    public System::DateTimeOffset? DueAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("due_at");
        }
        init { this._rawData.Set("due_at", value); }
    }

    /// <summary>
    /// `null` for an invoice that has no collection: draft, paid, void or uncollectable.
    /// </summary>
    public ApiEnum<string, DunningState>? DunningState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DunningState>>("dunning_state");
        }
        init { this._rawData.Set("dunning_state", value); }
    }

    public System::DateTimeOffset? FinalizedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("finalized_at");
        }
        init { this._rawData.Set("finalized_at", value); }
    }

    /// <summary>
    /// The page where the customer pays. `null` until the invoice is sent.
    /// </summary>
    public string? HostedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hosted_url");
        }
        init { this._rawData.Set("hosted_url", value); }
    }

    /// <summary>
    /// Only on a single invoice. A list leaves it out.
    /// </summary>
    public IReadOnlyList<InvoiceLine>? Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InvoiceLine>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceLine>?>(
                "lines",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
    }

    /// <summary>
    /// The time of the next reminder email to the customer, before or after the
    /// due date. `null` when no reminder email will go out.
    /// </summary>
    public System::DateTimeOffset? NextReminderAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("next_reminder_at");
        }
        init { this._rawData.Set("next_reminder_at", value); }
    }

    public System::DateTimeOffset? NextRetryAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("next_retry_at");
        }
        init { this._rawData.Set("next_retry_at", value); }
    }

    /// <summary>
    /// Days from finalise to the due date. `null` when the invoice has a custom
    /// due date.
    /// </summary>
    public int? PaymentTermsDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("payment_terms_days");
        }
        init { this._rawData.Set("payment_terms_days", value); }
    }

    /// <summary>
    /// Only on a single invoice. A list leaves it out.
    /// </summary>
    public IReadOnlyList<Payment>? Payments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Payment>>("payments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Payment>?>(
                "payments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? PdfUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pdf_url");
        }
        init { this._rawData.Set("pdf_url", value); }
    }

    /// <summary>
    /// `null` on a draft that keeps all reminder settings of the business.
    /// </summary>
    public ReminderSettings? ReminderSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReminderSettings>("reminder_settings");
        }
        init { this._rawData.Set("reminder_settings", value); }
    }

    /// <summary>
    /// The time at which a draft that waits for review finalises.
    /// </summary>
    public System::DateTimeOffset? ReviewDeadline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("review_deadline");
        }
        init { this._rawData.Set("review_deadline", value); }
    }

    public System::DateTimeOffset? SentAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("sent_at");
        }
        init { this._rawData.Set("sent_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AllowedActions)
        {
            item.Validate();
        }
        _ = this.AmountDue;
        _ = this.AmountPaid;
        _ = this.AmountRefunded;
        this.BillingMode.Validate();
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.Credits;
        this.Currency.Validate();
        this.Customer.Validate();
        _ = this.DiscountIds;
        foreach (var item in this.EditableFields)
        {
            item.Validate();
        }
        this.Frequency.Validate();
        _ = this.InvoiceID;
        _ = this.Metadata;
        _ = this.RefundIds;
        _ = this.RetryCount;
        _ = this.RowVersion;
        this.Status.Validate();
        _ = this.SubscriptionIds;
        foreach (var item in this.Tags)
        {
            item.Validate();
        }
        _ = this.Tax;
        _ = this.TotalAmount;
        this.CollectionMethod?.Validate();
        _ = this.DueAt;
        this.DunningState?.Validate();
        _ = this.FinalizedAt;
        _ = this.HostedUrl;
        foreach (var item in this.Lines ?? [])
        {
            item.Validate();
        }
        _ = this.Memo;
        _ = this.NextReminderAt;
        _ = this.NextRetryAt;
        _ = this.PaymentTermsDays;
        foreach (var item in this.Payments ?? [])
        {
            item.Validate();
        }
        _ = this.PdfUrl;
        this.ReminderSettings?.Validate();
        _ = this.ReviewDeadline;
        _ = this.SentAt;
    }

    public Invoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invoice(Invoice invoice)
        : base(invoice) { }
#pragma warning restore CS8618

    public Invoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceFromRaw.FromRawUnchecked"/>
    public static Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceFromRaw : IFromRawJson<Invoice>
{
    /// <inheritdoc/>
    public Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Invoice.FromRawUnchecked(rawData);
}

/// <summary>
/// An action that a merchant can request on the invoice in its current status.
/// </summary>
[JsonConverter(typeof(AllowedActionConverter))]
public enum AllowedAction
{
    Edit,
    Finalize,
    Delete,
    Send,
    Retry,
    Void,
    MarkUncollectable,
    ChangeDunning,
    AddNote,
    Duplicate,
}

sealed class AllowedActionConverter : JsonConverter<AllowedAction>
{
    public override AllowedAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "edit" => AllowedAction.Edit,
            "finalize" => AllowedAction.Finalize,
            "delete" => AllowedAction.Delete,
            "send" => AllowedAction.Send,
            "retry" => AllowedAction.Retry,
            "void" => AllowedAction.Void,
            "mark_uncollectable" => AllowedAction.MarkUncollectable,
            "change_dunning" => AllowedAction.ChangeDunning,
            "add_note" => AllowedAction.AddNote,
            "duplicate" => AllowedAction.Duplicate,
            _ => (AllowedAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllowedAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllowedAction.Edit => "edit",
                AllowedAction.Finalize => "finalize",
                AllowedAction.Delete => "delete",
                AllowedAction.Send => "send",
                AllowedAction.Retry => "retry",
                AllowedAction.Void => "void",
                AllowedAction.MarkUncollectable => "mark_uncollectable",
                AllowedAction.ChangeDunning => "change_dunning",
                AllowedAction.AddNote => "add_note",
                AllowedAction.Duplicate => "duplicate",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BillingModeConverter))]
public enum BillingMode
{
    Normal,
    InvoiceLed,
}

sealed class BillingModeConverter : JsonConverter<BillingMode>
{
    public override BillingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => BillingMode.Normal,
            "invoice_led" => BillingMode.InvoiceLed,
            _ => (BillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingMode.Normal => "normal",
                BillingMode.InvoiceLed => "invoice_led",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Customer, CustomerFromRaw>))]
public sealed record class Customer : JsonModel
{
    /// <summary>
    /// A draft can have no country yet. Finalise needs it.
    /// </summary>
    public required CustomerBillingAddress BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerBillingAddress>("billing_address");
        }
        init { this._rawData.Set("billing_address", value); }
    }

    public required IReadOnlyList<string> CcEmails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("cc_emails");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "cc_emails",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    public string? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingAddress.Validate();
        _ = this.CcEmails;
        _ = this.CustomerID;
        _ = this.Email;
        _ = this.TaxID;
    }

    public Customer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Customer(Customer customer)
        : base(customer) { }
#pragma warning restore CS8618

    public Customer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerFromRaw.FromRawUnchecked"/>
    public static Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerFromRaw : IFromRawJson<Customer>
{
    /// <inheritdoc/>
    public Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Customer.FromRawUnchecked(rawData);
}

/// <summary>
/// A draft can have no country yet. Finalise needs it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerBillingAddress, CustomerBillingAddressFromRaw>))]
public sealed record class CustomerBillingAddress : JsonModel
{
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// ISO country code alpha2 variant
    /// </summary>
    public ApiEnum<string, CountryCode>? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CountryCode>>("country");
        }
        init { this._rawData.Set("country", value); }
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
        _ = this.City;
        this.Country?.Validate();
        _ = this.State;
        _ = this.Street;
        _ = this.Zipcode;
    }

    public CustomerBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerBillingAddress(CustomerBillingAddress customerBillingAddress)
        : base(customerBillingAddress) { }
#pragma warning restore CS8618

    public CustomerBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerBillingAddressFromRaw : IFromRawJson<CustomerBillingAddress>
{
    /// <inheritdoc/>
    public CustomerBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerBillingAddress.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EditableFieldConverter))]
public enum EditableField
{
    Customer,
    Items,
    Discounts,
    Currency,
    BillingAddress,
    TaxID,
    ReviewRequired,
    DueAt,
    CollectionMethod,
    Memo,
    CustomerEmail,
    CcEmails,
    Dunning,
    Metadata,
}

sealed class EditableFieldConverter : JsonConverter<EditableField>
{
    public override EditableField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "customer" => EditableField.Customer,
            "items" => EditableField.Items,
            "discounts" => EditableField.Discounts,
            "currency" => EditableField.Currency,
            "billing_address" => EditableField.BillingAddress,
            "tax_id" => EditableField.TaxID,
            "review_required" => EditableField.ReviewRequired,
            "due_at" => EditableField.DueAt,
            "collection_method" => EditableField.CollectionMethod,
            "memo" => EditableField.Memo,
            "customer_email" => EditableField.CustomerEmail,
            "cc_emails" => EditableField.CcEmails,
            "dunning" => EditableField.Dunning,
            "metadata" => EditableField.Metadata,
            _ => (EditableField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EditableField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EditableField.Customer => "customer",
                EditableField.Items => "items",
                EditableField.Discounts => "discounts",
                EditableField.Currency => "currency",
                EditableField.BillingAddress => "billing_address",
                EditableField.TaxID => "tax_id",
                EditableField.ReviewRequired => "review_required",
                EditableField.DueAt => "due_at",
                EditableField.CollectionMethod => "collection_method",
                EditableField.Memo => "memo",
                EditableField.CustomerEmail => "customer_email",
                EditableField.CcEmails => "cc_emails",
                EditableField.Dunning => "dunning",
                EditableField.Metadata => "metadata",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How often the invoice lines bill. `mixed` covers several intervals, or one-time
/// lines next to a plan.
/// </summary>
[JsonConverter(typeof(FrequencyConverter))]
public record class Frequency : ModelBase
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

    public Frequency(OneTime value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Frequency(Recurring value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Frequency(Mixed value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Frequency(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OneTime"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOneTime(out var value)) {
    ///     // `value` is of type `OneTime`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOneTime([NotNullWhen(true)] out OneTime? value)
    {
        value = this.Value as OneTime;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Recurring"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRecurring(out var value)) {
    ///     // `value` is of type `Recurring`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRecurring([NotNullWhen(true)] out Recurring? value)
    {
        value = this.Value as Recurring;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Mixed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `Mixed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed([NotNullWhen(true)] out Mixed? value)
    {
        value = this.Value as Mixed;
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
    ///     (OneTime value) =&gt; {...},
    ///     (Recurring value) =&gt; {...},
    ///     (Mixed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<OneTime> oneTime,
        System::Action<Recurring> recurring,
        System::Action<Mixed> mixed
    )
    {
        switch (this.Value)
        {
            case OneTime value:
                oneTime(value);
                break;
            case Recurring value:
                recurring(value);
                break;
            case Mixed value:
                mixed(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Frequency"
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
    ///     (OneTime value) =&gt; {...},
    ///     (Recurring value) =&gt; {...},
    ///     (Mixed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<OneTime, T> oneTime,
        System::Func<Recurring, T> recurring,
        System::Func<Mixed, T> mixed
    )
    {
        return this.Value switch
        {
            OneTime value => oneTime(value),
            Recurring value => recurring(value),
            Mixed value => mixed(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Frequency"
            ),
        };
    }

    public static implicit operator Frequency(OneTime value) => new(value);

    public static implicit operator Frequency(Recurring value) => new(value);

    public static implicit operator Frequency(Mixed value) => new(value);

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
                "Data did not match any variant of Frequency"
            );
        }
        this.Switch(
            (oneTime) => oneTime.Validate(),
            (recurring) => recurring.Validate(),
            (mixed) => mixed.Validate()
        );
    }

    public virtual bool Equals(Frequency? other) =>
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
            OneTime _ => 0,
            Recurring _ => 1,
            Mixed _ => 2,
            _ => -1,
        };
    }
}

sealed class FrequencyConverter : JsonConverter<Frequency>
{
    public override Frequency? Read(
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
            case "one_time":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OneTime>(element, options);
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
            case "recurring":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Recurring>(element, options);
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
            case "mixed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Mixed>(element, options);
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
                return new Frequency(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Frequency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(OneTimeConverter))]
public record class OneTime
{
    public JsonElement Element { get; private init; }

    public OneTime()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "one_time"
            }
            """
        );
    }

    internal OneTime(JsonElement element)
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
        if (this != new OneTime())
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for 'OneTime'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(OneTime? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class OneTimeConverter : JsonConverter<OneTime>
{
    public override OneTime? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, OneTime value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Recurring, RecurringFromRaw>))]
public sealed record class Recurring : JsonModel
{
    public required int Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Unit of a duration count (e.g. license-key validity period).
    /// </summary>
    public required ApiEnum<string, Subscriptions::TimeInterval> Interval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Subscriptions::TimeInterval>>(
                "interval"
            );
        }
        init { this._rawData.Set("interval", value); }
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
        _ = this.Count;
        this.Interval.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("recurring")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public Recurring()
    {
        this.Type = JsonSerializer.SerializeToElement("recurring");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recurring(Recurring recurring)
        : base(recurring) { }
#pragma warning restore CS8618

    public Recurring(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("recurring");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recurring(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringFromRaw.FromRawUnchecked"/>
    public static Recurring FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringFromRaw : IFromRawJson<Recurring>
{
    /// <inheritdoc/>
    public Recurring FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recurring.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MixedConverter))]
public record class Mixed
{
    public JsonElement Element { get; private init; }

    public Mixed()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "mixed"
            }
            """
        );
    }

    internal Mixed(JsonElement element)
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
        if (this != new Mixed())
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for 'Mixed'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Mixed? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class MixedConverter : JsonConverter<Mixed>
{
    public override Mixed? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Mixed value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(InvoiceTagConverter))]
public enum InvoiceTag
{
    Refunded,
    PartiallyRefunded,
    Disputed,
    PaymentReversed,
}

sealed class InvoiceTagConverter : JsonConverter<InvoiceTag>
{
    public override InvoiceTag Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refunded" => InvoiceTag.Refunded,
            "partially_refunded" => InvoiceTag.PartiallyRefunded,
            "disputed" => InvoiceTag.Disputed,
            "payment_reversed" => InvoiceTag.PaymentReversed,
            _ => (InvoiceTag)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceTag value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceTag.Refunded => "refunded",
                InvoiceTag.PartiallyRefunded => "partially_refunded",
                InvoiceTag.Disputed => "disputed",
                InvoiceTag.PaymentReversed => "payment_reversed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Payment, PaymentFromRaw>))]
public sealed record class Payment : JsonModel
{
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string PaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_id");
        }
        init { this._rawData.Set("payment_id", value); }
    }

    /// <summary>
    /// The automatic charge number. `null` for a payment that the customer started.
    /// </summary>
    public int? RetryAttempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("retry_attempt");
        }
        init { this._rawData.Set("retry_attempt", value); }
    }

    /// <summary>
    /// `null` while the processor has not answered.
    /// </summary>
    public ApiEnum<string, Payments::IntentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Payments::IntentStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.PaymentID;
        _ = this.RetryAttempt;
        this.Status?.Validate();
    }

    public Payment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payment(Payment payment)
        : base(payment) { }
#pragma warning restore CS8618

    public Payment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentFromRaw.FromRawUnchecked"/>
    public static Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentFromRaw : IFromRawJson<Payment>
{
    /// <inheritdoc/>
    public Payment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payment.FromRawUnchecked(rawData);
}

/// <summary>
/// `null` on a draft that keeps all reminder settings of the business.
/// </summary>
[JsonConverter(typeof(ReminderSettingsConverter))]
public record class ReminderSettings : ModelBase
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

    public JsonElement Kind
    {
        get { return Match(snapshot: (x) => x.Kind, override_: (x) => x.Kind); }
    }

    public bool? Paused
    {
        get { return Match<bool?>(snapshot: (x) => x.Paused, override_: (x) => x.Paused); }
    }

    public bool? RemindersEnabled
    {
        get
        {
            return Match<bool?>(
                snapshot: (x) => x.RemindersEnabled,
                override_: (x) => x.RemindersEnabled
            );
        }
    }

    public ReminderSettings(Snapshot value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReminderSettings(Override value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReminderSettings(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Snapshot"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSnapshot(out var value)) {
    ///     // `value` is of type `Snapshot`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSnapshot([NotNullWhen(true)] out Snapshot? value)
    {
        value = this.Value as Snapshot;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Override"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOverride(out var value)) {
    ///     // `value` is of type `Override`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOverride([NotNullWhen(true)] out Override? value)
    {
        value = this.Value as Override;
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
    ///     (Snapshot value) =&gt; {...},
    ///     (Override value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<Snapshot> snapshot, System::Action<Override> override_)
    {
        switch (this.Value)
        {
            case Snapshot value:
                snapshot(value);
                break;
            case Override value:
                override_(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of ReminderSettings"
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
    ///     (Snapshot value) =&gt; {...},
    ///     (Override value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Snapshot, T> snapshot, System::Func<Override, T> override_)
    {
        return this.Value switch
        {
            Snapshot value => snapshot(value),
            Override value => override_(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of ReminderSettings"
            ),
        };
    }

    public static implicit operator ReminderSettings(Snapshot value) => new(value);

    public static implicit operator ReminderSettings(Override value) => new(value);

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
                "Data did not match any variant of ReminderSettings"
            );
        }
        this.Switch((snapshot) => snapshot.Validate(), (override_) => override_.Validate());
    }

    public virtual bool Equals(ReminderSettings? other) =>
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
            Snapshot _ => 0,
            Override _ => 1,
            _ => -1,
        };
    }
}

sealed class ReminderSettingsConverter : JsonConverter<ReminderSettings?>
{
    public override ReminderSettings? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? kind;
        try
        {
            kind = element.GetProperty("kind").GetString();
        }
        catch
        {
            kind = null;
        }

        switch (kind)
        {
            case "snapshot":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Snapshot>(element, options);
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
            case "override":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Override>(element, options);
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
                return new ReminderSettings(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReminderSettings? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The settings that finalise froze. The reminders run on them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Snapshot, SnapshotFromRaw>))]
public sealed record class Snapshot : JsonModel
{
    public JsonElement Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    public required IReadOnlyList<long> OffsetsMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("offsets_minutes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "offsets_minutes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool Paused
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("paused");
        }
        init { this._rawData.Set("paused", value); }
    }

    public required bool RemindersEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("reminders_enabled");
        }
        init { this._rawData.Set("reminders_enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Kind, JsonSerializer.SerializeToElement("snapshot")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
        _ = this.OffsetsMinutes;
        _ = this.Paused;
        _ = this.RemindersEnabled;
    }

    public Snapshot()
    {
        this.Kind = JsonSerializer.SerializeToElement("snapshot");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Snapshot(Snapshot snapshot)
        : base(snapshot) { }
#pragma warning restore CS8618

    public Snapshot(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Kind = JsonSerializer.SerializeToElement("snapshot");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Snapshot(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SnapshotFromRaw.FromRawUnchecked"/>
    public static Snapshot FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SnapshotFromRaw : IFromRawJson<Snapshot>
{
    /// <inheritdoc/>
    public Snapshot FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Snapshot.FromRawUnchecked(rawData);
}

/// <summary>
/// The changes of a draft. A `null` field keeps the business value at finalise.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Override, OverrideFromRaw>))]
public sealed record class Override : JsonModel
{
    public JsonElement Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    public IReadOnlyList<long>? OffsetsMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("offsets_minutes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "offsets_minutes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? Paused
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("paused");
        }
        init { this._rawData.Set("paused", value); }
    }

    public bool? RemindersEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("reminders_enabled");
        }
        init { this._rawData.Set("reminders_enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Kind, JsonSerializer.SerializeToElement("override")))
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
        _ = this.OffsetsMinutes;
        _ = this.Paused;
        _ = this.RemindersEnabled;
    }

    public Override()
    {
        this.Kind = JsonSerializer.SerializeToElement("override");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Override(Override override_)
        : base(override_) { }
#pragma warning restore CS8618

    public Override(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Kind = JsonSerializer.SerializeToElement("override");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Override(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OverrideFromRaw.FromRawUnchecked"/>
    public static Override FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OverrideFromRaw : IFromRawJson<Override>
{
    /// <inheritdoc/>
    public Override FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Override.FromRawUnchecked(rawData);
}
