using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// Capability conferred by a `feature_flag` grant.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
{
    /// <summary>
    /// Identifier of the capability this grant confers.
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("feature_id");
        }
        init { this._rawData.Set("feature_id", value); }
    }

    /// <summary>
    /// Type of capability conferred.
    /// </summary>
    public required ApiEnum<string, FeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeatureType>>("feature_type");
        }
        init { this._rawData.Set("feature_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        this.FeatureType.Validate();
    }

    public Feature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feature(Feature feature)
        : base(feature) { }
#pragma warning restore CS8618

    public Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Feature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFromRaw.FromRawUnchecked"/>
    public static Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureFromRaw : IFromRawJson<Feature>
{
    /// <inheritdoc/>
    public Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feature.FromRawUnchecked(rawData);
}
