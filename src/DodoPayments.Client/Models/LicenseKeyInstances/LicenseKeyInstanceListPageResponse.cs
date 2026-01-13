using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

[JsonConverter(
    typeof(JsonModelConverter<
        LicenseKeyInstanceListPageResponse,
        LicenseKeyInstanceListPageResponseFromRaw
    >)
)]
public sealed record class LicenseKeyInstanceListPageResponse : JsonModel
{
    public required IReadOnlyList<LicenseKeyInstance> Items
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<LicenseKeyInstance>>("items"); }
        init
        {
            this._rawData.Set<ImmutableArray<LicenseKeyInstance>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public LicenseKeyInstanceListPageResponse(
        LicenseKeyInstanceListPageResponse licenseKeyInstanceListPageResponse
    )
        : base(licenseKeyInstanceListPageResponse) { }

    public LicenseKeyInstanceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyInstanceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class LicenseKeyInstanceListPageResponseFromRaw : IFromRawJson<LicenseKeyInstanceListPageResponse>
{
    /// <inheritdoc/>
    public LicenseKeyInstanceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyInstanceListPageResponse.FromRawUnchecked(rawData);
}
