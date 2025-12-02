using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : ModelBase
{
    public required string BrandID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    public required string BusinessID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "business_id"); }
        init { ModelBase.Set(this._rawData, "business_id", value); }
    }

    public required bool Enabled
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "enabled"); }
        init { ModelBase.Set(this._rawData, "enabled", value); }
    }

    public required string StatementDescriptor
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "statement_descriptor"); }
        init { ModelBase.Set(this._rawData, "statement_descriptor", value); }
    }

    public required bool VerificationEnabled
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "verification_enabled"); }
        init { ModelBase.Set(this._rawData, "verification_enabled", value); }
    }

    public required ApiEnum<string, VerificationStatus> VerificationStatus
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, VerificationStatus>>(
                this.RawData,
                "verification_status"
            );
        }
        init { ModelBase.Set(this._rawData, "verification_status", value); }
    }

    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public string? Image
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "image"); }
        init { ModelBase.Set(this._rawData, "image", value); }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Incase the brand verification fails or is put on hold
    /// </summary>
    public string? ReasonForHold
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason_for_hold"); }
        init { ModelBase.Set(this._rawData, "reason_for_hold", value); }
    }

    public string? SupportEmail
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "support_email"); }
        init { ModelBase.Set(this._rawData, "support_email", value); }
    }

    public string? URL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

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
        _ = this.URL;
    }

    public Brand() { }

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandFromRaw : IFromRaw<Brand>
{
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
