using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Entitlements.Translations;

namespace DodoPayments.Client.Tests.Models.Entitlements.Translations;

public class TranslationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationListParams { ID = "id", Locale = ["string"] };

        string expectedID = "id";
        List<string> expectedLocale = ["string"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Locale);
        Assert.Equal(expectedLocale.Count, parameters.Locale.Count);
        for (int i = 0; i < expectedLocale.Count; i++)
        {
            Assert.Equal(expectedLocale[i], parameters.Locale[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TranslationListParams { ID = "id" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TranslationListParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        TranslationListParams parameters = new() { ID = "id", Locale = ["string"] };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/entitlements/id/translations?locale=string"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranslationListParams { ID = "id", Locale = ["string"] };

        TranslationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
