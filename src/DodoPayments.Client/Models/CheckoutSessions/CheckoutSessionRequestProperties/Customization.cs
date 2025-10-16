using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionRequestProperties.CustomizationProperties;

namespace DodoPayments.Client.Models.CheckoutSessions.CheckoutSessionRequestProperties;

/// <summary>
/// Customization for the checkout session page
/// </summary>
[JsonConverter(typeof(ModelConverter<Customization>))]
public sealed record class Customization : ModelBase, IFromRaw<Customization>
{
    /// <summary>
    /// Force the checkout interface to render in a specific language (e.g. `en`, `es`)
    /// </summary>
    public string? ForceLanguage
    {
        get
        {
            if (!this.Properties.TryGetValue("force_language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["force_language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["show_on_demand_tag"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["show_order_details"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Theme of the page
    ///
    /// Default is `System`.
    /// </summary>
    public ApiEnum<string, Theme>? Theme
    {
        get
        {
            if (!this.Properties.TryGetValue("theme", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Theme>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["theme"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ForceLanguage;
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
