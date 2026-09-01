using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers;

public class CreateBlockedCustomerRequestTest : TestBase
{
    [Fact]
    public void BlocklistCustomersBlockByCustomerIDValidationWorks()
    {
        CreateBlockedCustomerRequest value = new BlocklistCustomersBlockByCustomerID()
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };
        value.Validate();
    }

    [Fact]
    public void BlocklistCustomersBlockByEmailValidationWorks()
    {
        CreateBlockedCustomerRequest value = new BlocklistCustomersBlockByEmail()
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };
        value.Validate();
    }

    [Fact]
    public void BlocklistCustomersBlockByCustomerIDSerializationRoundtripWorks()
    {
        CreateBlockedCustomerRequest value = new BlocklistCustomersBlockByCustomerID()
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateBlockedCustomerRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BlocklistCustomersBlockByEmailSerializationRoundtripWorks()
    {
        CreateBlockedCustomerRequest value = new BlocklistCustomersBlockByEmail()
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateBlockedCustomerRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BlocklistCustomersBlockByCustomerIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string expectedCustomerID = "customer_id";
        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlocklistCustomersBlockByCustomerID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlocklistCustomersBlockByCustomerID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customer_id";
        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
        };

        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Source = null,
        };

        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Source = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Source = BlockedCustomerSource.BlocklistPage,

            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Source = BlockedCustomerSource.BlocklistPage,

            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlocklistCustomersBlockByCustomerID
        {
            CustomerID = "customer_id",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        BlocklistCustomersBlockByCustomerID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1 { Reason = null, Source = null };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1 { Reason = null, Source = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlocklistCustomersBlockByEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string expectedEmail = "email";
        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlocklistCustomersBlockByEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlocklistCustomersBlockByEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";
        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByEmail { Email = "email", Reason = "reason" };

        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlocklistCustomersBlockByEmail { Email = "email", Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Source = null,
        };

        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Source = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Source = BlockedCustomerSource.BlocklistPage,

            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Source = BlockedCustomerSource.BlocklistPage,

            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlocklistCustomersBlockByEmail
        {
            Email = "email",
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        BlocklistCustomersBlockByEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlocklistCustomersBlockByEmailIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BlocklistCustomersBlockByEmailIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BlocklistCustomersBlockByEmailIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedReason = "reason";
        ApiEnum<string, BlockedCustomerSource> expectedSource = BlockedCustomerSource.BlocklistPage;

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1 { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = null,
            Source = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = null,
            Source = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlocklistCustomersBlockByEmailIntersectionMember1
        {
            Reason = "reason",
            Source = BlockedCustomerSource.BlocklistPage,
        };

        BlocklistCustomersBlockByEmailIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
