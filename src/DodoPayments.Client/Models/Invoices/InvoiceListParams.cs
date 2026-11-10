using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Invoices;

/// <summary>
/// Lists invoice-led invoices, newest first. The items have no `lines` and no `payments`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceListParams : ParamsBase
{
    public ApiEnum<string, CollectionMethod>? CollectionMethod
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, CollectionMethod>>(
                "collection_method"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("collection_method", value);
        }
    }

    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at_gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at_gte", value);
        }
    }

    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at_lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at_lte", value);
        }
    }

    public string? CustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("customer_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("customer_id", value);
        }
    }

    public System::DateTimeOffset? DueAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("due_at_gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("due_at_gte", value);
        }
    }

    public System::DateTimeOffset? DueAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("due_at_lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("due_at_lte", value);
        }
    }

    /// <summary>
    /// Page number. The default is 0.
    /// </summary>
    public int? PageNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_number", value);
        }
    }

    /// <summary>
    /// Page size. The default is 10 and the maximum is 100.
    /// </summary>
    public int? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Repeat the key to match more than one status, for example `status=open&amp;status=past_due`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Status>>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Status>>>(
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Status>>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? SubscriptionID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("subscription_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("subscription_id", value);
        }
    }

    /// <summary>
    /// Repeat the key to match an invoice that has any one of the tags.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Tag>>? Tags
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Tag>>>(
                "tags"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Tag>>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? TotalAmountGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("total_amount_gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("total_amount_gte", value);
        }
    }

    public long? TotalAmountLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("total_amount_lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("total_amount_lte", value);
        }
    }

    public InvoiceListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListParams(InvoiceListParams invoiceListParams)
        : base(invoiceListParams) { }
#pragma warning restore CS8618

    public InvoiceListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InvoiceListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InvoiceListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/billing/invoices")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(CollectionMethodConverter))]
public enum CollectionMethod
{
    AutoCharge,
    Manual,
}

sealed class CollectionMethodConverter : JsonConverter<CollectionMethod>
{
    public override CollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_charge" => CollectionMethod.AutoCharge,
            "manual" => CollectionMethod.Manual,
            _ => (CollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CollectionMethod.AutoCharge => "auto_charge",
                CollectionMethod.Manual => "manual",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The `message` of each variant is the label of the invoice document.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Open,
    Paid,
    Void,
    Draft,
    PastDue,
    Uncollectable,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => Status.Open,
            "paid" => Status.Paid,
            "void" => Status.Void,
            "draft" => Status.Draft,
            "past_due" => Status.PastDue,
            "uncollectable" => Status.Uncollectable,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Open => "open",
                Status.Paid => "paid",
                Status.Void => "void",
                Status.Draft => "draft",
                Status.PastDue => "past_due",
                Status.Uncollectable => "uncollectable",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TagConverter))]
public enum Tag
{
    Refunded,
    PartiallyRefunded,
    Disputed,
    PaymentReversed,
}

sealed class TagConverter : JsonConverter<Tag>
{
    public override Tag Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refunded" => Tag.Refunded,
            "partially_refunded" => Tag.PartiallyRefunded,
            "disputed" => Tag.Disputed,
            "payment_reversed" => Tag.PaymentReversed,
            _ => (Tag)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Tag value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Tag.Refunded => "refunded",
                Tag.PartiallyRefunded => "partially_refunded",
                Tag.Disputed => "disputed",
                Tag.PaymentReversed => "payment_reversed",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
