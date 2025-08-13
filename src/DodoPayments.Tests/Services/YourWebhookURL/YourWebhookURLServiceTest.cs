using System;
using System.Threading.Tasks;
using DodoPayments.Models.Misc;
using DodoPayments.Models.WebhookEvents;
using DodoPayments.Models.YourWebhookURL.YourWebhookURLCreateParamsProperties.DataProperties;
using DodoPayments.Models.YourWebhookURL.YourWebhookURLCreateParamsProperties.DataProperties.PaymentProperties.IntersectionMember1Properties;
using Disputes = DodoPayments.Models.Disputes;
using Payments = DodoPayments.Models.Payments;
using Refunds = DodoPayments.Models.Refunds;

namespace DodoPayments.Tests.Services.YourWebhookURL;

public class YourWebhookURLServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.YourWebhookURL.Create(
            new()
            {
                BusinessID = "business_id",
                Data = new Payment()
                {
                    Billing = new()
                    {
                        City = "city",
                        Country = CountryCode.Af,
                        State = "state",
                        Street = "street",
                        Zipcode = "zipcode",
                    },
                    BrandID = "brand_id",
                    BusinessID = "business_id",
                    CreatedAt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Customer = new()
                    {
                        CustomerID = "customer_id",
                        Email = "email",
                        Name = "name",
                    },
                    DigitalProductsDelivered = true,
                    Disputes =
                    [
                        new()
                        {
                            Amount = "amount",
                            BusinessID = "business_id",
                            CreatedAt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                            Currency = "currency",
                            DisputeID = "dispute_id",
                            DisputeStage = Disputes::DisputeStage.PreDispute,
                            DisputeStatus = Disputes::DisputeStatus.DisputeOpened,
                            PaymentID = "payment_id",
                            Remarks = "remarks",
                        },
                    ],
                    Metadata = new() { { "foo", "string" } },
                    PaymentID = "payment_id",
                    Refunds =
                    [
                        new()
                        {
                            BusinessID = "business_id",
                            CreatedAt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                            IsPartial = true,
                            PaymentID = "payment_id",
                            RefundID = "refund_id",
                            Status = Refunds::RefundStatus.Succeeded,
                            Amount = 0,
                            Currency = Currency.Aed,
                            Reason = "reason",
                        },
                    ],
                    SettlementAmount = 0,
                    SettlementCurrency = Currency.Aed,
                    TotalAmount = 0,
                    CardIssuingCountry = CountryCode.Af,
                    CardLastFour = "card_last_four",
                    CardNetwork = "card_network",
                    CardType = "card_type",
                    DiscountID = "discount_id",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    PaymentLink = "payment_link",
                    PaymentMethod = "payment_method",
                    PaymentMethodType = "payment_method_type",
                    ProductCart = [new() { ProductID = "product_id", Quantity = 0 }],
                    SettlementTax = 0,
                    Status = Payments::IntentStatus.Succeeded,
                    SubscriptionID = "subscription_id",
                    Tax = 0,
                    UpdatedAt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    PayloadType = PayloadType.Payment,
                },
                Timestamp = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Type = WebhookEventType.PaymentSucceeded,
                WebhookID = "webhook-id",
                WebhookSignature = "webhook-signature",
                WebhookTimestamp = "webhook-timestamp",
            }
        );
    }
}
