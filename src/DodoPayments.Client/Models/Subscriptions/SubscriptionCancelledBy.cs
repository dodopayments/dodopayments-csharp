using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// The caller that cancelled a subscription or scheduled its cancel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SubscriptionCancelledBy, SubscriptionCancelledByFromRaw>))]
public sealed record class SubscriptionCancelledBy : JsonModel
{
    /// <summary>
    /// The kind of caller.
    /// </summary>
    public required ApiEnum<string, ActorType> ActorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActorType>>("actor_type");
        }
        init { this._rawData.Set("actor_type", value); }
    }

    /// <summary>
    /// Email of the customer or of the dashboard user. `null` for an API key or the
    /// Dodo Payments team.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Name of the customer or of the dashboard user. `null` for an API key or the
    /// Dodo Payments team.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ActorType.Validate();
        _ = this.Email;
        _ = this.Name;
    }

    public SubscriptionCancelledBy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCancelledBy(SubscriptionCancelledBy subscriptionCancelledBy)
        : base(subscriptionCancelledBy) { }
#pragma warning restore CS8618

    public SubscriptionCancelledBy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCancelledBy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionCancelledByFromRaw.FromRawUnchecked"/>
    public static SubscriptionCancelledBy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionCancelledBy(ApiEnum<string, ActorType> actorType)
        : this()
    {
        this.ActorType = actorType;
    }
}

class SubscriptionCancelledByFromRaw : IFromRawJson<SubscriptionCancelledBy>
{
    /// <inheritdoc/>
    public SubscriptionCancelledBy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionCancelledBy.FromRawUnchecked(rawData);
}

/// <summary>
/// The kind of caller.
/// </summary>
[JsonConverter(typeof(ActorTypeConverter))]
public enum ActorType
{
    Customer,
    MerchantUser,
    ApiKey,
    DodoTeam,
}

sealed class ActorTypeConverter : JsonConverter<ActorType>
{
    public override ActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "customer" => ActorType.Customer,
            "merchant_user" => ActorType.MerchantUser,
            "api_key" => ActorType.ApiKey,
            "dodo_team" => ActorType.DodoTeam,
            _ => (ActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActorType.Customer => "customer",
                ActorType.MerchantUser => "merchant_user",
                ActorType.ApiKey => "api_key",
                ActorType.DodoTeam => "dodo_team",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
