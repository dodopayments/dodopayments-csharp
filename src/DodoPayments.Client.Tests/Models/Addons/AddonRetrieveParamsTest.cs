using System;
using DodoPayments.Client.Models.Addons;

namespace DodoPayments.Client.Tests.Models.Addons;

public class AddonRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonRetrieveParams
        {
            ID = "adn_NX1zdqW4Hbivsqz8vI9dc",
            Locale = "locale",
        };

        string expectedID = "adn_NX1zdqW4Hbivsqz8vI9dc";
        string expectedLocale = "locale";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonRetrieveParams { ID = "adn_NX1zdqW4Hbivsqz8vI9dc" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AddonRetrieveParams
        {
            ID = "adn_NX1zdqW4Hbivsqz8vI9dc",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        AddonRetrieveParams parameters = new()
        {
            ID = "adn_NX1zdqW4Hbivsqz8vI9dc",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/addons/adn_NX1zdqW4Hbivsqz8vI9dc?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonRetrieveParams
        {
            ID = "adn_NX1zdqW4Hbivsqz8vI9dc",
            Locale = "locale",
        };

        AddonRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
