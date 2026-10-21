using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrieveRefundParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrieveRefundParams
        {
            RefundID = "ref_F0gZetLvTxxBrMU2CZcmy",
            Token = "token",
        };

        string expectedRefundID = "ref_F0gZetLvTxxBrMU2CZcmy";
        string expectedToken = "token";

        Assert.Equal(expectedRefundID, parameters.RefundID);
        Assert.Equal(expectedToken, parameters.Token);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentRetrieveRefundParams { RefundID = "ref_F0gZetLvTxxBrMU2CZcmy" };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PaymentRetrieveRefundParams
        {
            RefundID = "ref_F0gZetLvTxxBrMU2CZcmy",

            // Null should be interpreted as omitted for these properties
            Token = null,
        };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrieveRefundParams parameters = new()
        {
            RefundID = "ref_F0gZetLvTxxBrMU2CZcmy",
            Token = "token",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/invoices/refunds/ref_F0gZetLvTxxBrMU2CZcmy?token=token"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrieveRefundParams
        {
            RefundID = "ref_F0gZetLvTxxBrMU2CZcmy",
            Token = "token",
        };

        PaymentRetrieveRefundParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
