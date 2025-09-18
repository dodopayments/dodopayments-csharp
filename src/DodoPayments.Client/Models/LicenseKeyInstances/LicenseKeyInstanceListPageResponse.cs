using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.LicenseKeyInstances;

[JsonConverter(typeof(ModelConverter<LicenseKeyInstanceListPageResponse>))]
public sealed record class LicenseKeyInstanceListPageResponse
    : ModelBase,
        IFromRaw<LicenseKeyInstanceListPageResponse>
{
    public required List<LicenseKeyInstance> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<LicenseKeyInstance>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("items");
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public LicenseKeyInstanceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyInstanceListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LicenseKeyInstanceListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public LicenseKeyInstanceListPageResponse(List<LicenseKeyInstance> items)
        : this()
    {
        this.Items = items;
    }
}
