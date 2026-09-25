using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// The probability, from 0 to 1, that the screen falls in each category.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ModerationCategoryScores, ModerationCategoryScoresFromRaw>)
)]
public sealed record class ModerationCategoryScores : JsonModel
{
    /// <summary>
    /// Child sexual exploitation.
    /// </summary>
    public required double ChildSexualExploitation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("child_sexual_exploitation");
        }
        init { this._rawData.Set("child_sexual_exploitation", value); }
    }

    /// <summary>
    /// False depiction that is likely to injure the reputation of a real person.
    /// </summary>
    public required double Defamation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("defamation");
        }
        init { this._rawData.Set("defamation", value); }
    }

    /// <summary>
    /// Demeaning people because of a protected characteristic.
    /// </summary>
    public required double Hate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("hate");
        }
        init { this._rawData.Set("hate", value); }
    }

    /// <summary>
    /// Chemical, biological, radiological, nuclear or explosive weapons.
    /// </summary>
    public required double IndiscriminateWeapons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("indiscriminate_weapons");
        }
        init { this._rawData.Set("indiscriminate_weapons", value); }
    }

    /// <summary>
    /// Copyright or trademark infringement.
    /// </summary>
    public required double IntellectualProperty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("intellectual_property");
        }
        init { this._rawData.Set("intellectual_property", value); }
    }

    /// <summary>
    /// Imitation of the signature style of a specific living artist.
    /// </summary>
    public required double LivingArtistStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("living_artist_style");
        }
        init { this._rawData.Set("living_artist_style", value); }
    }

    /// <summary>
    /// Age-coded language that suggests the subject is a minor.
    /// </summary>
    public required double MinorCodedLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("minor_coded_language");
        }
        init { this._rawData.Set("minor_coded_language", value); }
    }

    /// <summary>
    /// Non-consensual intimate imagery: undressing, nudifying or sexualising a real person.
    /// </summary>
    public required double NonConsensualIntimateImagery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("non_consensual_intimate_imagery");
        }
        init { this._rawData.Set("non_consensual_intimate_imagery", value); }
    }

    /// <summary>
    /// Non-violent crimes.
    /// </summary>
    public required double NonViolentCrimes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("non_violent_crimes");
        }
        init { this._rawData.Set("non_violent_crimes", value); }
    }

    /// <summary>
    /// Sensitive private information about a person.
    /// </summary>
    public required double Privacy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("privacy");
        }
        init { this._rawData.Set("privacy", value); }
    }

    /// <summary>
    /// An attempt to override or manipulate the instructions of the system.
    /// </summary>
    public required double PromptInjection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("prompt_injection");
        }
        init { this._rawData.Set("prompt_injection", value); }
    }

    /// <summary>
    /// The likeness of a real, identifiable, named person.
    /// </summary>
    public required double RealPersonLikeness
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("real_person_likeness");
        }
        init { this._rawData.Set("real_person_likeness", value); }
    }

    /// <summary>
    /// Sex-related crimes.
    /// </summary>
    public required double SexRelatedCrimes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("sex_related_crimes");
        }
        init { this._rawData.Set("sex_related_crimes", value); }
    }

    /// <summary>
    /// Sexually explicit or pornographic content.
    /// </summary>
    public required double SexualContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("sexual_content");
        }
        init { this._rawData.Set("sexual_content", value); }
    }

    /// <summary>
    /// Unqualified financial, medical, legal or electoral advice.
    /// </summary>
    public required double SpecializedAdvice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("specialized_advice");
        }
        init { this._rawData.Set("specialized_advice", value); }
    }

    /// <summary>
    /// Suicide and self-harm.
    /// </summary>
    public required double SuicideAndSelfHarm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("suicide_and_self_harm");
        }
        init { this._rawData.Set("suicide_and_self_harm", value); }
    }

    /// <summary>
    /// Violent crimes.
    /// </summary>
    public required double ViolentCrimes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("violent_crimes");
        }
        init { this._rawData.Set("violent_crimes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChildSexualExploitation;
        _ = this.Defamation;
        _ = this.Hate;
        _ = this.IndiscriminateWeapons;
        _ = this.IntellectualProperty;
        _ = this.LivingArtistStyle;
        _ = this.MinorCodedLanguage;
        _ = this.NonConsensualIntimateImagery;
        _ = this.NonViolentCrimes;
        _ = this.Privacy;
        _ = this.PromptInjection;
        _ = this.RealPersonLikeness;
        _ = this.SexRelatedCrimes;
        _ = this.SexualContent;
        _ = this.SpecializedAdvice;
        _ = this.SuicideAndSelfHarm;
        _ = this.ViolentCrimes;
    }

    public ModerationCategoryScores() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModerationCategoryScores(ModerationCategoryScores moderationCategoryScores)
        : base(moderationCategoryScores) { }
#pragma warning restore CS8618

    public ModerationCategoryScores(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModerationCategoryScores(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModerationCategoryScoresFromRaw.FromRawUnchecked"/>
    public static ModerationCategoryScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModerationCategoryScoresFromRaw : IFromRawJson<ModerationCategoryScores>
{
    /// <inheritdoc/>
    public ModerationCategoryScores FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModerationCategoryScores.FromRawUnchecked(rawData);
}
