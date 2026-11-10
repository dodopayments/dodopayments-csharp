using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoicePreviewExistingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoicePreviewExistingParams
        {
            InvoiceID = "invoice_id",
            Format = InvoicePreviewExistingParamsFormat.Json,
        };

        string expectedInvoiceID = "invoice_id";
        ApiEnum<string, InvoicePreviewExistingParamsFormat> expectedFormat =
            InvoicePreviewExistingParamsFormat.Json;

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedFormat, parameters.Format);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoicePreviewExistingParams { InvoiceID = "invoice_id" };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoicePreviewExistingParams
        {
            InvoiceID = "invoice_id",

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoicePreviewExistingParams parameters = new()
        {
            InvoiceID = "invoice_id",
            Format = InvoicePreviewExistingParamsFormat.Json,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://live.dodopayments.com/billing/invoices/invoice_id/preview?format=json"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoicePreviewExistingParams
        {
            InvoiceID = "invoice_id",
            Format = InvoicePreviewExistingParamsFormat.Json,
        };

        InvoicePreviewExistingParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InvoicePreviewExistingParamsFormatTest : TestBase
{
    [Theory]
    [InlineData(InvoicePreviewExistingParamsFormat.Json)]
    [InlineData(InvoicePreviewExistingParamsFormat.Pdf)]
    [InlineData(InvoicePreviewExistingParamsFormat.Email)]
    public void Validation_Works(InvoicePreviewExistingParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoicePreviewExistingParamsFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoicePreviewExistingParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoicePreviewExistingParamsFormat.Json)]
    [InlineData(InvoicePreviewExistingParamsFormat.Pdf)]
    [InlineData(InvoicePreviewExistingParamsFormat.Email)]
    public void SerializationRoundtrip_Works(InvoicePreviewExistingParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoicePreviewExistingParamsFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoicePreviewExistingParamsFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoicePreviewExistingParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoicePreviewExistingParamsFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
