using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class RefundFailedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RefundFailedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
                PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundFailedWebhookEventType.RefundFailed,
        };

        string expectedBusinessID = "business_id";
        RefundFailedWebhookEventData expectedData = new()
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RefundFailedWebhookEventType> expectedType =
            RefundFailedWebhookEventType.RefundFailed;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RefundFailedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
                PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundFailedWebhookEventType.RefundFailed,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RefundFailedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
                PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundFailedWebhookEventType.RefundFailed,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEvent>(json);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        RefundFailedWebhookEventData expectedData = new()
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RefundFailedWebhookEventType> expectedType =
            RefundFailedWebhookEventType.RefundFailed;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RefundFailedWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                IsPartial = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                RefundID = "refund_id",
                Status = RefundStatus.Succeeded,
                Amount = 0,
                Currency = Currency.Aed,
                Reason = "reason",
                PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = RefundFailedWebhookEventType.RefundFailed,
        };

        model.Validate();
    }
}

public class RefundFailedWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        bool expectedIsPartial = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        string expectedRefundID = "refund_id";
        ApiEnum<string, RefundStatus> expectedStatus = RefundStatus.Succeeded;
        int expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedReason = "reason";
        ApiEnum<
            string,
            RefundFailedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund;

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedIsPartial, model.IsPartial);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRefundID, model.RefundID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEventData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RefundFailedWebhookEventData>(json);
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        bool expectedIsPartial = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentID = "payment_id";
        string expectedRefundID = "refund_id";
        ApiEnum<string, RefundStatus> expectedStatus = RefundStatus.Succeeded;
        int expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        string expectedReason = "reason";
        ApiEnum<
            string,
            RefundFailedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund;

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedIsPartial, deserialized.IsPartial);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRefundID, deserialized.RefundID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Currency = Currency.Aed,
            Reason = "reason",
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Currency = null,
            PayloadType = null,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Amount = 0,
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Currency = null,
            PayloadType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Currency = Currency.Aed,
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Currency = Currency.Aed,
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Currency = Currency.Aed,
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,

            Amount = null,
            Reason = null,
        };

        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RefundFailedWebhookEventData
        {
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            IsPartial = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentID = "payment_id",
            RefundID = "refund_id",
            Status = RefundStatus.Succeeded,
            Currency = Currency.Aed,
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,

            Amount = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class RefundFailedWebhookEventDataIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1
        {
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        ApiEnum<
            string,
            RefundFailedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund;

        Assert.Equal(expectedPayloadType, model.PayloadType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1
        {
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<RefundFailedWebhookEventDataIntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1
        {
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<RefundFailedWebhookEventDataIntersectionMember1>(json);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RefundFailedWebhookEventDataIntersectionMember1PayloadType
        > expectedPayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund;

        Assert.Equal(expectedPayloadType, deserialized.PayloadType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1
        {
            PayloadType = RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1 { };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        Assert.Null(model.PayloadType);
        Assert.False(model.RawData.ContainsKey("payload_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RefundFailedWebhookEventDataIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            PayloadType = null,
        };

        model.Validate();
    }
}

public class RefundFailedWebhookEventDataIntersectionMember1PayloadTypeTest : TestBase
{
    [Theory]
    [InlineData(RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund)]
    public void Validation_Works(
        RefundFailedWebhookEventDataIntersectionMember1PayloadType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RefundFailedWebhookEventDataIntersectionMember1PayloadType.Refund)]
    public void SerializationRoundtrip_Works(
        RefundFailedWebhookEventDataIntersectionMember1PayloadType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RefundFailedWebhookEventDataIntersectionMember1PayloadType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RefundFailedWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(RefundFailedWebhookEventType.RefundFailed)]
    public void Validation_Works(RefundFailedWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundFailedWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefundFailedWebhookEventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RefundFailedWebhookEventType.RefundFailed)]
    public void SerializationRoundtrip_Works(RefundFailedWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefundFailedWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RefundFailedWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefundFailedWebhookEventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RefundFailedWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
