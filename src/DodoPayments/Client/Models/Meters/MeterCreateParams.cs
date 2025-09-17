using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Client = DodoPayments.Client;
using System = System;

namespace DodoPayments.Client.Models.Meters;

public sealed record class MeterCreateParams : Client::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Aggregation configuration for the meter
    /// </summary>
    public required MeterAggregation Aggregation
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("aggregation", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "aggregation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MeterAggregation>(
                    element,
                    Client::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("aggregation");
        }
        set { this.BodyProperties["aggregation"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Event name to track
    /// </summary>
    public required string EventName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("event_name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "event_name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("event_name");
        }
        set { this.BodyProperties["event_name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// measurement unit
    /// </summary>
    public required string MeasurementUnit
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("measurement_unit", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "measurement_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("measurement_unit");
        }
        set { this.BodyProperties["measurement_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Name of the meter
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, Client::ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional description of the meter
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional filter to apply to the meter
    /// </summary>
    public MeterFilter? Filter
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MeterFilter?>(
                element,
                Client::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["filter"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Client::IDodoPaymentsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/meters")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, Client::IDodoPaymentsClient client)
    {
        Client::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Client::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
