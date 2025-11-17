using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using System = System;

namespace DodoPayments.Client.Models.Subscriptions;

public sealed record class SubscriptionUpdatePaymentMethodParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string SubscriptionID { get; init; }

    public required Body Body
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("body", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentNullException("body")
                );
        }
        init
        {
            this._bodyProperties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionUpdatePaymentMethodParams() { }

    public SubscriptionUpdatePaymentMethodParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUpdatePaymentMethodParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionUpdatePaymentMethodParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update-payment-method", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(BodyConverter))]
public record class Body
{
    public object Value { get; private init; }

    public Body(New value)
    {
        Value = value;
    }

    public Body(Existing value)
    {
        Value = value;
    }

    Body(UnknownVariant value)
    {
        Value = value;
    }

    public static Body CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickNew([NotNullWhen(true)] out New? value)
    {
        value = this.Value as New;
        return value != null;
    }

    public bool TryPickExisting([NotNullWhen(true)] out Existing? value)
    {
        value = this.Value as Existing;
        return value != null;
    }

    public void Switch(System::Action<New> new1, System::Action<Existing> existing)
    {
        switch (this.Value)
        {
            case New value:
                new1(value);
                break;
            case Existing value:
                existing(value);
                break;
            default:
                throw new DodoPaymentsInvalidDataException(
                    "Data did not match any variant of Body"
                );
        }
    }

    public T Match<T>(System::Func<New, T> new1, System::Func<Existing, T> existing)
    {
        return this.Value switch
        {
            New value => new1(value),
            Existing value => existing(value),
            _ => throw new DodoPaymentsInvalidDataException(
                "Data did not match any variant of Body"
            ),
        };
    }

    public static implicit operator Body(New value) => new(value);

    public static implicit operator Body(Existing value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new DodoPaymentsInvalidDataException("Data did not match any variant of Body");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<DodoPaymentsInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<New>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Body(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException("Data does not match union variant 'New'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Existing>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Body(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is DodoPaymentsInvalidDataException)
        {
            exceptions.Add(
                new DodoPaymentsInvalidDataException(
                    "Data does not match union variant 'Existing'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<New>))]
public sealed record class New : ModelBase, IFromRaw<New>
{
    public required ApiEnum<string, global::DodoPayments.Client.Models.Subscriptions.Type> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::DodoPayments.Client.Models.Subscriptions.Type>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ReturnURL
    {
        get
        {
            if (!this._properties.TryGetValue("return_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["return_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ReturnURL;
    }

    public New() { }

    public New(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    New(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static New FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public New(ApiEnum<string, global::DodoPayments.Client.Models.Subscriptions.Type> type)
        : this()
    {
        this.Type = type;
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    New,
}

sealed class TypeConverter : JsonConverter<global::DodoPayments.Client.Models.Subscriptions.Type>
{
    public override global::DodoPayments.Client.Models.Subscriptions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "new" => global::DodoPayments.Client.Models.Subscriptions.Type.New,
            _ => (global::DodoPayments.Client.Models.Subscriptions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DodoPayments.Client.Models.Subscriptions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DodoPayments.Client.Models.Subscriptions.Type.New => "new",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Existing>))]
public sealed record class Existing : ModelBase, IFromRaw<Existing>
{
    public required string PaymentMethodID
    {
        get
        {
            if (!this._properties.TryGetValue("payment_method_id", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'payment_method_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "payment_method_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DodoPaymentsInvalidDataException(
                    "'payment_method_id' cannot be null",
                    new System::ArgumentNullException("payment_method_id")
                );
        }
        init
        {
            this._properties["payment_method_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, ExistingType> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new DodoPaymentsInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ExistingType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PaymentMethodID;
        this.Type.Validate();
    }

    public Existing() { }

    public Existing(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Existing(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Existing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ExistingTypeConverter))]
public enum ExistingType
{
    Existing,
}

sealed class ExistingTypeConverter : JsonConverter<ExistingType>
{
    public override ExistingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "existing" => ExistingType.Existing,
            _ => (ExistingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExistingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExistingType.Existing => "existing",
                _ => throw new DodoPaymentsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
