using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(ModelConverter<RefundListPageResponse, RefundListPageResponseFromRaw>))]
public sealed record class RefundListPageResponse : ModelBase
{
    public required IReadOnlyList<RefundListPageResponseItem> Items
    {
        get
        {
            return ModelBase.GetNotNullClass<List<RefundListPageResponseItem>>(
                this.RawData,
                "items"
            );
        }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public RefundListPageResponse() { }

    public RefundListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundListPageResponseFromRaw.FromRawUnchecked"/>
    public static RefundListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RefundListPageResponse(List<RefundListPageResponseItem> items)
        : this()
    {
        this.Items = items;
    }
}

class RefundListPageResponseFromRaw : IFromRaw<RefundListPageResponse>
{
    /// <inheritdoc/>
    public RefundListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<RefundListPageResponseItem, RefundListPageResponseItemFromRaw>)
)]
public sealed record class RefundListPageResponseItem : ModelBase
{
    /// <summary>
    /// The unique identifier of the business issuing the refund.
    /// </summary>
    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    /// <summary>
    /// The timestamp of when the refund was created in UTC.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "is_partial"); }
        init { ModelBase.Set(this._rawData, "is_partial", value); }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the refund.
    /// </summary>
    public required string PaymentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "payment_id"); }
        init { ModelBase.Set(this._rawData, "payment_id", value); }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "refund_id"); }
        init { ModelBase.Set(this._rawData, "refund_id", value); }
    }

    /// <summary>
    /// The current status of the refund.
    /// </summary>
    public required ApiEnum<string, RefundStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, RefundStatus>>(this.RawData, "status");
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get { return ModelBase.GetNullableStruct<int>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The currency of the refund, represented as an ISO 4217 currency code.
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Currency>>(this.RawData, "currency");
        }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BusinessID;
        _ = this.CreatedAt;
        _ = this.IsPartial;
        _ = this.PaymentID;
        _ = this.RefundID;
        this.Status.Validate();
        _ = this.Amount;
        this.Currency?.Validate();
        _ = this.Reason;
    }

    public RefundListPageResponseItem() { }

    public RefundListPageResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefundListPageResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefundListPageResponseItemFromRaw.FromRawUnchecked"/>
    public static RefundListPageResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefundListPageResponseItemFromRaw : IFromRaw<RefundListPageResponseItem>
{
    /// <inheritdoc/>
    public RefundListPageResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundListPageResponseItem.FromRawUnchecked(rawData);
}
