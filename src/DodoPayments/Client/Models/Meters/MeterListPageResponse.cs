using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Meters;

[JsonConverter(typeof(Client::ModelConverter<MeterListPageResponse>))]
public sealed record class MeterListPageResponse
    : Client::ModelBase,
        Client::IFromRaw<MeterListPageResponse>
{
    public required List<Meter> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Meter>>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("items");
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

    public MeterListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeterListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MeterListPageResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MeterListPageResponse(List<Meter> items)
        : this()
    {
        this.Items = items;
    }
}
