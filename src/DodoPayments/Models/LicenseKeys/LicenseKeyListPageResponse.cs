using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments = DodoPayments;

namespace DodoPayments.Models.LicenseKeys;

[JsonConverter(typeof(DodoPayments::ModelConverter<LicenseKeyListPageResponse>))]
public sealed record class LicenseKeyListPageResponse
    : DodoPayments::ModelBase,
        DodoPayments::IFromRaw<LicenseKeyListPageResponse>
{
    public required List<LicenseKey> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<LicenseKey>>(
                    element,
                    DodoPayments::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public LicenseKeyListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LicenseKeyListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public LicenseKeyListPageResponse(List<LicenseKey> items)
        : this()
    {
        this.Items = items;
    }
}
