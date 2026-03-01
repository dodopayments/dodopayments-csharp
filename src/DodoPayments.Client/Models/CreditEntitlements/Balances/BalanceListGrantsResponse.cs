using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CreditEntitlements.Balances;

/// <summary>
/// Response for a credit grant
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BalanceListGrantsResponse, BalanceListGrantsResponseFromRaw>)
)]
public sealed record class BalanceListGrantsResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string CreditEntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_entitlement_id");
        }
        init { this._rawData.Set("credit_entitlement_id", value); }
    }

    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    public required string InitialAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("initial_amount");
        }
        init { this._rawData.Set("initial_amount", value); }
    }

    public required bool IsExpired
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_expired");
        }
        init { this._rawData.Set("is_expired", value); }
    }

    public required bool IsRolledOver
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_rolled_over");
        }
        init { this._rawData.Set("is_rolled_over", value); }
    }

    public required string RemainingAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("remaining_amount");
        }
        init { this._rawData.Set("remaining_amount", value); }
    }

    public required int RolloverCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("rollover_count");
        }
        init { this._rawData.Set("rollover_count", value); }
    }

    public required ApiEnum<string, SourceType> SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceType>>("source_type");
        }
        init { this._rawData.Set("source_type", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ParentGrantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_grant_id");
        }
        init { this._rawData.Set("parent_grant_id", value); }
    }

    public string? SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_id");
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CreditEntitlementID;
        _ = this.CustomerID;
        _ = this.InitialAmount;
        _ = this.IsExpired;
        _ = this.IsRolledOver;
        _ = this.RemainingAmount;
        _ = this.RolloverCount;
        this.SourceType.Validate();
        _ = this.UpdatedAt;
        _ = this.ExpiresAt;
        _ = this.Metadata;
        _ = this.ParentGrantID;
        _ = this.SourceID;
    }

    public BalanceListGrantsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceListGrantsResponse(BalanceListGrantsResponse balanceListGrantsResponse)
        : base(balanceListGrantsResponse) { }
#pragma warning restore CS8618

    public BalanceListGrantsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceListGrantsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceListGrantsResponseFromRaw.FromRawUnchecked"/>
    public static BalanceListGrantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceListGrantsResponseFromRaw : IFromRawJson<BalanceListGrantsResponse>
{
    /// <inheritdoc/>
    public BalanceListGrantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceListGrantsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    Subscription,
    OneTime,
    Addon,
    Api,
    Rollover,
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => SourceType.Subscription,
            "one_time" => SourceType.OneTime,
            "addon" => SourceType.Addon,
            "api" => SourceType.Api,
            "rollover" => SourceType.Rollover,
            _ => (SourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceType.Subscription => "subscription",
                SourceType.OneTime => "one_time",
                SourceType.Addon => "addon",
                SourceType.Api => "api",
                SourceType.Rollover => "rollover",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
