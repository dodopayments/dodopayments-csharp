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

[JsonConverter(typeof(JsonModelConverter<EntitlementListResponse, EntitlementListResponseFromRaw>))]
public sealed record class EntitlementListResponse : JsonModel
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
    public required EntitlementListResponseIntegrationConfig IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementListResponseIntegrationConfig>(
                "integration_config"
            );
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, EntitlementListResponseIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementListResponseIntegrationType>
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

    public EntitlementListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponse(EntitlementListResponse entitlementListResponse)
        : base(entitlementListResponse) { }
#pragma warning restore CS8618

    public EntitlementListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseFromRaw : IFromRawJson<EntitlementListResponse>
{
    /// <inheritdoc/>
    public EntitlementListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
/// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
/// object (resolved download URLs etc.).  The persisted JSONB stays ID-only via [`IntegrationConfig`];
/// this enum is response-only.
/// </summary>
[JsonConverter(typeof(EntitlementListResponseIntegrationConfigConverter))]
public record class EntitlementListResponseIntegrationConfig : ModelBase
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

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseIntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigGitHubConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigDiscordConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigTelegramConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigFigmaConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigFramerConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigNotionConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigDigitalFilesConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseIntegrationConfigLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `EntitlementListResponseIntegrationConfigLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey(
        [NotNullWhen(true)] out EntitlementListResponseIntegrationConfigLicenseKeyConfig? value
    )
    {
        value = this.Value as EntitlementListResponseIntegrationConfigLicenseKeyConfig;
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
    ///     (EntitlementListResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<EntitlementListResponseIntegrationConfigGitHubConfig> github,
        Action<EntitlementListResponseIntegrationConfigDiscordConfig> discord,
        Action<EntitlementListResponseIntegrationConfigTelegramConfig> telegram,
        Action<EntitlementListResponseIntegrationConfigFigmaConfig> figma,
        Action<EntitlementListResponseIntegrationConfigFramerConfig> framer,
        Action<EntitlementListResponseIntegrationConfigNotionConfig> notion,
        Action<EntitlementListResponseIntegrationConfigDigitalFilesConfig> digitalFiles,
        Action<EntitlementListResponseIntegrationConfigLicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case EntitlementListResponseIntegrationConfigGitHubConfig value:
                github(value);
                break;
            case EntitlementListResponseIntegrationConfigDiscordConfig value:
                discord(value);
                break;
            case EntitlementListResponseIntegrationConfigTelegramConfig value:
                telegram(value);
                break;
            case EntitlementListResponseIntegrationConfigFigmaConfig value:
                figma(value);
                break;
            case EntitlementListResponseIntegrationConfigFramerConfig value:
                framer(value);
                break;
            case EntitlementListResponseIntegrationConfigNotionConfig value:
                notion(value);
                break;
            case EntitlementListResponseIntegrationConfigDigitalFilesConfig value:
                digitalFiles(value);
                break;
            case EntitlementListResponseIntegrationConfigLicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of EntitlementListResponseIntegrationConfig"
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
    ///     (EntitlementListResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementListResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<EntitlementListResponseIntegrationConfigGitHubConfig, T> github,
        Func<EntitlementListResponseIntegrationConfigDiscordConfig, T> discord,
        Func<EntitlementListResponseIntegrationConfigTelegramConfig, T> telegram,
        Func<EntitlementListResponseIntegrationConfigFigmaConfig, T> figma,
        Func<EntitlementListResponseIntegrationConfigFramerConfig, T> framer,
        Func<EntitlementListResponseIntegrationConfigNotionConfig, T> notion,
        Func<EntitlementListResponseIntegrationConfigDigitalFilesConfig, T> digitalFiles,
        Func<EntitlementListResponseIntegrationConfigLicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            EntitlementListResponseIntegrationConfigGitHubConfig value => github(value),
            EntitlementListResponseIntegrationConfigDiscordConfig value => discord(value),
            EntitlementListResponseIntegrationConfigTelegramConfig value => telegram(value),
            EntitlementListResponseIntegrationConfigFigmaConfig value => figma(value),
            EntitlementListResponseIntegrationConfigFramerConfig value => framer(value),
            EntitlementListResponseIntegrationConfigNotionConfig value => notion(value),
            EntitlementListResponseIntegrationConfigDigitalFilesConfig value => digitalFiles(value),
            EntitlementListResponseIntegrationConfigLicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of EntitlementListResponseIntegrationConfig"
            ),
        };
    }

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigGitHubConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigDiscordConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigTelegramConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigFigmaConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigFramerConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigNotionConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigDigitalFilesConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseIntegrationConfig(
        EntitlementListResponseIntegrationConfigLicenseKeyConfig value
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
                "Data did not match any variant of EntitlementListResponseIntegrationConfig"
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

    public virtual bool Equals(EntitlementListResponseIntegrationConfig? other) =>
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
            EntitlementListResponseIntegrationConfigGitHubConfig _ => 0,
            EntitlementListResponseIntegrationConfigDiscordConfig _ => 1,
            EntitlementListResponseIntegrationConfigTelegramConfig _ => 2,
            EntitlementListResponseIntegrationConfigFigmaConfig _ => 3,
            EntitlementListResponseIntegrationConfigFramerConfig _ => 4,
            EntitlementListResponseIntegrationConfigNotionConfig _ => 5,
            EntitlementListResponseIntegrationConfigDigitalFilesConfig _ => 6,
            EntitlementListResponseIntegrationConfigLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class EntitlementListResponseIntegrationConfigConverter
    : JsonConverter<EntitlementListResponseIntegrationConfig>
{
    public override EntitlementListResponseIntegrationConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigGitHubConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDiscordConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigTelegramConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigFigmaConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigFramerConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigNotionConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigLicenseKeyConfig>(
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
        EntitlementListResponseIntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigGitHubConfig,
        EntitlementListResponseIntegrationConfigGitHubConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigGitHubConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigGitHubConfig(
        EntitlementListResponseIntegrationConfigGitHubConfig entitlementListResponseIntegrationConfigGitHubConfig
    )
        : base(entitlementListResponseIntegrationConfigGitHubConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigGitHubConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigGitHubConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigGitHubConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseIntegrationConfigGitHubConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigGitHubConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigDiscordConfig,
        EntitlementListResponseIntegrationConfigDiscordConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigDiscordConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDiscordConfig(
        EntitlementListResponseIntegrationConfigDiscordConfig entitlementListResponseIntegrationConfigDiscordConfig
    )
        : base(entitlementListResponseIntegrationConfigDiscordConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigDiscordConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigDiscordConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigDiscordConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class EntitlementListResponseIntegrationConfigDiscordConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigDiscordConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigTelegramConfig,
        EntitlementListResponseIntegrationConfigTelegramConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigTelegramConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigTelegramConfig(
        EntitlementListResponseIntegrationConfigTelegramConfig entitlementListResponseIntegrationConfigTelegramConfig
    )
        : base(entitlementListResponseIntegrationConfigTelegramConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigTelegramConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigTelegramConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigTelegramConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class EntitlementListResponseIntegrationConfigTelegramConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigTelegramConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigFigmaConfig,
        EntitlementListResponseIntegrationConfigFigmaConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigFigmaConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigFigmaConfig(
        EntitlementListResponseIntegrationConfigFigmaConfig entitlementListResponseIntegrationConfigFigmaConfig
    )
        : base(entitlementListResponseIntegrationConfigFigmaConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigFigmaConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigFigmaConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigFigmaConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class EntitlementListResponseIntegrationConfigFigmaConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigFigmaConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigFramerConfig,
        EntitlementListResponseIntegrationConfigFramerConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigFramerConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigFramerConfig(
        EntitlementListResponseIntegrationConfigFramerConfig entitlementListResponseIntegrationConfigFramerConfig
    )
        : base(entitlementListResponseIntegrationConfigFramerConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigFramerConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigFramerConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigFramerConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class EntitlementListResponseIntegrationConfigFramerConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigFramerConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigNotionConfig,
        EntitlementListResponseIntegrationConfigNotionConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigNotionConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigNotionConfig(
        EntitlementListResponseIntegrationConfigNotionConfig entitlementListResponseIntegrationConfigNotionConfig
    )
        : base(entitlementListResponseIntegrationConfigNotionConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigNotionConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigNotionConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigNotionConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class EntitlementListResponseIntegrationConfigNotionConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigNotionConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigDigitalFilesConfig,
        EntitlementListResponseIntegrationConfigDigitalFilesConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigDigitalFilesConfig : JsonModel
{
    /// <summary>
    /// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
    /// but is sourced from an entitlement's `integration_config` (not a grant) and
    /// tags each file with its origin (`legacy` vs `ee`).
    /// </summary>
    public required EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles DigitalFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
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

    public EntitlementListResponseIntegrationConfigDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDigitalFilesConfig(
        EntitlementListResponseIntegrationConfigDigitalFilesConfig entitlementListResponseIntegrationConfigDigitalFilesConfig
    )
        : base(entitlementListResponseIntegrationConfigDigitalFilesConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigDigitalFilesConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDigitalFilesConfig(
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles digitalFiles
    )
        : this()
    {
        this.DigitalFiles = digitalFiles;
    }
}

class EntitlementListResponseIntegrationConfigDigitalFilesConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigDigitalFilesConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigDigitalFilesConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
/// but is sourced from an entitlement's `integration_config` (not a grant) and tags
/// each file with its origin (`legacy` vs `ee`).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles,
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
    : JsonModel
{
    public required IReadOnlyList<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
            >("files");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
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

    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles entitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
    )
        : base(entitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        IReadOnlyList<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> files
    )
        : this()
    {
        this.Files = files;
    }
}

class EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile,
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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

    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile entitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
    )
        : base(entitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementListResponseIntegrationConfigLicenseKeyConfig,
        EntitlementListResponseIntegrationConfigLicenseKeyConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseIntegrationConfigLicenseKeyConfig : JsonModel
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

    public EntitlementListResponseIntegrationConfigLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseIntegrationConfigLicenseKeyConfig(
        EntitlementListResponseIntegrationConfigLicenseKeyConfig entitlementListResponseIntegrationConfigLicenseKeyConfig
    )
        : base(entitlementListResponseIntegrationConfigLicenseKeyConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseIntegrationConfigLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseIntegrationConfigLicenseKeyConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseIntegrationConfigLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseIntegrationConfigLicenseKeyConfigFromRaw
    : IFromRawJson<EntitlementListResponseIntegrationConfigLicenseKeyConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseIntegrationConfigLicenseKeyConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementListResponseIntegrationTypeConverter))]
public enum EntitlementListResponseIntegrationType
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

sealed class EntitlementListResponseIntegrationTypeConverter
    : JsonConverter<EntitlementListResponseIntegrationType>
{
    public override EntitlementListResponseIntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => EntitlementListResponseIntegrationType.Discord,
            "telegram" => EntitlementListResponseIntegrationType.Telegram,
            "github" => EntitlementListResponseIntegrationType.GitHub,
            "figma" => EntitlementListResponseIntegrationType.Figma,
            "framer" => EntitlementListResponseIntegrationType.Framer,
            "notion" => EntitlementListResponseIntegrationType.Notion,
            "digital_files" => EntitlementListResponseIntegrationType.DigitalFiles,
            "license_key" => EntitlementListResponseIntegrationType.LicenseKey,
            _ => (EntitlementListResponseIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseIntegrationType.Discord => "discord",
                EntitlementListResponseIntegrationType.Telegram => "telegram",
                EntitlementListResponseIntegrationType.GitHub => "github",
                EntitlementListResponseIntegrationType.Figma => "figma",
                EntitlementListResponseIntegrationType.Framer => "framer",
                EntitlementListResponseIntegrationType.Notion => "notion",
                EntitlementListResponseIntegrationType.DigitalFiles => "digital_files",
                EntitlementListResponseIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
