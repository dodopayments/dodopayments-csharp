using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// A moderation category.
/// </summary>
[JsonConverter(typeof(ModerationCategoryConverter))]
public enum ModerationCategory
{
    ViolentCrimes,
    SexRelatedCrimes,
    ChildSexualExploitation,
    SuicideAndSelfHarm,
    IndiscriminateWeapons,
    IntellectualProperty,
    Defamation,
    NonViolentCrimes,
    Hate,
    Privacy,
    SpecializedAdvice,
    SexualContent,
    NonConsensualIntimateImagery,
    MinorCodedLanguage,
    RealPersonLikeness,
    LivingArtistStyle,
    PromptInjection,
}

sealed class ModerationCategoryConverter : JsonConverter<ModerationCategory>
{
    public override ModerationCategory Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "violent_crimes" => ModerationCategory.ViolentCrimes,
            "sex_related_crimes" => ModerationCategory.SexRelatedCrimes,
            "child_sexual_exploitation" => ModerationCategory.ChildSexualExploitation,
            "suicide_and_self_harm" => ModerationCategory.SuicideAndSelfHarm,
            "indiscriminate_weapons" => ModerationCategory.IndiscriminateWeapons,
            "intellectual_property" => ModerationCategory.IntellectualProperty,
            "defamation" => ModerationCategory.Defamation,
            "non_violent_crimes" => ModerationCategory.NonViolentCrimes,
            "hate" => ModerationCategory.Hate,
            "privacy" => ModerationCategory.Privacy,
            "specialized_advice" => ModerationCategory.SpecializedAdvice,
            "sexual_content" => ModerationCategory.SexualContent,
            "non_consensual_intimate_imagery" => ModerationCategory.NonConsensualIntimateImagery,
            "minor_coded_language" => ModerationCategory.MinorCodedLanguage,
            "real_person_likeness" => ModerationCategory.RealPersonLikeness,
            "living_artist_style" => ModerationCategory.LivingArtistStyle,
            "prompt_injection" => ModerationCategory.PromptInjection,
            _ => (ModerationCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModerationCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModerationCategory.ViolentCrimes => "violent_crimes",
                ModerationCategory.SexRelatedCrimes => "sex_related_crimes",
                ModerationCategory.ChildSexualExploitation => "child_sexual_exploitation",
                ModerationCategory.SuicideAndSelfHarm => "suicide_and_self_harm",
                ModerationCategory.IndiscriminateWeapons => "indiscriminate_weapons",
                ModerationCategory.IntellectualProperty => "intellectual_property",
                ModerationCategory.Defamation => "defamation",
                ModerationCategory.NonViolentCrimes => "non_violent_crimes",
                ModerationCategory.Hate => "hate",
                ModerationCategory.Privacy => "privacy",
                ModerationCategory.SpecializedAdvice => "specialized_advice",
                ModerationCategory.SexualContent => "sexual_content",
                ModerationCategory.NonConsensualIntimateImagery =>
                    "non_consensual_intimate_imagery",
                ModerationCategory.MinorCodedLanguage => "minor_coded_language",
                ModerationCategory.RealPersonLikeness => "real_person_likeness",
                ModerationCategory.LivingArtistStyle => "living_artist_style",
                ModerationCategory.PromptInjection => "prompt_injection",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
