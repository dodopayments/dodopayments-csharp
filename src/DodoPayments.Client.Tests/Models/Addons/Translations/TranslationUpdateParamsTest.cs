using System;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Addons.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Addons.Translations;

public class TranslationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            ID = "id",
            Locale = Locale.Ar,
            Description = "description",
            Name = "name",
        };

        string expectedID = "id";
        ApiEnum<string, Locale> expectedLocale = Locale.Ar;
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TranslationUpdateParams { ID = "id", Locale = Locale.Ar };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            ID = "id",
            Locale = Locale.Ar,

            Description = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        TranslationUpdateParams parameters = new() { ID = "id", Locale = Locale.Ar };

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
        var parameters = new TranslationUpdateParams
        {
            ID = "id",
            Locale = Locale.Ar,
            Description = "description",
            Name = "name",
        };

        TranslationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
