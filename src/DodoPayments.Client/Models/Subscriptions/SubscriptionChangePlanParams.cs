using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionChangePlanParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Unique identifier of the product to subscribe to
    /// </summary>
    public required string ProductID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("product_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "product_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'product_id' cannot be null",
                    new System::ArgumentNullException("product_id")
                );
        }
        init
        {
            this._bodyProperties["product_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Proration Billing Mode
    /// </summary>
    public required ApiEnum<string, ProrationBillingMode> ProrationBillingMode
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue("proration_billing_mode", out JsonElement element)
            )
                throw new DodoPaymentsInvalidDataException(
                    "'proration_billing_mode' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "proration_billing_mode",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProrationBillingMode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["proration_billing_mode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of units to subscribe for. Must be at least 1.
    /// </summary>
    public required int Quantity
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("quantity", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Addons for the new plan. Note : Leaving this empty would remove any existing addons
    /// </summary>
    public List<AttachAddon>? Addons
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("addons", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AttachAddon>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["addons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionChangePlanParams() { }

    public SubscriptionChangePlanParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangePlanParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionChangePlanParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/change-plan", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
/// Proration Billing Mode
/// </summary>
[JsonConverter(typeof(ProrationBillingModeConverter))]
public enum ProrationBillingMode
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
}

sealed class ProrationBillingModeConverter : JsonConverter<ProrationBillingMode>
{
    public override ProrationBillingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" => ProrationBillingMode.ProratedImmediately,
            "full_immediately" => ProrationBillingMode.FullImmediately,
            "difference_immediately" => ProrationBillingMode.DifferenceImmediately,
            _ => (ProrationBillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProrationBillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProrationBillingMode.ProratedImmediately => "prorated_immediately",
                ProrationBillingMode.FullImmediately => "full_immediately",
                ProrationBillingMode.DifferenceImmediately => "difference_immediately",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
