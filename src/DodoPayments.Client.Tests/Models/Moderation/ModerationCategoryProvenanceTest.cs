using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationCategoryProvenanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModerationCategoryProvenance
        {
            ChildSexualExploitation = ModerationProvenance.Targeted,
            Defamation = ModerationProvenance.Targeted,
            Hate = ModerationProvenance.Targeted,
            IndiscriminateWeapons = ModerationProvenance.Targeted,
            IntellectualProperty = ModerationProvenance.Targeted,
            LivingArtistStyle = ModerationProvenance.Targeted,
            MinorCodedLanguage = ModerationProvenance.Targeted,
            NonConsensualIntimateImagery = ModerationProvenance.Targeted,
            NonViolentCrimes = ModerationProvenance.Targeted,
            Privacy = ModerationProvenance.Targeted,
            PromptInjection = ModerationProvenance.Targeted,
            RealPersonLikeness = ModerationProvenance.Targeted,
            SexRelatedCrimes = ModerationProvenance.Targeted,
            SexualContent = ModerationProvenance.Targeted,
            SpecializedAdvice = ModerationProvenance.Targeted,
            SuicideAndSelfHarm = ModerationProvenance.Targeted,
            ViolentCrimes = ModerationProvenance.Targeted,
        };

        ApiEnum<string, ModerationProvenance> expectedChildSexualExploitation =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedDefamation = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedHate = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedIndiscriminateWeapons =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedIntellectualProperty =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedLivingArtistStyle =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedMinorCodedLanguage =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedNonConsensualIntimateImagery =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedNonViolentCrimes =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedPrivacy = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedPromptInjection =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedRealPersonLikeness =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSexRelatedCrimes =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSexualContent = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSpecializedAdvice =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSuicideAndSelfHarm =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedViolentCrimes = ModerationProvenance.Targeted;

        Assert.Equal(expectedChildSexualExploitation, model.ChildSexualExploitation);
        Assert.Equal(expectedDefamation, model.Defamation);
        Assert.Equal(expectedHate, model.Hate);
        Assert.Equal(expectedIndiscriminateWeapons, model.IndiscriminateWeapons);
        Assert.Equal(expectedIntellectualProperty, model.IntellectualProperty);
        Assert.Equal(expectedLivingArtistStyle, model.LivingArtistStyle);
        Assert.Equal(expectedMinorCodedLanguage, model.MinorCodedLanguage);
        Assert.Equal(expectedNonConsensualIntimateImagery, model.NonConsensualIntimateImagery);
        Assert.Equal(expectedNonViolentCrimes, model.NonViolentCrimes);
        Assert.Equal(expectedPrivacy, model.Privacy);
        Assert.Equal(expectedPromptInjection, model.PromptInjection);
        Assert.Equal(expectedRealPersonLikeness, model.RealPersonLikeness);
        Assert.Equal(expectedSexRelatedCrimes, model.SexRelatedCrimes);
        Assert.Equal(expectedSexualContent, model.SexualContent);
        Assert.Equal(expectedSpecializedAdvice, model.SpecializedAdvice);
        Assert.Equal(expectedSuicideAndSelfHarm, model.SuicideAndSelfHarm);
        Assert.Equal(expectedViolentCrimes, model.ViolentCrimes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModerationCategoryProvenance
        {
            ChildSexualExploitation = ModerationProvenance.Targeted,
            Defamation = ModerationProvenance.Targeted,
            Hate = ModerationProvenance.Targeted,
            IndiscriminateWeapons = ModerationProvenance.Targeted,
            IntellectualProperty = ModerationProvenance.Targeted,
            LivingArtistStyle = ModerationProvenance.Targeted,
            MinorCodedLanguage = ModerationProvenance.Targeted,
            NonConsensualIntimateImagery = ModerationProvenance.Targeted,
            NonViolentCrimes = ModerationProvenance.Targeted,
            Privacy = ModerationProvenance.Targeted,
            PromptInjection = ModerationProvenance.Targeted,
            RealPersonLikeness = ModerationProvenance.Targeted,
            SexRelatedCrimes = ModerationProvenance.Targeted,
            SexualContent = ModerationProvenance.Targeted,
            SpecializedAdvice = ModerationProvenance.Targeted,
            SuicideAndSelfHarm = ModerationProvenance.Targeted,
            ViolentCrimes = ModerationProvenance.Targeted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationCategoryProvenance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModerationCategoryProvenance
        {
            ChildSexualExploitation = ModerationProvenance.Targeted,
            Defamation = ModerationProvenance.Targeted,
            Hate = ModerationProvenance.Targeted,
            IndiscriminateWeapons = ModerationProvenance.Targeted,
            IntellectualProperty = ModerationProvenance.Targeted,
            LivingArtistStyle = ModerationProvenance.Targeted,
            MinorCodedLanguage = ModerationProvenance.Targeted,
            NonConsensualIntimateImagery = ModerationProvenance.Targeted,
            NonViolentCrimes = ModerationProvenance.Targeted,
            Privacy = ModerationProvenance.Targeted,
            PromptInjection = ModerationProvenance.Targeted,
            RealPersonLikeness = ModerationProvenance.Targeted,
            SexRelatedCrimes = ModerationProvenance.Targeted,
            SexualContent = ModerationProvenance.Targeted,
            SpecializedAdvice = ModerationProvenance.Targeted,
            SuicideAndSelfHarm = ModerationProvenance.Targeted,
            ViolentCrimes = ModerationProvenance.Targeted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationCategoryProvenance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ModerationProvenance> expectedChildSexualExploitation =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedDefamation = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedHate = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedIndiscriminateWeapons =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedIntellectualProperty =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedLivingArtistStyle =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedMinorCodedLanguage =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedNonConsensualIntimateImagery =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedNonViolentCrimes =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedPrivacy = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedPromptInjection =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedRealPersonLikeness =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSexRelatedCrimes =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSexualContent = ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSpecializedAdvice =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedSuicideAndSelfHarm =
            ModerationProvenance.Targeted;
        ApiEnum<string, ModerationProvenance> expectedViolentCrimes = ModerationProvenance.Targeted;

        Assert.Equal(expectedChildSexualExploitation, deserialized.ChildSexualExploitation);
        Assert.Equal(expectedDefamation, deserialized.Defamation);
        Assert.Equal(expectedHate, deserialized.Hate);
        Assert.Equal(expectedIndiscriminateWeapons, deserialized.IndiscriminateWeapons);
        Assert.Equal(expectedIntellectualProperty, deserialized.IntellectualProperty);
        Assert.Equal(expectedLivingArtistStyle, deserialized.LivingArtistStyle);
        Assert.Equal(expectedMinorCodedLanguage, deserialized.MinorCodedLanguage);
        Assert.Equal(
            expectedNonConsensualIntimateImagery,
            deserialized.NonConsensualIntimateImagery
        );
        Assert.Equal(expectedNonViolentCrimes, deserialized.NonViolentCrimes);
        Assert.Equal(expectedPrivacy, deserialized.Privacy);
        Assert.Equal(expectedPromptInjection, deserialized.PromptInjection);
        Assert.Equal(expectedRealPersonLikeness, deserialized.RealPersonLikeness);
        Assert.Equal(expectedSexRelatedCrimes, deserialized.SexRelatedCrimes);
        Assert.Equal(expectedSexualContent, deserialized.SexualContent);
        Assert.Equal(expectedSpecializedAdvice, deserialized.SpecializedAdvice);
        Assert.Equal(expectedSuicideAndSelfHarm, deserialized.SuicideAndSelfHarm);
        Assert.Equal(expectedViolentCrimes, deserialized.ViolentCrimes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModerationCategoryProvenance
        {
            ChildSexualExploitation = ModerationProvenance.Targeted,
            Defamation = ModerationProvenance.Targeted,
            Hate = ModerationProvenance.Targeted,
            IndiscriminateWeapons = ModerationProvenance.Targeted,
            IntellectualProperty = ModerationProvenance.Targeted,
            LivingArtistStyle = ModerationProvenance.Targeted,
            MinorCodedLanguage = ModerationProvenance.Targeted,
            NonConsensualIntimateImagery = ModerationProvenance.Targeted,
            NonViolentCrimes = ModerationProvenance.Targeted,
            Privacy = ModerationProvenance.Targeted,
            PromptInjection = ModerationProvenance.Targeted,
            RealPersonLikeness = ModerationProvenance.Targeted,
            SexRelatedCrimes = ModerationProvenance.Targeted,
            SexualContent = ModerationProvenance.Targeted,
            SpecializedAdvice = ModerationProvenance.Targeted,
            SuicideAndSelfHarm = ModerationProvenance.Targeted,
            ViolentCrimes = ModerationProvenance.Targeted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModerationCategoryProvenance
        {
            ChildSexualExploitation = ModerationProvenance.Targeted,
            Defamation = ModerationProvenance.Targeted,
            Hate = ModerationProvenance.Targeted,
            IndiscriminateWeapons = ModerationProvenance.Targeted,
            IntellectualProperty = ModerationProvenance.Targeted,
            LivingArtistStyle = ModerationProvenance.Targeted,
            MinorCodedLanguage = ModerationProvenance.Targeted,
            NonConsensualIntimateImagery = ModerationProvenance.Targeted,
            NonViolentCrimes = ModerationProvenance.Targeted,
            Privacy = ModerationProvenance.Targeted,
            PromptInjection = ModerationProvenance.Targeted,
            RealPersonLikeness = ModerationProvenance.Targeted,
            SexRelatedCrimes = ModerationProvenance.Targeted,
            SexualContent = ModerationProvenance.Targeted,
            SpecializedAdvice = ModerationProvenance.Targeted,
            SuicideAndSelfHarm = ModerationProvenance.Targeted,
            ViolentCrimes = ModerationProvenance.Targeted,
        };

        ModerationCategoryProvenance copied = new(model);

        Assert.Equal(model, copied);
    }
}
