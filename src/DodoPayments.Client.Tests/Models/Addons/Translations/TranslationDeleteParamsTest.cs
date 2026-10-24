using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Addons.Translations;

public class TranslationDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationDeleteParams { ID = "id", Locale = Locale.Ar };

        string expectedID = "id";
        ApiEnum<string, Locale> expectedLocale = Locale.Ar;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void Url_Works()
    {
        TranslationDeleteParams parameters = new() { ID = "id", Locale = Locale.Ar };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/addons/id/translations/ar"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranslationDeleteParams { ID = "id", Locale = Locale.Ar };

        TranslationDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
