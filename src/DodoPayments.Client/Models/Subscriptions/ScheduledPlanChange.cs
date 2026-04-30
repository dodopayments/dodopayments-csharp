using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Subscriptions;

[JsonConverter(typeof(JsonModelConverter<ScheduledPlanChange, ScheduledPlanChangeFromRaw>))]
public sealed record class ScheduledPlanChange : JsonModel
{
    /// <summary>
    /// The scheduled plan change ID
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Addons included in the scheduled change
    /// </summary>
    public required IReadOnlyList<Addon> Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Addon>>("addons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Addon>>(
                "addons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When this scheduled change was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// When the change will be applied
    /// </summary>
    public required DateTimeOffset EffectiveAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("effective_at");
        }
        init { this._rawData.Set("effective_at", value); }
    }

    /// <summary>
    /// The product ID the subscription will change to
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    /// <summary>
    /// Quantity for the new plan
    /// </summary>
    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Description of the product being changed to
    /// </summary>
    public string? ProductDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_description");
        }
        init { this._rawData.Set("product_description", value); }
    }

    /// <summary>
    /// Name of the product being changed to
    /// </summary>
    public string? ProductName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_name");
        }
        init { this._rawData.Set("product_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Addons)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.EffectiveAt;
        _ = this.ProductID;
        _ = this.Quantity;
        _ = this.ProductDescription;
        _ = this.ProductName;
    }

    public ScheduledPlanChange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledPlanChange(ScheduledPlanChange scheduledPlanChange)
        : base(scheduledPlanChange) { }
#pragma warning restore CS8618

    public ScheduledPlanChange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledPlanChange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScheduledPlanChangeFromRaw.FromRawUnchecked"/>
    public static ScheduledPlanChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScheduledPlanChangeFromRaw : IFromRawJson<ScheduledPlanChange>
{
    /// <inheritdoc/>
    public ScheduledPlanChange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ScheduledPlanChange.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Addon, AddonFromRaw>))]
public sealed record class Addon : JsonModel
{
    /// <summary>
    /// The addon ID
    /// </summary>
    public required string AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("addon_id");
        }
        init { this._rawData.Set("addon_id", value); }
    }

    /// <summary>
    /// Name of the addon
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Quantity of the addon
    /// </summary>
    public required int Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Name;
        _ = this.Quantity;
    }

    public Addon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Addon(Addon addon)
        : base(addon) { }
#pragma warning restore CS8618

    public Addon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Addon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonFromRaw.FromRawUnchecked"/>
    public static Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonFromRaw : IFromRawJson<Addon>
{
    /// <inheritdoc/>
    public Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addon.FromRawUnchecked(rawData);
}
