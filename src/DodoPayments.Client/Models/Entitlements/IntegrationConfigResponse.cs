using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// Integration-specific configuration on an entitlement read response.
///
/// <para>For `digital_files` entitlements the response includes presigned download
/// URLs for each attached file; other integrations match the shape supplied at creation.</para>
/// </summary>
[JsonConverter(typeof(IntegrationConfigResponseConverter))]
public record class IntegrationConfigResponse : ModelBase
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

    public IntegrationConfigResponse(
        IntegrationConfigResponseGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(
        IntegrationConfigResponseLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfigResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHubConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHubConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseGitHubConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscordConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscordConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseDiscordConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegramConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegramConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseTelegramConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigmaConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigmaConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseFigmaConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramerConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramerConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseFramerConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotionConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotionConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseNotionConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFilesConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFilesConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseDigitalFilesConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationConfigResponseLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKeyConfig(out var value)) {
    ///     // `value` is of type `IntegrationConfigResponseLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKeyConfig(
        [NotNullWhen(true)] out IntegrationConfigResponseLicenseKeyConfig? value
    )
    {
        value = this.Value as IntegrationConfigResponseLicenseKeyConfig;
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
    ///     (IntegrationConfigResponseGitHubConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseDiscordConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseTelegramConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseFigmaConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseFramerConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseNotionConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseDigitalFilesConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IntegrationConfigResponseGitHubConfig> githubConfig,
        Action<IntegrationConfigResponseDiscordConfig> discordConfig,
        Action<IntegrationConfigResponseTelegramConfig> telegramConfig,
        Action<IntegrationConfigResponseFigmaConfig> figmaConfig,
        Action<IntegrationConfigResponseFramerConfig> framerConfig,
        Action<IntegrationConfigResponseNotionConfig> notionConfig,
        Action<IntegrationConfigResponseDigitalFilesConfig> digitalFilesConfig,
        Action<IntegrationConfigResponseLicenseKeyConfig> licenseKeyConfig
    )
    {
        switch (this.Value)
        {
            case IntegrationConfigResponseGitHubConfig value:
                githubConfig(value);
                break;
            case IntegrationConfigResponseDiscordConfig value:
                discordConfig(value);
                break;
            case IntegrationConfigResponseTelegramConfig value:
                telegramConfig(value);
                break;
            case IntegrationConfigResponseFigmaConfig value:
                figmaConfig(value);
                break;
            case IntegrationConfigResponseFramerConfig value:
                framerConfig(value);
                break;
            case IntegrationConfigResponseNotionConfig value:
                notionConfig(value);
                break;
            case IntegrationConfigResponseDigitalFilesConfig value:
                digitalFilesConfig(value);
                break;
            case IntegrationConfigResponseLicenseKeyConfig value:
                licenseKeyConfig(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of IntegrationConfigResponse"
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
    ///     (IntegrationConfigResponseGitHubConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseDiscordConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseTelegramConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseFigmaConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseFramerConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseNotionConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseDigitalFilesConfig value) =&gt; {...},
    ///     (IntegrationConfigResponseLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IntegrationConfigResponseGitHubConfig, T> githubConfig,
        Func<IntegrationConfigResponseDiscordConfig, T> discordConfig,
        Func<IntegrationConfigResponseTelegramConfig, T> telegramConfig,
        Func<IntegrationConfigResponseFigmaConfig, T> figmaConfig,
        Func<IntegrationConfigResponseFramerConfig, T> framerConfig,
        Func<IntegrationConfigResponseNotionConfig, T> notionConfig,
        Func<IntegrationConfigResponseDigitalFilesConfig, T> digitalFilesConfig,
        Func<IntegrationConfigResponseLicenseKeyConfig, T> licenseKeyConfig
    )
    {
        return this.Value switch
        {
            IntegrationConfigResponseGitHubConfig value => githubConfig(value),
            IntegrationConfigResponseDiscordConfig value => discordConfig(value),
            IntegrationConfigResponseTelegramConfig value => telegramConfig(value),
            IntegrationConfigResponseFigmaConfig value => figmaConfig(value),
            IntegrationConfigResponseFramerConfig value => framerConfig(value),
            IntegrationConfigResponseNotionConfig value => notionConfig(value),
            IntegrationConfigResponseDigitalFilesConfig value => digitalFilesConfig(value),
            IntegrationConfigResponseLicenseKeyConfig value => licenseKeyConfig(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of IntegrationConfigResponse"
            ),
        };
    }

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseGitHubConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseDiscordConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseTelegramConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseFigmaConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseFramerConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseNotionConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseDigitalFilesConfig value
    ) => new(value);

    public static implicit operator IntegrationConfigResponse(
        IntegrationConfigResponseLicenseKeyConfig value
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
                "Data did not match any variant of IntegrationConfigResponse"
            );
        }
        this.Switch(
            (githubConfig) => githubConfig.Validate(),
            (discordConfig) => discordConfig.Validate(),
            (telegramConfig) => telegramConfig.Validate(),
            (figmaConfig) => figmaConfig.Validate(),
            (framerConfig) => framerConfig.Validate(),
            (notionConfig) => notionConfig.Validate(),
            (digitalFilesConfig) => digitalFilesConfig.Validate(),
            (licenseKeyConfig) => licenseKeyConfig.Validate()
        );
    }

    public virtual bool Equals(IntegrationConfigResponse? other) =>
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
            IntegrationConfigResponseGitHubConfig _ => 0,
            IntegrationConfigResponseDiscordConfig _ => 1,
            IntegrationConfigResponseTelegramConfig _ => 2,
            IntegrationConfigResponseFigmaConfig _ => 3,
            IntegrationConfigResponseFramerConfig _ => 4,
            IntegrationConfigResponseNotionConfig _ => 5,
            IntegrationConfigResponseDigitalFilesConfig _ => 6,
            IntegrationConfigResponseLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class IntegrationConfigResponseConverter : JsonConverter<IntegrationConfigResponse>
{
    public override IntegrationConfigResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<IntegrationConfigResponseGitHubConfig>(
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
            var deserialized = JsonSerializer.Deserialize<IntegrationConfigResponseDiscordConfig>(
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
            var deserialized = JsonSerializer.Deserialize<IntegrationConfigResponseTelegramConfig>(
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
            var deserialized = JsonSerializer.Deserialize<IntegrationConfigResponseFigmaConfig>(
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
            var deserialized = JsonSerializer.Deserialize<IntegrationConfigResponseFramerConfig>(
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
            var deserialized = JsonSerializer.Deserialize<IntegrationConfigResponseNotionConfig>(
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
                JsonSerializer.Deserialize<IntegrationConfigResponseDigitalFilesConfig>(
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
                JsonSerializer.Deserialize<IntegrationConfigResponseLicenseKeyConfig>(
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
        IntegrationConfigResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseGitHubConfig,
        IntegrationConfigResponseGitHubConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseGitHubConfig : JsonModel
{
    /// <summary>
    /// Permission to grant on the repository.
    /// </summary>
    public required ApiEnum<string, GitHubPermission> Permission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GitHubPermission>>("permission");
        }
        init { this._rawData.Set("permission", value); }
    }

    /// <summary>
    /// Repository or organisation slug to grant access to.
    /// </summary>
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
        this.Permission.Validate();
        _ = this.TargetID;
    }

    public IntegrationConfigResponseGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseGitHubConfig(
        IntegrationConfigResponseGitHubConfig integrationConfigResponseGitHubConfig
    )
        : base(integrationConfigResponseGitHubConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseGitHubConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseGitHubConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseGitHubConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationConfigResponseGitHubConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseGitHubConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseDiscordConfig,
        IntegrationConfigResponseDiscordConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseDiscordConfig : JsonModel
{
    /// <summary>
    /// Discord guild (server) ID.
    /// </summary>
    public required string GuildID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("guild_id");
        }
        init { this._rawData.Set("guild_id", value); }
    }

    /// <summary>
    /// Optional Discord role to assign within the guild.
    /// </summary>
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

    public IntegrationConfigResponseDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseDiscordConfig(
        IntegrationConfigResponseDiscordConfig integrationConfigResponseDiscordConfig
    )
        : base(integrationConfigResponseDiscordConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseDiscordConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseDiscordConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseDiscordConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationConfigResponseDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class IntegrationConfigResponseDiscordConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseDiscordConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseTelegramConfig,
        IntegrationConfigResponseTelegramConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseTelegramConfig : JsonModel
{
    /// <summary>
    /// Telegram chat ID. For groups this is typically a negative integer.
    /// </summary>
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

    public IntegrationConfigResponseTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseTelegramConfig(
        IntegrationConfigResponseTelegramConfig integrationConfigResponseTelegramConfig
    )
        : base(integrationConfigResponseTelegramConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseTelegramConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseTelegramConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseTelegramConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationConfigResponseTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class IntegrationConfigResponseTelegramConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseTelegramConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseFigmaConfig,
        IntegrationConfigResponseFigmaConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseFigmaConfig : JsonModel
{
    /// <summary>
    /// Figma file identifier to grant access to.
    /// </summary>
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

    public IntegrationConfigResponseFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseFigmaConfig(
        IntegrationConfigResponseFigmaConfig integrationConfigResponseFigmaConfig
    )
        : base(integrationConfigResponseFigmaConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseFigmaConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseFigmaConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseFigmaConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationConfigResponseFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class IntegrationConfigResponseFigmaConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseFigmaConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseFramerConfig,
        IntegrationConfigResponseFramerConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseFramerConfig : JsonModel
{
    /// <summary>
    /// Framer template identifier to grant access to.
    /// </summary>
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

    public IntegrationConfigResponseFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseFramerConfig(
        IntegrationConfigResponseFramerConfig integrationConfigResponseFramerConfig
    )
        : base(integrationConfigResponseFramerConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseFramerConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseFramerConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseFramerConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationConfigResponseFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class IntegrationConfigResponseFramerConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseFramerConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseNotionConfig,
        IntegrationConfigResponseNotionConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseNotionConfig : JsonModel
{
    /// <summary>
    /// Notion template identifier to grant access to.
    /// </summary>
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

    public IntegrationConfigResponseNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseNotionConfig(
        IntegrationConfigResponseNotionConfig integrationConfigResponseNotionConfig
    )
        : base(integrationConfigResponseNotionConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseNotionConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseNotionConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseNotionConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationConfigResponseNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class IntegrationConfigResponseNotionConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseNotionConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationConfigResponseDigitalFilesConfig,
        IntegrationConfigResponseDigitalFilesConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseDigitalFilesConfig : JsonModel
{
    /// <summary>
    /// Populated digital-files payload with each file's metadata and a short-lived
    /// presigned download URL.
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

    public IntegrationConfigResponseDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseDigitalFilesConfig(
        IntegrationConfigResponseDigitalFilesConfig integrationConfigResponseDigitalFilesConfig
    )
        : base(integrationConfigResponseDigitalFilesConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseDigitalFilesConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationConfigResponseDigitalFilesConfig(DigitalFiles digitalFiles)
        : this()
    {
        this.DigitalFiles = digitalFiles;
    }
}

class IntegrationConfigResponseDigitalFilesConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseDigitalFilesConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseDigitalFilesConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated digital-files payload with each file's metadata and a short-lived presigned
/// download URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalFiles, DigitalFilesFromRaw>))]
public sealed record class DigitalFiles : JsonModel
{
    /// <summary>
    /// One entry per attached file.
    /// </summary>
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

    /// <summary>
    /// Optional external URL, passed through from the entitlement configuration.
    /// </summary>
    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    /// <summary>
    /// Optional human-readable delivery instructions, passed through from the entitlement configuration.
    /// </summary>
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

/// <summary>
/// One file in a resolved digital-files payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    /// <summary>
    /// Short-lived presigned URL for downloading the file.
    /// </summary>
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

    /// <summary>
    /// Identifier of the attached file.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// Original filename of the attached file.
    /// </summary>
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
    /// Optional content-type declared at upload.
    /// </summary>
    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    /// <summary>
    /// Optional size of the file in bytes.
    /// </summary>
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
        IntegrationConfigResponseLicenseKeyConfig,
        IntegrationConfigResponseLicenseKeyConfigFromRaw
    >)
)]
public sealed record class IntegrationConfigResponseLicenseKeyConfig : JsonModel
{
    /// <summary>
    /// Optional message displayed when a customer activates the license key (≤ 2500 characters).
    /// </summary>
    public string? ActivationMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("activation_message");
        }
        init { this._rawData.Set("activation_message", value); }
    }

    /// <summary>
    /// Maximum activations allowed per issued license key. Omit for unlimited.
    /// </summary>
    public int? ActivationsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("activations_limit");
        }
        init { this._rawData.Set("activations_limit", value); }
    }

    /// <summary>
    /// Validity duration of issued license keys. Provide both `duration_count` and
    /// `duration_interval` together for a fixed duration; omit both for non-expiring keys.
    /// </summary>
    public int? DurationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("duration_count");
        }
        init { this._rawData.Set("duration_count", value); }
    }

    /// <summary>
    /// Unit of `duration_count`.
    /// </summary>
    public ApiEnum<string, TimeInterval>? DurationInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TimeInterval>>(
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

    public IntegrationConfigResponseLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConfigResponseLicenseKeyConfig(
        IntegrationConfigResponseLicenseKeyConfig integrationConfigResponseLicenseKeyConfig
    )
        : base(integrationConfigResponseLicenseKeyConfig) { }
#pragma warning restore CS8618

    public IntegrationConfigResponseLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConfigResponseLicenseKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConfigResponseLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static IntegrationConfigResponseLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationConfigResponseLicenseKeyConfigFromRaw
    : IFromRawJson<IntegrationConfigResponseLicenseKeyConfig>
{
    /// <inheritdoc/>
    public IntegrationConfigResponseLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationConfigResponseLicenseKeyConfig.FromRawUnchecked(rawData);
}
