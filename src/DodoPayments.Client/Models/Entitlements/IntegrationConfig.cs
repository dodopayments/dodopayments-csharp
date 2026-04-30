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

/// <summary>
/// Platform-specific configuration for an entitlement. Each variant uses unique field
/// names so `#[serde(untagged)]` can disambiguate correctly.
/// </summary>
[JsonConverter(typeof(IntegrationConfigConverter))]
public record class IntegrationConfig : ModelBase
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

    public IntegrationConfig(GitHubConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(DiscordConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(TelegramConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(FigmaConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(FramerConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(NotionConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(DigitalFilesConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(LicenseKeyConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `GitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub([NotNullWhen(true)] out GitHubConfig? value)
    {
        value = this.Value as GitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `DiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord([NotNullWhen(true)] out DiscordConfig? value)
    {
        value = this.Value as DiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `TelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram([NotNullWhen(true)] out TelegramConfig? value)
    {
        value = this.Value as TelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `FigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma([NotNullWhen(true)] out FigmaConfig? value)
    {
        value = this.Value as FigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `FramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer([NotNullWhen(true)] out FramerConfig? value)
    {
        value = this.Value as FramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `NotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion([NotNullWhen(true)] out NotionConfig? value)
    {
        value = this.Value as NotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `DigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles([NotNullWhen(true)] out DigitalFilesConfig? value)
    {
        value = this.Value as DigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `LicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey([NotNullWhen(true)] out LicenseKeyConfig? value)
    {
        value = this.Value as LicenseKeyConfig;
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
    ///     (GitHubConfig value) =&gt; {...},
    ///     (DiscordConfig value) =&gt; {...},
    ///     (TelegramConfig value) =&gt; {...},
    ///     (FigmaConfig value) =&gt; {...},
    ///     (FramerConfig value) =&gt; {...},
    ///     (NotionConfig value) =&gt; {...},
    ///     (DigitalFilesConfig value) =&gt; {...},
    ///     (LicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<GitHubConfig> github,
        Action<DiscordConfig> discord,
        Action<TelegramConfig> telegram,
        Action<FigmaConfig> figma,
        Action<FramerConfig> framer,
        Action<NotionConfig> notion,
        Action<DigitalFilesConfig> digitalFiles,
        Action<LicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case GitHubConfig value:
                github(value);
                break;
            case DiscordConfig value:
                discord(value);
                break;
            case TelegramConfig value:
                telegram(value);
                break;
            case FigmaConfig value:
                figma(value);
                break;
            case FramerConfig value:
                framer(value);
                break;
            case NotionConfig value:
                notion(value);
                break;
            case DigitalFilesConfig value:
                digitalFiles(value);
                break;
            case LicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of IntegrationConfig"
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
    ///     (GitHubConfig value) =&gt; {...},
    ///     (DiscordConfig value) =&gt; {...},
    ///     (TelegramConfig value) =&gt; {...},
    ///     (FigmaConfig value) =&gt; {...},
    ///     (FramerConfig value) =&gt; {...},
    ///     (NotionConfig value) =&gt; {...},
    ///     (DigitalFilesConfig value) =&gt; {...},
    ///     (LicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<GitHubConfig, T> github,
        Func<DiscordConfig, T> discord,
        Func<TelegramConfig, T> telegram,
        Func<FigmaConfig, T> figma,
        Func<FramerConfig, T> framer,
        Func<NotionConfig, T> notion,
        Func<DigitalFilesConfig, T> digitalFiles,
        Func<LicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            GitHubConfig value => github(value),
            DiscordConfig value => discord(value),
            TelegramConfig value => telegram(value),
            FigmaConfig value => figma(value),
            FramerConfig value => framer(value),
            NotionConfig value => notion(value),
            DigitalFilesConfig value => digitalFiles(value),
            LicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of IntegrationConfig"
            ),
        };
    }

    public static implicit operator IntegrationConfig(GitHubConfig value) => new(value);

    public static implicit operator IntegrationConfig(DiscordConfig value) => new(value);

    public static implicit operator IntegrationConfig(TelegramConfig value) => new(value);

    public static implicit operator IntegrationConfig(FigmaConfig value) => new(value);

    public static implicit operator IntegrationConfig(FramerConfig value) => new(value);

    public static implicit operator IntegrationConfig(NotionConfig value) => new(value);

    public static implicit operator IntegrationConfig(DigitalFilesConfig value) => new(value);

    public static implicit operator IntegrationConfig(LicenseKeyConfig value) => new(value);

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
                "Data did not match any variant of IntegrationConfig"
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

    public virtual bool Equals(IntegrationConfig? other) =>
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
            GitHubConfig _ => 0,
            DiscordConfig _ => 1,
            TelegramConfig _ => 2,
            FigmaConfig _ => 3,
            FramerConfig _ => 4,
            NotionConfig _ => 5,
            DigitalFilesConfig _ => 6,
            LicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class IntegrationConfigConverter : JsonConverter<IntegrationConfig>
{
    public override IntegrationConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<GitHubConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<DiscordConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<TelegramConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<FigmaConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<FramerConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<NotionConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<DigitalFilesConfig>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<LicenseKeyConfig>(element, options);
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
        IntegrationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<GitHubConfig, GitHubConfigFromRaw>))]
public sealed record class GitHubConfig : JsonModel
{
    /// <summary>
    /// One of: pull, push, admin, maintain, triage
    /// </summary>
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

    public GitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GitHubConfig(GitHubConfig githubConfig)
        : base(githubConfig) { }
#pragma warning restore CS8618

    public GitHubConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GitHubConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GitHubConfigFromRaw.FromRawUnchecked"/>
    public static GitHubConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GitHubConfigFromRaw : IFromRawJson<GitHubConfig>
{
    /// <inheritdoc/>
    public GitHubConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DiscordConfig, DiscordConfigFromRaw>))]
public sealed record class DiscordConfig : JsonModel
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

    public DiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscordConfig(DiscordConfig discordConfig)
        : base(discordConfig) { }
#pragma warning restore CS8618

    public DiscordConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscordConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscordConfigFromRaw.FromRawUnchecked"/>
    public static DiscordConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class DiscordConfigFromRaw : IFromRawJson<DiscordConfig>
{
    /// <inheritdoc/>
    public DiscordConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TelegramConfig, TelegramConfigFromRaw>))]
public sealed record class TelegramConfig : JsonModel
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

    public TelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelegramConfig(TelegramConfig telegramConfig)
        : base(telegramConfig) { }
#pragma warning restore CS8618

    public TelegramConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TelegramConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TelegramConfigFromRaw.FromRawUnchecked"/>
    public static TelegramConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class TelegramConfigFromRaw : IFromRawJson<TelegramConfig>
{
    /// <inheritdoc/>
    public TelegramConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FigmaConfig, FigmaConfigFromRaw>))]
public sealed record class FigmaConfig : JsonModel
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

    public FigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FigmaConfig(FigmaConfig figmaConfig)
        : base(figmaConfig) { }
#pragma warning restore CS8618

    public FigmaConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FigmaConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FigmaConfigFromRaw.FromRawUnchecked"/>
    public static FigmaConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class FigmaConfigFromRaw : IFromRawJson<FigmaConfig>
{
    /// <inheritdoc/>
    public FigmaConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FramerConfig, FramerConfigFromRaw>))]
