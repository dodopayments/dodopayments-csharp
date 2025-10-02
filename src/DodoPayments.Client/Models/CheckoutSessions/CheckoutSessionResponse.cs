using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

[JsonConverter(typeof(ModelConverter<CheckoutSessionResponse>))]
public sealed record class CheckoutSessionResponse : ModelBase, IFromRaw<CheckoutSessionResponse>
{
    /// <summary>
    /// Checkout url
    /// </summary>
    public required string CheckoutURL
    {
        get
        {
            if (!this.Properties.TryGetValue("checkout_url", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'checkout_url' cannot be null",
                    new ArgumentOutOfRangeException("checkout_url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'checkout_url' cannot be null",
                    new ArgumentNullException("checkout_url")
                );
        }
        set
        {
            this.Properties["checkout_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the created checkout session
    /// </summary>
    public required string SessionID
    {
        get
        {
            if (!this.Properties.TryGetValue("session_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'session_id' cannot be null",
                    new ArgumentOutOfRangeException("session_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'session_id' cannot be null",
                    new ArgumentNullException("session_id")
                );
        }
        set
        {
            this.Properties["session_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CheckoutURL;
        _ = this.SessionID;
    }

    public CheckoutSessionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutSessionResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CheckoutSessionResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
