using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;
using Invoices = DodoPayments.Client.Services.Invoices;

namespace DodoPayments.Client.Services;

/// <inheritdoc/>
public sealed class InvoiceService : IInvoiceService
{
    readonly Lazy<IInvoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    public InvoiceService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvoiceServiceWithRawResponse(client.WithRawResponse));
        _payments = new(() => new Invoices::PaymentService(client));
    }

    readonly Lazy<Invoices::IPaymentService> _payments;
    public Invoices::IPaymentService Payments
    {
        get { return _payments.Value; }
    }

    /// <inheritdoc/>
    public async Task<Invoice> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Update(
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListPage> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string invoiceID,
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { InvoiceID = invoiceID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Invoice> AddNote(
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddNote(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> AddNote(
        string invoiceID,
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddNote(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceCreateHostedLinkResponse> CreateHostedLink(
        InvoiceCreateHostedLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateHostedLink(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceCreateHostedLinkResponse> CreateHostedLink(
        string invoiceID,
        InvoiceCreateHostedLinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateHostedLink(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Duplicate(
        InvoiceDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Duplicate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Duplicate(
        string invoiceID,
        InvoiceDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Duplicate(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Finalize(
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Finalize(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Finalize(
        string invoiceID,
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Finalize(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListEventsResponse> ListEvents(
        InvoiceListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceListEventsResponse> ListEvents(
        string invoiceID,
        InvoiceListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEvents(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> MarkUncollectable(
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MarkUncollectable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> MarkUncollectable(
        string invoiceID,
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.MarkUncollectable(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview(
        InvoicePreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Preview(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> PreviewExisting(
        InvoicePreviewExistingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.PreviewExisting(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> PreviewExisting(
        string invoiceID,
        InvoicePreviewExistingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PreviewExisting(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Retry(
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retry(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Retry(
        string invoiceID,
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retry(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Send(
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Send(
        string invoiceID,
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> UpdateDunning(
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateDunning(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> UpdateDunning(
        string invoiceID,
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateDunning(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Void(
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Void(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Void(
        string invoiceID,
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Void(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InvoiceServiceWithRawResponse : IInvoiceServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvoiceServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;

        _payments = new(() => new Invoices::PaymentServiceWithRawResponse(client));
    }

    readonly Lazy<Invoices::IPaymentServiceWithRawResponse> _payments;
    public Invoices::IPaymentServiceWithRawResponse Payments
    {
        get { return _payments.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceUpdateParams> request = new()
        {
            Method = DodoPaymentsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Update(
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceListPage>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<InvoiceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InvoiceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string invoiceID,
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> AddNote(
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceAddNoteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> AddNote(
        string invoiceID,
        InvoiceAddNoteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddNote(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceCreateHostedLinkResponse>> CreateHostedLink(
        InvoiceCreateHostedLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceCreateHostedLinkParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<InvoiceCreateHostedLinkResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvoiceCreateHostedLinkResponse>> CreateHostedLink(
        string invoiceID,
        InvoiceCreateHostedLinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateHostedLink(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Duplicate(
        InvoiceDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceDuplicateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Duplicate(
        string invoiceID,
        InvoiceDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Duplicate(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Finalize(
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceFinalizeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Finalize(
        string invoiceID,
        InvoiceFinalizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Finalize(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceListEventsResponse>> ListEvents(
        InvoiceListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceListEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<InvoiceListEventsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvoiceListEventsResponse>> ListEvents(
        string invoiceID,
        InvoiceListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEvents(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> MarkUncollectable(
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceMarkUncollectableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> MarkUncollectable(
        string invoiceID,
        InvoiceMarkUncollectableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.MarkUncollectable(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview(
        InvoicePreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoicePreviewParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> PreviewExisting(
        InvoicePreviewExistingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoicePreviewExistingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> PreviewExisting(
        string invoiceID,
        InvoicePreviewExistingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PreviewExisting(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Retry(
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceRetryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Retry(
        string invoiceID,
        InvoiceRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retry(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Send(
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Send(
        string invoiceID,
        InvoiceSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> UpdateDunning(
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceUpdateDunningParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> UpdateDunning(
        string invoiceID,
        InvoiceUpdateDunningParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateDunning(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Void(
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceVoidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Void(
        string invoiceID,
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Void(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}
