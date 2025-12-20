# Dodo Payments C# API Library

> [!NOTE]
> The Dodo Payments C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/dodopayments/dodopayments-csharp/issues/new).

The Dodo Payments C# SDK provides convenient access to the [Dodo Payments REST API](https://docs.dodopayments.com/api-reference/introduction) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.dodopayments.com](https://docs.dodopayments.com/api-reference/introduction).

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/DodoPayments.Client):

```bash
dotnet add package DodoPayments.Client
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using DodoPayments.Client;
using DodoPayments.Client.Models.CheckoutSessions;

DodoPaymentsClient client = new();

CheckoutSessionCreateParams parameters = new()
{
    ProductCart =
    [
        new()
        {
            ProductID = "product_id",
            Quantity = 0,
        },
    ],
};

var checkoutSessionResponse = await client.CheckoutSessions.Create(parameters);

Console.WriteLine(checkoutSessionResponse);
```

## Client configuration

Configure the client using environment variables:

```csharp
using DodoPayments.Client;

// Configured using the DODO_PAYMENTS_API_KEY, DODO_PAYMENTS_WEBHOOK_KEY and DODO_PAYMENTS_BASE_URL environment variables
DodoPaymentsClient client = new();
```

Or manually:

```csharp
using DodoPayments.Client;

DodoPaymentsClient client = new() { BearerToken = "My Bearer Token" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property      | Environment variable        | Required | Default value                     |
| ------------- | --------------------------- | -------- | --------------------------------- |
| `BearerToken` | `DODO_PAYMENTS_API_KEY`     | true     | -                                 |
| `WebhookKey`  | `DODO_PAYMENTS_WEBHOOK_KEY` | false    | -                                 |
| `BaseUrl`     | `DODO_PAYMENTS_BASE_URL`    | true     | `"https://live.dodopayments.com"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var checkoutSessionResponse = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .CheckoutSessions.Create(parameters);

Console.WriteLine(checkoutSessionResponse);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Dodo Payments API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.CheckoutSessions.Create` should be called with an instance of `CheckoutSessionCreateParams`, and it will return an instance of `Task<CheckoutSessionResponse>`.

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

```csharp
using System;
using DodoPayments.Client.Models.Invoices.Payments;

PaymentRetrieveParams parameters = new() { PaymentID = "payment_id" };

var payment = await client.Invoices.Payments.Retrieve(parameters);

Console.WriteLine(payment);
```

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Invoices.Payments.Retrieve(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Error handling

The SDK throws custom unchecked exception types:

- `DodoPaymentsApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                   |
| ------ | ------------------------------------------- |
| 400    | `DodoPaymentsBadRequestException`           |
| 401    | `DodoPaymentsUnauthorizedException`         |
| 403    | `DodoPaymentsForbiddenException`            |
| 404    | `DodoPaymentsNotFoundException`             |
| 422    | `DodoPaymentsUnprocessableEntityException`  |
| 429    | `DodoPaymentsRateLimitException`            |
| 5xx    | `DodoPayments5xxException`                  |
| others | `DodoPaymentsUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `DodoPayments4xxException`.

false

- `DodoPaymentsIOException`: I/O networking errors.

- `DodoPaymentsInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `DodoPaymentsException`: Base class for all exceptions.

## Pagination

The SDK defines methods that return a paginated lists of results. It provides convenient ways to access the results either one page at a time or item-by-item across all pages.

### Auto-pagination

To iterate through all results across all pages, use the `Paginate` method, which automatically fetches more pages as needed. The method returns an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;

var page = await client.Payments.List(parameters);
await foreach (var item in page.Paginate())
{
    Console.WriteLine(item);
}
```

### Manual pagination

To access individual page items and manually request the next page, use the `Items` property, and `HasNext` and `Next` methods:

```csharp
using System;

var page = await client.Payments.List();
while (true)
{
    foreach (var item in page.Items)
    {
        Console.WriteLine(item);
    }
    if (!page.HasNext())
    {
        break;
    }
    page = await page.Next();
}
```

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using DodoPayments.Client;

DodoPaymentsClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var checkoutSessionResponse = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .CheckoutSessions.Create(parameters);

Console.WriteLine(checkoutSessionResponse);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using DodoPayments.Client;

DodoPaymentsClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var checkoutSessionResponse = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .CheckoutSessions.Create(parameters);

Console.WriteLine(checkoutSessionResponse);
```

### Environments

The SDK sends requests to the live_mode environment by default. To send requests to a different environment, configure the client like so:

```csharp
using DodoPayments.Client;
using DodoPayments.Client.Core;

DodoPaymentsClient client = new() { BaseUrl = EnvironmentUrl.TestMode };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `DodoPaymentsInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var checkoutSessionResponse = client.CheckoutSessions.Create(parameters);
checkoutSessionResponse.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using DodoPayments.Client;

DodoPaymentsClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var checkoutSessionResponse = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .CheckoutSessions.Create(parameters);

Console.WriteLine(checkoutSessionResponse);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/dodopayments/dodopayments-csharp/issues) with questions, bugs, or suggestions.
