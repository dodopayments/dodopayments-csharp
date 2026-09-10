using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Customers.Emails;

namespace DodoPayments.Client.Services.Customers;

/// <inheritdoc/>
public sealed class EmailService : IEmailService
{
    readonly Lazy<IEmailServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDodoPaymentsClient _client;

    /// <inheritdoc/>
    public IEmailService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EmailService(this._client.WithOptions(modifier));
    }

    public EmailService(IDodoPaymentsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EmailServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EmailListPage> List(
        EmailListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EmailListPage> List(
        string customerID,
        EmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailBody> RetrieveBody(
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBody(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EmailBody> RetrieveBody(
        string emailLogID,
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveBody(parameters with { EmailLogID = emailLogID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EmailServiceWithRawResponse : IEmailServiceWithRawResponse
{
    readonly IDodoPaymentsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EmailServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailServiceWithRawResponse(IDodoPaymentsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailListPage>> List(
        EmailListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<EmailListParams> request = new()
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
                    .Deserialize<EmailListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EmailListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EmailListPage>> List(
        string customerID,
        EmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBody>> RetrieveBody(
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EmailLogID == null)
        {
            throw new DodoPaymentsInvalidDataException("'parameters.EmailLogID' cannot be null");
        }

        HttpRequest<EmailRetrieveBodyParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var emailBody = await response.Deserialize<EmailBody>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    emailBody.Validate();
                }
                return emailBody;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EmailBody>> RetrieveBody(
        string emailLogID,
        EmailRetrieveBodyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveBody(parameters with { EmailLogID = emailLogID }, cancellationToken);
    }
}
