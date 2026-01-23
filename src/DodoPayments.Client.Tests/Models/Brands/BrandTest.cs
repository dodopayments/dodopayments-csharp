using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
            Description = "description",
            Image = "image",
            Name = "name",
            ReasonForHold = "reason_for_hold",
            SupportEmail = "support_email",
            Url = "url",
        };

        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        bool expectedEnabled = true;
        string expectedStatementDescriptor = "statement_descriptor";
        bool expectedVerificationEnabled = true;
        ApiEnum<string, VerificationStatus> expectedVerificationStatus = VerificationStatus.Success;
        string expectedDescription = "description";
        string expectedImage = "image";
        string expectedName = "name";
        string expectedReasonForHold = "reason_for_hold";
        string expectedSupportEmail = "support_email";
        string expectedUrl = "url";

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedStatementDescriptor, model.StatementDescriptor);
        Assert.Equal(expectedVerificationEnabled, model.VerificationEnabled);
        Assert.Equal(expectedVerificationStatus, model.VerificationStatus);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedImage, model.Image);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedReasonForHold, model.ReasonForHold);
        Assert.Equal(expectedSupportEmail, model.SupportEmail);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
            Description = "description",
            Image = "image",
            Name = "name",
            ReasonForHold = "reason_for_hold",
            SupportEmail = "support_email",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
            Description = "description",
            Image = "image",
            Name = "name",
            ReasonForHold = "reason_for_hold",
            SupportEmail = "support_email",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        bool expectedEnabled = true;
        string expectedStatementDescriptor = "statement_descriptor";
        bool expectedVerificationEnabled = true;
        ApiEnum<string, VerificationStatus> expectedVerificationStatus = VerificationStatus.Success;
        string expectedDescription = "description";
        string expectedImage = "image";
        string expectedName = "name";
        string expectedReasonForHold = "reason_for_hold";
        string expectedSupportEmail = "support_email";
        string expectedUrl = "url";

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedStatementDescriptor, deserialized.StatementDescriptor);
        Assert.Equal(expectedVerificationEnabled, deserialized.VerificationEnabled);
        Assert.Equal(expectedVerificationStatus, deserialized.VerificationStatus);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedImage, deserialized.Image);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedReasonForHold, deserialized.ReasonForHold);
        Assert.Equal(expectedSupportEmail, deserialized.SupportEmail);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
            Description = "description",
            Image = "image",
            Name = "name",
            ReasonForHold = "reason_for_hold",
            SupportEmail = "support_email",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ReasonForHold);
        Assert.False(model.RawData.ContainsKey("reason_for_hold"));
        Assert.Null(model.SupportEmail);
        Assert.False(model.RawData.ContainsKey("support_email"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,

            Description = null,
            Image = null,
            Name = null,
            ReasonForHold = null,
            SupportEmail = null,
            Url = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Image);
        Assert.True(model.RawData.ContainsKey("image"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.ReasonForHold);
        Assert.True(model.RawData.ContainsKey("reason_for_hold"));
        Assert.Null(model.SupportEmail);
        Assert.True(model.RawData.ContainsKey("support_email"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,

            Description = null,
            Image = null,
            Name = null,
            ReasonForHold = null,
            SupportEmail = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
            Description = "description",
            Image = "image",
            Name = "name",
            ReasonForHold = "reason_for_hold",
            SupportEmail = "support_email",
            Url = "url",
        };

        Brand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerificationStatusTest : TestBase
{
    [Theory]
    [InlineData(VerificationStatus.Success)]
    [InlineData(VerificationStatus.Fail)]
    [InlineData(VerificationStatus.Review)]
    [InlineData(VerificationStatus.Hold)]
    public void Validation_Works(VerificationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerificationStatus.Success)]
    [InlineData(VerificationStatus.Fail)]
    [InlineData(VerificationStatus.Review)]
    [InlineData(VerificationStatus.Hold)]
    public void SerializationRoundtrip_Works(VerificationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerificationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerificationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerificationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerificationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
