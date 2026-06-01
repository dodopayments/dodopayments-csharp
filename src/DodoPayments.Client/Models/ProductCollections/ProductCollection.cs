using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.ProductCollections.Groups;

namespace DodoPayments.Client.Models.ProductCollections;

[JsonConverter(typeof(JsonModelConverter<ProductCollection, ProductCollectionFromRaw>))]
public sealed record class ProductCollection : JsonModel
{
    /// <summary>
    /// Unique identifier for the product collection
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
    /// Brand ID for the collection
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Timestamp when the collection was created
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
    /// Groups in this collection
    /// </summary>
    public required IReadOnlyList<ProductCollectionGroupResponse> Groups
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProductCollectionGroupResponse>>(
                "groups"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProductCollectionGroupResponse>>(
                "groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the collection
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
    /// Timestamp when the collection was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Description of the collection
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Default effective_at setting for subscription plan downgrades (null = inherit
    /// from business)
    /// </summary>
    public ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade>? EffectiveAtOnDowngrade
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProductCollectionEffectiveAtOnDowngrade>
            >("effective_at_on_downgrade");
        }
        init { this._rawData.Set("effective_at_on_downgrade", value); }
    }

    /// <summary>
    /// Default effective_at setting for subscription plan upgrades (null = inherit
    /// from business)
    /// </summary>
    public ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade>? EffectiveAtOnUpgrade
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProductCollectionEffectiveAtOnUpgrade>
            >("effective_at_on_upgrade");
        }
        init { this._rawData.Set("effective_at_on_upgrade", value); }
    }

    /// <summary>
    /// URL of the collection image
    /// </summary>
    public string? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image");
        }
        init { this._rawData.Set("image", value); }
    }

    /// <summary>
    /// Default behavior for subscription plan changes on payment failure (null =
    /// inherit from business)
    /// </summary>
    public ApiEnum<string, ProductCollectionOnPaymentFailure>? OnPaymentFailure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProductCollectionOnPaymentFailure>
            >("on_payment_failure");
        }
        init { this._rawData.Set("on_payment_failure", value); }
    }

    /// <summary>
    /// Default proration billing mode for subscription plan downgrades (null = inherit
    /// from business)
    /// </summary>
    public ApiEnum<
        string,
        ProductCollectionProrationBillingModeOnDowngrade
    >? ProrationBillingModeOnDowngrade
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProductCollectionProrationBillingModeOnDowngrade>
            >("proration_billing_mode_on_downgrade");
        }
        init { this._rawData.Set("proration_billing_mode_on_downgrade", value); }
    }

    /// <summary>
    /// Default proration billing mode for subscription plan upgrades (null = inherit
    /// from business)
    /// </summary>
    public ApiEnum<
        string,
        ProductCollectionProrationBillingModeOnUpgrade
    >? ProrationBillingModeOnUpgrade
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProductCollectionProrationBillingModeOnUpgrade>
            >("proration_billing_mode_on_upgrade");
        }
        init { this._rawData.Set("proration_billing_mode_on_upgrade", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BrandID;
        _ = this.CreatedAt;
        foreach (var item in this.Groups)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.Description;
        this.EffectiveAtOnDowngrade?.Validate();
        this.EffectiveAtOnUpgrade?.Validate();
        _ = this.Image;
        this.OnPaymentFailure?.Validate();
        this.ProrationBillingModeOnDowngrade?.Validate();
        this.ProrationBillingModeOnUpgrade?.Validate();
    }

    public ProductCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCollection(ProductCollection productCollection)
        : base(productCollection) { }
#pragma warning restore CS8618

    public ProductCollection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCollectionFromRaw.FromRawUnchecked"/>
    public static ProductCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCollectionFromRaw : IFromRawJson<ProductCollection>
{
    /// <inheritdoc/>
    public ProductCollection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductCollection.FromRawUnchecked(rawData);
}

/// <summary>
/// Default effective_at setting for subscription plan downgrades (null = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(ProductCollectionEffectiveAtOnDowngradeConverter))]
public enum ProductCollectionEffectiveAtOnDowngrade
{
    Immediately,
    NextBillingDate,
}

sealed class ProductCollectionEffectiveAtOnDowngradeConverter
    : JsonConverter<ProductCollectionEffectiveAtOnDowngrade>
{
    public override ProductCollectionEffectiveAtOnDowngrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => ProductCollectionEffectiveAtOnDowngrade.Immediately,
            "next_billing_date" => ProductCollectionEffectiveAtOnDowngrade.NextBillingDate,
            _ => (ProductCollectionEffectiveAtOnDowngrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionEffectiveAtOnDowngrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionEffectiveAtOnDowngrade.Immediately => "immediately",
                ProductCollectionEffectiveAtOnDowngrade.NextBillingDate => "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default effective_at setting for subscription plan upgrades (null = inherit from business)
/// </summary>
[JsonConverter(typeof(ProductCollectionEffectiveAtOnUpgradeConverter))]
public enum ProductCollectionEffectiveAtOnUpgrade
{
    Immediately,
    NextBillingDate,
}

sealed class ProductCollectionEffectiveAtOnUpgradeConverter
    : JsonConverter<ProductCollectionEffectiveAtOnUpgrade>
{
    public override ProductCollectionEffectiveAtOnUpgrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediately" => ProductCollectionEffectiveAtOnUpgrade.Immediately,
            "next_billing_date" => ProductCollectionEffectiveAtOnUpgrade.NextBillingDate,
            _ => (ProductCollectionEffectiveAtOnUpgrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionEffectiveAtOnUpgrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionEffectiveAtOnUpgrade.Immediately => "immediately",
                ProductCollectionEffectiveAtOnUpgrade.NextBillingDate => "next_billing_date",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default behavior for subscription plan changes on payment failure (null = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(ProductCollectionOnPaymentFailureConverter))]
public enum ProductCollectionOnPaymentFailure
{
    PreventChange,
    ApplyChange,
}

sealed class ProductCollectionOnPaymentFailureConverter
    : JsonConverter<ProductCollectionOnPaymentFailure>
{
    public override ProductCollectionOnPaymentFailure Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prevent_change" => ProductCollectionOnPaymentFailure.PreventChange,
            "apply_change" => ProductCollectionOnPaymentFailure.ApplyChange,
            _ => (ProductCollectionOnPaymentFailure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionOnPaymentFailure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionOnPaymentFailure.PreventChange => "prevent_change",
                ProductCollectionOnPaymentFailure.ApplyChange => "apply_change",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default proration billing mode for subscription plan downgrades (null = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(ProductCollectionProrationBillingModeOnDowngradeConverter))]
public enum ProductCollectionProrationBillingModeOnDowngrade
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class ProductCollectionProrationBillingModeOnDowngradeConverter
    : JsonConverter<ProductCollectionProrationBillingModeOnDowngrade>
{
    public override ProductCollectionProrationBillingModeOnDowngrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" =>
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately,
            "full_immediately" => ProductCollectionProrationBillingModeOnDowngrade.FullImmediately,
            "difference_immediately" =>
                ProductCollectionProrationBillingModeOnDowngrade.DifferenceImmediately,
            "do_not_bill" => ProductCollectionProrationBillingModeOnDowngrade.DoNotBill,
            _ => (ProductCollectionProrationBillingModeOnDowngrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionProrationBillingModeOnDowngrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionProrationBillingModeOnDowngrade.ProratedImmediately =>
                    "prorated_immediately",
                ProductCollectionProrationBillingModeOnDowngrade.FullImmediately =>
                    "full_immediately",
                ProductCollectionProrationBillingModeOnDowngrade.DifferenceImmediately =>
                    "difference_immediately",
                ProductCollectionProrationBillingModeOnDowngrade.DoNotBill => "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default proration billing mode for subscription plan upgrades (null = inherit
/// from business)
/// </summary>
[JsonConverter(typeof(ProductCollectionProrationBillingModeOnUpgradeConverter))]
public enum ProductCollectionProrationBillingModeOnUpgrade
{
    ProratedImmediately,
    FullImmediately,
    DifferenceImmediately,
    DoNotBill,
}

sealed class ProductCollectionProrationBillingModeOnUpgradeConverter
    : JsonConverter<ProductCollectionProrationBillingModeOnUpgrade>
{
    public override ProductCollectionProrationBillingModeOnUpgrade Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prorated_immediately" =>
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately,
            "full_immediately" => ProductCollectionProrationBillingModeOnUpgrade.FullImmediately,
            "difference_immediately" =>
                ProductCollectionProrationBillingModeOnUpgrade.DifferenceImmediately,
            "do_not_bill" => ProductCollectionProrationBillingModeOnUpgrade.DoNotBill,
            _ => (ProductCollectionProrationBillingModeOnUpgrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCollectionProrationBillingModeOnUpgrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCollectionProrationBillingModeOnUpgrade.ProratedImmediately =>
                    "prorated_immediately",
                ProductCollectionProrationBillingModeOnUpgrade.FullImmediately =>
                    "full_immediately",
                ProductCollectionProrationBillingModeOnUpgrade.DifferenceImmediately =>
                    "difference_immediately",
                ProductCollectionProrationBillingModeOnUpgrade.DoNotBill => "do_not_bill",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
