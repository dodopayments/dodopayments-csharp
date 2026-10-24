using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Translations;

public class TranslationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            ID = "id",
            Locale = Locale.Ar,
            Name = "name",
            Unit = "unit",
        };

        string expectedID = "id";
        ApiEnum<string, Locale> expectedLocale = Locale.Ar;
        string expectedName = "name";
        string expectedUnit = "unit";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedUnit, parameters.Unit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TranslationUpdateParams { ID = "id", Locale = Locale.Ar };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Unit);
        Assert.False(parameters.RawBodyData.ContainsKey("unit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            ID = "id",
            Locale = Locale.Ar,

            Name = null,
            Unit = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Unit);
        Assert.True(parameters.RawBodyData.ContainsKey("unit"));
    }

    [Fact]
    public void Url_Works()
    {
        TranslationUpdateParams parameters = new() { ID = "id", Locale = Locale.Ar };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/credit-entitlements/id/translations/ar"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            ID = "id",
            Locale = Locale.Ar,
            Name = "name",
            Unit = "unit",
        };

        TranslationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
