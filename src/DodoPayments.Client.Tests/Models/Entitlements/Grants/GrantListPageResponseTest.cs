using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Entitlements.Grants;

namespace DodoPayments.Client.Tests.Models.Entitlements.Grants;

public class GrantListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customer_id",
                    EntitlementID = "entitlement_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
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
            ],
        };

        List<EntitlementGrant> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                IntegrationType = EntitlementIntegrationType.Discord,
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
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GrantListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customer_id",
                    EntitlementID = "entitlement_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customer_id",
                    EntitlementID = "entitlement_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EntitlementGrant> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EntitlementID = "entitlement_id",
                IntegrationType = EntitlementIntegrationType.Discord,
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
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GrantListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customer_id",
                    EntitlementID = "entitlement_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrantListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customer_id",
                    EntitlementID = "entitlement_id",
                    IntegrationType = EntitlementIntegrationType.Discord,
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
            ],
        };

        GrantListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
