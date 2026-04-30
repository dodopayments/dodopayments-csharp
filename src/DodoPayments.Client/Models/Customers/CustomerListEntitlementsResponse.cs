using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;

namespace DodoPayments.Client.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListEntitlementsResponse,
        CustomerListEntitlementsResponseFromRaw
    >)
)]
public sealed record class CustomerListEntitlementsResponse : JsonModel
{
    public required IReadOnlyList<CustomerListEntitlementsResponseItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CustomerListEntitlementsResponseItem>
            >("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerListEntitlementsResponseItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public CustomerListEntitlementsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListEntitlementsResponse(
        CustomerListEntitlementsResponse customerListEntitlementsResponse
    )
        : base(customerListEntitlementsResponse) { }
#pragma warning restore CS8618

    public CustomerListEntitlementsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListEntitlementsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListEntitlementsResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListEntitlementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerListEntitlementsResponse(
        IReadOnlyList<CustomerListEntitlementsResponseItem> items
    )
        : this()
    {
        this.Items = items;
    }
}

class CustomerListEntitlementsResponseFromRaw : IFromRawJson<CustomerListEntitlementsResponse>
{
    /// <inheritdoc/>
    public CustomerListEntitlementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListEntitlementsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListEntitlementsResponseItem,
        CustomerListEntitlementsResponseItemFromRaw
    >)
)]
public sealed record class CustomerListEntitlementsResponseItem : JsonModel
{
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
    /// The entitlement this grant belongs to.
    /// </summary>
    public required string EntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlement_id");
        }
        init { this._rawData.Set("entitlement_id", value); }
    }

    public required string EntitlementName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlement_name");
        }
        init { this._rawData.Set("entitlement_name", value); }
    }

    /// <summary>
    /// Grant id (the per-customer row in `entitlement_grants`).
    /// </summary>
    public required string GrantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grant_id");
        }
        init { this._rawData.Set("grant_id", value); }
    }

    public required ApiEnum<string, EntitlementIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntitlementIntegrationType>>(
                "integration_type"
            );
        }
        init { this._rawData.Set("integration_type", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public DateTimeOffset? DeliveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("delivered_at");
        }
        init { this._rawData.Set("delivered_at", value); }
    }

    public string? EntitlementDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entitlement_description");
        }
        init { this._rawData.Set("entitlement_description", value); }
    }

    public DateTimeOffset? RevokedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("revoked_at");
        }
        init { this._rawData.Set("revoked_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.EntitlementID;
        _ = this.EntitlementName;
        _ = this.GrantID;
        this.IntegrationType.Validate();
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.DeliveredAt;
        _ = this.EntitlementDescription;
        _ = this.RevokedAt;
    }

    public CustomerListEntitlementsResponseItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListEntitlementsResponseItem(
        CustomerListEntitlementsResponseItem customerListEntitlementsResponseItem
    )
        : base(customerListEntitlementsResponseItem) { }
#pragma warning restore CS8618

    public CustomerListEntitlementsResponseItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListEntitlementsResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListEntitlementsResponseItemFromRaw.FromRawUnchecked"/>
    public static CustomerListEntitlementsResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListEntitlementsResponseItemFromRaw
    : IFromRawJson<CustomerListEntitlementsResponseItem>
{
    /// <inheritdoc/>
    public CustomerListEntitlementsResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListEntitlementsResponseItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Delivered,
    Failed,
    Revoked,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "delivered" => Status.Delivered,
            "failed" => Status.Failed,
            "revoked" => Status.Revoked,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Delivered => "delivered",
                Status.Failed => "failed",
                Status.Revoked => "revoked",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
