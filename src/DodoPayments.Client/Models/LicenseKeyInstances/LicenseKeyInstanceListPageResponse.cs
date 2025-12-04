using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

[JsonConverter(
    typeof(ModelConverter<
        LicenseKeyInstanceListPageResponse,
        LicenseKeyInstanceListPageResponseFromRaw
    >)
)]
public sealed record class LicenseKeyInstanceListPageResponse : ModelBase
{
    public required IReadOnlyList<LicenseKeyInstance> Items
    {
        get { return ModelBase.GetNotNullClass<List<LicenseKeyInstance>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public LicenseKeyInstanceListPageResponse() { }

    public LicenseKeyInstanceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyInstanceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyInstanceListPageResponseFromRaw.FromRawUnchecked"/>
    public static LicenseKeyInstanceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LicenseKeyInstanceListPageResponse(List<LicenseKeyInstance> items)
        : this()
    {
        this.Items = items;
    }
}

class LicenseKeyInstanceListPageResponseFromRaw : IFromRaw<LicenseKeyInstanceListPageResponse>
{
    /// <inheritdoc/>
    public LicenseKeyInstanceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyInstanceListPageResponse.FromRawUnchecked(rawData);
}
