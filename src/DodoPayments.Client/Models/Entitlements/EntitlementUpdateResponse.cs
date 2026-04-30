using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Entitlements;

[JsonConverter(
    typeof(JsonModelConverter<EntitlementUpdateResponse, EntitlementUpdateResponseFromRaw>)
)]
public sealed record class EntitlementUpdateResponse : JsonModel
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

    public required string BusinessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("business_id");
        }
        init { this._rawData.Set("business_id", value); }
    }

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
    /// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
    /// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
    /// object (resolved download URLs etc.).  The persisted JSONB stays ID-only
    /// via [`IntegrationConfig`]; this enum is response-only.
    /// </summary>
    public required EntitlementUpdateResponseIntegrationConfig IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementUpdateResponseIntegrationConfig>(
                "integration_config"
            );
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, EntitlementUpdateResponseIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementUpdateResponseIntegrationType>
            >("integration_type");
        }
        init { this._rawData.Set("integration_type", value); }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_active");
        }
        init { this._rawData.Set("is_active", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BusinessID;
        _ = this.CreatedAt;
        this.IntegrationConfig.Validate();
        this.IntegrationType.Validate();
        _ = this.IsActive;
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.Metadata;
    }

    public EntitlementUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponse(EntitlementUpdateResponse entitlementUpdateResponse)
        : base(entitlementUpdateResponse) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateResponseFromRaw : IFromRawJson<EntitlementUpdateResponse>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
/// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
/// object (resolved download URLs etc.).  The persisted JSONB stays ID-only via [`IntegrationConfig`];
/// this enum is response-only.
/// </summary>
[JsonConverter(typeof(EntitlementUpdateResponseIntegrationConfigConverter))]
public record class EntitlementUpdateResponseIntegrationConfig : ModelBase
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

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateResponseIntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigGitHubConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigDiscordConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigTelegramConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigFigmaConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigFramerConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigNotionConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey(
        [NotNullWhen(true)] out EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig? value
    )
    {
        value = this.Value as EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig;
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
    ///     (EntitlementUpdateResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<EntitlementUpdateResponseIntegrationConfigGitHubConfig> github,
        Action<EntitlementUpdateResponseIntegrationConfigDiscordConfig> discord,
        Action<EntitlementUpdateResponseIntegrationConfigTelegramConfig> telegram,
        Action<EntitlementUpdateResponseIntegrationConfigFigmaConfig> figma,
        Action<EntitlementUpdateResponseIntegrationConfigFramerConfig> framer,
        Action<EntitlementUpdateResponseIntegrationConfigNotionConfig> notion,
        Action<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig> digitalFiles,
        Action<EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case EntitlementUpdateResponseIntegrationConfigGitHubConfig value:
                github(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigDiscordConfig value:
                discord(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigTelegramConfig value:
                telegram(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigFigmaConfig value:
                figma(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigFramerConfig value:
                framer(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigNotionConfig value:
                notion(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig value:
                digitalFiles(value);
                break;
            case EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of EntitlementUpdateResponseIntegrationConfig"
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
    ///     (EntitlementUpdateResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<EntitlementUpdateResponseIntegrationConfigGitHubConfig, T> github,
        Func<EntitlementUpdateResponseIntegrationConfigDiscordConfig, T> discord,
        Func<EntitlementUpdateResponseIntegrationConfigTelegramConfig, T> telegram,
        Func<EntitlementUpdateResponseIntegrationConfigFigmaConfig, T> figma,
        Func<EntitlementUpdateResponseIntegrationConfigFramerConfig, T> framer,
        Func<EntitlementUpdateResponseIntegrationConfigNotionConfig, T> notion,
        Func<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig, T> digitalFiles,
        Func<EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            EntitlementUpdateResponseIntegrationConfigGitHubConfig value => github(value),
            EntitlementUpdateResponseIntegrationConfigDiscordConfig value => discord(value),
            EntitlementUpdateResponseIntegrationConfigTelegramConfig value => telegram(value),
            EntitlementUpdateResponseIntegrationConfigFigmaConfig value => figma(value),
            EntitlementUpdateResponseIntegrationConfigFramerConfig value => framer(value),
            EntitlementUpdateResponseIntegrationConfigNotionConfig value => notion(value),
            EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig value => digitalFiles(
                value
            ),
            EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of EntitlementUpdateResponseIntegrationConfig"
            ),
        };
    }

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigGitHubConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigDiscordConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigTelegramConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigFigmaConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigFramerConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigNotionConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateResponseIntegrationConfig(
        EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig value
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
                "Data did not match any variant of EntitlementUpdateResponseIntegrationConfig"
            );
        }
        this.Switch(
            (github) => github.Validate(),
            (discord) => discord.Validate(),
            (telegram) => telegram.Validate(),
            (figma) => figma.Validate(),
            (framer) => framer.Validate(),
            (notion) => notion.Validate(),
            (digitalFiles) => digitalFiles.Validate(),
            (licenseKey) => licenseKey.Validate()
        );
    }

    public virtual bool Equals(EntitlementUpdateResponseIntegrationConfig? other) =>
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
            EntitlementUpdateResponseIntegrationConfigGitHubConfig _ => 0,
            EntitlementUpdateResponseIntegrationConfigDiscordConfig _ => 1,
            EntitlementUpdateResponseIntegrationConfigTelegramConfig _ => 2,
            EntitlementUpdateResponseIntegrationConfigFigmaConfig _ => 3,
            EntitlementUpdateResponseIntegrationConfigFramerConfig _ => 4,
            EntitlementUpdateResponseIntegrationConfigNotionConfig _ => 5,
            EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig _ => 6,
            EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class EntitlementUpdateResponseIntegrationConfigConverter
    : JsonConverter<EntitlementUpdateResponseIntegrationConfig>
{
    public override EntitlementUpdateResponseIntegrationConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigGitHubConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigDiscordConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigTelegramConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigFigmaConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigFramerConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigNotionConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig>(
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
        EntitlementUpdateResponseIntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigGitHubConfig,
        EntitlementUpdateResponseIntegrationConfigGitHubConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigGitHubConfig : JsonModel
{
    public required string Permission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("permission");
        }
        init { this._rawData.Set("permission", value); }
    }

    public required string TargetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target_id");
        }
        init { this._rawData.Set("target_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Permission;
        _ = this.TargetID;
    }

    public EntitlementUpdateResponseIntegrationConfigGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigGitHubConfig(
        EntitlementUpdateResponseIntegrationConfigGitHubConfig entitlementUpdateResponseIntegrationConfigGitHubConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigGitHubConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigGitHubConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigGitHubConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigGitHubConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateResponseIntegrationConfigGitHubConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigGitHubConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigDiscordConfig,
        EntitlementUpdateResponseIntegrationConfigDiscordConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigDiscordConfig : JsonModel
{
    public required string GuildID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("guild_id");
        }
        init { this._rawData.Set("guild_id", value); }
    }

    public string? RoleID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role_id");
        }
        init { this._rawData.Set("role_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GuildID;
        _ = this.RoleID;
    }

    public EntitlementUpdateResponseIntegrationConfigDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDiscordConfig(
        EntitlementUpdateResponseIntegrationConfigDiscordConfig entitlementUpdateResponseIntegrationConfigDiscordConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigDiscordConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigDiscordConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigDiscordConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigDiscordConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class EntitlementUpdateResponseIntegrationConfigDiscordConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigDiscordConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigTelegramConfig,
        EntitlementUpdateResponseIntegrationConfigTelegramConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigTelegramConfig : JsonModel
{
    public required string ChatID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chat_id");
        }
        init { this._rawData.Set("chat_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChatID;
    }

    public EntitlementUpdateResponseIntegrationConfigTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigTelegramConfig(
        EntitlementUpdateResponseIntegrationConfigTelegramConfig entitlementUpdateResponseIntegrationConfigTelegramConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigTelegramConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigTelegramConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigTelegramConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigTelegramConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class EntitlementUpdateResponseIntegrationConfigTelegramConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigTelegramConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigFigmaConfig,
        EntitlementUpdateResponseIntegrationConfigFigmaConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigFigmaConfig : JsonModel
{
    public required string FigmaFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("figma_file_id");
        }
        init { this._rawData.Set("figma_file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FigmaFileID;
    }

    public EntitlementUpdateResponseIntegrationConfigFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigFigmaConfig(
        EntitlementUpdateResponseIntegrationConfigFigmaConfig entitlementUpdateResponseIntegrationConfigFigmaConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigFigmaConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigFigmaConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigFigmaConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigFigmaConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class EntitlementUpdateResponseIntegrationConfigFigmaConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigFigmaConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigFramerConfig,
        EntitlementUpdateResponseIntegrationConfigFramerConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigFramerConfig : JsonModel
{
    public required string FramerTemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("framer_template_id");
        }
        init { this._rawData.Set("framer_template_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FramerTemplateID;
    }

    public EntitlementUpdateResponseIntegrationConfigFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigFramerConfig(
        EntitlementUpdateResponseIntegrationConfigFramerConfig entitlementUpdateResponseIntegrationConfigFramerConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigFramerConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigFramerConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigFramerConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigFramerConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class EntitlementUpdateResponseIntegrationConfigFramerConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigFramerConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigNotionConfig,
        EntitlementUpdateResponseIntegrationConfigNotionConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigNotionConfig : JsonModel
{
    public required string NotionTemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("notion_template_id");
        }
        init { this._rawData.Set("notion_template_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NotionTemplateID;
    }

    public EntitlementUpdateResponseIntegrationConfigNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigNotionConfig(
        EntitlementUpdateResponseIntegrationConfigNotionConfig entitlementUpdateResponseIntegrationConfigNotionConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigNotionConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigNotionConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigNotionConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigNotionConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class EntitlementUpdateResponseIntegrationConfigNotionConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigNotionConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig,
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig : JsonModel
{
    /// <summary>
    /// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
    /// but is sourced from an entitlement's `integration_config` (not a grant) and
    /// tags each file with its origin (`legacy` vs `ee`).
    /// </summary>
    public required EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles DigitalFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
                "digital_files"
            );
        }
        init { this._rawData.Set("digital_files", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DigitalFiles.Validate();
    }

    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig(
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig entitlementUpdateResponseIntegrationConfigDigitalFilesConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigDigitalFilesConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig(
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles digitalFiles
    )
        : this()
    {
        this.DigitalFiles = digitalFiles;
    }
}

class EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigDigitalFilesConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
/// but is sourced from an entitlement's `integration_config` (not a grant) and tags
/// each file with its origin (`legacy` vs `ee`).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles,
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles
    : JsonModel
{
    public required IReadOnlyList<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
            >("files");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
            >("files", ImmutableArray.ToImmutableArray(value));
        }
    }

    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Files)
        {
            item.Validate();
        }
        _ = this.ExternalUrl;
        _ = this.Instructions;
    }

    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles entitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles
    )
        : base(entitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        IReadOnlyList<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> files
    )
        : this()
    {
        this.Files = files;
    }
}

class EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFiles.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile,
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
    : JsonModel
{
    public required string DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("download_url");
        }
        init { this._rawData.Set("download_url", value); }
    }

    /// <summary>
    /// Seconds until `download_url` expires.
    /// </summary>
    public required long ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expires_in");
        }
        init { this._rawData.Set("expires_in", value); }
    }

    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// `"legacy"` for files in `product_files`, `"ee"` for files managed by the Entitlements Engine.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    public long? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_size");
        }
        init { this._rawData.Set("file_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadUrl;
        _ = this.ExpiresIn;
        _ = this.FileID;
        _ = this.Filename;
        _ = this.Source;
        _ = this.ContentType;
        _ = this.FileSize;
    }

    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile entitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
    )
        : base(entitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementUpdateResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig,
        EntitlementUpdateResponseIntegrationConfigLicenseKeyConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig : JsonModel
{
    public string? ActivationMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("activation_message");
        }
        init { this._rawData.Set("activation_message", value); }
    }

    public int? ActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawData.Set("activations_limit", value); }
    }

    public int? DurationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_count");
        }
        init { this._rawData.Set("duration_count", value); }
    }

    public ApiEnum<string, Subscriptions::TimeInterval>? DurationInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Subscriptions::TimeInterval>>(
                "duration_interval"
            );
        }
        init { this._rawData.Set("duration_interval", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActivationMessage;
        _ = this.ActivationsLimit;
        _ = this.DurationCount;
        this.DurationInterval?.Validate();
    }

    public EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig(
        EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig entitlementUpdateResponseIntegrationConfigLicenseKeyConfig
    )
        : base(entitlementUpdateResponseIntegrationConfigLicenseKeyConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateResponseIntegrationConfigLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateResponseIntegrationConfigLicenseKeyConfigFromRaw
    : IFromRawJson<EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateResponseIntegrationConfigLicenseKeyConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementUpdateResponseIntegrationTypeConverter))]
