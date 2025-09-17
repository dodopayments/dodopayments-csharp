using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Addons;

[JsonConverter(typeof(Client::ModelConverter<AddonListPageResponse>))]
public sealed record class AddonListPageResponse
    : Client::ModelBase,
        Client::IFromRaw<AddonListPageResponse>
{
    public required List<AddonResponse> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<AddonResponse>>(
                    element,
                    Client::ModelBase.SerializerOptions
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

    public AddonListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddonListPageResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AddonListPageResponse(List<AddonResponse> items)
        : this()
    {
        this.Items = items;
    }
}
