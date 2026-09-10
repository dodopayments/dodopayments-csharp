using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Emails;

[JsonConverter(typeof(JsonModelConverter<EmailBody, EmailBodyFromRaw>))]
public sealed record class EmailBody : JsonModel
{
    /// <summary>
    /// Whether the merchant wrote this content. It is true for the recovery and dunning
    /// emails, which the merchant writes.
    ///
    /// <para>The content is email HTML. Render it in a sandbox, whatever this value is.</para>
    /// </summary>
    public required bool MerchantAuthored
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("merchant_authored");
        }
        init { this._rawData.Set("merchant_authored", value); }
    }

    /// <summary>
    /// Why the email did not arrive. It is null unless the email failed.
    /// </summary>
    public ApiEnum<string, EmailFailureCode>? FailureCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EmailFailureCode>>(
                "failure_code"
            );
        }
        init { this._rawData.Set("failure_code", value); }
    }

    /// <summary>
    /// A sentence that explains `failure_code`. It is null unless the email failed.
    /// </summary>
    public string? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failure_reason");
        }
        init { this._rawData.Set("failure_reason", value); }
    }

    /// <summary>
    /// The stored HTML. It is null on a text-only email.
    /// </summary>
    public string? Html
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("html");
        }
        init { this._rawData.Set("html", value); }
    }

    /// <summary>
    /// The stored plain text.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MerchantAuthored;
        this.FailureCode?.Validate();
        _ = this.FailureReason;
        _ = this.Html;
        _ = this.Text;
    }

    public EmailBody() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBody(EmailBody emailBody)
        : base(emailBody) { }
#pragma warning restore CS8618

    public EmailBody(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBody(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailBodyFromRaw.FromRawUnchecked"/>
    public static EmailBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailBody(bool merchantAuthored)
        : this()
    {
        this.MerchantAuthored = merchantAuthored;
    }
}

class EmailBodyFromRaw : IFromRawJson<EmailBody>
{
    /// <inheritdoc/>
    public EmailBody FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailBody.FromRawUnchecked(rawData);
}
