using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
{
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
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

    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    public required string StatementDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statement_descriptor");
        }
        init { this._rawData.Set("statement_descriptor", value); }
    }

    public required bool VerificationEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verification_enabled");
        }
        init { this._rawData.Set("verification_enabled", value); }
    }

    public required ApiEnum<string, VerificationStatus> VerificationStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerificationStatus>>(
                "verification_status"
            );
        }
        init { this._rawData.Set("verification_status", value); }
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

    public string? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image");
        }
        init { this._rawData.Set("image", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Incase the brand verification fails or is put on hold
    /// </summary>
    public string? ReasonForHold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason_for_hold");
        }
        init { this._rawData.Set("reason_for_hold", value); }
    }

    public string? SupportEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("support_email");
        }
        init { this._rawData.Set("support_email", value); }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.BusinessID;
        _ = this.Enabled;
        _ = this.StatementDescriptor;
        _ = this.VerificationEnabled;
        this.VerificationStatus.Validate();
        _ = this.Description;
        _ = this.Image;
        _ = this.Name;
        _ = this.ReasonForHold;
        _ = this.SupportEmail;
        _ = this.Url;
    }

    public Brand() { }

    public Brand(Brand brand)
        : base(brand) { }

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(VerificationStatusConverter))]
public enum VerificationStatus
{
    Success,
    Fail,
    Review,
    Hold,
}

sealed class VerificationStatusConverter : JsonConverter<VerificationStatus>
{
    public override VerificationStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Success" => VerificationStatus.Success,
            "Fail" => VerificationStatus.Fail,
            "Review" => VerificationStatus.Review,
            "Hold" => VerificationStatus.Hold,
            _ => (VerificationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerificationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerificationStatus.Success => "Success",
                VerificationStatus.Fail => "Fail",
                VerificationStatus.Review => "Review",
                VerificationStatus.Hold => "Hold",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
