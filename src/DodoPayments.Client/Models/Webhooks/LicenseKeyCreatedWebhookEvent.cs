using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<LicenseKeyCreatedWebhookEvent, LicenseKeyCreatedWebhookEventFromRaw>)
)]
public sealed record class LicenseKeyCreatedWebhookEvent : JsonModel
{
    /// <summary>
    /// The business identifier
    /// </summary>
    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

    public required LicenseKey Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LicenseKey>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The timestamp of when the event occurred
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The event type
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        this.Data.Validate();
        _ = this.Timestamp;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("license_key.created")
            )
        )
        {
            throw new DodoPaymentsInvalidDataException("Invalid value given for constant");
        }
    }

    public LicenseKeyCreatedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("license_key.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKeyCreatedWebhookEvent(
        LicenseKeyCreatedWebhookEvent licenseKeyCreatedWebhookEvent
    )
        : base(licenseKeyCreatedWebhookEvent) { }
#pragma warning restore CS8618

    public LicenseKeyCreatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("license_key.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyCreatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyCreatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyCreatedWebhookEventFromRaw : IFromRawJson<LicenseKeyCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public LicenseKeyCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseKeyCreatedWebhookEvent.FromRawUnchecked(rawData);
}
