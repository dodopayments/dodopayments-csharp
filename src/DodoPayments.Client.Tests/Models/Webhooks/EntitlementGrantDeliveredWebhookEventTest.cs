using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Grants;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class EntitlementGrantDeliveredWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementGrantDeliveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Status = EntitlementGrantStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DigitalProductDelivery = new()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                },
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                LicenseKey = new()
                {
                    ActivationsUsed = 0,
                    Key = "key",
                    ActivationsLimit = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OAuthUrl = "oauth_url",
                PaymentID = "payment_id",
                RevocationReason = "revocation_reason",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBusinessID = "business_id";
        EntitlementGrant expectedData = new()
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("entitlement_grant.delivered");

        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementGrantDeliveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Status = EntitlementGrantStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DigitalProductDelivery = new()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                },
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                LicenseKey = new()
                {
                    ActivationsUsed = 0,
                    Key = "key",
                    ActivationsLimit = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OAuthUrl = "oauth_url",
                PaymentID = "payment_id",
                RevocationReason = "revocation_reason",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementGrantDeliveredWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementGrantDeliveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Status = EntitlementGrantStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DigitalProductDelivery = new()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                },
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                LicenseKey = new()
                {
                    ActivationsUsed = 0,
                    Key = "key",
                    ActivationsLimit = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OAuthUrl = "oauth_url",
                PaymentID = "payment_id",
                RevocationReason = "revocation_reason",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementGrantDeliveredWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBusinessID = "business_id";
        EntitlementGrant expectedData = new()
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = EntitlementGrantStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DigitalProductDelivery = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            LicenseKey = new()
            {
                ActivationsUsed = 0,
                Key = "key",
                ActivationsLimit = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("entitlement_grant.delivered");

        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementGrantDeliveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Status = EntitlementGrantStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DigitalProductDelivery = new()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                },
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                LicenseKey = new()
                {
                    ActivationsUsed = 0,
                    Key = "key",
                    ActivationsLimit = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OAuthUrl = "oauth_url",
                PaymentID = "payment_id",
                RevocationReason = "revocation_reason",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementGrantDeliveredWebhookEvent
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Status = EntitlementGrantStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DigitalProductDelivery = new()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                },
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                LicenseKey = new()
                {
                    ActivationsUsed = 0,
                    Key = "key",
                    ActivationsLimit = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OAuthUrl = "oauth_url",
                PaymentID = "payment_id",
                RevocationReason = "revocation_reason",
                RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        EntitlementGrantDeliveredWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
