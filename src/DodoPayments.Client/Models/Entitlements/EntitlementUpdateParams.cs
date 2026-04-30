using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Subscriptions = DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Models.Entitlements;

/// <summary>
/// PATCH /entitlements/{id}
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntitlementUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Platform-specific configuration for an entitlement. Each variant uses unique
    /// field names so `#[serde(untagged)]` can disambiguate correctly.
    /// </summary>
    public EntitlementUpdateParamsIntegrationConfig? IntegrationConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntitlementUpdateParamsIntegrationConfig>(
                "integration_config"
            );
        }
        init { this._rawBodyData.Set("integration_config", value); }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public EntitlementUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParams(EntitlementUpdateParams entitlementUpdateParams)
        : base(entitlementUpdateParams)
    {
        this.ID = entitlementUpdateParams.ID;

        this._rawBodyData = new(entitlementUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntitlementUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntitlementUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EntitlementUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/entitlements/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// Platform-specific configuration for an entitlement. Each variant uses unique field
/// names so `#[serde(untagged)]` can disambiguate correctly.
/// </summary>
[JsonConverter(typeof(EntitlementUpdateParamsIntegrationConfigConverter))]
public record class EntitlementUpdateParamsIntegrationConfig : ModelBase
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

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigGitHubConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigDiscordConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigTelegramConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigFigmaConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigFramerConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigNotionConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementUpdateParamsIntegrationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigGitHubConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHub(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigGitHubConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHub(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigGitHubConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigGitHubConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigDiscordConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDiscord(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigDiscordConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDiscord(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigDiscordConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigDiscordConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigTelegramConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTelegram(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigTelegramConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTelegram(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigTelegramConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigTelegramConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigFigmaConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFigma(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigFigmaConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFigma(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigFigmaConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigFigmaConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigFramerConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFramer(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigFramerConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFramer(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigFramerConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigFramerConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigNotionConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotion(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigNotionConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotion(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigNotionConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigNotionConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDigitalFiles(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDigitalFiles(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLicenseKey(out var value)) {
    ///     // `value` is of type `EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLicenseKey(
        [NotNullWhen(true)] out EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig? value
    )
    {
        value = this.Value as EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig;
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
    ///     (EntitlementUpdateParamsIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<EntitlementUpdateParamsIntegrationConfigGitHubConfig> github,
        Action<EntitlementUpdateParamsIntegrationConfigDiscordConfig> discord,
        Action<EntitlementUpdateParamsIntegrationConfigTelegramConfig> telegram,
        Action<EntitlementUpdateParamsIntegrationConfigFigmaConfig> figma,
        Action<EntitlementUpdateParamsIntegrationConfigFramerConfig> framer,
        Action<EntitlementUpdateParamsIntegrationConfigNotionConfig> notion,
        Action<EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig> digitalFiles,
        Action<EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig> licenseKey
    )
    {
        switch (this.Value)
        {
            case EntitlementUpdateParamsIntegrationConfigGitHubConfig value:
                github(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigDiscordConfig value:
                discord(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigTelegramConfig value:
                telegram(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigFigmaConfig value:
                figma(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigFramerConfig value:
                framer(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigNotionConfig value:
                notion(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig value:
                digitalFiles(value);
                break;
            case EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig value:
                licenseKey(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of EntitlementUpdateParamsIntegrationConfig"
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
    ///     (EntitlementUpdateParamsIntegrationConfigGitHubConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigDiscordConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigTelegramConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigFigmaConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigFramerConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigNotionConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig value) =&gt; {...},
    ///     (EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<EntitlementUpdateParamsIntegrationConfigGitHubConfig, T> github,
        Func<EntitlementUpdateParamsIntegrationConfigDiscordConfig, T> discord,
        Func<EntitlementUpdateParamsIntegrationConfigTelegramConfig, T> telegram,
        Func<EntitlementUpdateParamsIntegrationConfigFigmaConfig, T> figma,
        Func<EntitlementUpdateParamsIntegrationConfigFramerConfig, T> framer,
        Func<EntitlementUpdateParamsIntegrationConfigNotionConfig, T> notion,
        Func<EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig, T> digitalFiles,
        Func<EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig, T> licenseKey
    )
    {
        return this.Value switch
        {
            EntitlementUpdateParamsIntegrationConfigGitHubConfig value => github(value),
            EntitlementUpdateParamsIntegrationConfigDiscordConfig value => discord(value),
            EntitlementUpdateParamsIntegrationConfigTelegramConfig value => telegram(value),
            EntitlementUpdateParamsIntegrationConfigFigmaConfig value => figma(value),
            EntitlementUpdateParamsIntegrationConfigFramerConfig value => framer(value),
            EntitlementUpdateParamsIntegrationConfigNotionConfig value => notion(value),
            EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig value => digitalFiles(value),
            EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig value => licenseKey(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of EntitlementUpdateParamsIntegrationConfig"
            ),
        };
    }

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigGitHubConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigDiscordConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigTelegramConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigFigmaConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigFramerConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigNotionConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig value
    ) => new(value);

    public static implicit operator EntitlementUpdateParamsIntegrationConfig(
        EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig value
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
                "Data did not match any variant of EntitlementUpdateParamsIntegrationConfig"
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

    public virtual bool Equals(EntitlementUpdateParamsIntegrationConfig? other) =>
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
            EntitlementUpdateParamsIntegrationConfigGitHubConfig _ => 0,
            EntitlementUpdateParamsIntegrationConfigDiscordConfig _ => 1,
            EntitlementUpdateParamsIntegrationConfigTelegramConfig _ => 2,
            EntitlementUpdateParamsIntegrationConfigFigmaConfig _ => 3,
            EntitlementUpdateParamsIntegrationConfigFramerConfig _ => 4,
            EntitlementUpdateParamsIntegrationConfigNotionConfig _ => 5,
            EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig _ => 6,
            EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class EntitlementUpdateParamsIntegrationConfigConverter
    : JsonConverter<EntitlementUpdateParamsIntegrationConfig?>
{
    public override EntitlementUpdateParamsIntegrationConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigGitHubConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigDiscordConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigTelegramConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigFigmaConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigFramerConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigNotionConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig>(
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
                JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig>(
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
        EntitlementUpdateParamsIntegrationConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigGitHubConfig,
        EntitlementUpdateParamsIntegrationConfigGitHubConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigGitHubConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigGitHubConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigGitHubConfig(
        EntitlementUpdateParamsIntegrationConfigGitHubConfig entitlementUpdateParamsIntegrationConfigGitHubConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigGitHubConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigGitHubConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigGitHubConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigGitHubConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateParamsIntegrationConfigGitHubConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigGitHubConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigGitHubConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigGitHubConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigDiscordConfig,
        EntitlementUpdateParamsIntegrationConfigDiscordConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigDiscordConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigDiscordConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigDiscordConfig(
        EntitlementUpdateParamsIntegrationConfigDiscordConfig entitlementUpdateParamsIntegrationConfigDiscordConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigDiscordConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigDiscordConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigDiscordConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigDiscordConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigDiscordConfig(string guildID)
        : this()
    {
        this.GuildID = guildID;
    }
}

class EntitlementUpdateParamsIntegrationConfigDiscordConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigDiscordConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigDiscordConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigDiscordConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigTelegramConfig,
        EntitlementUpdateParamsIntegrationConfigTelegramConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigTelegramConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigTelegramConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigTelegramConfig(
        EntitlementUpdateParamsIntegrationConfigTelegramConfig entitlementUpdateParamsIntegrationConfigTelegramConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigTelegramConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigTelegramConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigTelegramConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigTelegramConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigTelegramConfig(string chatID)
        : this()
    {
        this.ChatID = chatID;
    }
}

class EntitlementUpdateParamsIntegrationConfigTelegramConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigTelegramConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigTelegramConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigTelegramConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigFigmaConfig,
        EntitlementUpdateParamsIntegrationConfigFigmaConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigFigmaConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigFigmaConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigFigmaConfig(
        EntitlementUpdateParamsIntegrationConfigFigmaConfig entitlementUpdateParamsIntegrationConfigFigmaConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigFigmaConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigFigmaConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigFigmaConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigFigmaConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigFigmaConfig(string figmaFileID)
        : this()
    {
        this.FigmaFileID = figmaFileID;
    }
}

class EntitlementUpdateParamsIntegrationConfigFigmaConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigFigmaConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigFigmaConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigFigmaConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigFramerConfig,
        EntitlementUpdateParamsIntegrationConfigFramerConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigFramerConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigFramerConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigFramerConfig(
        EntitlementUpdateParamsIntegrationConfigFramerConfig entitlementUpdateParamsIntegrationConfigFramerConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigFramerConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigFramerConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigFramerConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigFramerConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigFramerConfig(string framerTemplateID)
        : this()
    {
        this.FramerTemplateID = framerTemplateID;
    }
}

class EntitlementUpdateParamsIntegrationConfigFramerConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigFramerConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigFramerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigFramerConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigNotionConfig,
        EntitlementUpdateParamsIntegrationConfigNotionConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigNotionConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigNotionConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigNotionConfig(
        EntitlementUpdateParamsIntegrationConfigNotionConfig entitlementUpdateParamsIntegrationConfigNotionConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigNotionConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigNotionConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigNotionConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigNotionConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigNotionConfig(string notionTemplateID)
        : this()
    {
        this.NotionTemplateID = notionTemplateID;
    }
}

class EntitlementUpdateParamsIntegrationConfigNotionConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigNotionConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigNotionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigNotionConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig,
        EntitlementUpdateParamsIntegrationConfigDigitalFilesConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig(
        EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig entitlementUpdateParamsIntegrationConfigDigitalFilesConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigDigitalFilesConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigDigitalFilesConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig(
        IReadOnlyList<string> digitalFileIds
    )
        : this()
    {
        this.DigitalFileIds = digitalFileIds;
    }
}

class EntitlementUpdateParamsIntegrationConfigDigitalFilesConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig,
        EntitlementUpdateParamsIntegrationConfigLicenseKeyConfigFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig : JsonModel
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

    public EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig(
        EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig entitlementUpdateParamsIntegrationConfigLicenseKeyConfig
    )
        : base(entitlementUpdateParamsIntegrationConfigLicenseKeyConfig) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsIntegrationConfigLicenseKeyConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateParamsIntegrationConfigLicenseKeyConfigFromRaw
    : IFromRawJson<EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig.FromRawUnchecked(rawData);
}
