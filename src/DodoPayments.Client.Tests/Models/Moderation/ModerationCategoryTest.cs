using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationCategoryTest : TestBase
{
    [Theory]
    [InlineData(ModerationCategory.ViolentCrimes)]
    [InlineData(ModerationCategory.SexRelatedCrimes)]
    [InlineData(ModerationCategory.ChildSexualExploitation)]
    [InlineData(ModerationCategory.SuicideAndSelfHarm)]
    [InlineData(ModerationCategory.IndiscriminateWeapons)]
    [InlineData(ModerationCategory.IntellectualProperty)]
    [InlineData(ModerationCategory.Defamation)]
    [InlineData(ModerationCategory.NonViolentCrimes)]
    [InlineData(ModerationCategory.Hate)]
    [InlineData(ModerationCategory.Privacy)]
    [InlineData(ModerationCategory.SpecializedAdvice)]
    [InlineData(ModerationCategory.SexualContent)]
    [InlineData(ModerationCategory.NonConsensualIntimateImagery)]
    [InlineData(ModerationCategory.MinorCodedLanguage)]
    [InlineData(ModerationCategory.RealPersonLikeness)]
    [InlineData(ModerationCategory.LivingArtistStyle)]
    [InlineData(ModerationCategory.PromptInjection)]
    public void Validation_Works(ModerationCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModerationCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModerationCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModerationCategory.ViolentCrimes)]
    [InlineData(ModerationCategory.SexRelatedCrimes)]
    [InlineData(ModerationCategory.ChildSexualExploitation)]
    [InlineData(ModerationCategory.SuicideAndSelfHarm)]
    [InlineData(ModerationCategory.IndiscriminateWeapons)]
    [InlineData(ModerationCategory.IntellectualProperty)]
    [InlineData(ModerationCategory.Defamation)]
    [InlineData(ModerationCategory.NonViolentCrimes)]
    [InlineData(ModerationCategory.Hate)]
    [InlineData(ModerationCategory.Privacy)]
    [InlineData(ModerationCategory.SpecializedAdvice)]
    [InlineData(ModerationCategory.SexualContent)]
    [InlineData(ModerationCategory.NonConsensualIntimateImagery)]
    [InlineData(ModerationCategory.MinorCodedLanguage)]
    [InlineData(ModerationCategory.RealPersonLikeness)]
    [InlineData(ModerationCategory.LivingArtistStyle)]
    [InlineData(ModerationCategory.PromptInjection)]
    public void SerializationRoundtrip_Works(ModerationCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModerationCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModerationCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModerationCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModerationCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
