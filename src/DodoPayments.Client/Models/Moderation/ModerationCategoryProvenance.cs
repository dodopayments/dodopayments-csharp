using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// How each score in `categories` was measured.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ModerationCategoryProvenance, ModerationCategoryProvenanceFromRaw>)
)]
public sealed record class ModerationCategoryProvenance : JsonModel
{
    /// <summary>
    /// Child sexual exploitation.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> ChildSexualExploitation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "child_sexual_exploitation"
            );
        }
        init { this._rawData.Set("child_sexual_exploitation", value); }
    }

    /// <summary>
    /// False depiction that is likely to injure the reputation of a real person.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> Defamation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "defamation"
            );
        }
        init { this._rawData.Set("defamation", value); }
    }

    /// <summary>
    /// Demeaning people because of a protected characteristic.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> Hate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>("hate");
        }
        init { this._rawData.Set("hate", value); }
    }

    /// <summary>
    /// Chemical, biological, radiological, nuclear or explosive weapons.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> IndiscriminateWeapons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "indiscriminate_weapons"
            );
        }
        init { this._rawData.Set("indiscriminate_weapons", value); }
    }

    /// <summary>
    /// Copyright or trademark infringement.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> IntellectualProperty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "intellectual_property"
            );
        }
        init { this._rawData.Set("intellectual_property", value); }
    }

    /// <summary>
    /// Imitation of the signature style of a specific living artist.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> LivingArtistStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "living_artist_style"
            );
        }
        init { this._rawData.Set("living_artist_style", value); }
    }

    /// <summary>
    /// Age-coded language that suggests the subject is a minor.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> MinorCodedLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "minor_coded_language"
            );
        }
        init { this._rawData.Set("minor_coded_language", value); }
    }

    /// <summary>
    /// Non-consensual intimate imagery: undressing, nudifying or sexualising a real person.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> NonConsensualIntimateImagery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "non_consensual_intimate_imagery"
            );
        }
        init { this._rawData.Set("non_consensual_intimate_imagery", value); }
    }

    /// <summary>
    /// Non-violent crimes.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> NonViolentCrimes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "non_violent_crimes"
            );
        }
        init { this._rawData.Set("non_violent_crimes", value); }
    }

    /// <summary>
    /// Sensitive private information about a person.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> Privacy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>("privacy");
        }
        init { this._rawData.Set("privacy", value); }
    }

    /// <summary>
    /// An attempt to override or manipulate the instructions of the system.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> PromptInjection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "prompt_injection"
            );
        }
        init { this._rawData.Set("prompt_injection", value); }
    }

    /// <summary>
    /// The likeness of a real, identifiable, named person.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> RealPersonLikeness
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "real_person_likeness"
            );
        }
        init { this._rawData.Set("real_person_likeness", value); }
    }

    /// <summary>
    /// Sex-related crimes.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> SexRelatedCrimes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "sex_related_crimes"
            );
        }
        init { this._rawData.Set("sex_related_crimes", value); }
    }

    /// <summary>
    /// Sexually explicit or pornographic content.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> SexualContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "sexual_content"
            );
        }
        init { this._rawData.Set("sexual_content", value); }
    }

    /// <summary>
    /// Unqualified financial, medical, legal or electoral advice.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> SpecializedAdvice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "specialized_advice"
            );
        }
        init { this._rawData.Set("specialized_advice", value); }
    }

    /// <summary>
    /// Suicide and self-harm.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> SuicideAndSelfHarm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "suicide_and_self_harm"
            );
        }
        init { this._rawData.Set("suicide_and_self_harm", value); }
    }

    /// <summary>
    /// Violent crimes.
    /// </summary>
    public required ApiEnum<string, ModerationProvenance> ViolentCrimes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationProvenance>>(
                "violent_crimes"
            );
        }
        init { this._rawData.Set("violent_crimes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChildSexualExploitation.Validate();
        this.Defamation.Validate();
        this.Hate.Validate();
        this.IndiscriminateWeapons.Validate();
        this.IntellectualProperty.Validate();
        this.LivingArtistStyle.Validate();
        this.MinorCodedLanguage.Validate();
        this.NonConsensualIntimateImagery.Validate();
        this.NonViolentCrimes.Validate();
        this.Privacy.Validate();
        this.PromptInjection.Validate();
        this.RealPersonLikeness.Validate();
        this.SexRelatedCrimes.Validate();
        this.SexualContent.Validate();
        this.SpecializedAdvice.Validate();
        this.SuicideAndSelfHarm.Validate();
        this.ViolentCrimes.Validate();
    }

    public ModerationCategoryProvenance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModerationCategoryProvenance(ModerationCategoryProvenance moderationCategoryProvenance)
        : base(moderationCategoryProvenance) { }
#pragma warning restore CS8618

    public ModerationCategoryProvenance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModerationCategoryProvenance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModerationCategoryProvenanceFromRaw.FromRawUnchecked"/>
    public static ModerationCategoryProvenance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModerationCategoryProvenanceFromRaw : IFromRawJson<ModerationCategoryProvenance>
{
    /// <inheritdoc/>
    public ModerationCategoryProvenance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModerationCategoryProvenance.FromRawUnchecked(rawData);
}
