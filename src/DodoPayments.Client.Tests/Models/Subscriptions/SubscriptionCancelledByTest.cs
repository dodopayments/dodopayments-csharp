using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Subscriptions;

public class SubscriptionCancelledByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,
            Email = "email",
            Name = "name",
        };

        ApiEnum<string, ActorType> expectedActorType = ActorType.Customer;
        string expectedEmail = "email";
        string expectedName = "name";

        Assert.Equal(expectedActorType, model.ActorType);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,
            Email = "email",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCancelledBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,
            Email = "email",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCancelledBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ActorType> expectedActorType = ActorType.Customer;
        string expectedEmail = "email";
        string expectedName = "name";

        Assert.Equal(expectedActorType, deserialized.ActorType);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,
            Email = "email",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionCancelledBy { ActorType = ActorType.Customer };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionCancelledBy { ActorType = ActorType.Customer };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,

            Email = null,
            Name = null,
        };

        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,

            Email = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionCancelledBy
        {
            ActorType = ActorType.Customer,
            Email = "email",
            Name = "name",
        };

        SubscriptionCancelledBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActorTypeTest : TestBase
{
    [Theory]
    [InlineData(ActorType.Customer)]
    [InlineData(ActorType.MerchantUser)]
    [InlineData(ActorType.ApiKey)]
    [InlineData(ActorType.DodoTeam)]
    public void Validation_Works(ActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ActorType.Customer)]
    [InlineData(ActorType.MerchantUser)]
    [InlineData(ActorType.ApiKey)]
    [InlineData(ActorType.DodoTeam)]
    public void SerializationRoundtrip_Works(ActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ActorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
