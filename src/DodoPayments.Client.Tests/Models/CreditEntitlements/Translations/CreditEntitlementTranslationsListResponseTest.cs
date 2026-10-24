using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.CreditEntitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.CreditEntitlements.Translations;

public class CreditEntitlementTranslationsListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditEntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Unit = "unit",
                },
            ],
        };

        List<CreditEntitlementTranslation> expectedItems =
        [
            new()
            {
                Locale = Locale.Ar,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                Unit = "unit",
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
        var model = new CreditEntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Unit = "unit",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementTranslationsListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditEntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Unit = "unit",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditEntitlementTranslationsListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CreditEntitlementTranslation> expectedItems =
        [
            new()
            {
                Locale = Locale.Ar,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
                Unit = "unit",
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
        var model = new CreditEntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Unit = "unit",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditEntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                    Unit = "unit",
                },
            ],
        };

        CreditEntitlementTranslationsListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
