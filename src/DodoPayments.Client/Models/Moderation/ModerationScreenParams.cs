using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Moderation;

/// <summary>
/// Screens text, an image, or both, and returns a verdict: `allow`, `flag` or `deny`.
/// The API is fail-closed: do not generate when you get no verdict.
///
/// <para>**Pricing.** Dodo Payments charges $0.30 per 1000 billable screens and
/// debits the fee from your balance. A billable screen is a live-mode screen that
/// returns a verdict. Errors and test-mode screens are free.</para>
///
/// <para>**429.** Honour `Retry-After` and retry. A 429 is a throughput limit, not
/// a verdict.</para>
///
/// <para>**Test mode** returns mock verdicts and never calls the model. The default
/// verdict is `allow`. Put one of these strings in `text` to select another outcome:
/// `dodo_mock_flag` (`flag`), `dodo_mock_deny` (`deny`), `dodo_mock_overloaded` (429)
/// or `dodo_mock_not_ready` (503).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ModerationScreenParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The image to screen, as base64, with or without a `data:image/...;base64,`
    /// prefix. The formats are JPEG, PNG, WebP, GIF and BMP. The limit is 6991530
    /// base64 characters, and the decoded image must be at most 5 MiB.
    /// </summary>
    public string? Image
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("image");
        }
        init { this._rawBodyData.Set("image", value); }
    }

    /// <summary>
    /// Your identifier for this screen, up to 128 characters, with no control characters.
    /// The response returns it in `request_id`.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("request_id");
        }
        init { this._rawBodyData.Set("request_id", value); }
    }

    /// <summary>
    /// The text to screen, up to 8000 characters.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("text");
        }
        init { this._rawBodyData.Set("text", value); }
    }

    public ModerationScreenParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModerationScreenParams(ModerationScreenParams moderationScreenParams)
        : base(moderationScreenParams)
    {
        this._rawBodyData = new(moderationScreenParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ModerationScreenParams(
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
    ModerationScreenParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ModerationScreenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ModerationScreenParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/moderation/screen")
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
