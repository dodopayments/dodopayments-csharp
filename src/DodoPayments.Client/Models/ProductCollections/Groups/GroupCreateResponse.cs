using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Models.ProductCollections.Groups;

[JsonConverter(typeof(JsonModelConverter<GroupCreateResponse, GroupCreateResponseFromRaw>))]
public sealed record class GroupCreateResponse : JsonModel
{
    public required string GroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_id");
        }
        init { this._rawData.Set("group_id", value); }
    }

    public required IReadOnlyList<GroupCreateResponseProduct> Products
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GroupCreateResponseProduct>>(
                "products"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroupCreateResponseProduct>>(
                "products",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? GroupName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group_name");
        }
        init { this._rawData.Set("group_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupID;
        foreach (var item in this.Products)
        {
            item.Validate();
        }
        _ = this.Status;
        _ = this.GroupName;
    }

    public GroupCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupCreateResponse(GroupCreateResponse groupCreateResponse)
        : base(groupCreateResponse) { }
#pragma warning restore CS8618

    public GroupCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupCreateResponseFromRaw.FromRawUnchecked"/>
    public static GroupCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupCreateResponseFromRaw : IFromRawJson<GroupCreateResponse>
{
    /// <inheritdoc/>
    public GroupCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GroupCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<GroupCreateResponseProduct, GroupCreateResponseProductFromRaw>)
)]
public sealed record class GroupCreateResponseProduct : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required long AddonsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("addons_count");
        }
        init { this._rawData.Set("addons_count", value); }
    }

    public required long FilesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("files_count");
        }
        init { this._rawData.Set("files_count", value); }
    }

    /// <summary>
    /// Whether this product has any credit entitlements attached
    /// </summary>
    public required bool HasCreditEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_credit_entitlements");
        }
        init { this._rawData.Set("has_credit_entitlements", value); }
    }

    public required bool IsRecurring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_recurring");
        }
        init { this._rawData.Set("is_recurring", value); }
    }

    public required bool LicenseKeyEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("license_key_enabled");
        }
        init { this._rawData.Set("license_key_enabled", value); }
    }

    public required long MetersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("meters_count");
        }
        init { this._rawData.Set("meters_count", value); }
    }

    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public required bool Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public int? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// One-time price details.
    /// </summary>
    public Price? PriceDetail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Price>("price_detail");
        }
        init { this._rawData.Set("price_detail", value); }
    }

    /// <summary>
    /// Represents the different categories of taxation applicable to various products
    /// and services.
    /// </summary>
    public ApiEnum<string, TaxCategory>? TaxCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TaxCategory>>("tax_category");
        }
        init { this._rawData.Set("tax_category", value); }
    }

    public bool? TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AddonsCount;
        _ = this.FilesCount;
        _ = this.HasCreditEntitlements;
        _ = this.IsRecurring;
        _ = this.LicenseKeyEnabled;
        _ = this.MetersCount;
        _ = this.ProductID;
        _ = this.Status;
        this.Currency?.Validate();
        _ = this.Description;
        _ = this.Name;
        _ = this.Price;
        this.PriceDetail?.Validate();
        this.TaxCategory?.Validate();
        _ = this.TaxInclusive;
    }

    public GroupCreateResponseProduct() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupCreateResponseProduct(GroupCreateResponseProduct groupCreateResponseProduct)
        : base(groupCreateResponseProduct) { }
#pragma warning restore CS8618

    public GroupCreateResponseProduct(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupCreateResponseProduct(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupCreateResponseProductFromRaw.FromRawUnchecked"/>
    public static GroupCreateResponseProduct FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupCreateResponseProductFromRaw : IFromRawJson<GroupCreateResponseProduct>
{
    /// <inheritdoc/>
    public GroupCreateResponseProduct FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupCreateResponseProduct.FromRawUnchecked(rawData);
}
