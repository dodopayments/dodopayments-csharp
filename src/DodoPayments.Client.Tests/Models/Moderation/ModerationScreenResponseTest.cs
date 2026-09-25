using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationScreenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModerationScreenResponse
        {
            Categories = new()
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
            },
            CompoundTriggered = true,
            Decision = ModerationDecision.Allow,
            LatencyMs = 0,
            NormalizedApplied = true,
            Notes = ["string"],
            Passes = 0,
            Provenance = new()
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
            },
            RequestID = "request_id",
            Triggered = [ModerationCategory.ViolentCrimes],
        };

        ModerationCategoryScores expectedCategories = new()
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
        bool expectedCompoundTriggered = true;
        ApiEnum<string, ModerationDecision> expectedDecision = ModerationDecision.Allow;
        long expectedLatencyMs = 0;
        bool expectedNormalizedApplied = true;
        List<string> expectedNotes = ["string"];
        long expectedPasses = 0;
        ModerationCategoryProvenance expectedProvenance = new()
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
        string expectedRequestID = "request_id";
        List<ApiEnum<string, ModerationCategory>> expectedTriggered =
        [
            ModerationCategory.ViolentCrimes,
        ];

        Assert.Equal(expectedCategories, model.Categories);
        Assert.Equal(expectedCompoundTriggered, model.CompoundTriggered);
        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedLatencyMs, model.LatencyMs);
        Assert.Equal(expectedNormalizedApplied, model.NormalizedApplied);
        Assert.Equal(expectedNotes.Count, model.Notes.Count);
        for (int i = 0; i < expectedNotes.Count; i++)
        {
            Assert.Equal(expectedNotes[i], model.Notes[i]);
        }
        Assert.Equal(expectedPasses, model.Passes);
        Assert.Equal(expectedProvenance, model.Provenance);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedTriggered.Count, model.Triggered.Count);
        for (int i = 0; i < expectedTriggered.Count; i++)
        {
            Assert.Equal(expectedTriggered[i], model.Triggered[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModerationScreenResponse
        {
            Categories = new()
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
            },
            CompoundTriggered = true,
            Decision = ModerationDecision.Allow,
            LatencyMs = 0,
            NormalizedApplied = true,
            Notes = ["string"],
            Passes = 0,
            Provenance = new()
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
            },
            RequestID = "request_id",
            Triggered = [ModerationCategory.ViolentCrimes],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationScreenResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModerationScreenResponse
        {
            Categories = new()
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
            },
            CompoundTriggered = true,
            Decision = ModerationDecision.Allow,
            LatencyMs = 0,
            NormalizedApplied = true,
            Notes = ["string"],
            Passes = 0,
            Provenance = new()
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
            },
            RequestID = "request_id",
            Triggered = [ModerationCategory.ViolentCrimes],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationScreenResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ModerationCategoryScores expectedCategories = new()
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
        bool expectedCompoundTriggered = true;
        ApiEnum<string, ModerationDecision> expectedDecision = ModerationDecision.Allow;
        long expectedLatencyMs = 0;
        bool expectedNormalizedApplied = true;
        List<string> expectedNotes = ["string"];
        long expectedPasses = 0;
        ModerationCategoryProvenance expectedProvenance = new()
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
        string expectedRequestID = "request_id";
        List<ApiEnum<string, ModerationCategory>> expectedTriggered =
        [
            ModerationCategory.ViolentCrimes,
        ];

        Assert.Equal(expectedCategories, deserialized.Categories);
        Assert.Equal(expectedCompoundTriggered, deserialized.CompoundTriggered);
        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedLatencyMs, deserialized.LatencyMs);
        Assert.Equal(expectedNormalizedApplied, deserialized.NormalizedApplied);
        Assert.Equal(expectedNotes.Count, deserialized.Notes.Count);
        for (int i = 0; i < expectedNotes.Count; i++)
        {
            Assert.Equal(expectedNotes[i], deserialized.Notes[i]);
        }
        Assert.Equal(expectedPasses, deserialized.Passes);
        Assert.Equal(expectedProvenance, deserialized.Provenance);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedTriggered.Count, deserialized.Triggered.Count);
        for (int i = 0; i < expectedTriggered.Count; i++)
        {
            Assert.Equal(expectedTriggered[i], deserialized.Triggered[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModerationScreenResponse
        {
            Categories = new()
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
            },
            CompoundTriggered = true,
            Decision = ModerationDecision.Allow,
            LatencyMs = 0,
            NormalizedApplied = true,
            Notes = ["string"],
            Passes = 0,
            Provenance = new()
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
            },
            RequestID = "request_id",
            Triggered = [ModerationCategory.ViolentCrimes],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModerationScreenResponse
        {
            Categories = new()
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
            },
            CompoundTriggered = true,
            Decision = ModerationDecision.Allow,
            LatencyMs = 0,
            NormalizedApplied = true,
            Notes = ["string"],
            Passes = 0,
            Provenance = new()
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
            },
            RequestID = "request_id",
            Triggered = [ModerationCategory.ViolentCrimes],
        };

        ModerationScreenResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
