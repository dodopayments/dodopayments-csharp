using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(typeof(Client::ModelConverter<UsageEventIngestResponse>))]
public sealed record class UsageEventIngestResponse
    : Client::ModelBase,
        Client::IFromRaw<UsageEventIngestResponse>
{
    public required long IngestedCount
    {
        get
        {
            if (!this.Properties.TryGetValue("ingested_count", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "ingested_count",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, Client::ModelBase.SerializerOptions);
        }
        set { this.Properties["ingested_count"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.IngestedCount;
    }

    public UsageEventIngestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEventIngestResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UsageEventIngestResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public UsageEventIngestResponse(long ingestedCount)
        : this()
    {
        this.IngestedCount = ingestedCount;
    }
}
