using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DodoPayments.Models.Discounts;
using DodoPayments = DodoPayments;

namespace DodoPayments.Services.Discounts;

public sealed class DiscountService : IDiscountService
{
    readonly DodoPayments::IDodoPaymentsClient _client;

    public DiscountService(DodoPayments::IDodoPaymentsClient client)
    {
        _client = client;
    }

    public async Task<Discount> Create(DiscountCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Discount>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Discount> Retrieve(DiscountRetrieveParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Discount>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Discount> Update(DiscountUpdateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Patch, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Discount>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<DiscountListPageResponse> List(DiscountListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<DiscountListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                DodoPayments::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task Delete(DiscountDeleteParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Delete, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new DodoPayments::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
    }
}
