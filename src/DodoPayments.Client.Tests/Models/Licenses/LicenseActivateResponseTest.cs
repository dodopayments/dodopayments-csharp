using System;
using System.Collections.Generic;
using DodoPayments.Client.Models.Licenses;
using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Licenses;

public class LicenseActivateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseActivateResponse
        {
            ID = "lki_123",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            Customer = new()
            {
                CustomerID = "customer_id",
                Email = "email",
                Name = "name",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PhoneNumber = "phone_number",
            },
            LicenseKeyID = "lic_123",
            Name = "Production Server 1",
            Product = new() { ProductID = "product_id", Name = "name" },
        };

        string expectedID = "lki_123";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        CustomerLimitedDetails expectedCustomer = new()
        {
            CustomerID = "customer_id",
            Email = "email",
            Name = "name",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PhoneNumber = "phone_number",
        };
        string expectedLicenseKeyID = "lic_123";
        string expectedName = "Production Server 1";
        Product expectedProduct = new() { ProductID = "product_id", Name = "name" };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedLicenseKeyID, model.LicenseKeyID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProduct, model.Product);
    }
}

public class ProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Product { ProductID = "product_id", Name = "name" };

        string expectedProductID = "product_id";
        string expectedName = "name";

        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedName, model.Name);
    }
}
