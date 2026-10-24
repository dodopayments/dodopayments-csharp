using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements.Translations;
using DodoPayments.Client.Models.Misc;

namespace DodoPayments.Client.Tests.Models.Entitlements.Translations;

public class EntitlementTranslationsListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationMessage = "activation_message",
                    Description = "description",
                    Instructions = "instructions",
                    Name = "name",
                },
            ],
        };

        List<EntitlementTranslation> expectedItems =
        [
            new()
            {
                Locale = Locale.Ar,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationMessage = "activation_message",
                Description = "description",
                Instructions = "instructions",
                Name = "name",
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
        var model = new EntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationMessage = "activation_message",
                    Description = "description",
                    Instructions = "instructions",
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementTranslationsListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationMessage = "activation_message",
                    Description = "description",
                    Instructions = "instructions",
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementTranslationsListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EntitlementTranslation> expectedItems =
        [
            new()
            {
                Locale = Locale.Ar,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationMessage = "activation_message",
                Description = "description",
                Instructions = "instructions",
                Name = "name",
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
        var model = new EntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationMessage = "activation_message",
                    Description = "description",
                    Instructions = "instructions",
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementTranslationsListResponse
        {
            Items =
            [
                new()
                {
                    Locale = Locale.Ar,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationMessage = "activation_message",
                    Description = "description",
                    Instructions = "instructions",
                    Name = "name",
                },
            ],
        };

        EntitlementTranslationsListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
