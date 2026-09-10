using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;

namespace DodoPayments.Client.Models.Customers.Emails;

[JsonConverter(typeof(JsonModelConverter<EmailListPageResponse, EmailListPageResponseFromRaw>))]
public sealed record class EmailListPageResponse : JsonModel
{
    /// <summary>
    /// This page of emails, newest first.
    /// </summary>
    public required IReadOnlyList<EmailLogItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailLogItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EmailLogItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How many emails this customer has in the last 180 days, across pages.
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public EmailListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailListPageResponse(EmailListPageResponse emailListPageResponse)
        : base(emailListPageResponse) { }
#pragma warning restore CS8618

    public EmailListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailListPageResponseFromRaw : IFromRawJson<EmailListPageResponse>
{
    /// <inheritdoc/>
    public EmailListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailListPageResponse.FromRawUnchecked(rawData);
}
