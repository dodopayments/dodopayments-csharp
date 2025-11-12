using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Disputes;

public sealed record class DisputeListParams : ParamsBase
{
    /// <summary>
    /// Get events after this created time
    /// </summary>
    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            if (!this._queryProperties.TryGetValue("created_at_gte", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["created_at_gte"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Get events created before this time
    /// </summary>
    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            if (!this._queryProperties.TryGetValue("created_at_lte", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["created_at_lte"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by customer_id
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this._queryProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by dispute stage
    /// </summary>
    public ApiEnum<string, DisputeStage>? DisputeStage
    {
        get
        {
            if (!this._queryProperties.TryGetValue("dispute_stage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["dispute_stage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by dispute status
    /// </summary>
    public ApiEnum<string, DisputeStatus>? DisputeStatus
    {
        get
        {
            if (!this._queryProperties.TryGetValue("dispute_status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["dispute_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get
        {
            if (!this._queryProperties.TryGetValue("page_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["page_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get
        {
            if (!this._queryProperties.TryGetValue("page_size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["page_size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DisputeListParams() { }

    public DisputeListParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeListParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static DisputeListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/disputes")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Filter by dispute stage
/// </summary>
[JsonConverter(typeof(DisputeStageConverter))]
public enum DisputeStage
{
    PreDispute,
    Dispute,
    PreArbitration,
}

sealed class DisputeStageConverter : JsonConverter<DisputeStage>
{
    public override DisputeStage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pre_dispute" => DisputeStage.PreDispute,
            "dispute" => DisputeStage.Dispute,
            "pre_arbitration" => DisputeStage.PreArbitration,
            _ => (DisputeStage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeStage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeStage.PreDispute => "pre_dispute",
                DisputeStage.Dispute => "dispute",
                DisputeStage.PreArbitration => "pre_arbitration",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by dispute status
/// </summary>
[JsonConverter(typeof(DisputeStatusConverter))]
public enum DisputeStatus
{
    DisputeOpened,
    DisputeExpired,
    DisputeAccepted,
    DisputeCancelled,
    DisputeChallenged,
    DisputeWon,
    DisputeLost,
}

sealed class DisputeStatusConverter : JsonConverter<DisputeStatus>
{
    public override DisputeStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dispute_opened" => DisputeStatus.DisputeOpened,
            "dispute_expired" => DisputeStatus.DisputeExpired,
            "dispute_accepted" => DisputeStatus.DisputeAccepted,
            "dispute_cancelled" => DisputeStatus.DisputeCancelled,
            "dispute_challenged" => DisputeStatus.DisputeChallenged,
            "dispute_won" => DisputeStatus.DisputeWon,
            "dispute_lost" => DisputeStatus.DisputeLost,
            _ => (DisputeStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DisputeStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DisputeStatus.DisputeOpened => "dispute_opened",
                DisputeStatus.DisputeExpired => "dispute_expired",
                DisputeStatus.DisputeAccepted => "dispute_accepted",
                DisputeStatus.DisputeCancelled => "dispute_cancelled",
                DisputeStatus.DisputeChallenged => "dispute_challenged",
                DisputeStatus.DisputeWon => "dispute_won",
                DisputeStatus.DisputeLost => "dispute_lost",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
