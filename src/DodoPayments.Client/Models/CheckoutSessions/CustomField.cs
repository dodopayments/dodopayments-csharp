using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.CheckoutSessions;

/// <summary>
/// Definition of a custom field for checkout
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomField, CustomFieldFromRaw>))]
public sealed record class CustomField : JsonModel
{
    /// <summary>
    /// Type of field determining validation rules
    /// </summary>
    public required ApiEnum<string, FieldType> FieldType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FieldType>>("field_type");
        }
        init { this._rawData.Set("field_type", value); }
    }

    /// <summary>
    /// Unique identifier for this field (used as key in responses)
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// Display label shown to customer
    /// </summary>
    public required string Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Options for dropdown type (required for dropdown, ignored for others)
    /// </summary>
    public IReadOnlyList<string>? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Placeholder text for the input
    /// </summary>
    public string? Placeholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("placeholder");
        }
        init { this._rawData.Set("placeholder", value); }
    }

    /// <summary>
    /// Whether this field is required
    /// </summary>
    public bool? Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("required");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("required", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType.Validate();
        _ = this.Key;
        _ = this.Label;
        _ = this.Options;
        _ = this.Placeholder;
        _ = this.Required;
    }

    public CustomField() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomField(CustomField customField)
        : base(customField) { }
#pragma warning restore CS8618

    public CustomField(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomField(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomFieldFromRaw.FromRawUnchecked"/>
    public static CustomField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomFieldFromRaw : IFromRawJson<CustomField>
{
    /// <inheritdoc/>
    public CustomField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomField.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of field determining validation rules
/// </summary>
[JsonConverter(typeof(FieldTypeConverter))]
public enum FieldType
{
    Text,
    Number,
    Email,
    Url,
    Date,
    Dropdown,
    Boolean,
}

sealed class FieldTypeConverter : JsonConverter<FieldType>
{
    public override FieldType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FieldType.Text,
            "number" => FieldType.Number,
            "email" => FieldType.Email,
            "url" => FieldType.Url,
            "date" => FieldType.Date,
            "dropdown" => FieldType.Dropdown,
            "boolean" => FieldType.Boolean,
            _ => (FieldType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FieldType.Text => "text",
                FieldType.Number => "number",
                FieldType.Email => "email",
                FieldType.Url => "url",
                FieldType.Date => "date",
                FieldType.Dropdown => "dropdown",
                FieldType.Boolean => "boolean",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
