using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentListPageResponse, PaymentListPageResponseFromRaw>))]
public sealed record class PaymentListPageResponse : JsonModel
{
    public required IReadOnlyList<PaymentListResponse> Items
    {
        get { return JsonModel.GetNotNullClass<List<PaymentListResponse>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PaymentListPageResponse() { }

    public PaymentListPageResponse(PaymentListPageResponse paymentListPageResponse)
        : base(paymentListPageResponse) { }

    public PaymentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentListPageResponseFromRaw.FromRawUnchecked"/>
    public static PaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaymentListPageResponse(List<PaymentListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class PaymentListPageResponseFromRaw : IFromRawJson<PaymentListPageResponse>
{
    /// <inheritdoc/>
    public PaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentListPageResponse.FromRawUnchecked(rawData);
}
