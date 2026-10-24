using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Misc;

public class LocaleInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocaleInfo
        {
            Code = Locale.Ar,
            Name = "name",
            NativeName = "native_name",
        };

        ApiEnum<string, Locale> expectedCode = Locale.Ar;
        string expectedName = "name";
        string expectedNativeName = "native_name";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNativeName, model.NativeName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LocaleInfo
        {
            Code = Locale.Ar,
            Name = "name",
            NativeName = "native_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LocaleInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LocaleInfo
        {
            Code = Locale.Ar,
            Name = "name",
            NativeName = "native_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LocaleInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Locale> expectedCode = Locale.Ar;
        string expectedName = "name";
        string expectedNativeName = "native_name";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNativeName, deserialized.NativeName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LocaleInfo
        {
            Code = Locale.Ar,
            Name = "name",
            NativeName = "native_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LocaleInfo
        {
            Code = Locale.Ar,
            Name = "name",
            NativeName = "native_name",
        };

        LocaleInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
