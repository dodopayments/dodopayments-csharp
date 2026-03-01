using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements;
using DodoPayments.Client.Models.Misc;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements;

public class CreditEntitlementListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    Precision = 0,
                    RolloverEnabled = true,
                    Unit = "unit",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Description = "description",
                    ExpiresAfterDays = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = 0,
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
        };

        List<CreditEntitlement> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                OverageEnabled = true,
                Precision = 0,
                RolloverEnabled = true,
                Unit = "unit",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Description = "description",
                ExpiresAfterDays = 0,
                MaxRolloverCount = 0,
                OverageLimit = 0,
                PricePerUnit = "price_per_unit",
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
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
        var model = new CreditEntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    Precision = 0,
                    RolloverEnabled = true,
                    Unit = "unit",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Description = "description",
                    ExpiresAfterDays = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = 0,
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    Precision = 0,
                    RolloverEnabled = true,
                    Unit = "unit",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Description = "description",
                    ExpiresAfterDays = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = 0,
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CreditEntitlement> expectedItems =
        [
            new()
            {
                ID = "id",
                BusinessID = "business_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                OverageEnabled = true,
                Precision = 0,
                RolloverEnabled = true,
                Unit = "unit",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = Currency.Aed,
                Description = "description",
                ExpiresAfterDays = 0,
                MaxRolloverCount = 0,
                OverageLimit = 0,
                PricePerUnit = "price_per_unit",
                RolloverPercentage = 0,
                RolloverTimeframeCount = 0,
                RolloverTimeframeInterval = TimeInterval.Day,
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
        var model = new CreditEntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    Precision = 0,
                    RolloverEnabled = true,
                    Unit = "unit",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Description = "description",
                    ExpiresAfterDays = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = 0,
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditEntitlementListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    BusinessID = "business_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    OverageBehavior = CbbOverageBehavior.ForgiveAtReset,
                    OverageEnabled = true,
                    Precision = 0,
                    RolloverEnabled = true,
                    Unit = "unit",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = Currency.Aed,
                    Description = "description",
                    ExpiresAfterDays = 0,
                    MaxRolloverCount = 0,
                    OverageLimit = 0,
                    PricePerUnit = "price_per_unit",
                    RolloverPercentage = 0,
                    RolloverTimeframeCount = 0,
                    RolloverTimeframeInterval = TimeInterval.Day,
                },
            ],
        };

        CreditEntitlementListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
