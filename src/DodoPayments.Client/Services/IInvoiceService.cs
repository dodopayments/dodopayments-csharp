using System;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Invoices;
using Invoices = DodoPayments.Client.Services.Invoices;

namespace DodoPayments.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Invoices::IPaymentService Payments { get; }

    /// <summary>
    /// Creates a draft. A repeat with the same `Idempotency-Key` returns the first
    /// draft.
    /// </summary>
    Task<Invoice> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an invoice
    /// </summary>
    Task<Invoice> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvoiceRetrieveParams, CancellationToken)"/>
    Task<Invoice> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes only the sent fields. `null` clears a field that can be empty.
    /// </summary>
    Task<Invoice> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvoiceUpdateParams, CancellationToken)"/>
    Task<Invoice> Update(
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists invoice-led invoices, newest first. The items have no `lines` and no
    /// `payments`.
    /// </summary>
    Task<InvoiceListPage> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a draft invoice
    /// </summary>
    Task Delete(InvoiceDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(InvoiceDeleteParams, CancellationToken)"/>
    Task Delete(
        string invoiceID,
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// A note changes no field, so it needs no `If-Match`. The note shows in `/events`.
    /// </summary>
    Task<Invoice> AddNote(
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddNote(InvoiceAddNoteParams, CancellationToken)"/>
    Task<Invoice> AddNote(
        string invoiceID,
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the page where the customer pays. A copied link counts as a send, so the
    /// first call sets `sent_at`.
    /// </summary>
    Task<InvoiceCreateHostedLinkResponse> CreateHostedLink(
        InvoiceCreateHostedLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateHostedLink(InvoiceCreateHostedLinkParams, CancellationToken)"/>
    Task<InvoiceCreateHostedLinkResponse> CreateHostedLink(
        string invoiceID,
        InvoiceCreateHostedLinkParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Copies the customer, the product lines, the terms and the recipients into a new
    /// draft. Usage lines are not copied.
    /// </summary>
    Task<Invoice> Duplicate(
        InvoiceDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(InvoiceDuplicateParams, CancellationToken)"/>
    Task<Invoice> Duplicate(
        string invoiceID,
        InvoiceDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Issues the draft. With `send: true`, the invoice email goes out after the issue.
    /// A failed send keeps the invoice issued. Call `/send` again with the new `ETag`.
    /// </summary>
    Task<Invoice> Finalize(
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Finalize(InvoiceFinalizeParams, CancellationToken)"/>
    Task<Invoice> Finalize(
        string invoiceID,
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the change history of the invoice, oldest first.
    /// </summary>
    Task<InvoiceListEventsResponse> ListEvents(
        InvoiceListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(InvoiceListEventsParams, CancellationToken)"/>
    Task<InvoiceListEventsResponse> ListEvents(
        string invoiceID,
        InvoiceListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mark an invoice uncollectable
    /// </summary>
    Task<Invoice> MarkUncollectable(
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkUncollectable(InvoiceMarkUncollectableParams, CancellationToken)"/>
    Task<Invoice> MarkUncollectable(
        string invoiceID,
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Prices the body as a draft and returns it. No row is saved.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Preview(
        InvoicePreviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Preview a draft invoice
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> PreviewExisting(
        InvoicePreviewExistingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PreviewExisting(InvoicePreviewExistingParams, CancellationToken)"/>
    Task<HttpResponse> PreviewExisting(
        string invoiceID,
        InvoicePreviewExistingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Charges the saved payment method of the invoice subscription now.
    /// </summary>
    Task<Invoice> Retry(
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retry(InvoiceRetryParams, CancellationToken)"/>
    Task<Invoice> Retry(
        string invoiceID,
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Emails the invoice to the customer email and the CC emails.
    /// </summary>
    Task<Invoice> Send(InvoiceSendParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Send(InvoiceSendParams, CancellationToken)"/>
    Task<Invoice> Send(
        string invoiceID,
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Pauses, resumes or moves the reminders of an open or past-due invoice.
    /// </summary>
    Task<Invoice> UpdateDunning(
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateDunning(InvoiceUpdateDunningParams, CancellationToken)"/>
    Task<Invoice> UpdateDunning(
        string invoiceID,
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Closes an open or past-due invoice. Applied credits go back to the customer
    /// wallet.
    /// </summary>
    Task<Invoice> Void(InvoiceVoidParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Void(InvoiceVoidParams, CancellationToken)"/>
    Task<Invoice> Void(
        string invoiceID,
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Invoices::IPaymentServiceWithRawResponse Payments { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Create(InvoiceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /billing/invoices/{invoice_id}</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Retrieve(InvoiceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvoiceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /billing/invoices/{invoice_id}</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Update(InvoiceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvoiceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Update(
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /billing/invoices</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.List(InvoiceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceListPage>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /billing/invoices/{invoice_id}</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Delete(InvoiceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InvoiceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string invoiceID,
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/notes</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.AddNote(InvoiceAddNoteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> AddNote(
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddNote(InvoiceAddNoteParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> AddNote(
        string invoiceID,
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/hosted-link</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.CreateHostedLink(InvoiceCreateHostedLinkParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceCreateHostedLinkResponse>> CreateHostedLink(
        InvoiceCreateHostedLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateHostedLink(InvoiceCreateHostedLinkParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceCreateHostedLinkResponse>> CreateHostedLink(
        string invoiceID,
        InvoiceCreateHostedLinkParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/duplicate</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Duplicate(InvoiceDuplicateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Duplicate(
        InvoiceDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(InvoiceDuplicateParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Duplicate(
        string invoiceID,
        InvoiceDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/finalize</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Finalize(InvoiceFinalizeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Finalize(
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Finalize(InvoiceFinalizeParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Finalize(
        string invoiceID,
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /billing/invoices/{invoice_id}/events</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.ListEvents(InvoiceListEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceListEventsResponse>> ListEvents(
        InvoiceListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(InvoiceListEventsParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceListEventsResponse>> ListEvents(
        string invoiceID,
        InvoiceListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/mark-uncollectable</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.MarkUncollectable(InvoiceMarkUncollectableParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> MarkUncollectable(
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkUncollectable(InvoiceMarkUncollectableParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> MarkUncollectable(
        string invoiceID,
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/preview</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Preview(InvoicePreviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Preview(
        InvoicePreviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /billing/invoices/{invoice_id}/preview</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.PreviewExisting(InvoicePreviewExistingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> PreviewExisting(
        InvoicePreviewExistingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PreviewExisting(InvoicePreviewExistingParams, CancellationToken)"/>
    Task<HttpResponse> PreviewExisting(
        string invoiceID,
        InvoicePreviewExistingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/retry</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Retry(InvoiceRetryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Retry(
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retry(InvoiceRetryParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Retry(
        string invoiceID,
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/send</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Send(InvoiceSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Send(
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(InvoiceSendParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Send(
        string invoiceID,
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/dunning</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.UpdateDunning(InvoiceUpdateDunningParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> UpdateDunning(
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateDunning(InvoiceUpdateDunningParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> UpdateDunning(
        string invoiceID,
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /billing/invoices/{invoice_id}/void</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Void(InvoiceVoidParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Void(
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Void(InvoiceVoidParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Void(
        string invoiceID,
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    );
}
