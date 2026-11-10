using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using Invoices = DodoPayments.Client.Models.Invoices;

namespace DodoPayments.Client.Tests.Models.Invoices;

public class InvoiceUpdateDunningParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Invoices::InvoiceUpdateDunningParams
        {
            InvoiceID = "invoice_id",
            Action = Invoices::Action.Pause,
            IfMatch = "If-Match",
            OffsetsDays = [0],
        };

        string expectedInvoiceID = "invoice_id";
        ApiEnum<string, Invoices::Action> expectedAction = Invoices::Action.Pause;
        string expectedIfMatch = "If-Match";
        List<int> expectedOffsetsDays = [0];

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedAction, parameters.Action);
        Assert.Equal(expectedIfMatch, parameters.IfMatch);
        Assert.NotNull(parameters.OffsetsDays);
        Assert.Equal(expectedOffsetsDays.Count, parameters.OffsetsDays.Count);
        for (int i = 0; i < expectedOffsetsDays.Count; i++)
        {
            Assert.Equal(expectedOffsetsDays[i], parameters.OffsetsDays[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Invoices::InvoiceUpdateDunningParams
        {
            InvoiceID = "invoice_id",
            Action = Invoices::Action.Pause,
            IfMatch = "If-Match",
        };

        Assert.Null(parameters.OffsetsDays);
        Assert.False(parameters.RawBodyData.ContainsKey("offsets_days"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Invoices::InvoiceUpdateDunningParams
        {
            InvoiceID = "invoice_id",
            Action = Invoices::Action.Pause,
            IfMatch = "If-Match",

            OffsetsDays = null,
        };

        Assert.Null(parameters.OffsetsDays);
        Assert.True(parameters.RawBodyData.ContainsKey("offsets_days"));
    }

    [Fact]
    public void Url_Works()
    {
        Invoices::InvoiceUpdateDunningParams parameters = new()
        {
            InvoiceID = "invoice_id",
            Action = Invoices::Action.Pause,
            IfMatch = "If-Match",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/billing/invoices/invoice_id/dunning"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Invoices::InvoiceUpdateDunningParams parameters = new()
        {
            InvoiceID = "invoice_id",
            Action = Invoices::Action.Pause,
            IfMatch = "If-Match",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { BearerToken = "My Bearer Token" });

        Assert.Equal(["If-Match"], requestMessage.Headers.GetValues("If-Match"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Invoices::InvoiceUpdateDunningParams
        {
            InvoiceID = "invoice_id",
            Action = Invoices::Action.Pause,
            IfMatch = "If-Match",
            OffsetsDays = [0],
        };

        Invoices::InvoiceUpdateDunningParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Invoices::Action.Pause)]
    [InlineData(Invoices::Action.Resume)]
    [InlineData(Invoices::Action.Reschedule)]
    public void Validation_Works(Invoices::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::Action.Pause)]
    [InlineData(Invoices::Action.Resume)]
    [InlineData(Invoices::Action.Reschedule)]
    public void SerializationRoundtrip_Works(Invoices::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
