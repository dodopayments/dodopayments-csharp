using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationCategoryScoresTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModerationCategoryScores
        {
            ChildSexualExploitation = 0,
            Defamation = 0,
            Hate = 0,
            IndiscriminateWeapons = 0,
            IntellectualProperty = 0,
            LivingArtistStyle = 0,
            MinorCodedLanguage = 0,
            NonConsensualIntimateImagery = 0,
            NonViolentCrimes = 0,
            Privacy = 0,
            PromptInjection = 0,
            RealPersonLikeness = 0,
            SexRelatedCrimes = 0,
            SexualContent = 0,
            SpecializedAdvice = 0,
            SuicideAndSelfHarm = 0,
            ViolentCrimes = 0,
        };

        double expectedChildSexualExploitation = 0;
        double expectedDefamation = 0;
        double expectedHate = 0;
        double expectedIndiscriminateWeapons = 0;
        double expectedIntellectualProperty = 0;
        double expectedLivingArtistStyle = 0;
        double expectedMinorCodedLanguage = 0;
        double expectedNonConsensualIntimateImagery = 0;
        double expectedNonViolentCrimes = 0;
        double expectedPrivacy = 0;
        double expectedPromptInjection = 0;
        double expectedRealPersonLikeness = 0;
        double expectedSexRelatedCrimes = 0;
        double expectedSexualContent = 0;
        double expectedSpecializedAdvice = 0;
        double expectedSuicideAndSelfHarm = 0;
        double expectedViolentCrimes = 0;

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
        var model = new ModerationCategoryScores
        {
            ChildSexualExploitation = 0,
            Defamation = 0,
            Hate = 0,
            IndiscriminateWeapons = 0,
            IntellectualProperty = 0,
            LivingArtistStyle = 0,
            MinorCodedLanguage = 0,
            NonConsensualIntimateImagery = 0,
            NonViolentCrimes = 0,
            Privacy = 0,
            PromptInjection = 0,
            RealPersonLikeness = 0,
            SexRelatedCrimes = 0,
            SexualContent = 0,
            SpecializedAdvice = 0,
            SuicideAndSelfHarm = 0,
            ViolentCrimes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationCategoryScores>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModerationCategoryScores
        {
            ChildSexualExploitation = 0,
            Defamation = 0,
            Hate = 0,
            IndiscriminateWeapons = 0,
            IntellectualProperty = 0,
            LivingArtistStyle = 0,
            MinorCodedLanguage = 0,
            NonConsensualIntimateImagery = 0,
            NonViolentCrimes = 0,
            Privacy = 0,
            PromptInjection = 0,
            RealPersonLikeness = 0,
            SexRelatedCrimes = 0,
            SexualContent = 0,
            SpecializedAdvice = 0,
            SuicideAndSelfHarm = 0,
            ViolentCrimes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationCategoryScores>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedChildSexualExploitation = 0;
        double expectedDefamation = 0;
        double expectedHate = 0;
        double expectedIndiscriminateWeapons = 0;
        double expectedIntellectualProperty = 0;
        double expectedLivingArtistStyle = 0;
        double expectedMinorCodedLanguage = 0;
        double expectedNonConsensualIntimateImagery = 0;
        double expectedNonViolentCrimes = 0;
        double expectedPrivacy = 0;
        double expectedPromptInjection = 0;
        double expectedRealPersonLikeness = 0;
        double expectedSexRelatedCrimes = 0;
        double expectedSexualContent = 0;
        double expectedSpecializedAdvice = 0;
        double expectedSuicideAndSelfHarm = 0;
        double expectedViolentCrimes = 0;

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
        var model = new ModerationCategoryScores
        {
            ChildSexualExploitation = 0,
            Defamation = 0,
            Hate = 0,
            IndiscriminateWeapons = 0,
            IntellectualProperty = 0,
            LivingArtistStyle = 0,
            MinorCodedLanguage = 0,
            NonConsensualIntimateImagery = 0,
            NonViolentCrimes = 0,
            Privacy = 0,
            PromptInjection = 0,
            RealPersonLikeness = 0,
            SexRelatedCrimes = 0,
            SexualContent = 0,
            SpecializedAdvice = 0,
            SuicideAndSelfHarm = 0,
            ViolentCrimes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModerationCategoryScores
        {
            ChildSexualExploitation = 0,
            Defamation = 0,
            Hate = 0,
            IndiscriminateWeapons = 0,
            IntellectualProperty = 0,
            LivingArtistStyle = 0,
            MinorCodedLanguage = 0,
            NonConsensualIntimateImagery = 0,
            NonViolentCrimes = 0,
            Privacy = 0,
            PromptInjection = 0,
            RealPersonLikeness = 0,
            SexRelatedCrimes = 0,
            SexualContent = 0,
            SpecializedAdvice = 0,
            SuicideAndSelfHarm = 0,
            ViolentCrimes = 0,
        };

        ModerationCategoryScores copied = new(model);

        Assert.Equal(model, copied);
    }
}
