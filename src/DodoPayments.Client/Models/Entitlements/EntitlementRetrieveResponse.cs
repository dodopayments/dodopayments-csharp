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
    typeof(JsonModelConverter<EntitlementRetrieveResponse, EntitlementRetrieveResponseFromRaw>)
)]
public sealed record class EntitlementRetrieveResponse : JsonModel
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
    public required EntitlementRetrieveResponseIntegrationConfig IntegrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementRetrieveResponseIntegrationConfig>(
                "integration_config"
            );
        }
        init { this._rawData.Set("integration_config", value); }
    }

    public required ApiEnum<string, EntitlementRetrieveResponseIntegrationType> IntegrationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementRetrieveResponseIntegrationType>
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

    public EntitlementRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponse(EntitlementRetrieveResponse entitlementRetrieveResponse)
        : base(entitlementRetrieveResponse) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementRetrieveResponseFromRaw : IFromRawJson<EntitlementRetrieveResponse>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Public-facing variant of [`IntegrationConfig`].  Mirrors every variant shape
/// on the wire EXCEPT `DigitalFiles`, which is replaced with a hydrated `digital_files`
/// object (resolved download URLs etc.).  The persisted JSONB stays ID-only via [`IntegrationConfig`];
/// this enum is response-only.
/// </summary>
[JsonConverter(typeof(EntitlementRetrieveResponseIntegrationConfigConverter))]
public record class EntitlementRetrieveResponseIntegrationConfig : ModelBase
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

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementRetrieveResponseIntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigGitHubConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigDiscordConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigTelegramConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigFigmaConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigFramerConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigNotionConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles(
        [NotNullWhen(true)]
            out EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey(
        [NotNullWhen(true)] out EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig? value
    )
    {
        value = this.Value as EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig;
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
    ///     (EntitlementRetrieveResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<EntitlementRetrieveResponseIntegrationConfigGitHubConfig> github,
        Action<EntitlementRetrieveResponseIntegrationConfigDiscordConfig> discord,
        Action<EntitlementRetrieveResponseIntegrationConfigTelegramConfig> telegram,
        Action<EntitlementRetrieveResponseIntegrationConfigFigmaConfig> figma,
        Action<EntitlementRetrieveResponseIntegrationConfigFramerConfig> framer,
        Action<EntitlementRetrieveResponseIntegrationConfigNotionConfig> notion,
        Action<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig> digitalFiles,
        Action<EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case EntitlementRetrieveResponseIntegrationConfigGitHubConfig value:
                github(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigDiscordConfig value:
                discord(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigTelegramConfig value:
                telegram(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigFigmaConfig value:
                figma(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigFramerConfig value:
                framer(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigNotionConfig value:
                notion(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig value:
                digitalFiles(value);
                break;
            case EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of EntitlementRetrieveResponseIntegrationConfig"
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
    ///     (EntitlementRetrieveResponseIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<EntitlementRetrieveResponseIntegrationConfigGitHubConfig, T> github,
        Func<EntitlementRetrieveResponseIntegrationConfigDiscordConfig, T> discord,
        Func<EntitlementRetrieveResponseIntegrationConfigTelegramConfig, T> telegram,
        Func<EntitlementRetrieveResponseIntegrationConfigFigmaConfig, T> figma,
        Func<EntitlementRetrieveResponseIntegrationConfigFramerConfig, T> framer,
        Func<EntitlementRetrieveResponseIntegrationConfigNotionConfig, T> notion,
        Func<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig, T> digitalFiles,
        Func<EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            EntitlementRetrieveResponseIntegrationConfigGitHubConfig value => github(value),
            EntitlementRetrieveResponseIntegrationConfigDiscordConfig value => discord(value),
            EntitlementRetrieveResponseIntegrationConfigTelegramConfig value => telegram(value),
            EntitlementRetrieveResponseIntegrationConfigFigmaConfig value => figma(value),
            EntitlementRetrieveResponseIntegrationConfigFramerConfig value => framer(value),
            EntitlementRetrieveResponseIntegrationConfigNotionConfig value => notion(value),
            EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig value => digitalFiles(
                value
            ),
            EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of EntitlementRetrieveResponseIntegrationConfig"
            ),
        };
    }

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigGitHubConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigDiscordConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigTelegramConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigFigmaConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigFramerConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigNotionConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig value
    ) => new(value);

    public static implicit operator EntitlementRetrieveResponseIntegrationConfig(
        EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig value
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
                "Data did not match any variant of EntitlementRetrieveResponseIntegrationConfig"
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

    public virtual bool Equals(EntitlementRetrieveResponseIntegrationConfig? other) =>
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
            EntitlementRetrieveResponseIntegrationConfigGitHubConfig _ => 0,
            EntitlementRetrieveResponseIntegrationConfigDiscordConfig _ => 1,
            EntitlementRetrieveResponseIntegrationConfigTelegramConfig _ => 2,
            EntitlementRetrieveResponseIntegrationConfigFigmaConfig _ => 3,
            EntitlementRetrieveResponseIntegrationConfigFramerConfig _ => 4,
            EntitlementRetrieveResponseIntegrationConfigNotionConfig _ => 5,
            EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig _ => 6,
            EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class EntitlementRetrieveResponseIntegrationConfigConverter
    : JsonConverter<EntitlementRetrieveResponseIntegrationConfig>
{
    public override EntitlementRetrieveResponseIntegrationConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigGitHubConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDiscordConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigTelegramConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigFigmaConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigFramerConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigNotionConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig>(
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
                JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig>(
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
        EntitlementRetrieveResponseIntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigGitHubConfig,
        EntitlementRetrieveResponseIntegrationConfigGitHubConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigGitHubConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigGitHubConfig(
        EntitlementRetrieveResponseIntegrationConfigGitHubConfig entitlementRetrieveResponseIntegrationConfigGitHubConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigGitHubConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigGitHubConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigGitHubConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigGitHubConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementRetrieveResponseIntegrationConfigGitHubConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigGitHubConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigDiscordConfig,
        EntitlementRetrieveResponseIntegrationConfigDiscordConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigDiscordConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDiscordConfig(
        EntitlementRetrieveResponseIntegrationConfigDiscordConfig entitlementRetrieveResponseIntegrationConfigDiscordConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigDiscordConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigDiscordConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigDiscordConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigDiscordConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class EntitlementRetrieveResponseIntegrationConfigDiscordConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigDiscordConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigTelegramConfig,
        EntitlementRetrieveResponseIntegrationConfigTelegramConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigTelegramConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigTelegramConfig(
        EntitlementRetrieveResponseIntegrationConfigTelegramConfig entitlementRetrieveResponseIntegrationConfigTelegramConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigTelegramConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigTelegramConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigTelegramConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigTelegramConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class EntitlementRetrieveResponseIntegrationConfigTelegramConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigTelegramConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigFigmaConfig,
        EntitlementRetrieveResponseIntegrationConfigFigmaConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigFigmaConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigFigmaConfig(
        EntitlementRetrieveResponseIntegrationConfigFigmaConfig entitlementRetrieveResponseIntegrationConfigFigmaConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigFigmaConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigFigmaConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigFigmaConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigFigmaConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class EntitlementRetrieveResponseIntegrationConfigFigmaConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigFigmaConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigFramerConfig,
        EntitlementRetrieveResponseIntegrationConfigFramerConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigFramerConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigFramerConfig(
        EntitlementRetrieveResponseIntegrationConfigFramerConfig entitlementRetrieveResponseIntegrationConfigFramerConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigFramerConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigFramerConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigFramerConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigFramerConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class EntitlementRetrieveResponseIntegrationConfigFramerConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigFramerConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigNotionConfig,
        EntitlementRetrieveResponseIntegrationConfigNotionConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigNotionConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigNotionConfig(
        EntitlementRetrieveResponseIntegrationConfigNotionConfig entitlementRetrieveResponseIntegrationConfigNotionConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigNotionConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigNotionConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigNotionConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigNotionConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class EntitlementRetrieveResponseIntegrationConfigNotionConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigNotionConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig,
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
    : JsonModel
{
    /// <summary>
    /// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
    /// but is sourced from an entitlement's `integration_config` (not a grant) and
    /// tags each file with its origin (`legacy` vs `ee`).
    /// </summary>
    public required EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles DigitalFiles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
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

    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig(
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig entitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigDigitalFilesConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig(
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles digitalFiles
    )
        : this()
    {
        this.DigitalFiles = digitalFiles;
    }
}

class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated digital-files payload for entitlement read surfaces. Mirrors `DigitalProductDelivery`
/// but is sourced from an entitlement's `integration_config` (not a grant) and tags
/// each file with its origin (`legacy` vs `ee`).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles,
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
    : JsonModel
{
    public required IReadOnlyList<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
            >("files");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
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

    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles entitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
    )
        : base(entitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles(
        IReadOnlyList<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> files
    )
        : this()
    {
        this.Files = files;
    }
}

class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile,
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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

    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile entitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
    )
        : base(entitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig,
        EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfigFromRaw
    >)
)]
public sealed record class EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig : JsonModel
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

    public EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig(
        EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig entitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
    )
        : base(entitlementRetrieveResponseIntegrationConfigLicenseKeyConfig) { }
#pragma warning restore CS8618

    public EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfigFromRaw
    : IFromRawJson<EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig>
{
    /// <inheritdoc/>
    public EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementRetrieveResponseIntegrationTypeConverter))]
public enum EntitlementRetrieveResponseIntegrationType
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

sealed class EntitlementRetrieveResponseIntegrationTypeConverter
    : JsonConverter<EntitlementRetrieveResponseIntegrationType>
{
    public override EntitlementRetrieveResponseIntegrationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "discord" => EntitlementRetrieveResponseIntegrationType.Discord,
            "telegram" => EntitlementRetrieveResponseIntegrationType.Telegram,
            "github" => EntitlementRetrieveResponseIntegrationType.GitHub,
            "figma" => EntitlementRetrieveResponseIntegrationType.Figma,
            "framer" => EntitlementRetrieveResponseIntegrationType.Framer,
            "notion" => EntitlementRetrieveResponseIntegrationType.Notion,
            "digital_files" => EntitlementRetrieveResponseIntegrationType.DigitalFiles,
            "license_key" => EntitlementRetrieveResponseIntegrationType.LicenseKey,
            _ => (EntitlementRetrieveResponseIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementRetrieveResponseIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementRetrieveResponseIntegrationType.Discord => "discord",
                EntitlementRetrieveResponseIntegrationType.Telegram => "telegram",
                EntitlementRetrieveResponseIntegrationType.GitHub => "github",
                EntitlementRetrieveResponseIntegrationType.Figma => "figma",
                EntitlementRetrieveResponseIntegrationType.Framer => "framer",
                EntitlementRetrieveResponseIntegrationType.Notion => "notion",
                EntitlementRetrieveResponseIntegrationType.DigitalFiles => "digital_files",
                EntitlementRetrieveResponseIntegrationType.LicenseKey => "license_key",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
