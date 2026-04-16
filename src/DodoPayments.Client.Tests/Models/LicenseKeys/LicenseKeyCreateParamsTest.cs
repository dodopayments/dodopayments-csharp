using System;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyCreateParams
        {
            CustomerID = "customer_id",
            Key = "key",
            ProductID = "product_id",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCustomerID = "customer_id";
        string expectedKey = "key";
        string expectedProductID = "product_id";
        int expectedActivationsLimit = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedKey, parameters.Key);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedActivationsLimit, parameters.ActivationsLimit);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseKeyCreateParams
        {
            CustomerID = "customer_id",
            Key = "key",
            ProductID = "product_id",
        };

        Assert.Null(parameters.ActivationsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("activations_limit"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseKeyCreateParams
        {
            CustomerID = "customer_id",
            Key = "key",
            ProductID = "product_id",

            ActivationsLimit = null,
            ExpiresAt = null,
        };

        Assert.Null(parameters.ActivationsLimit);
        Assert.True(parameters.RawBodyData.ContainsKey("activations_limit"));
        Assert.Null(parameters.ExpiresAt);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void Url_Works()
    {
        LicenseKeyCreateParams parameters = new()
        {
            CustomerID = "customer_id",
            Key = "key",
            ProductID = "product_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://live.dodopayments.com/license_keys"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseKeyCreateParams
        {
            CustomerID = "customer_id",
            Key = "key",
            ProductID = "product_id",
            ActivationsLimit = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        LicenseKeyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
