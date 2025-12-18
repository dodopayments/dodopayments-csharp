using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.LicenseKeys;

[JsonConverter(
    typeof(JsonModelConverter<LicenseKeyListPageResponse, LicenseKeyListPageResponseFromRaw>)
)]
public sealed record class LicenseKeyListPageResponse : JsonModel
{
    public required IReadOnlyList<LicenseKey> Items
    {
        get { return JsonModel.GetNotNullClass<List<LicenseKey>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
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

    public LicenseKeyListPageResponse(LicenseKeyListPageResponse licenseKeyListPageResponse)
        : base(licenseKeyListPageResponse) { }

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

class LicenseKeyListPageResponseFromRaw : IFromRawJson<LicenseKeyListPageResponse>
{
    /// <inheritdoc/>
    public LicenseKeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyListPageResponse.FromRawUnchecked(rawData);
}
