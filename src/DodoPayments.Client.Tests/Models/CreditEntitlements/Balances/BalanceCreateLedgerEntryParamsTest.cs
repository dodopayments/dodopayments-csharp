using System;
using System.Collections.Generic;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Balances;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Balances;

public class BalanceCreateLedgerEntryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceCreateLedgerEntryParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Amount = "amount",
            EntryType = LedgerEntryType.Credit,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdempotencyKey = "idempotency_key",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Reason = "reason",
        };

        string expectedCreditEntitlementID = "credit_entitlement_id";
        string expectedCustomerID = "customer_id";
        string expectedAmount = "amount";
        ApiEnum<string, LedgerEntryType> expectedEntryType = LedgerEntryType.Credit;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIdempotencyKey = "idempotency_key";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedReason = "reason";

        Assert.Equal(expectedCreditEntitlementID, parameters.CreditEntitlementID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedEntryType, parameters.EntryType);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceCreateLedgerEntryParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Amount = "amount",
            EntryType = LedgerEntryType.Credit,
        };

        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BalanceCreateLedgerEntryParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Amount = "amount",
            EntryType = LedgerEntryType.Credit,

            ExpiresAt = null,
            IdempotencyKey = null,
            Metadata = null,
            Reason = null,
        };

        Assert.Null(parameters.ExpiresAt);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.True(parameters.RawBodyData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Reason);
        Assert.True(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceCreateLedgerEntryParams parameters = new()
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Amount = "amount",
            EntryType = LedgerEntryType.Credit,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/credit-entitlements/credit_entitlement_id/balances/customer_id/ledger-entries"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceCreateLedgerEntryParams
        {
            CreditEntitlementID = "credit_entitlement_id",
            CustomerID = "customer_id",
            Amount = "amount",
            EntryType = LedgerEntryType.Credit,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdempotencyKey = "idempotency_key",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Reason = "reason",
        };

        BalanceCreateLedgerEntryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
