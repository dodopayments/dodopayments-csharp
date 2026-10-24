using System;
using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterRetrieveParams
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",
            Locale = "locale",
        };

        string expectedID = "mtr_h5tgTWL55OyMO0L2Q9w9v";
        string expectedLocale = "locale";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MeterRetrieveParams { ID = "mtr_h5tgTWL55OyMO0L2Q9w9v" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MeterRetrieveParams
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        MeterRetrieveParams parameters = new()
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",
            Locale = "locale",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/meters/mtr_h5tgTWL55OyMO0L2Q9w9v?locale=locale"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MeterRetrieveParams
        {
            ID = "mtr_h5tgTWL55OyMO0L2Q9w9v",
            Locale = "locale",
        };

        MeterRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
