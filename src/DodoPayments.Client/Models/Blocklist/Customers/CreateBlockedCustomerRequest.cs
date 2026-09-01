using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Blocklist.Customers;

[JsonConverter(typeof(CreateBlockedCustomerRequestConverter))]
public record class CreateBlockedCustomerRequest : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                blocklistCustomersBlockByCustomerID: (x) => x.Reason,
                blocklistCustomersBlockByEmail: (x) => x.Reason
            );
        }
    }

    public ApiEnum<string, BlockedCustomerSource>? Source
    {
        get
        {
            return Match<ApiEnum<string, BlockedCustomerSource>?>(
                blocklistCustomersBlockByCustomerID: (x) => x.Source,
                blocklistCustomersBlockByEmail: (x) => x.Source
            );
        }
    }

    public CreateBlockedCustomerRequest(
        BlocklistCustomersBlockByCustomerID value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateBlockedCustomerRequest(
        BlocklistCustomersBlockByEmail value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateBlockedCustomerRequest(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BlocklistCustomersBlockByCustomerID"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBlocklistCustomersBlockByCustomerID(out var value)) {
    ///     // `value` is of type `BlocklistCustomersBlockByCustomerID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBlocklistCustomersBlockByCustomerID(
        [NotNullWhen(true)] out BlocklistCustomersBlockByCustomerID? value
    )
    {
        value = this.Value as BlocklistCustomersBlockByCustomerID;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BlocklistCustomersBlockByEmail"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBlocklistCustomersBlockByEmail(out var value)) {
    ///     // `value` is of type `BlocklistCustomersBlockByEmail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBlocklistCustomersBlockByEmail(
        [NotNullWhen(true)] out BlocklistCustomersBlockByEmail? value
    )
    {
        value = this.Value as BlocklistCustomersBlockByEmail;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BlocklistCustomersBlockByCustomerID value) =&gt; {...},
    ///     (BlocklistCustomersBlockByEmail value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BlocklistCustomersBlockByCustomerID> blocklistCustomersBlockByCustomerID,
        Action<BlocklistCustomersBlockByEmail> blocklistCustomersBlockByEmail
    )
    {
        switch (this.Value)
        {
            case BlocklistCustomersBlockByCustomerID value:
                blocklistCustomersBlockByCustomerID(value);
                break;
            case BlocklistCustomersBlockByEmail value:
                blocklistCustomersBlockByEmail(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of CreateBlockedCustomerRequest"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BlocklistCustomersBlockByCustomerID value) =&gt; {...},
    ///     (BlocklistCustomersBlockByEmail value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BlocklistCustomersBlockByCustomerID, T> blocklistCustomersBlockByCustomerID,
        Func<BlocklistCustomersBlockByEmail, T> blocklistCustomersBlockByEmail
    )
    {
        return this.Value switch
        {
            BlocklistCustomersBlockByCustomerID value => blocklistCustomersBlockByCustomerID(value),
            BlocklistCustomersBlockByEmail value => blocklistCustomersBlockByEmail(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CreateBlockedCustomerRequest"
            ),
        };
    }

    public static implicit operator CreateBlockedCustomerRequest(
        BlocklistCustomersBlockByCustomerID value
    ) => new(value);

    public static implicit operator CreateBlockedCustomerRequest(
        BlocklistCustomersBlockByEmail value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DodoPaymentsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of CreateBlockedCustomerRequest"
            );
        }
        this.Switch(
            (blocklistCustomersBlockByCustomerID) => blocklistCustomersBlockByCustomerID.Validate(),
            (blocklistCustomersBlockByEmail) => blocklistCustomersBlockByEmail.Validate()
        );
    }

    public virtual bool Equals(CreateBlockedCustomerRequest? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BlocklistCustomersBlockByCustomerID _ => 0,
            BlocklistCustomersBlockByEmail _ => 1,
            _ => -1,
        };
    }
}

sealed class CreateBlockedCustomerRequestConverter : JsonConverter<CreateBlockedCustomerRequest>
{
    public override CreateBlockedCustomerRequest? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BlocklistCustomersBlockByCustomerID>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BlocklistCustomersBlockByEmail>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateBlockedCustomerRequest value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        BlocklistCustomersBlockByCustomerID,
        BlocklistCustomersBlockByCustomerIDFromRaw
    >)
)]
public sealed record class BlocklistCustomersBlockByCustomerID : JsonModel
{
    /// <summary>
    /// Customer to block. The block still applies to that customer's email.
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customer_id");
        }
        init { this._rawData.Set("customer_id", value); }
    }

    /// <summary>
    /// Why the merchant blocked this customer. The entry page shows it.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Where a block came from. `Api` marks an API-key caller, which carries no dashboard
    /// actor. The other values name the screen the merchant used.
    /// </summary>
    public ApiEnum<string, BlockedCustomerSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BlockedCustomerSource>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public static implicit operator BlockByCustomerID(
        BlocklistCustomersBlockByCustomerID blocklistCustomersBlockByCustomerID
    ) => new() { CustomerID = blocklistCustomersBlockByCustomerID.CustomerID };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerID;
        _ = this.Reason;
        this.Source?.Validate();
    }

    public BlocklistCustomersBlockByCustomerID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlocklistCustomersBlockByCustomerID(
        BlocklistCustomersBlockByCustomerID blocklistCustomersBlockByCustomerID
    )
        : base(blocklistCustomersBlockByCustomerID) { }
