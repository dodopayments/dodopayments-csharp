using System;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementRetrieveParams
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",
            Locale = "locale",
        };

        string expectedID = "ent_jt7jcvI79Xh8eehqgWdcm";
        string expectedLocale = "locale";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementRetrieveParams { ID = "ent_jt7jcvI79Xh8eehqgWdcm" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntitlementRetrieveParams
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementRetrieveParams parameters = new()
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/entitlements/ent_jt7jcvI79Xh8eehqgWdcm?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementRetrieveParams
        {
            ID = "ent_jt7jcvI79Xh8eehqgWdcm",
            Locale = "locale",
        };

        EntitlementRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
