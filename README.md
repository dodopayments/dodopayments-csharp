# Dodo Payments C# API Library

> [!NOTE]
> The Dodo Payments C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/stainless-sdks/dodo-payments-csharp/issues/new).

The Dodo Payments C# SDK provides convenient access to the [Dodo Payments REST API](https://docs.dodopayments.com) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.dodopayments.com](https://docs.dodopayments.com).

## Installation

```bash
dotnet add package DodoPayments
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using DodoPayments;
using DodoPayments.Models.Misc;
using DodoPayments.Models.Payments;
using System;

// Configured using the DODO_PAYMENTS_API_KEY and DODO_PAYMENTS_BASE_URL environment variables
DodoPaymentsClient client = new();

PaymentCreateParams parameters = new()
{
    Billing = new()
    {
        City = "city",
        Country = CountryCode.Af,
        State = "state",
        Street = "street",
        Zipcode = "zipcode",
    },
    Customer = new AttachExistingCustomer("customer_id"),
    ProductCart =
    [
        new()
        {
            ProductID = "product_id",
            Quantity = 0,
        },
    ],
};

var payment = await client.Payments.Create(parameters);

Console.WriteLine(payment);
```

## Client Configuration

Configure the client using environment variables:

```csharp
using DodoPayments;

// Configured using the DODO_PAYMENTS_API_KEY and DODO_PAYMENTS_BASE_URL environment variables
DodoPaymentsClient client = new();
```

Or manually:

```csharp
using DodoPayments;

DodoPaymentsClient client = new() { BearerToken = "My Bearer Token" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property      | Environment variable     | Required | Default value                     |
| ------------- | ------------------------ | -------- | --------------------------------- |
| `BearerToken` | `DODO_PAYMENTS_API_KEY`  | true     | -                                 |
| `BaseUrl`     | `DODO_PAYMENTS_BASE_URL` | true     | `"https://live.dodopayments.com"` |

## Requests and responses

To send a request to the Dodo Payments API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Payments.Create` should be called with an instance of `PaymentCreateParams`, and it will return an instance of `Task<PaymentCreateResponse>`.

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/stainless-sdks/dodo-payments-csharp/issues) with questions, bugs, or suggestions.