public enum EntitlementUpdateResponseIntegrationType
{
    Discord,
    Telegram,
    GitHub,
    Figma,
    Framer,
    Notion,
    DigitalFiles,
    LicenseKey,
}

sealed class EntitlementUpdateResponseIntegrationTypeConverter
    : JsonConverter<EntitlementUpdateResponseIntegrationType>
{
    public override EntitlementUpdateResponseIntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => EntitlementUpdateResponseIntegrationType.Discord,
            "telegram" => EntitlementUpdateResponseIntegrationType.Telegram,
            "github" => EntitlementUpdateResponseIntegrationType.GitHub,
            "figma" => EntitlementUpdateResponseIntegrationType.Figma,
            "framer" => EntitlementUpdateResponseIntegrationType.Framer,
            "notion" => EntitlementUpdateResponseIntegrationType.Notion,
            "digital_files" => EntitlementUpdateResponseIntegrationType.DigitalFiles,
            "license_key" => EntitlementUpdateResponseIntegrationType.LicenseKey,
            _ => (EntitlementUpdateResponseIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateResponseIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateResponseIntegrationType.Discord => "discord",
                EntitlementUpdateResponseIntegrationType.Telegram => "telegram",
                EntitlementUpdateResponseIntegrationType.GitHub => "github",
                EntitlementUpdateResponseIntegrationType.Figma => "figma",
                EntitlementUpdateResponseIntegrationType.Framer => "framer",
                EntitlementUpdateResponseIntegrationType.Notion => "notion",
                EntitlementUpdateResponseIntegrationType.DigitalFiles => "digital_files",
                EntitlementUpdateResponseIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
