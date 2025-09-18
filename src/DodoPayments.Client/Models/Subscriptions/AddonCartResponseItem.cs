using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DodoPayments.Client.Models.Subscriptions;

/// <summary>
/// Response struct representing subscription details
/// </summary>
[JsonConverter(typeof(ModelConverter<AddonCartResponseItem>))]
public sealed record class AddonCartResponseItem : ModelBase, IFromRaw<AddonCartResponseItem>
{
    public required string AddonID
    {
        get
        {
            if (!this.Properties.TryGetValue("addon_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("addon_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("addon_id");
        }
        set
        {
            this.Properties["addon_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required int Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

            return JsonSerializer.Deserialize<int>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Quantity;
    }

    public AddonCartResponseItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonCartResponseItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddonCartResponseItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
