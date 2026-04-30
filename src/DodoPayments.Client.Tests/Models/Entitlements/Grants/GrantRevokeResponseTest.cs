using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements.Grants;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.Entitlements.Grants;

public class GrantRevokeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedEntitlementID = "entitlement_id";
        string expectedExternalID = "external_id";
        ApiEnum<string, GrantRevokeResponseStatus> expectedStatus =
            GrantRevokeResponseStatus.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
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
        };
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        GrantRevokeResponseLicenseKey expectedLicenseKey = new()
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedOAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOAuthUrl = "oauth_url";
        string expectedPaymentID = "payment_id";
        string expectedRevocationReason = "revocation_reason";
        DateTimeOffset expectedRevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEntitlementID, model.EntitlementID);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDeliveredAt, model.DeliveredAt);
        Assert.Equal(expectedDigitalProductDelivery, model.DigitalProductDelivery);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedLicenseKey, model.LicenseKey);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedOAuthExpiresAt, model.OAuthExpiresAt);
        Assert.Equal(expectedOAuthUrl, model.OAuthUrl);
        Assert.Equal(expectedPaymentID, model.PaymentID);
        Assert.Equal(expectedRevocationReason, model.RevocationReason);
        Assert.Equal(expectedRevokedAt, model.RevokedAt);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantRevokeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantRevokeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        string expectedEntitlementID = "entitlement_id";
        string expectedExternalID = "external_id";
        ApiEnum<string, GrantRevokeResponseStatus> expectedStatus =
            GrantRevokeResponseStatus.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductDigitalProductDelivery expectedDigitalProductDelivery = new()
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
        };
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        GrantRevokeResponseLicenseKey expectedLicenseKey = new()
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedOAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOAuthUrl = "oauth_url";
        string expectedPaymentID = "payment_id";
        string expectedRevocationReason = "revocation_reason";
        DateTimeOffset expectedRevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEntitlementID, deserialized.EntitlementID);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDeliveredAt, deserialized.DeliveredAt);
        Assert.Equal(expectedDigitalProductDelivery, deserialized.DigitalProductDelivery);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedLicenseKey, deserialized.LicenseKey);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedOAuthExpiresAt, deserialized.OAuthExpiresAt);
        Assert.Equal(expectedOAuthUrl, deserialized.OAuthUrl);
        Assert.Equal(expectedPaymentID, deserialized.PaymentID);
        Assert.Equal(expectedRevocationReason, deserialized.RevocationReason);
        Assert.Equal(expectedRevokedAt, deserialized.RevokedAt);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("delivered_at"));
        Assert.Null(model.DigitalProductDelivery);
        Assert.False(model.RawData.ContainsKey("digital_product_delivery"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.LicenseKey);
        Assert.False(model.RawData.ContainsKey("license_key"));
        Assert.Null(model.OAuthExpiresAt);
        Assert.False(model.RawData.ContainsKey("oauth_expires_at"));
        Assert.Null(model.OAuthUrl);
        Assert.False(model.RawData.ContainsKey("oauth_url"));
        Assert.Null(model.PaymentID);
        Assert.False(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.RevocationReason);
        Assert.False(model.RawData.ContainsKey("revocation_reason"));
        Assert.Null(model.RevokedAt);
        Assert.False(model.RawData.ContainsKey("revoked_at"));
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),

            DeliveredAt = null,
            DigitalProductDelivery = null,
            ErrorCode = null,
            ErrorMessage = null,
            LicenseKey = null,
            OAuthExpiresAt = null,
            OAuthUrl = null,
            PaymentID = null,
            RevocationReason = null,
            RevokedAt = null,
            SubscriptionID = null,
        };

        Assert.Null(model.DeliveredAt);
        Assert.True(model.RawData.ContainsKey("delivered_at"));
        Assert.Null(model.DigitalProductDelivery);
        Assert.True(model.RawData.ContainsKey("digital_product_delivery"));
        Assert.Null(model.ErrorCode);
        Assert.True(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.LicenseKey);
        Assert.True(model.RawData.ContainsKey("license_key"));
        Assert.Null(model.OAuthExpiresAt);
        Assert.True(model.RawData.ContainsKey("oauth_expires_at"));
        Assert.Null(model.OAuthUrl);
        Assert.True(model.RawData.ContainsKey("oauth_url"));
        Assert.Null(model.PaymentID);
        Assert.True(model.RawData.ContainsKey("payment_id"));
        Assert.Null(model.RevocationReason);
        Assert.True(model.RawData.ContainsKey("revocation_reason"));
        Assert.Null(model.RevokedAt);
        Assert.True(model.RawData.ContainsKey("revoked_at"));
        Assert.Null(model.SubscriptionID);
        Assert.True(model.RawData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),

            DeliveredAt = null,
            DigitalProductDelivery = null,
            ErrorCode = null,
            ErrorMessage = null,
            LicenseKey = null,
            OAuthExpiresAt = null,
            OAuthUrl = null,
            PaymentID = null,
            RevocationReason = null,
            RevokedAt = null,
            SubscriptionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrantRevokeResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EntitlementID = "entitlement_id",
            ExternalID = "external_id",
            Status = GrantRevokeResponseStatus.Pending,
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
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OAuthExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OAuthUrl = "oauth_url",
            PaymentID = "payment_id",
            RevocationReason = "revocation_reason",
            RevokedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscription_id",
        };

        GrantRevokeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantRevokeResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(GrantRevokeResponseStatus.Pending)]
    [InlineData(GrantRevokeResponseStatus.Delivered)]
    [InlineData(GrantRevokeResponseStatus.Failed)]
    [InlineData(GrantRevokeResponseStatus.Revoked)]
    public void Validation_Works(GrantRevokeResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantRevokeResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantRevokeResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantRevokeResponseStatus.Pending)]
    [InlineData(GrantRevokeResponseStatus.Delivered)]
    [InlineData(GrantRevokeResponseStatus.Failed)]
    [InlineData(GrantRevokeResponseStatus.Revoked)]
    public void SerializationRoundtrip_Works(GrantRevokeResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantRevokeResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantRevokeResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantRevokeResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantRevokeResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GrantRevokeResponseLicenseKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        int expectedActivationsUsed = 0;
        string expectedKey = "key";
        int expectedActivationsLimit = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActivationsUsed, model.ActivationsUsed);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantRevokeResponseLicenseKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantRevokeResponseLicenseKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedActivationsUsed = 0;
        string expectedKey = "key";
        int expectedActivationsLimit = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActivationsUsed, deserialized.ActivationsUsed);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GrantRevokeResponseLicenseKey { ActivationsUsed = 0, Key = "key" };

        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GrantRevokeResponseLicenseKey { ActivationsUsed = 0, Key = "key" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",

            ActivationsLimit = null,
            ExpiresAt = null,
        };

        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",

            ActivationsLimit = null,
            ExpiresAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrantRevokeResponseLicenseKey
        {
            ActivationsUsed = 0,
            Key = "key",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        GrantRevokeResponseLicenseKey copied = new(model);

        Assert.Equal(model, copied);
    }
}