public sealed record class FramerConfig : JsonModel
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

    public FramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FramerConfig(FramerConfig framerConfig)
        : base(framerConfig) { }
#pragma warning restore CS8618

    public FramerConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FramerConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FramerConfigFromRaw.FromRawUnchecked"/>
    public static FramerConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class FramerConfigFromRaw : IFromRawJson<FramerConfig>
{
    /// <inheritdoc/>
    public FramerConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NotionConfig, NotionConfigFromRaw>))]
public sealed record class NotionConfig : JsonModel
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

    public NotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotionConfig(NotionConfig notionConfig)
        : base(notionConfig) { }
#pragma warning restore CS8618

    public NotionConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotionConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotionConfigFromRaw.FromRawUnchecked"/>
    public static NotionConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class NotionConfigFromRaw : IFromRawJson<NotionConfig>
{
    /// <inheritdoc/>
    public NotionConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DigitalFilesConfig, DigitalFilesConfigFromRaw>))]
public sealed record class DigitalFilesConfig : JsonModel
{
    public required IReadOnlyList<string> DigitalFileIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("digital_file_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "digital_file_ids",
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

    /// <summary>
    /// Three-way patchable field (mirrors the credit_entitlements pattern):
    ///
    /// <para>* omitted → preserve persisted (`None`) * `null`  → clear
    ///     (`Some(None)`) * `[...]` → replace            (`Some(Some(...))`)</para>
    ///
    /// <para>On Create / storage we collapse "clear" and empty-array to `None` so
    /// the persisted JSONB never carries a `null` legacy_file_ids key.</para>
    /// </summary>
    public IReadOnlyList<string>? LegacyFileIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("legacy_file_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "legacy_file_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DigitalFileIds;
        _ = this.ExternalUrl;
        _ = this.Instructions;
        _ = this.LegacyFileIds;
    }

    public DigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalFilesConfig(DigitalFilesConfig digitalFilesConfig)
        : base(digitalFilesConfig) { }
#pragma warning restore CS8618

    public DigitalFilesConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalFilesConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static DigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalFilesConfig(IReadOnlyList<string> digitalFileIds)
        : this()
    {
        this.DigitalFileIds = digitalFileIds;
    }
}

class DigitalFilesConfigFromRaw : IFromRawJson<DigitalFilesConfig>
{
    /// <inheritdoc/>
    public DigitalFilesConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalFilesConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LicenseKeyConfig, LicenseKeyConfigFromRaw>))]
public sealed record class LicenseKeyConfig : JsonModel
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

    public LicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseKeyConfig(LicenseKeyConfig licenseKeyConfig)
        : base(licenseKeyConfig) { }
#pragma warning restore CS8618

    public LicenseKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static LicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseKeyConfigFromRaw : IFromRawJson<LicenseKeyConfig>
{
    /// <inheritdoc/>
    public LicenseKeyConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseKeyConfig.FromRawUnchecked(rawData);
}
