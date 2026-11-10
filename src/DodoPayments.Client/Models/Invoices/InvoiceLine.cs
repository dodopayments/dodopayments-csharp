using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// One frozen line. Amounts are in the smallest currency unit.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InvoiceLine, InvoiceLineFromRaw>))]
public sealed record class InvoiceLine : JsonModel
{
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required ApiEnum<string, Kind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Kind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// A usage line has a quantity of 1. Its amount is the full usage charge.
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

    public required long Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// `true` when `amount` includes `tax`.
    /// </summary>
    public required bool TaxInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_inclusive");
        }
        init { this._rawData.Set("tax_inclusive", value); }
    }

    public required long UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    public string? AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("addon_id");
        }
        init { this._rawData.Set("addon_id", value); }
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

    public System::DateTimeOffset? PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("period_end");
        }
        init { this._rawData.Set("period_end", value); }
    }

    public System::DateTimeOffset? PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("period_start");
        }
        init { this._rawData.Set("period_start", value); }
    }

    public string? ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_id");
        }
        init { this._rawData.Set("product_id", value); }
    }

    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Tax percent times 100. For example, 1800 is 18%.
    /// </summary>
    public int? TaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tax_rate");
        }
        init { this._rawData.Set("tax_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Kind.Validate();
        _ = this.Quantity;
        _ = this.Tax;
        _ = this.TaxInclusive;
        _ = this.UnitAmount;
        _ = this.AddonID;
        _ = this.Description;
        _ = this.Name;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        _ = this.ProductID;
        _ = this.SubscriptionID;
        _ = this.TaxRate;
    }

    public InvoiceLine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceLine(InvoiceLine invoiceLine)
        : base(invoiceLine) { }
#pragma warning restore CS8618

    public InvoiceLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceLineFromRaw.FromRawUnchecked"/>
    public static InvoiceLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceLineFromRaw : IFromRawJson<InvoiceLine>
{
    /// <inheritdoc/>
    public InvoiceLine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceLine.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    Subscription,
    Addon,
    Meter,
    CreditOverage,
    OneTime,
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => Kind.Subscription,
            "addon" => Kind.Addon,
            "meter" => Kind.Meter,
            "credit_overage" => Kind.CreditOverage,
            "one_time" => Kind.OneTime,
            _ => (Kind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Kind.Subscription => "subscription",
                Kind.Addon => "addon",
                Kind.Meter => "meter",
                Kind.CreditOverage => "credit_overage",
                Kind.OneTime => "one_time",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
