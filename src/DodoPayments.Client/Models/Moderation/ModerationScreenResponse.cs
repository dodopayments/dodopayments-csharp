using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// The verdict of one screen.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ModerationScreenResponse, ModerationScreenResponseFromRaw>)
)]
public sealed record class ModerationScreenResponse : JsonModel
{
    /// <summary>
    /// The probability, from 0 to 1, that the screen falls in each category.
    /// </summary>
    public required ModerationCategoryScores Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModerationCategoryScores>("categories");
        }
        init { this._rawData.Set("categories", value); }
    }

    /// <summary>
    /// True when real-person likeness and sexual content together crossed their
    /// combined threshold, the pattern of a sexual deepfake.
    /// </summary>
    public required bool CompoundTriggered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("compound_triggered");
        }
        init { this._rawData.Set("compound_triggered", value); }
    }

    /// <summary>
    /// The verdict. `allow` means the content passed. `deny` means block the content.
    /// `flag` means apply your own judgement. It is not a soft deny.
    /// </summary>
    public required ApiEnum<string, ModerationDecision> Decision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ModerationDecision>>("decision");
        }
        init { this._rawData.Set("decision", value); }
    }

    /// <summary>
    /// The time the screen took, in milliseconds.
    /// </summary>
    public required long LatencyMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("latency_ms");
        }
        init { this._rawData.Set("latency_ms", value); }
    }

    /// <summary>
    /// True when the text was also screened in a normalized form, with obfuscation
    /// such as invisible or look-alike characters removed.
    /// </summary>
    public required bool NormalizedApplied
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("normalized_applied");
        }
        init { this._rawData.Set("normalized_applied", value); }
    }

    /// <summary>
    /// Human-readable reasons for the decision. The wording can change, so do not
    /// parse it.
    /// </summary>
    public required IReadOnlyList<string> Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("notes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "notes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of yes/no questions the model answered for this screen.
    /// </summary>
    public required long Passes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("passes");
        }
        init { this._rawData.Set("passes", value); }
    }

    /// <summary>
    /// How each score in `categories` was measured.
    /// </summary>
    public required ModerationCategoryProvenance Provenance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModerationCategoryProvenance>("provenance");
        }
        init { this._rawData.Set("provenance", value); }
    }

    /// <summary>
    /// The `request_id` you sent, or null.
    /// </summary>
    public required string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init { this._rawData.Set("request_id", value); }
    }

    /// <summary>
    /// The categories whose score crossed the threshold of the category. It can
    /// be empty on a `flag` from the general check. `notes` then gives the reason.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, ModerationCategory>> Triggered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ModerationCategory>>
            >("triggered");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ModerationCategory>>>(
                "triggered",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Categories.Validate();
        _ = this.CompoundTriggered;
        this.Decision.Validate();
        _ = this.LatencyMs;
        _ = this.NormalizedApplied;
        _ = this.Notes;
        _ = this.Passes;
        this.Provenance.Validate();
        _ = this.RequestID;
        foreach (var item in this.Triggered)
        {
            item.Validate();
        }
    }

    public ModerationScreenResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModerationScreenResponse(ModerationScreenResponse moderationScreenResponse)
        : base(moderationScreenResponse) { }
#pragma warning restore CS8618

    public ModerationScreenResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModerationScreenResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModerationScreenResponseFromRaw.FromRawUnchecked"/>
    public static ModerationScreenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModerationScreenResponseFromRaw : IFromRawJson<ModerationScreenResponse>
{
    /// <inheritdoc/>
    public ModerationScreenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModerationScreenResponse.FromRawUnchecked(rawData);
}
