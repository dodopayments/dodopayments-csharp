using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Emails;

/// <summary>
/// What the merchant may do with one row. The server decides; the client never derives
/// eligibility itself.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailPolicies, EmailPoliciesFromRaw>))]
public sealed record class EmailPolicies : JsonModel
{
    /// <summary>
    /// A permanent failure was recorded, so the same address would be a no-op.
    /// </summary>
    public required bool RequiresDifferentAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("requires_different_address");
        }
        init { this._rawData.Set("requires_different_address", value); }
    }

    /// <summary>
    /// The row was delivered and may be sent again.
    /// </summary>
    public required bool ResendAllowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("resend_allowed");
        }
        init { this._rawData.Set("resend_allowed", value); }
    }

    /// <summary>
    /// How many sends are left in this email's chain.
    /// </summary>
    public required long ResendsRemaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("resends_remaining");
        }
        init { this._rawData.Set("resends_remaining", value); }
    }

    /// <summary>
    /// The row failed and may be sent again.
    /// </summary>
    public required bool RetryAllowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("retry_allowed");
        }
        init { this._rawData.Set("retry_allowed", value); }
    }

    /// <summary>
    /// A later send of this email replaced this row, so this row is history. A row
    /// that never went out needs a later send that reached the provider. A failed
    /// row needs a later send that was delivered.
    /// </summary>
    public required bool Superseded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("superseded");
        }
        init { this._rawData.Set("superseded", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequiresDifferentAddress;
        _ = this.ResendAllowed;
        _ = this.ResendsRemaining;
        _ = this.RetryAllowed;
        _ = this.Superseded;
    }

    public EmailPolicies() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailPolicies(EmailPolicies emailPolicies)
        : base(emailPolicies) { }
#pragma warning restore CS8618

    public EmailPolicies(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailPolicies(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailPoliciesFromRaw.FromRawUnchecked"/>
    public static EmailPolicies FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailPoliciesFromRaw : IFromRawJson<EmailPolicies>
{
    /// <inheritdoc/>
    public EmailPolicies FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailPolicies.FromRawUnchecked(rawData);
}
