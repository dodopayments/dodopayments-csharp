using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.ProductCollections.Groups;
using DodoPayments.Client.Models.ProductCollections.Groups.Items;
using DodoPayments.Client.Models.Products;

namespace DodoPayments.Client.Tests.Models.ProductCollections.Groups;

public class ProductCollectionGroupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
            GroupName = "group_name",
        };

        string expectedGroupID = "group_id";
        List<ProductCollectionProduct> expectedProducts =
        [
            new()
            {
                ID = "id",
                AddonsCount = 0,
                FilesCount = 0,
                HasCreditEntitlements = true,
                IsRecurring = true,
                LicenseKeyEnabled = true,
                MetersCount = 0,
                ProductID = "product_id",
                Status = true,
                Currency = Currency.Aed,
                Description = "description",
                Name = "name",
                Price = 0,
                PriceDetail = new OneTimePrice()
                {
                    Currency = Currency.Aed,
                    Discount = 0,
                    PriceValue = 0,
                    PurchasingPowerParity = true,
                    PayWhatYouWant = true,
                    SuggestedPrice = 0,
                    TaxInclusive = true,
                },
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
            },
        ];
        bool expectedStatus = true;
        string expectedGroupName = "group_name";

        Assert.Equal(expectedGroupID, model.GroupID);
        Assert.Equal(expectedProducts.Count, model.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], model.Products[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedGroupName, model.GroupName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
            GroupName = "group_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionGroupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
            GroupName = "group_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCollectionGroupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedGroupID = "group_id";
        List<ProductCollectionProduct> expectedProducts =
        [
            new()
            {
                ID = "id",
                AddonsCount = 0,
                FilesCount = 0,
                HasCreditEntitlements = true,
                IsRecurring = true,
                LicenseKeyEnabled = true,
                MetersCount = 0,
                ProductID = "product_id",
                Status = true,
                Currency = Currency.Aed,
                Description = "description",
                Name = "name",
                Price = 0,
                PriceDetail = new OneTimePrice()
                {
                    Currency = Currency.Aed,
                    Discount = 0,
                    PriceValue = 0,
                    PurchasingPowerParity = true,
                    PayWhatYouWant = true,
                    SuggestedPrice = 0,
                    TaxInclusive = true,
                },
                TaxCategory = TaxCategory.DigitalProducts,
                TaxInclusive = true,
            },
        ];
        bool expectedStatus = true;
        string expectedGroupName = "group_name";

        Assert.Equal(expectedGroupID, deserialized.GroupID);
        Assert.Equal(expectedProducts.Count, deserialized.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], deserialized.Products[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedGroupName, deserialized.GroupName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
            GroupName = "group_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
        };

        Assert.Null(model.GroupName);
        Assert.False(model.RawData.ContainsKey("group_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,

            GroupName = null,
        };

        Assert.Null(model.GroupName);
        Assert.True(model.RawData.ContainsKey("group_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,

            GroupName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCollectionGroupResponse
        {
            GroupID = "group_id",
            Products =
            [
                new()
                {
                    ID = "id",
                    AddonsCount = 0,
                    FilesCount = 0,
                    HasCreditEntitlements = true,
                    IsRecurring = true,
                    LicenseKeyEnabled = true,
                    MetersCount = 0,
                    ProductID = "product_id",
                    Status = true,
                    Currency = Currency.Aed,
                    Description = "description",
                    Name = "name",
                    Price = 0,
                    PriceDetail = new OneTimePrice()
                    {
                        Currency = Currency.Aed,
                        Discount = 0,
                        PriceValue = 0,
                        PurchasingPowerParity = true,
                        PayWhatYouWant = true,
                        SuggestedPrice = 0,
                        TaxInclusive = true,
                    },
                    TaxCategory = TaxCategory.DigitalProducts,
                    TaxInclusive = true,
                },
            ],
            Status = true,
            GroupName = "group_name",
        };

        ProductCollectionGroupResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
