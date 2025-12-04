using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeys;

[JsonConverter(
    typeof(ModelConverter<LicenseKeyListPageResponse, LicenseKeyListPageResponseFromRaw>)
)]
public sealed record class LicenseKeyListPageResponse : ModelBase
{
    public required IReadOnlyList<LicenseKey> Items
    {
        get { return ModelBase.GetNotNullClass<List<LicenseKey>>(this.RawData, "items"); }
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

    public LicenseKeyListPageResponse() { }

    public LicenseKeyListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyListPageResponseFromRaw.FromRawUnchecked"/>
    public static LicenseKeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LicenseKeyListPageResponse(List<LicenseKey> items)
        : this()
    {
        this.Items = items;
    }
}

class LicenseKeyListPageResponseFromRaw : IFromRaw<LicenseKeyListPageResponse>
{
    /// <inheritdoc/>
    public LicenseKeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyListPageResponse.FromRawUnchecked(rawData);
}
