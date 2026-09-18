using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Emails;

[JsonConverter(typeof(JsonModelConverter<EmailLogItem, EmailLogItemFromRaw>))]
public sealed record class EmailLogItem : JsonModel
{
    /// <summary>
    /// The group this email belongs to: payments, refunds, subscriptions, dunning_recovery,
    /// entitlements or auth.
    /// </summary>
    public required string Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// When this email was sent.
    /// </summary>
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
    /// Identifies this email. Use it to read the body or to send it again.
    /// </summary>
    public required string EmailLogID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email_log_id");
        }
        init { this._rawData.Set("email_log_id", value); }
    }

    /// <summary>
    /// What kind of email this is, for example `payment_successful`.
    /// </summary>
    public required string EmailType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email_type");
        }
        init { this._rawData.Set("email_type", value); }
    }

    /// <summary>
    /// Whether this email has content to show. The content endpoint can still refuse,
    /// because the content is removed after 180 days.
    /// </summary>
    public required bool HasPreview
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_preview");
        }
        init { this._rawData.Set("has_preview", value); }
    }

    /// <summary>
    /// What you may do with this email.
    /// </summary>
    public required EmailPolicies Policies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailPolicies>("policies");
        }
        init { this._rawData.Set("policies", value); }
    }

    /// <summary>
    /// Where the email got to: sent, delivered, failed, complained or blocked.
    /// </summary>
    public required ApiEnum<string, EmailLogStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailLogStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
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
    /// The address the email was sent from.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// The address the email reached.
    /// </summary>
    public string? Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient");
        }
        init { this._rawData.Set("recipient", value); }
    }

    /// <summary>
    /// The subject line as it was sent. Empty until the provider replicates.
    /// </summary>
    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Category;
        _ = this.CreatedAt;
        _ = this.EmailLogID;
        _ = this.EmailType;
        _ = this.HasPreview;
        this.Policies.Validate();
        this.Status.Validate();
        this.FailureCode?.Validate();
        _ = this.FailureReason;
        _ = this.From;
        _ = this.Recipient;
        _ = this.Subject;
    }

    public EmailLogItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailLogItem(EmailLogItem emailLogItem)
        : base(emailLogItem) { }
#pragma warning restore CS8618

    public EmailLogItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailLogItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailLogItemFromRaw.FromRawUnchecked"/>
    public static EmailLogItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailLogItemFromRaw : IFromRawJson<EmailLogItem>
{
    /// <inheritdoc/>
    public EmailLogItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailLogItem.FromRawUnchecked(rawData);
}
