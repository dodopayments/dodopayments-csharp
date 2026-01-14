using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Disputes;

namespace DodoPayments.Client.Tests.Models.Disputes;

public class DisputeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DisputeListParams
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DisputeStage = DisputeStage.PreDispute,
            DisputeStatus = DisputeStatus.DisputeOpened,
            PageNumber = 0,
            PageSize = 0,
        };

        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        ApiEnum<string, DisputeStage> expectedDisputeStage = DisputeStage.PreDispute;
        ApiEnum<string, DisputeStatus> expectedDisputeStatus = DisputeStatus.DisputeOpened;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDisputeStage, parameters.DisputeStage);
        Assert.Equal(expectedDisputeStatus, parameters.DisputeStatus);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DisputeListParams { };

        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.DisputeStage);
        Assert.False(parameters.RawQueryData.ContainsKey("dispute_stage"));
        Assert.Null(parameters.DisputeStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("dispute_status"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DisputeListParams
        {
            // Null should be interpreted as omitted for these properties
            CreatedAtGte = null,
            CreatedAtLte = null,
            CustomerID = null,
            DisputeStage = null,
            DisputeStatus = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.DisputeStage);
        Assert.False(parameters.RawQueryData.ContainsKey("dispute_stage"));
        Assert.Null(parameters.DisputeStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("dispute_status"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void Url_Works()
    {
        DisputeListParams parameters = new()
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            DisputeStage = DisputeStage.PreDispute,
            DisputeStatus = DisputeStatus.DisputeOpened,
            PageNumber = 0,
            PageSize = 0,
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/disputes?created_at_gte=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_lte=2019-12-27T18%3a11%3a19.117%2b00%3a00&customer_id=customer_id&dispute_stage=pre_dispute&dispute_status=dispute_opened&page_number=0&page_size=0"
            ),
            url
        );
    }
}

public class DisputeStageTest : TestBase
{
    [Theory]
    [InlineData(DisputeStage.PreDispute)]
    [InlineData(DisputeStage.Dispute)]
    [InlineData(DisputeStage.PreArbitration)]
    public void Validation_Works(DisputeStage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeStage.PreDispute)]
    [InlineData(DisputeStage.Dispute)]
    [InlineData(DisputeStage.PreArbitration)]
    public void SerializationRoundtrip_Works(DisputeStage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DisputeStatusTest : TestBase
{
    [Theory]
    [InlineData(DisputeStatus.DisputeOpened)]
    [InlineData(DisputeStatus.DisputeExpired)]
    [InlineData(DisputeStatus.DisputeAccepted)]
    [InlineData(DisputeStatus.DisputeCancelled)]
    [InlineData(DisputeStatus.DisputeChallenged)]
    [InlineData(DisputeStatus.DisputeWon)]
    [InlineData(DisputeStatus.DisputeLost)]
    public void Validation_Works(DisputeStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DisputeStatus.DisputeOpened)]
    [InlineData(DisputeStatus.DisputeExpired)]
    [InlineData(DisputeStatus.DisputeAccepted)]
    [InlineData(DisputeStatus.DisputeCancelled)]
    [InlineData(DisputeStatus.DisputeChallenged)]
    [InlineData(DisputeStatus.DisputeWon)]
    [InlineData(DisputeStatus.DisputeLost)]
    public void SerializationRoundtrip_Works(DisputeStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DisputeStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DisputeStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
