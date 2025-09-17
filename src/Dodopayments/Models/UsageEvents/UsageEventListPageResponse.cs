using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using System = System;

namespace Dodopayments.Models.UsageEvents;

[JsonConverter(typeof(Dodopayments::ModelConverter<UsageEventListPageResponse>))]
public sealed record class UsageEventListPageResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<UsageEventListPageResponse>
{
    public required List<Event> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<List<Event>>(
                    element,
                    Dodopayments::ModelBase.SerializerOptions
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

    public UsageEventListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UsageEventListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public UsageEventListPageResponse(List<Event> items)
        : this()
    {
        this.Items = items;
    }
}
