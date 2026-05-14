using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.CreditEntitlements.Balances;
using DodoPayments.Client.Models.Discounts;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Entitlements.Grants;
using DodoPayments.Client.Models.LicenseKeys;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Payments;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.Subscriptions;
using DodoPayments.Client.Models.Webhooks;

namespace DodoPayments.Client.Tests.Models.Webhooks;

public class UnsafeUnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void AbandonedCheckoutDetectedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new AbandonedCheckoutDetectedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = global::DodoPayments.Client.Models.Webhooks.Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void AbandonedCheckoutRecoveredValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new AbandonedCheckoutRecoveredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditAddedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditAddedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditBalanceLowValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditBalanceLowWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditDeductedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditDeductedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditExpiredValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditManualAdjustmentValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditManualAdjustmentWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditOverageChargedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditOverageChargedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditOverageResetValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditOverageResetWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditRolledOverValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditRolledOverWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditRolloverForfeitedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditRolloverForfeitedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeAcceptedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeCancelledValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeChallengedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeExpiredValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeLostValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeLostWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeOpenedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DisputeWonValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeWonWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DunningRecoveredValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DunningRecoveredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void DunningStartedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DunningStartedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void EntitlementGrantCreatedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantCreatedWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void EntitlementGrantDeliveredValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantDeliveredWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void EntitlementGrantFailedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantFailedWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void EntitlementGrantRevokedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantRevokedWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void LicenseKeyCreatedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "lic_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                CustomerID = "cus_123",
                InstancesCount = 0,
                Key = "key",
                ProductID = "product_id",
                Source = LicenseKeySource.Auto,
                Status = LicenseKeyStatus.Active,
                ActivationsLimit = 5,
                ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
                PaymentID = "payment_id",
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void PaymentCancelledValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void PaymentFailedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void PaymentProcessingValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void PaymentSucceededValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void RefundFailedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new RefundFailedWebhookEvent()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void RefundSucceededValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionActiveValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionCancelledValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionExpiredValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionFailedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionOnHoldValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionPlanChangedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionRenewedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SubscriptionUpdatedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void AbandonedCheckoutDetectedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new AbandonedCheckoutDetectedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason = AbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = global::DodoPayments.Client.Models.Webhooks.Status.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AbandonedCheckoutRecoveredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new AbandonedCheckoutRecoveredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AbandonedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AbandonmentReason =
                    AbandonedCheckoutRecoveredWebhookEventDataAbandonmentReason.PaymentFailed,
                CustomerID = "customer_id",
                PaymentID = "payment_id",
                Status = AbandonedCheckoutRecoveredWebhookEventDataStatus.Abandoned,
                RecoveredPaymentID = "recovered_payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditAddedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditAddedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditBalanceLowSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditBalanceLowWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                AvailableBalance = "available_balance",
                CreditEntitlementID = "credit_entitlement_id",
                CreditEntitlementName = "credit_entitlement_name",
                CustomerID = "customer_id",
                SubscriptionCreditsAmount = "subscription_credits_amount",
                SubscriptionID = "subscription_id",
                ThresholdAmount = "threshold_amount",
                ThresholdPercent = 0,
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditDeductedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditDeductedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditExpiredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditManualAdjustmentSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditManualAdjustmentWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditOverageChargedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditOverageChargedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditOverageResetSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditOverageResetWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditRolledOverSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditRolledOverWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditRolloverForfeitedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new CreditRolloverForfeitedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "id",
                Amount = "amount",
                BalanceAfter = "balance_after",
                BalanceBefore = "balance_before",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementID = "credit_entitlement_id",
                CustomerID = "customer_id",
                IsCredit = true,
                OverageAfter = "overage_after",
                OverageBefore = "overage_before",
                TransactionType = TransactionType.CreditAdded,
                Description = "description",
                GrantID = "grant_id",
                ReferenceID = "reference_id",
                ReferenceType = "reference_type",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeAcceptedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeAcceptedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeCancelledSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeChallengedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeChallengedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeExpiredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeLostSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeLostWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeOpenedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeOpenedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisputeWonSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DisputeWonWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Amount = "amount",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DisputeID = "dispute_id",
                DisputeStage = DisputeDisputeStage.PreDispute,
                DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                PaymentID = "payment_id",
                IsResolvedByRdr = true,
                Remarks = "remarks",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DunningRecoveredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DunningRecoveredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningRecoveredWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = TriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DunningStartedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new DunningStartedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                Status = DunningStartedWebhookEventDataStatus.Recovering,
                SubscriptionID = "subscription_id",
                TriggerState = DunningStartedWebhookEventDataTriggerState.OnHold,
                PaymentID = "payment_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EntitlementGrantCreatedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantCreatedWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EntitlementGrantDeliveredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantDeliveredWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EntitlementGrantFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantFailedWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EntitlementGrantRevokedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new EntitlementGrantRevokedWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeyCreatedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new LicenseKeyCreatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                ID = "lic_123",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                CustomerID = "cus_123",
                InstancesCount = 0,
                Key = "key",
                ProductID = "product_id",
                Source = LicenseKeySource.Auto,
                Status = LicenseKeyStatus.Active,
                ActivationsLimit = 5,
                ExpiresAt = DateTimeOffset.Parse("2024-12-31T23:59:59Z"),
                PaymentID = "payment_id",
                SubscriptionID = "subscription_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentCancelledSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentProcessingSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentProcessingWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PaymentSucceededSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new PaymentSucceededWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                BrandID = "brand_id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                DigitalProductsDelivered = true,
                Disputes =
                [
                    new()
                    {
                        Amount = "amount",
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DisputeID = "dispute_id",
                        DisputeStage = DisputeDisputeStage.PreDispute,
                        DisputeStatus = DisputeDisputeStatus.DisputeOpened,
                        PaymentID = "payment_id",
                        IsResolvedByRdr = true,
                        Remarks = "remarks",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentID = "payment_id",
                Refunds =
                [
                    new()
                    {
                        BusinessID = "business_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IsPartial = true,
                        PaymentID = "payment_id",
                        RefundID = "refund_id",
                        Status = RefundStatus.Succeeded,
                        Amount = 0,
                        Currency = Currency.Aed,
                        Reason = "reason",
                    },
                ],
                SettlementAmount = 0,
                SettlementCurrency = Currency.Aed,
                TotalAmount = 0,
                CardHolderName = "card_holder_name",
                CardIssuingCountry = CountryCode.Af,
                CardLastFour = "card_last_four",
                CardNetwork = "card_network",
                CardType = "card_type",
                CheckoutSessionID = "checkout_session_id",
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                InvoiceID = "invoice_id",
                InvoiceUrl = "invoice_url",
                PaymentLink = "payment_link",
                PaymentMethod = "payment_method",
                PaymentMethodType = "payment_method_type",
                ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                RefundStatus = PaymentRefundStatus.Partial,
                SettlementTax = 0,
                Status = IntentStatus.Succeeded,
                SubscriptionID = "subscription_id",
                Tax = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new RefundFailedWebhookEvent()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefundSucceededSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new RefundSucceededWebhookEvent()
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
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionActiveSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionActiveWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionCancelledSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionCancelledWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionExpiredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionExpiredWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionFailedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionFailedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionOnHoldSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionOnHoldWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionPlanChangedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionPlanChangedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionRenewedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionRenewedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubscriptionUpdatedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SubscriptionUpdatedWebhookEvent()
        {
            BusinessID = "business_id",
            Data = new()
            {
                Addons = [new() { AddonID = "addon_id", Quantity = 0 }],
                Billing = new()
                {
                    Country = CountryCode.Af,
                    City = "city",
                    State = "state",
                    Street = "street",
                    Zipcode = "zipcode",
                },
                CancelAtNextBillingDate = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        CreditEntitlementName = "credit_entitlement_name",
                        CreditsAmount = "credits_amount",
                        OverageBalance = "overage_balance",
                        OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                        OverageEnabled = true,
                        ProductID = "product_id",
                        RemainingBalance = "remaining_balance",
                        RolloverEnabled = true,
                        Unit = "unit",
                        ExpiresAfterDays = 0,
                        LowBalanceThresholdPercent = 0,
                        MaxRolloverCount = 0,
                        OverageLimit = "overage_limit",
                        RolloverPercentage = 0,
                        RolloverTimeframeCount = 0,
                        RolloverTimeframeInterval = TimeInterval.Day,
                    },
                ],
                Currency = Currency.Aed,
                Customer = new()
                {
                    CustomerID = "customer_id",
                    Email = "email",
                    Name = "name",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PhoneNumber = "phone_number",
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterCreditEntitlementCart =
                [
                    new()
                    {
                        CreditEntitlementID = "credit_entitlement_id",
                        MeterID = "meter_id",
                        MeterName = "meter_name",
                        MeterUnitsPerCredit = "meter_units_per_credit",
                        ProductID = "product_id",
                    },
                ],
                Meters =
                [
                    new()
                    {
                        Currency = Currency.Aed,
                        FreeThreshold = 0,
                        MeasurementUnit = "measurement_unit",
                        MeterID = "meter_id",
                        Name = "name",
                        Description = "description",
                        PricePerUnit = "10.50",
                    },
                ],
                NextBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnDemand = true,
                PaymentFrequencyCount = 0,
                PaymentFrequencyInterval = TimeInterval.Day,
                PreviousBillingDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductID = "product_id",
                Quantity = 0,
                RecurringPreTaxAmount = 0,
                Status = SubscriptionStatus.Pending,
                SubscriptionID = "subscription_id",
                SubscriptionPeriodCount = 0,
                SubscriptionPeriodInterval = TimeInterval.Day,
                TaxInclusive = true,
                TrialPeriodDays = 0,
                CancellationComment = "cancellation_comment",
                CancellationFeedback = CancellationFeedback.TooExpensive,
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomFieldResponses = [new() { Key = "key", Value = "value" }],
                DiscountCyclesRemaining = 0,
                DiscountID = "discount_id",
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        BusinessID = "business_id",
                        Code = "code",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DiscountID = "discount_id",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Position = 0,
                        PreserveOnPlanChange = true,
                        RestrictedTo = ["string"],
                        TimesUsed = 0,
                        Type = DiscountType.Percentage,
                        CyclesRemaining = 0,
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                        SubscriptionCycles = 0,
                        UsageLimit = 0,
                    },
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentMethodID = "payment_method_id",
                ScheduledChange = new()
                {
                    ID = "id",
                    Addons =
                    [
                        new()
                        {
                            AddonID = "addon_id",
                            Name = "name",
                            Quantity = 0,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProductID = "product_id",
                    Quantity = 0,
                    ProductDescription = "product_description",
                    ProductName = "product_name",
                },
                TaxID = "tax_id",
            },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
