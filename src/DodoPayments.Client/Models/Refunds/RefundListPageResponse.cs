using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Models.Refunds;

[JsonConverter(typeof(ModelConverter<RefundListPageResponse, RefundListPageResponseFromRaw>))]
public sealed record class RefundListPageResponse : ModelBase
{
    public required List<ItemModel> Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<ItemModel>>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static RefundListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RefundListPageResponse(List<ItemModel> items)
        : this()
    {
        this.Items = items;
    }
}

class RefundListPageResponseFromRaw : IFromRaw<RefundListPageResponse>
{
    public RefundListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RefundListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ItemModel, ItemModelFromRaw>))]
public sealed record class ItemModel : ModelBase
{
    /// <summary>
    /// The unique identifier of the business issuing the refund.
    /// </summary>
    public required string BusinessID
    {
        get
        {
            if (!this._rawData.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentOutOfRangeException("business_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new ArgumentNullException("business_id")
                );
        }
        init
        {
            this._rawData["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of when the refund was created in UTC.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true the refund is a partial refund
    /// </summary>
    public required bool IsPartial
    {
        get
        {
            if (!this._rawData.TryGetValue("is_partial", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'is_partial' cannot be null",
                    new ArgumentOutOfRangeException("is_partial", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["is_partial"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the payment associated with the refund.
    /// </summary>
    public required string PaymentID
    {
        get
        {
            if (!this._rawData.TryGetValue("payment_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentOutOfRangeException("payment_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_id' cannot be null",
                    new ArgumentNullException("payment_id")
                );
        }
        init
        {
            this._rawData["payment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    public required string RefundID
    {
        get
        {
            if (!this._rawData.TryGetValue("refund_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'refund_id' cannot be null",
                    new ArgumentOutOfRangeException("refund_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'refund_id' cannot be null",
                    new ArgumentNullException("refund_id")
                );
        }
        init
        {
            this._rawData["refund_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current status of the refund.
    /// </summary>
    public required ApiEnum<string, RefundStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, RefundStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The refunded amount.
    /// </summary>
    public int? Amount
    {
        get
        {
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency of the refund, represented as an ISO 4217 currency code.
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Currency>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The reason provided for the refund, if any. Optional.
    /// </summary>
    public string? Reason
    {
        get
        {
            if (!this._rawData.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public ItemModel() { }

    public ItemModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ItemModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemModelFromRaw : IFromRaw<ItemModel>
{
    public ItemModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemModel.FromRawUnchecked(rawData);
}
