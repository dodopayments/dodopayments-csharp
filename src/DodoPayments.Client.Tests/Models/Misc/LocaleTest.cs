using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Misc;

public class LocaleTest : TestBase
{
    [Theory]
    [InlineData(Locale.Ar)]
    [InlineData(Locale.Ca)]
    [InlineData(Locale.Zh)]
    [InlineData(Locale.Nl)]
    [InlineData(Locale.En)]
    [InlineData(Locale.Fr)]
    [InlineData(Locale.De)]
    [InlineData(Locale.He)]
    [InlineData(Locale.ID)]
    [InlineData(Locale.It)]
    [InlineData(Locale.Ja)]
    [InlineData(Locale.Ka)]
    [InlineData(Locale.Ko)]
    [InlineData(Locale.Ms)]
    [InlineData(Locale.Pl)]
    [InlineData(Locale.Pt)]
    [InlineData(Locale.Ro)]
    [InlineData(Locale.Ru)]
    [InlineData(Locale.Es)]
    [InlineData(Locale.Sv)]
    [InlineData(Locale.Th)]
    [InlineData(Locale.Tr)]
    public void Validation_Works(Locale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Locale> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Locale.Ar)]
    [InlineData(Locale.Ca)]
    [InlineData(Locale.Zh)]
    [InlineData(Locale.Nl)]
    [InlineData(Locale.En)]
    [InlineData(Locale.Fr)]
    [InlineData(Locale.De)]
    [InlineData(Locale.He)]
    [InlineData(Locale.ID)]
    [InlineData(Locale.It)]
    [InlineData(Locale.Ja)]
    [InlineData(Locale.Ka)]
    [InlineData(Locale.Ko)]
    [InlineData(Locale.Ms)]
    [InlineData(Locale.Pl)]
    [InlineData(Locale.Pt)]
    [InlineData(Locale.Ro)]
    [InlineData(Locale.Ru)]
    [InlineData(Locale.Es)]
    [InlineData(Locale.Sv)]
    [InlineData(Locale.Th)]
    [InlineData(Locale.Tr)]
    public void SerializationRoundtrip_Works(Locale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Locale> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
