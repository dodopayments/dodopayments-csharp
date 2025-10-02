using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.UsageEvents;

[JsonConverter(typeof(ModelConverter<UsageEventIngestResponse>))]
public sealed record class UsageEventIngestResponse : ModelBase, IFromRaw<UsageEventIngestResponse>
{
    public required long IngestedCount
    {
        get
        {
            if (!this.Properties.TryGetValue("ingested_count", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'ingested_count' cannot be null",
                    new ArgumentOutOfRangeException("ingested_count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ingested_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
