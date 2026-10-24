using System;
using DodoPayments.Client.Models.CreditEntitlements;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditEntitlementRetrieveParams
        {
            ID = "cde_ztxm5XJsKxWucRWA3rjdM",
            Locale = "locale",
        };

        string expectedID = "cde_ztxm5XJsKxWucRWA3rjdM";
        string expectedLocale = "locale";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditEntitlementRetrieveParams { ID = "cde_ztxm5XJsKxWucRWA3rjdM" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CreditEntitlementRetrieveParams
        {
            ID = "cde_ztxm5XJsKxWucRWA3rjdM",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditEntitlementRetrieveParams parameters = new()
        {
            ID = "cde_ztxm5XJsKxWucRWA3rjdM",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/credit-entitlements/cde_ztxm5XJsKxWucRWA3rjdM?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditEntitlementRetrieveParams
        {
            ID = "cde_ztxm5XJsKxWucRWA3rjdM",
            Locale = "locale",
        };

        CreditEntitlementRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
