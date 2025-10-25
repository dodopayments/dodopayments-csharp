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

```bash
dotnet add package DodoPayments.Client
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using DodoPayments.Client;
using DodoPayments.Client.Models.CheckoutSessions;

// Configured using the DODO_PAYMENTS_API_KEY, DODO_PAYMENTS_WEBHOOK_KEY and DODO_PAYMENTS_BASE_URL environment variables
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

## Client Configuration

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

## Requests and responses

To send a request to the Dodo Payments API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.CheckoutSessions.Create` should be called with an instance of `CheckoutSessionCreateParams`, and it will return an instance of `Task<CheckoutSessionResponse>`.

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

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/dodopayments/dodopayments-csharp/issues) with questions, bugs, or suggestions.
