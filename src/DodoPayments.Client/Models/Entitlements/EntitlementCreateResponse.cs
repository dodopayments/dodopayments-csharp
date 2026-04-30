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
    typeof(JsonModelConverter<EntitlementCreateResponse, EntitlementCreateResponseFromRaw>)
)]
public sealed record class EntitlementCreateResponse : JsonModel
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
    public required EntitlementCreateResponseIntegrationConfig IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementCreateResponseIntegrationConfig>(
                "integration_config"
            );
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, EntitlementCreateResponseIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementCreateResponseIntegrationType>
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

    public EntitlementCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponse(EntitlementCreateResponse entitlementCreateResponse)
        : base(entitlementCreateResponse) { }
#pragma warning restore CS8618

    public EntitlementCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreateResponseFromRaw : IFromRawJson<EntitlementCreateResponse>
{
    /// <inheritdoc/>
    public EntitlementCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
/// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
/// object (resolved download URLs etc.).  The persisted JSONB stays ID-only via [`IntegrationConfig`];
/// this enum is response-only.
/// </summary>
[JsonConverter(typeof(EntitlementCreateResponseIntegrationConfigConverter))]
public record class EntitlementCreateResponseIntegrationConfig : ModelBase
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

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseIntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigGitHubConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigDiscordConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigTelegramConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigFigmaConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigFramerConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigNotionConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigDigitalFilesConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseIntegrationConfigLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseIntegrationConfigLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey(
        [NotNullWhen(true)] out EntitlementCreateResponseIntegrationConfigLicenseKeyConfig? value
    )
    {
        value = this.Value as EntitlementCreateResponseIntegrationConfigLicenseKeyConfig;
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
    ///     (EntitlementCreateResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<EntitlementCreateResponseIntegrationConfigGitHubConfig> github,
        Action<EntitlementCreateResponseIntegrationConfigDiscordConfig> discord,
        Action<EntitlementCreateResponseIntegrationConfigTelegramConfig> telegram,
        Action<EntitlementCreateResponseIntegrationConfigFigmaConfig> figma,
        Action<EntitlementCreateResponseIntegrationConfigFramerConfig> framer,
        Action<EntitlementCreateResponseIntegrationConfigNotionConfig> notion,
        Action<EntitlementCreateResponseIntegrationConfigDigitalFilesConfig> digitalFiles,
        Action<EntitlementCreateResponseIntegrationConfigLicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case EntitlementCreateResponseIntegrationConfigGitHubConfig value:
                github(value);
                break;
            case EntitlementCreateResponseIntegrationConfigDiscordConfig value:
                discord(value);
                break;
            case EntitlementCreateResponseIntegrationConfigTelegramConfig value:
                telegram(value);
                break;
            case EntitlementCreateResponseIntegrationConfigFigmaConfig value:
                figma(value);
                break;
            case EntitlementCreateResponseIntegrationConfigFramerConfig value:
                framer(value);
                break;
            case EntitlementCreateResponseIntegrationConfigNotionConfig value:
                notion(value);
                break;
            case EntitlementCreateResponseIntegrationConfigDigitalFilesConfig value:
                digitalFiles(value);
                break;
            case EntitlementCreateResponseIntegrationConfigLicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of EntitlementCreateResponseIntegrationConfig"
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
    ///     (EntitlementCreateResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementCreateResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<EntitlementCreateResponseIntegrationConfigGitHubConfig, T> github,
        Func<EntitlementCreateResponseIntegrationConfigDiscordConfig, T> discord,
        Func<EntitlementCreateResponseIntegrationConfigTelegramConfig, T> telegram,
        Func<EntitlementCreateResponseIntegrationConfigFigmaConfig, T> figma,
        Func<EntitlementCreateResponseIntegrationConfigFramerConfig, T> framer,
        Func<EntitlementCreateResponseIntegrationConfigNotionConfig, T> notion,
        Func<EntitlementCreateResponseIntegrationConfigDigitalFilesConfig, T> digitalFiles,
        Func<EntitlementCreateResponseIntegrationConfigLicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            EntitlementCreateResponseIntegrationConfigGitHubConfig value => github(value),
            EntitlementCreateResponseIntegrationConfigDiscordConfig value => discord(value),
            EntitlementCreateResponseIntegrationConfigTelegramConfig value => telegram(value),
            EntitlementCreateResponseIntegrationConfigFigmaConfig value => figma(value),
            EntitlementCreateResponseIntegrationConfigFramerConfig value => framer(value),
            EntitlementCreateResponseIntegrationConfigNotionConfig value => notion(value),
            EntitlementCreateResponseIntegrationConfigDigitalFilesConfig value => digitalFiles(
                value
            ),
            EntitlementCreateResponseIntegrationConfigLicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of EntitlementCreateResponseIntegrationConfig"
            ),
        };
    }

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigGitHubConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigDiscordConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigTelegramConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigFigmaConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigFramerConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigNotionConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigDigitalFilesConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseIntegrationConfig(
        EntitlementCreateResponseIntegrationConfigLicenseKeyConfig value
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
                "Data did not match any variant of EntitlementCreateResponseIntegrationConfig"
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

    public virtual bool Equals(EntitlementCreateResponseIntegrationConfig? other) =>
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
            EntitlementCreateResponseIntegrationConfigGitHubConfig _ => 0,
            EntitlementCreateResponseIntegrationConfigDiscordConfig _ => 1,
            EntitlementCreateResponseIntegrationConfigTelegramConfig _ => 2,
            EntitlementCreateResponseIntegrationConfigFigmaConfig _ => 3,
            EntitlementCreateResponseIntegrationConfigFramerConfig _ => 4,
            EntitlementCreateResponseIntegrationConfigNotionConfig _ => 5,
            EntitlementCreateResponseIntegrationConfigDigitalFilesConfig _ => 6,
            EntitlementCreateResponseIntegrationConfigLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class EntitlementCreateResponseIntegrationConfigConverter
    : JsonConverter<EntitlementCreateResponseIntegrationConfig>
{
    public override EntitlementCreateResponseIntegrationConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigGitHubConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigDiscordConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigTelegramConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigFigmaConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigFramerConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigNotionConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigDigitalFilesConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigLicenseKeyConfig>(
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
        EntitlementCreateResponseIntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigGitHubConfig,
        EntitlementCreateResponseIntegrationConfigGitHubConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigGitHubConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigGitHubConfig(
        EntitlementCreateResponseIntegrationConfigGitHubConfig entitlementCreateResponseIntegrationConfigGitHubConfig
    )
        : base(entitlementCreateResponseIntegrationConfigGitHubConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigGitHubConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigGitHubConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigGitHubConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreateResponseIntegrationConfigGitHubConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigGitHubConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigDiscordConfig,
        EntitlementCreateResponseIntegrationConfigDiscordConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigDiscordConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigDiscordConfig(
        EntitlementCreateResponseIntegrationConfigDiscordConfig entitlementCreateResponseIntegrationConfigDiscordConfig
    )
        : base(entitlementCreateResponseIntegrationConfigDiscordConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigDiscordConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigDiscordConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigDiscordConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class EntitlementCreateResponseIntegrationConfigDiscordConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigDiscordConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigTelegramConfig,
        EntitlementCreateResponseIntegrationConfigTelegramConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigTelegramConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigTelegramConfig(
        EntitlementCreateResponseIntegrationConfigTelegramConfig entitlementCreateResponseIntegrationConfigTelegramConfig
    )
        : base(entitlementCreateResponseIntegrationConfigTelegramConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigTelegramConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigTelegramConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigTelegramConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class EntitlementCreateResponseIntegrationConfigTelegramConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigTelegramConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigFigmaConfig,
        EntitlementCreateResponseIntegrationConfigFigmaConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigFigmaConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigFigmaConfig(
        EntitlementCreateResponseIntegrationConfigFigmaConfig entitlementCreateResponseIntegrationConfigFigmaConfig
    )
        : base(entitlementCreateResponseIntegrationConfigFigmaConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigFigmaConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigFigmaConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigFigmaConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class EntitlementCreateResponseIntegrationConfigFigmaConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigFigmaConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigFramerConfig,
        EntitlementCreateResponseIntegrationConfigFramerConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigFramerConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigFramerConfig(
        EntitlementCreateResponseIntegrationConfigFramerConfig entitlementCreateResponseIntegrationConfigFramerConfig
    )
        : base(entitlementCreateResponseIntegrationConfigFramerConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigFramerConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigFramerConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigFramerConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class EntitlementCreateResponseIntegrationConfigFramerConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigFramerConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigNotionConfig,
        EntitlementCreateResponseIntegrationConfigNotionConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigNotionConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigNotionConfig(
        EntitlementCreateResponseIntegrationConfigNotionConfig entitlementCreateResponseIntegrationConfigNotionConfig
    )
        : base(entitlementCreateResponseIntegrationConfigNotionConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigNotionConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigNotionConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigNotionConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class EntitlementCreateResponseIntegrationConfigNotionConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigNotionConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigDigitalFilesConfig,
        EntitlementCreateResponseIntegrationConfigDigitalFilesConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigDigitalFilesConfig : JsonModel
{
    /// <summary>
    /// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
    /// but is sourced from an entitlement's `integration_config` (not a grant) and
    /// tags each file with its origin (`legacy` vs `ee`).
    /// </summary>
    public required DigitalFiles DigitalFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DigitalFiles>("digital_files");
        }
        init { this._rawData.Set("digital_files", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DigitalFiles.Validate();
    }

    public EntitlementCreateResponseIntegrationConfigDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigDigitalFilesConfig(
        EntitlementCreateResponseIntegrationConfigDigitalFilesConfig entitlementCreateResponseIntegrationConfigDigitalFilesConfig
    )
        : base(entitlementCreateResponseIntegrationConfigDigitalFilesConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigDigitalFilesConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigDigitalFilesConfig(DigitalFiles digitalFiles)
        : this()
    {
        this.DigitalFiles = digitalFiles;
    }
}

class EntitlementCreateResponseIntegrationConfigDigitalFilesConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigDigitalFilesConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigDigitalFilesConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
/// but is sourced from an entitlement's `integration_config` (not a grant) and tags
/// each file with its origin (`legacy` vs `ee`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalFiles, DigitalFilesFromRaw>))]
public sealed record class DigitalFiles : JsonModel
{
    public required IReadOnlyList<File> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
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

    public DigitalFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalFiles(DigitalFiles digitalFiles)
        : base(digitalFiles) { }
#pragma warning restore CS8618

    public DigitalFiles(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalFiles(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalFilesFromRaw.FromRawUnchecked"/>
    public static DigitalFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalFiles(IReadOnlyList<File> files)
        : this()
    {
        this.Files = files;
    }
}

class DigitalFilesFromRaw : IFromRawJson<DigitalFiles>
{
    /// <inheritdoc/>
    public DigitalFiles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalFiles.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
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

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public File(File file)
        : base(file) { }
#pragma warning restore CS8618

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseIntegrationConfigLicenseKeyConfig,
        EntitlementCreateResponseIntegrationConfigLicenseKeyConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseIntegrationConfigLicenseKeyConfig : JsonModel
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

    public EntitlementCreateResponseIntegrationConfigLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseIntegrationConfigLicenseKeyConfig(
        EntitlementCreateResponseIntegrationConfigLicenseKeyConfig entitlementCreateResponseIntegrationConfigLicenseKeyConfig
    )
        : base(entitlementCreateResponseIntegrationConfigLicenseKeyConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseIntegrationConfigLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseIntegrationConfigLicenseKeyConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseIntegrationConfigLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreateResponseIntegrationConfigLicenseKeyConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseIntegrationConfigLicenseKeyConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseIntegrationConfigLicenseKeyConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementCreateResponseIntegrationTypeConverter))]
public enum EntitlementCreateResponseIntegrationType
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

sealed class EntitlementCreateResponseIntegrationTypeConverter
    : JsonConverter<EntitlementCreateResponseIntegrationType>
{
    public override EntitlementCreateResponseIntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => EntitlementCreateResponseIntegrationType.Discord,
            "telegram" => EntitlementCreateResponseIntegrationType.Telegram,
            "github" => EntitlementCreateResponseIntegrationType.GitHub,
            "figma" => EntitlementCreateResponseIntegrationType.Figma,
            "framer" => EntitlementCreateResponseIntegrationType.Framer,
            "notion" => EntitlementCreateResponseIntegrationType.Notion,
            "digital_files" => EntitlementCreateResponseIntegrationType.DigitalFiles,
            "license_key" => EntitlementCreateResponseIntegrationType.LicenseKey,
            _ => (EntitlementCreateResponseIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseIntegrationType.Discord => "discord",
                EntitlementCreateResponseIntegrationType.Telegram => "telegram",
                EntitlementCreateResponseIntegrationType.GitHub => "github",
                EntitlementCreateResponseIntegrationType.Figma => "figma",
                EntitlementCreateResponseIntegrationType.Framer => "framer",
                EntitlementCreateResponseIntegrationType.Notion => "notion",
                EntitlementCreateResponseIntegrationType.DigitalFiles => "digital_files",
                EntitlementCreateResponseIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
