using System;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Balances;

namespace DodoPayments.Client.Tests.Models.Balances;

public class BalanceRetrieveLedgerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceRetrieveLedgerParams
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            EventType = EventType.Payment,
            Limit = 0,
            PageNumber = 0,
            PageSize = 0,
            ReferenceObjectID = "reference_object_id",
        };

        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Currency> expectedCurrency = Currency.Aed;
        ApiEnum<string, EventType> expectedEventType = EventType.Payment;
        long expectedLimit = 0;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;
        string expectedReferenceObjectID = "reference_object_id";

        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedReferenceObjectID, parameters.ReferenceObjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceRetrieveLedgerParams { };

        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("event_type"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.ReferenceObjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BalanceRetrieveLedgerParams
        {
            // Null should be interpreted as omitted for these properties
            CreatedAtGte = null,
            CreatedAtLte = null,
            Currency = null,
            EventType = null,
            Limit = null,
            PageNumber = null,
            PageSize = null,
            ReferenceObjectID = null,
        };

        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_gte"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_lte"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("event_type"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.ReferenceObjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("reference_object_id"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceRetrieveLedgerParams parameters = new()
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            EventType = EventType.Payment,
            Limit = 0,
            PageNumber = 0,
            PageSize = 0,
            ReferenceObjectID = "reference_object_id",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://live.dodopayments.com/balances/ledger?created_at_gte=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_lte=2019-12-27T18%3a11%3a19.117%2b00%3a00&currency=AED&event_type=payment&limit=0&page_number=0&page_size=0&reference_object_id=reference_object_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceRetrieveLedgerParams
        {
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = Currency.Aed,
            EventType = EventType.Payment,
            Limit = 0,
            PageNumber = 0,
            PageSize = 0,
            ReferenceObjectID = "reference_object_id",
        };

        BalanceRetrieveLedgerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aoa)]
    [InlineData(Currency.Ars)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bhd)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bob)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Cop)]
    [InlineData(Currency.Crc)]
    [InlineData(Currency.Cup)]
    [InlineData(Currency.Cve)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Fkp)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Ghs)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Gtq)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hnl)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Huf)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Iqd)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jod)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kwd)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lak)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Lyd)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mru)]
    [InlineData(Currency.Mur)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nio)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Omr)]
    [InlineData(Currency.Pab)]
    [InlineData(Currency.Pen)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Shp)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Srd)]
    [InlineData(Currency.Ssp)]
    [InlineData(Currency.Stn)]
    [InlineData(Currency.Svc)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tnd)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Twd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Uyu)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Ves)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    public void Validation_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aoa)]
    [InlineData(Currency.Ars)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bhd)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bob)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Cop)]
    [InlineData(Currency.Crc)]
    [InlineData(Currency.Cup)]
    [InlineData(Currency.Cve)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Fkp)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Ghs)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Gtq)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hnl)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Huf)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Iqd)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jod)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kwd)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lak)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Lyd)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mru)]
    [InlineData(Currency.Mur)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nio)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Omr)]
    [InlineData(Currency.Pab)]
    [InlineData(Currency.Pen)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Shp)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Srd)]
    [InlineData(Currency.Ssp)]
    [InlineData(Currency.Stn)]
    [InlineData(Currency.Svc)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tnd)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Twd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Uyu)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Ves)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    public void SerializationRoundtrip_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.Payment)]
    [InlineData(EventType.Refund)]
    [InlineData(EventType.RefundReversal)]
    [InlineData(EventType.Dispute)]
    [InlineData(EventType.DisputeReversal)]
    [InlineData(EventType.Tax)]
    [InlineData(EventType.TaxReversal)]
    [InlineData(EventType.PaymentFees)]
    [InlineData(EventType.RefundFees)]
    [InlineData(EventType.RefundFeesReversal)]
    [InlineData(EventType.DisputeFees)]
    [InlineData(EventType.Payout)]
    [InlineData(EventType.PayoutFees)]
    [InlineData(EventType.PayoutReversal)]
    [InlineData(EventType.PayoutFeesReversal)]
    [InlineData(EventType.DodoCredits)]
    [InlineData(EventType.Adjustment)]
    [InlineData(EventType.CurrencyConversion)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.Payment)]
    [InlineData(EventType.Refund)]
    [InlineData(EventType.RefundReversal)]
    [InlineData(EventType.Dispute)]
    [InlineData(EventType.DisputeReversal)]
    [InlineData(EventType.Tax)]
    [InlineData(EventType.TaxReversal)]
    [InlineData(EventType.PaymentFees)]
    [InlineData(EventType.RefundFees)]
    [InlineData(EventType.RefundFeesReversal)]
    [InlineData(EventType.DisputeFees)]
    [InlineData(EventType.Payout)]
    [InlineData(EventType.PayoutFees)]
    [InlineData(EventType.PayoutReversal)]
    [InlineData(EventType.PayoutFeesReversal)]
    [InlineData(EventType.DodoCredits)]
    [InlineData(EventType.Adjustment)]
    [InlineData(EventType.CurrencyConversion)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
