using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Disputes;

public sealed record class DisputeListParams : ParamsBase
{
    /// <summary>
    /// Get events after this created time
    /// </summary>
    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "created_at_gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "created_at_gte", value);
        }
    }

    /// <summary>
    /// Get events created before this time
    /// </summary>
    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "created_at_lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "created_at_lte", value);
        }
    }

    /// <summary>
    /// Filter by customer_id
    /// </summary>
    public string? CustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "customer_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "customer_id", value);
        }
    }

    /// <summary>
    /// Filter by dispute stage
    /// </summary>
    public ApiEnum<string, DisputeStage>? DisputeStage
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, DisputeStage>>(
                this.RawQueryData,
                "dispute_stage"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "dispute_stage", value);
        }
    }

    /// <summary>
    /// Filter by dispute status
    /// </summary>
    public ApiEnum<string, DisputeStatus>? DisputeStatus
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, DisputeStatus>>(
                this.RawQueryData,
                "dispute_status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "dispute_status", value);
        }
    }

    /// <summary>
    /// Page number default is 0
    /// </summary>
    public int? PageNumber
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawQueryData, "page_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "page_number", value);
        }
    }

    /// <summary>
    /// Page size default is 10 max is 100
    /// </summary>
    public int? PageSize
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawQueryData, "page_size"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "page_size", value);
        }
    }

    public DisputeListParams() { }

    public DisputeListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DisputeListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static DisputeListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/disputes")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
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
        Type typeToConvert,
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
        Type typeToConvert,
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
