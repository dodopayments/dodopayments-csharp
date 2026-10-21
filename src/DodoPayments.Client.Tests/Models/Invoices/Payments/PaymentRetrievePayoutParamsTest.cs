using System;
using DodoPayments.Client.Models.Invoices.Payments;

namespace DodoPayments.Client.Tests.Models.Invoices.Payments;

public class PaymentRetrievePayoutParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentRetrievePayoutParams
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",
            Token = "token",
        };

        string expectedPayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T";
        string expectedToken = "token";

        Assert.Equal(expectedPayoutID, parameters.PayoutID);
        Assert.Equal(expectedToken, parameters.Token);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PaymentRetrievePayoutParams { PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T" };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PaymentRetrievePayoutParams
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",

            // Null should be interpreted as omitted for these properties
            Token = null,
        };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawQueryData.ContainsKey("token"));
    }

    [Fact]
    public void Url_Works()
    {
        PaymentRetrievePayoutParams parameters = new()
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",
            Token = "token",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/invoices/payouts/pyt_zFTrrn4sk3x3y2vjDBW3T?token=token"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentRetrievePayoutParams
        {
            PayoutID = "pyt_zFTrrn4sk3x3y2vjDBW3T",
            Token = "token",
        };

        PaymentRetrievePayoutParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
