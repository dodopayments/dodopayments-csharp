using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = IntegrationType.Discord,
            Name = "name",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        IntegrationConfig expectedIntegrationConfig = new GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        ApiEnum<string, IntegrationType> expectedIntegrationType = IntegrationType.Discord;
        string expectedName = "name";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedIntegrationConfig, parameters.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, parameters.IntegrationType);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = IntegrationType.Discord,
            Name = "name",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = IntegrationType.Discord,
            Name = "name",

            Description = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementCreateParams parameters = new()
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = IntegrationType.Discord,
            Name = "name",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://live.dodopayments.com/entitlements"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            IntegrationConfig = new GitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = IntegrationType.Discord,
            Name = "name",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        EntitlementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        IntegrationConfig value = new GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        IntegrationConfig value = new DiscordConfig() { GuildID = "guild_id", RoleID = "role_id" };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        IntegrationConfig value = new TelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        IntegrationConfig value = new FigmaConfig("figma_file_id");
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        IntegrationConfig value = new FramerConfig("framer_template_id");
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        IntegrationConfig value = new NotionConfig("notion_template_id");
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        IntegrationConfig value = new DigitalFilesConfig()
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
        IntegrationConfig value = new LicenseKeyConfig()
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
        IntegrationConfig value = new GitHubConfig()
        {
            Permission = "permission",
            TargetID = "target_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        IntegrationConfig value = new DiscordConfig() { GuildID = "guild_id", RoleID = "role_id" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        IntegrationConfig value = new TelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        IntegrationConfig value = new FigmaConfig("figma_file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        IntegrationConfig value = new FramerConfig("framer_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        IntegrationConfig value = new NotionConfig("notion_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        IntegrationConfig value = new DigitalFilesConfig()
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        IntegrationConfig value = new LicenseKeyConfig()
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GitHubConfig { Permission = "permission", TargetID = "target_id" };

        string expectedPermission = "permission";
        string expectedTargetID = "target_id";

        Assert.Equal(expectedPermission, model.Permission);
        Assert.Equal(expectedTargetID, model.TargetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GitHubConfig { Permission = "permission", TargetID = "target_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitHubConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GitHubConfig { Permission = "permission", TargetID = "target_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitHubConfig>(
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
        var model = new GitHubConfig { Permission = "permission", TargetID = "target_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GitHubConfig { Permission = "permission", TargetID = "target_id" };

        GitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        string expectedGuildID = "guild_id";
        string expectedRoleID = "role_id";

        Assert.Equal(expectedGuildID, model.GuildID);
        Assert.Equal(expectedRoleID, model.RoleID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscordConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscordConfig>(
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
        var model = new DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiscordConfig { GuildID = "guild_id" };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DiscordConfig { GuildID = "guild_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DiscordConfig
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
        var model = new DiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DiscordConfig { GuildID = "guild_id", RoleID = "role_id" };

        DiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TelegramConfig { ChatID = "chat_id" };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TelegramConfig { ChatID = "chat_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelegramConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TelegramConfig { ChatID = "chat_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelegramConfig>(
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
        var model = new TelegramConfig { ChatID = "chat_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TelegramConfig { ChatID = "chat_id" };

        TelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FigmaConfig { FigmaFileID = "figma_file_id" };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FigmaConfig { FigmaFileID = "figma_file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FigmaConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FigmaConfig { FigmaFileID = "figma_file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FigmaConfig>(
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
        var model = new FigmaConfig { FigmaFileID = "figma_file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FigmaConfig { FigmaFileID = "figma_file_id" };

        FigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FramerConfig { FramerTemplateID = "framer_template_id" };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FramerConfig { FramerTemplateID = "framer_template_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FramerConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FramerConfig { FramerTemplateID = "framer_template_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FramerConfig>(
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
        var model = new FramerConfig { FramerTemplateID = "framer_template_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FramerConfig { FramerTemplateID = "framer_template_id" };

        FramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotionConfig { NotionTemplateID = "notion_template_id" };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotionConfig { NotionTemplateID = "notion_template_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotionConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotionConfig { NotionTemplateID = "notion_template_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotionConfig>(
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
        var model = new NotionConfig { NotionTemplateID = "notion_template_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotionConfig { NotionTemplateID = "notion_template_id" };

        NotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalFilesConfig
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
        var model = new DigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalFilesConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalFilesConfig>(
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
        var model = new DigitalFilesConfig
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
        var model = new DigitalFilesConfig { DigitalFileIds = ["string"] };

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
        var model = new DigitalFilesConfig { DigitalFileIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DigitalFilesConfig
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
        var model = new DigitalFilesConfig
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
        var model = new DigitalFilesConfig
        {
            DigitalFileIds = ["string"],
            ExternalUrl = "external_url",
            Instructions = "instructions",
            LegacyFileIds = ["string"],
        };

        DigitalFilesConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseKeyConfig
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
        var model = new LicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseKeyConfig>(
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
        var model = new LicenseKeyConfig
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
        var model = new LicenseKeyConfig { };

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
        var model = new LicenseKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LicenseKeyConfig
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
        var model = new LicenseKeyConfig
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
        var model = new LicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        LicenseKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(IntegrationType.Discord)]
    [InlineData(IntegrationType.Telegram)]
    [InlineData(IntegrationType.GitHub)]
    [InlineData(IntegrationType.Figma)]
    [InlineData(IntegrationType.Framer)]
    [InlineData(IntegrationType.Notion)]
    [InlineData(IntegrationType.DigitalFiles)]
    [InlineData(IntegrationType.LicenseKey)]
    public void Validation_Works(IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationType.Discord)]
    [InlineData(IntegrationType.Telegram)]
    [InlineData(IntegrationType.GitHub)]
    [InlineData(IntegrationType.Figma)]
    [InlineData(IntegrationType.Framer)]
    [InlineData(IntegrationType.Notion)]
    [InlineData(IntegrationType.DigitalFiles)]
    [InlineData(IntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
