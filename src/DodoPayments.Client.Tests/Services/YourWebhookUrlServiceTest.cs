using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DodoPayments.Client.Models.Disputes;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Refunds;
using DodoPayments.Client.Models.YourWebhookUrl;
using Payments = DodoPayments.Client.Models.Payments;
using WebhookEvents = DodoPayments.Client.Models.WebhookEvents;

namespace DodoPayments.Client.Tests.Services;

public class YourWebhookUrlServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.YourWebhookUrl.Create(
            new()
            {
                BusinessID = "business_id",
                Data = new Payment()
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
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    InvoiceID = "invoice_id",
                    InvoiceUrl = "invoice_url",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    RefundStatus = Payments::PaymentRefundStatus.Partial,
                    SettlementTax = 0,
                    Status = Payments::IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType = PayloadType.Payment,
                },
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = WebhookEvents::WebhookEventType.PaymentSucceeded,
                WebhookID = "webhook-id",
                WebhookSignature = "webhook-signature",
                WebhookTimestamp = "webhook-timestamp",
            },
            TestContext.Current.CancellationToken
        );
    }
}
