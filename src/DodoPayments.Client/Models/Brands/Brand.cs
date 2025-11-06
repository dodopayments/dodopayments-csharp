using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Brands;

[JsonConverter(typeof(ModelConverter<Brand>))]
public sealed record class Brand : ModelBase, IFromRaw<Brand>
{
    public required string BrandID
    {
        get
        {
            if (!this._properties.TryGetValue("brand_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new System::ArgumentOutOfRangeException("brand_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'brand_id' cannot be null",
                    new System::ArgumentNullException("brand_id")
                );
        }
        init
        {
            this._properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string BusinessID
    {
        get
        {
            if (!this._properties.TryGetValue("business_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "business_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'business_id' cannot be null",
                    new System::ArgumentNullException("business_id")
                );
        }
        init
        {
            this._properties["business_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool Enabled
    {
        get
        {
            if (!this._properties.TryGetValue("enabled", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'enabled' cannot be null",
                    new System::ArgumentOutOfRangeException("enabled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string StatementDescriptor
    {
        get
        {
            if (!this._properties.TryGetValue("statement_descriptor", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'statement_descriptor' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "statement_descriptor",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'statement_descriptor' cannot be null",
                    new System::ArgumentNullException("statement_descriptor")
                );
        }
        init
        {
            this._properties["statement_descriptor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool VerificationEnabled
    {
        get
        {
            if (!this._properties.TryGetValue("verification_enabled", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'verification_enabled' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "verification_enabled",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["verification_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, VerificationStatus> VerificationStatus
    {
        get
        {
            if (!this._properties.TryGetValue("verification_status", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'verification_status' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "verification_status",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, VerificationStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["verification_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Image
    {
        get
        {
            if (!this._properties.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Incase the brand verification fails or is put on hold
    /// </summary>
    public string? ReasonForHold
    {
        get
        {
            if (!this._properties.TryGetValue("reason_for_hold", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reason_for_hold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? SupportEmail
    {
        get
        {
            if (!this._properties.TryGetValue("support_email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["support_email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? URL
    {
        get
        {
            if (!this._properties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public Brand(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
        System::Type typeToConvert,
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
