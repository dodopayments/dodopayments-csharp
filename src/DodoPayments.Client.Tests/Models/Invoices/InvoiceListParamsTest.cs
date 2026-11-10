using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceListParams
        {
            CollectionMethod = CollectionMethod.AutoCharge,
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DueAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
            Status = [Status.Open],
            SubscriptionID = "subscription_id",
            Tags = [Tag.Refunded],
            TotalAmountGte = 0,
            TotalAmountLte = 0,
        };

        ApiEnum<string, CollectionMethod> expectedCollectionMethod = CollectionMethod.AutoCharge;
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        DateTimeOffset expectedDueAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDueAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        List<ApiEnum<string, Status>> expectedStatus = [Status.Open];
        string expectedSubscriptionID = "subscription_id";
        List<ApiEnum<string, Tag>> expectedTags = [Tag.Refunded];
        long expectedTotalAmountGte = 0;
        long expectedTotalAmountLte = 0;

        Assert.Equal(expectedCollectionMethod, parameters.CollectionMethod);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDueAtGte, parameters.DueAtGte);
        Assert.Equal(expectedDueAtLte, parameters.DueAtLte);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.Equal(expectedTotalAmountGte, parameters.TotalAmountGte);
        Assert.Equal(expectedTotalAmountLte, parameters.TotalAmountLte);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceListParams { };

        Assert.Null(parameters.CollectionMethod);
        Assert.False(parameters.RawQueryData.ContainsKey("collection_method"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.DueAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("due_at_gte"));
        Assert.Null(parameters.DueAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("due_at_lte"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
        Assert.Null(parameters.TotalAmountGte);
        Assert.False(parameters.RawQueryData.ContainsKey("total_amount_gte"));
        Assert.Null(parameters.TotalAmountLte);
        Assert.False(parameters.RawQueryData.ContainsKey("total_amount_lte"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceListParams
        {
            // Null should be interpreted as omitted for these properties
            CollectionMethod = null,
            CreatedAtGte = null,
            CreatedAtLte = null,
            CustomerID = null,
            DueAtGte = null,
            DueAtLte = null,
            PageNumber = null,
            PageSize = null,
            Status = null,
            SubscriptionID = null,
            Tags = null,
            TotalAmountGte = null,
            TotalAmountLte = null,
        };

        Assert.Null(parameters.CollectionMethod);
        Assert.False(parameters.RawQueryData.ContainsKey("collection_method"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.DueAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("due_at_gte"));
        Assert.Null(parameters.DueAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("due_at_lte"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
        Assert.Null(parameters.TotalAmountGte);
        Assert.False(parameters.RawQueryData.ContainsKey("total_amount_gte"));
        Assert.Null(parameters.TotalAmountLte);
        Assert.False(parameters.RawQueryData.ContainsKey("total_amount_lte"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceListParams parameters = new()
        {
            CollectionMethod = CollectionMethod.AutoCharge,
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CustomerID = "customer_id",
            DueAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            DueAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            PageNumber = 0,
            PageSize = 0,
            Status = [Status.Open],
            SubscriptionID = "subscription_id",
            Tags = [Tag.Refunded],
            TotalAmountGte = 0,
            TotalAmountLte = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/billing/invoices?collection_method=auto_charge&created_at_gte=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_lte=2019-12-27T18%3a11%3a19.117%2b00%3a00&customer_id=customer_id&due_at_gte=2019-12-27T18%3a11%3a19.117%2b00%3a00&due_at_lte=2019-12-27T18%3a11%3a19.117%2b00%3a00&page_number=0&page_size=0&status=open&subscription_id=subscription_id&tags=refunded&total_amount_gte=0&total_amount_lte=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceListParams
        {
            CollectionMethod = CollectionMethod.AutoCharge,
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DueAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageNumber = 0,
            PageSize = 0,
            Status = [Status.Open],
            SubscriptionID = "subscription_id",
            Tags = [Tag.Refunded],
            TotalAmountGte = 0,
            TotalAmountLte = 0,
        };

        InvoiceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(CollectionMethod.AutoCharge)]
    [InlineData(CollectionMethod.Manual)]
    public void Validation_Works(CollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CollectionMethod.AutoCharge)]
    [InlineData(CollectionMethod.Manual)]
    public void SerializationRoundtrip_Works(CollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Open)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Void)]
    [InlineData(Status.Draft)]
    [InlineData(Status.PastDue)]
    [InlineData(Status.Uncollectable)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Open)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Void)]
    [InlineData(Status.Draft)]
    [InlineData(Status.PastDue)]
    [InlineData(Status.Uncollectable)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TagTest : TestBase
{
    [Theory]
    [InlineData(Tag.Refunded)]
    [InlineData(Tag.PartiallyRefunded)]
    [InlineData(Tag.Disputed)]
    [InlineData(Tag.PaymentReversed)]
    public void Validation_Works(Tag rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tag> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tag>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Tag.Refunded)]
    [InlineData(Tag.PartiallyRefunded)]
    [InlineData(Tag.Disputed)]
    [InlineData(Tag.PaymentReversed)]
    public void SerializationRoundtrip_Works(Tag rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tag> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tag>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tag>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tag>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
