using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dodopayments = Dodopayments;
using SubscriptionRetrieveUsageHistoryPageResponseProperties = Dodopayments.Models.Subscriptions.SubscriptionRetrieveUsageHistoryPageResponseProperties;

namespace Dodopayments.Models.Subscriptions;

[JsonConverter(typeof(Dodopayments::ModelConverter<SubscriptionRetrieveUsageHistoryPageResponse>))]
public sealed record class SubscriptionRetrieveUsageHistoryPageResponse
    : Dodopayments::ModelBase,
        Dodopayments::IFromRaw<SubscriptionRetrieveUsageHistoryPageResponse>
{
    /// <summary>
    /// List of usage history items
    /// </summary>
    public required List<SubscriptionRetrieveUsageHistoryPageResponseProperties::Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new ArgumentOutOfRangeException("items", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<SubscriptionRetrieveUsageHistoryPageResponseProperties::Item>
                >(element, Dodopayments::ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("items");
        }
        set { this.Properties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public SubscriptionRetrieveUsageHistoryPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveUsageHistoryPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionRetrieveUsageHistoryPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveUsageHistoryPageResponse(
        List<SubscriptionRetrieveUsageHistoryPageResponseProperties::Item> items
    )
        : this()
    {
        this.Items = items;
    }
}
