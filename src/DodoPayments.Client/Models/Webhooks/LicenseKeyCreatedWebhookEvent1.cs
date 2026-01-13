using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;
using System = System;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<LicenseKeyCreatedWebhookEvent, LicenseKeyCreatedWebhookEventFromRaw1>)
)]
public sealed record class LicenseKeyCreatedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get { return this._rawData.GetNotNullClass<string>("business_id"); }
        init { this._rawData.Set("business_id", value); }
    }

    public required LicenseKey Data
    {
        get { return this._rawData.GetNotNullClass<LicenseKey>("data"); }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get { return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp"); }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public required ApiEnum<string, Type6> Type
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Type6>>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public LicenseKeyCreatedWebhookEvent() { }

    public LicenseKeyCreatedWebhookEvent(
        LicenseKeyCreatedWebhookEvent licenseKeyCreatedWebhookEvent
    )
        : base(licenseKeyCreatedWebhookEvent) { }

    public LicenseKeyCreatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyCreatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyCreatedWebhookEventFromRaw1.FromRawUnchecked"/>
    public static LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyCreatedWebhookEventFromRaw1 : IFromRawJson<LicenseKeyCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyCreatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The event type
/// </summary>
[JsonConverter(typeof(Type6Converter))]
public enum Type6
{
    LicenseKeyCreated,
}

sealed class Type6Converter : JsonConverter<Type6>
{
    public override Type6 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "license_key.created" => Type6.LicenseKeyCreated,
            _ => (Type6)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type6 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type6.LicenseKeyCreated => "license_key.created",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
