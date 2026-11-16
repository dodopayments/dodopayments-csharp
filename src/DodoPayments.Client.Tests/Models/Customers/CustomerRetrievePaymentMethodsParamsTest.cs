using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Customers;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Customers;

public class CustomerRetrievePaymentMethodsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
        };

        string expectedCustomerID = "cus_TV52uJWWXt2yIoBBxpjaa";
        ApiEnum<string, CountryCode> expectedBillingCountry = CountryCode.Af;
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedBillingCountry, parameters.BillingCountry);
        Assert.Equal(expectedCurrency, parameters.Currency);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
        };

        Assert.Null(parameters.BillingCountry);
        Assert.False(parameters.RawQueryData.ContainsKey("billing_country"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",

            // Null should be interpreted as omitted for these properties
            BillingCountry = null,
            Currency = null,
        };

        Assert.Null(parameters.BillingCountry);
        Assert.False(parameters.RawQueryData.ContainsKey("billing_country"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerRetrievePaymentMethodsParams parameters = new()
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/customers/cus_TV52uJWWXt2yIoBBxpjaa/payment-methods?billing_country=AF&currency=AED"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerRetrievePaymentMethodsParams
        {
            CustomerID = "cus_TV52uJWWXt2yIoBBxpjaa",
            BillingCountry = CountryCode.Af,
            Currency = Currency.Aed,
        };

        CustomerRetrievePaymentMethodsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
