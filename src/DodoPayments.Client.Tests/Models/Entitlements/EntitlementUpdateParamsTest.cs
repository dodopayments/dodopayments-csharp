using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            ID = "id",
            Description = "description",
            IntegrationConfig = new EntitlementUpdateParamsIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        EntitlementUpdateParamsIntegrationConfig expectedIntegrationConfig =
            new EntitlementUpdateParamsIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedIntegrationConfig, parameters.IntegrationConfig);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementUpdateParams { ID = "id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.IntegrationConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("integration_config"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            ID = "id",

            Description = null,
            IntegrationConfig = null,
            Metadata = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.IntegrationConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("integration_config"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://live.dodopayments.com/entitlements/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            ID = "id",
            Description = "description",
            IntegrationConfig = new EntitlementUpdateParamsIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        EntitlementUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigTelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigFigmaConfig("figma_file_id");
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigFramerConfig("framer_template_id");
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigNotionConfig("notion_template_id");
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig()
            {
                DigitalFileIds = ["string"],
                ExternalUrl = "external_url",
                Instructions = "instructions",
                LegacyFileIds = ["string"],
            };
        value.Validate();
    }

    [Fact]
    public void LicenseKeyValidationWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = TimeInterval.Day,
            };
        value.Validate();
    }

    [Fact]
    public void GitHubSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigTelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigFigmaConfig("figma_file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigFramerConfig("framer_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigNotionConfig("notion_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig()
            {
                DigitalFileIds = ["string"],
                ExternalUrl = "external_url",
                Instructions = "instructions",
                LegacyFileIds = ["string"],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        EntitlementUpdateParamsIntegrationConfig value =
            new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = TimeInterval.Day,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsIntegrationConfigGitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string expectedPermission = "permission";
        string expectedTargetID = "target_id";

        Assert.Equal(expectedPermission, model.Permission);
        Assert.Equal(expectedTargetID, model.TargetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigGitHubConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigGitHubConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPermission = "permission";
        string expectedTargetID = "target_id";

        Assert.Equal(expectedPermission, deserialized.Permission);
        Assert.Equal(expectedTargetID, deserialized.TargetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        EntitlementUpdateParamsIntegrationConfigGitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigDiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string expectedGuildID = "guild_id";
        string expectedRoleID = "role_id";

        Assert.Equal(expectedGuildID, model.GuildID);
        Assert.Equal(expectedRoleID, model.RoleID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigDiscordConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigDiscordConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedGuildID = "guild_id";
        string expectedRoleID = "role_id";

        Assert.Equal(expectedGuildID, deserialized.GuildID);
        Assert.Equal(expectedRoleID, deserialized.RoleID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        Assert.Null(model.RoleID);
        Assert.True(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        EntitlementUpdateParamsIntegrationConfigDiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigTelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigTelegramConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigTelegramConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, deserialized.ChatID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        EntitlementUpdateParamsIntegrationConfigTelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigFigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigFigmaConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigFigmaConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, deserialized.FigmaFileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        EntitlementUpdateParamsIntegrationConfigFigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigFramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigFramerConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigFramerConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, deserialized.FramerTemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        EntitlementUpdateParamsIntegrationConfigFramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigNotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigNotionConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigNotionConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, deserialized.NotionTemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        EntitlementUpdateParamsIntegrationConfigNotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigDigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        List<string> expectedDigitalFileIds = ["string"];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";
        List<string> expectedLegacyFileIds = ["string"];

        Assert.Equal(expectedDigitalFileIds.Count, model.DigitalFileIds.Count);
        for (int i = 0; i < expectedDigitalFileIds.Count; i++)
        {
            Assert.Equal(expectedDigitalFileIds[i], model.DigitalFileIds[i]);
        }
        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.NotNull(model.LegacyFileIds);
        Assert.Equal(expectedLegacyFileIds.Count, model.LegacyFileIds.Count);
        for (int i = 0; i < expectedLegacyFileIds.Count; i++)
        {
            Assert.Equal(expectedLegacyFileIds[i], model.LegacyFileIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedDigitalFileIds = ["string"];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";
        List<string> expectedLegacyFileIds = ["string"];

        Assert.Equal(expectedDigitalFileIds.Count, deserialized.DigitalFileIds.Count);
        for (int i = 0; i < expectedDigitalFileIds.Count; i++)
        {
            Assert.Equal(expectedDigitalFileIds[i], deserialized.DigitalFileIds[i]);
        }
        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.NotNull(deserialized.LegacyFileIds);
        Assert.Equal(expectedLegacyFileIds.Count, deserialized.LegacyFileIds.Count);
        for (int i = 0; i < expectedLegacyFileIds.Count; i++)
        {
            Assert.Equal(expectedLegacyFileIds[i], deserialized.LegacyFileIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
        };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.LegacyFileIds);
        Assert.False(model.RawData.ContainsKey("legacy_file_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],

            ExternalUrl = null,
            Instructions = null,
            LegacyFileIds = null,
        };

        Assert.Null(model.ExternalUrl);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.LegacyFileIds);
        Assert.True(model.RawData.ContainsKey("legacy_file_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],

            ExternalUrl = null,
            Instructions = null,
            LegacyFileIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        EntitlementUpdateParamsIntegrationConfigDigitalFilesConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsIntegrationConfigLicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string expectedActivationMessage = "activation_message";
        int expectedActivationsLimit = 0;
        int expectedDurationCount = 0;
        ApiEnum<string, TimeInterval> expectedDurationInterval = TimeInterval.Day;

        Assert.Equal(expectedActivationMessage, model.ActivationMessage);
        Assert.Equal(expectedActivationsLimit, model.ActivationsLimit);
        Assert.Equal(expectedDurationCount, model.DurationCount);
        Assert.Equal(expectedDurationInterval, model.DurationInterval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedActivationMessage = "activation_message";
        int expectedActivationsLimit = 0;
        int expectedDurationCount = 0;
        ApiEnum<string, TimeInterval> expectedDurationInterval = TimeInterval.Day;

        Assert.Equal(expectedActivationMessage, deserialized.ActivationMessage);
        Assert.Equal(expectedActivationsLimit, deserialized.ActivationsLimit);
        Assert.Equal(expectedDurationCount, deserialized.DurationCount);
        Assert.Equal(expectedDurationInterval, deserialized.DurationInterval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig { };

        Assert.Null(model.ActivationMessage);
        Assert.False(model.RawData.ContainsKey("activation_message"));
        Assert.Null(model.ActivationsLimit);
        Assert.False(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.DurationCount);
        Assert.False(model.RawData.ContainsKey("duration_count"));
        Assert.Null(model.DurationInterval);
        Assert.False(model.RawData.ContainsKey("duration_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = null,
            ActivationsLimit = null,
            DurationCount = null,
            DurationInterval = null,
        };

        Assert.Null(model.ActivationMessage);
        Assert.True(model.RawData.ContainsKey("activation_message"));
        Assert.Null(model.ActivationsLimit);
        Assert.True(model.RawData.ContainsKey("activations_limit"));
        Assert.Null(model.DurationCount);
        Assert.True(model.RawData.ContainsKey("duration_count"));
        Assert.Null(model.DurationInterval);
        Assert.True(model.RawData.ContainsKey("duration_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = null,
            ActivationsLimit = null,
            DurationCount = null,
            DurationInterval = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        EntitlementUpdateParamsIntegrationConfigLicenseKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
