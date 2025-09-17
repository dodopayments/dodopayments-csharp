using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CustomizationProperties = Dodopayments.Models.CheckoutSessions.CheckoutSessionRequestProperties.CustomizationProperties;
using Dodopayments = Dodopayments;

namespace Dodopayments.Models.CheckoutSessions.CheckoutSessionRequestProperties;

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(typeof(Dodopayments::ModelConverter<Customization>))]
public sealed record class Customization
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<Customization>
{
    /// <summary>
    /// Show on demand tag
    ///
    /// Default is true
    /// </summary>
    public bool? ShowOnDemandTag
    {
        get
        {
            if (!this.Properties.TryGetValue("show_on_demand_tag", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["show_on_demand_tag"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Show order details by default
    ///
    /// Default is true
    /// </summary>
    public bool? ShowOrderDetails
    {
        get
        {
            if (!this.Properties.TryGetValue("show_order_details", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["show_order_details"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Theme of the page
    ///
    /// Default is `System`.
    /// </summary>
    public CustomizationProperties::Theme? Theme
    {
        get
        {
            if (!this.Properties.TryGetValue("theme", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomizationProperties::Theme?>(
                element,
                Dodopayments::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["theme"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ShowOnDemandTag;
        _ = this.ShowOrderDetails;
        this.Theme?.Validate();
    }

    public Customization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customization(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Customization FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
