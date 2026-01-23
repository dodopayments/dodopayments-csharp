using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandListResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        List<Brand> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandListResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandListResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Brand> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandListResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandListResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        BrandListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