#pragma warning restore CS8618

    public BlocklistCustomersBlockByCustomerID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlocklistCustomersBlockByCustomerID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlocklistCustomersBlockByCustomerIDFromRaw.FromRawUnchecked"/>
    public static BlocklistCustomersBlockByCustomerID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BlocklistCustomersBlockByCustomerID(string customerID)
        : this()
    {
        this.CustomerID = customerID;
    }
}

class BlocklistCustomersBlockByCustomerIDFromRaw : IFromRawJson<BlocklistCustomersBlockByCustomerID>
{
    /// <inheritdoc/>
    public BlocklistCustomersBlockByCustomerID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlocklistCustomersBlockByCustomerID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// Why the merchant blocked this customer. The entry page shows it.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Screen the merchant blocked from. Ignored for an API-key caller, whose entry
    /// always records `api`. A dashboard caller that omits it records `blocklist_page`.
    /// </summary>
    public ApiEnum<string, BlockedCustomerSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BlockedCustomerSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        this.Source?.Validate();
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        BlocklistCustomersBlockByEmail,
        BlocklistCustomersBlockByEmailFromRaw
    >)
)]
public sealed record class BlocklistCustomersBlockByEmail : JsonModel
{
    /// <summary>
    /// Email to block. It must belong to an existing customer of this business.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Why the merchant blocked this customer. The entry page shows it.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Where a block came from. `Api` marks an API-key caller, which carries no dashboard
    /// actor. The other values name the screen the merchant used.
    /// </summary>
    public ApiEnum<string, BlockedCustomerSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BlockedCustomerSource>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public static implicit operator BlockByEmail(
        BlocklistCustomersBlockByEmail blocklistCustomersBlockByEmail
    ) => new() { Email = blocklistCustomersBlockByEmail.Email };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Reason;
        this.Source?.Validate();
    }

    public BlocklistCustomersBlockByEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlocklistCustomersBlockByEmail(
        BlocklistCustomersBlockByEmail blocklistCustomersBlockByEmail
    )
        : base(blocklistCustomersBlockByEmail) { }
#pragma warning restore CS8618

    public BlocklistCustomersBlockByEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlocklistCustomersBlockByEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlocklistCustomersBlockByEmailFromRaw.FromRawUnchecked"/>
    public static BlocklistCustomersBlockByEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BlocklistCustomersBlockByEmail(string email)
        : this()
    {
        this.Email = email;
    }
}

class BlocklistCustomersBlockByEmailFromRaw : IFromRawJson<BlocklistCustomersBlockByEmail>
{
    /// <inheritdoc/>
    public BlocklistCustomersBlockByEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlocklistCustomersBlockByEmail.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        BlocklistCustomersBlockByEmailIntersectionMember1,
        BlocklistCustomersBlockByEmailIntersectionMember1FromRaw
    >)
)]
public sealed record class BlocklistCustomersBlockByEmailIntersectionMember1 : JsonModel
{
    /// <summary>
    /// Why the merchant blocked this customer. The entry page shows it.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Screen the merchant blocked from. Ignored for an API-key caller, whose entry
    /// always records `api`. A dashboard caller that omits it records `blocklist_page`.
    /// </summary>
    public ApiEnum<string, BlockedCustomerSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BlockedCustomerSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        this.Source?.Validate();
    }

    public BlocklistCustomersBlockByEmailIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlocklistCustomersBlockByEmailIntersectionMember1(
        BlocklistCustomersBlockByEmailIntersectionMember1 blocklistCustomersBlockByEmailIntersectionMember1
    )
        : base(blocklistCustomersBlockByEmailIntersectionMember1) { }
#pragma warning restore CS8618

    public BlocklistCustomersBlockByEmailIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlocklistCustomersBlockByEmailIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlocklistCustomersBlockByEmailIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static BlocklistCustomersBlockByEmailIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlocklistCustomersBlockByEmailIntersectionMember1FromRaw
    : IFromRawJson<BlocklistCustomersBlockByEmailIntersectionMember1>
{
    /// <inheritdoc/>
    public BlocklistCustomersBlockByEmailIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BlocklistCustomersBlockByEmailIntersectionMember1.FromRawUnchecked(rawData);
}
