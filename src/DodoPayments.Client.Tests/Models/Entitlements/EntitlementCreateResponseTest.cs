using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        EntitlementCreateResponseIntegrationConfig expectedIntegrationConfig =
            new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementCreateResponseIntegrationType> expectedIntegrationType =
            EntitlementCreateResponseIntegrationType.Discord;
        bool expectedIsActive = true;
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIntegrationConfig, model.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, model.IntegrationType);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        EntitlementCreateResponseIntegrationConfig expectedIntegrationConfig =
            new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementCreateResponseIntegrationType> expectedIntegrationType =
            EntitlementCreateResponseIntegrationType.Discord;
        bool expectedIsActive = true;
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusinessID, deserialized.BusinessID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIntegrationConfig, deserialized.IntegrationConfig);
        Assert.Equal(expectedIntegrationType, deserialized.IntegrationType);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementCreateResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EntitlementCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigTelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigFigmaConfig("figma_file_id");
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigFramerConfig("framer_template_id");
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigNotionConfig("notion_template_id");
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig(
                new DigitalFiles()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            Source = "source",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                }
            );
        value.Validate();
    }

    [Fact]
    public void LicenseKeyValidationWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig()
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
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigTelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigFigmaConfig("figma_file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigFramerConfig("framer_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigNotionConfig("notion_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig(
                new DigitalFiles()
                {
                    Files =
                    [
                        new()
                        {
                            DownloadUrl = "download_url",
                            ExpiresIn = 0,
                            FileID = "file_id",
                            Filename = "filename",
                            Source = "source",
                            ContentType = "content_type",
                            FileSize = 0,
                        },
                    ],
                    ExternalUrl = "external_url",
                    Instructions = "instructions",
                }
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        EntitlementCreateResponseIntegrationConfig value =
            new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = TimeInterval.Day,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseIntegrationConfigGitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigGitHubConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigGitHubConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigGitHubConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        EntitlementCreateResponseIntegrationConfigGitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigDiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigDiscordConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigDiscordConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        EntitlementCreateResponseIntegrationConfigDiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigTelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigTelegramConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigTelegramConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        EntitlementCreateResponseIntegrationConfigTelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigFigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigFigmaConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigFigmaConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        EntitlementCreateResponseIntegrationConfigFigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigFramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigFramerConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigFramerConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        EntitlementCreateResponseIntegrationConfigFramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigNotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigNotionConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigNotionConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        EntitlementCreateResponseIntegrationConfigNotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigDigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig
        {
            DigitalFiles = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        Source = "source",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
        };

        DigitalFiles expectedDigitalFiles = new()
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        Assert.Equal(expectedDigitalFiles, model.DigitalFiles);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig
        {
            DigitalFiles = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        Source = "source",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigDigitalFilesConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig
        {
            DigitalFiles = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        Source = "source",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigDigitalFilesConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DigitalFiles expectedDigitalFiles = new()
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        Assert.Equal(expectedDigitalFiles, deserialized.DigitalFiles);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig
        {
            DigitalFiles = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        Source = "source",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigDigitalFilesConfig
        {
            DigitalFiles = new()
            {
                Files =
                [
                    new()
                    {
                        DownloadUrl = "download_url",
                        ExpiresIn = 0,
                        FileID = "file_id",
                        Filename = "filename",
                        Source = "source",
                        ContentType = "content_type",
                        FileSize = 0,
                    },
                ],
                ExternalUrl = "external_url",
                Instructions = "instructions",
            },
        };

        EntitlementCreateResponseIntegrationConfigDigitalFilesConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalFilesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        List<File> expectedFiles =
        [
            new()
            {
                DownloadUrl = "download_url",
                ExpiresIn = 0,
                FileID = "file_id",
                Filename = "filename",
                Source = "source",
                ContentType = "content_type",
                FileSize = 0,
            },
        ];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedExternalUrl, model.ExternalUrl);
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalFiles>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalFiles>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<File> expectedFiles =
        [
            new()
            {
                DownloadUrl = "download_url",
                ExpiresIn = 0,
                FileID = "file_id",
                Filename = "filename",
                Source = "source",
                ContentType = "content_type",
                FileSize = 0,
            },
        ];
        string expectedExternalUrl = "external_url";
        string expectedInstructions = "instructions";

        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedExternalUrl, deserialized.ExternalUrl);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
        };

        Assert.Null(model.ExternalUrl);
        Assert.False(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],

            ExternalUrl = null,
            Instructions = null,
        };

        Assert.Null(model.ExternalUrl);
        Assert.True(model.RawData.ContainsKey("external_url"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],

            ExternalUrl = null,
            Instructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalFiles
        {
            Files =
            [
                new()
                {
                    DownloadUrl = "download_url",
                    ExpiresIn = 0,
                    FileID = "file_id",
                    Filename = "filename",
                    Source = "source",
                    ContentType = "content_type",
                    FileSize = 0,
                },
            ],
            ExternalUrl = "external_url",
            Instructions = "instructions",
        };

        DigitalFiles copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
            ContentType = "content_type",
            FileSize = 0,
        };

        string expectedDownloadUrl = "download_url";
        long expectedExpiresIn = 0;
        string expectedFileID = "file_id";
        string expectedFilename = "filename";
        string expectedSource = "source";
        string expectedContentType = "content_type";
        long expectedFileSize = 0;

        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedFileSize, model.FileSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
            ContentType = "content_type",
            FileSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
            ContentType = "content_type",
            FileSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDownloadUrl = "download_url";
        long expectedExpiresIn = 0;
        string expectedFileID = "file_id";
        string expectedFilename = "filename";
        string expectedSource = "source";
        string expectedContentType = "content_type";
        long expectedFileSize = 0;

        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
            ContentType = "content_type",
            FileSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
        };

        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",

            ContentType = null,
            FileSize = null,
        };

        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.FileSize);
        Assert.True(model.RawData.ContainsKey("file_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",

            ContentType = null,
            FileSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
            ContentType = "content_type",
            FileSize = 0,
        };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationConfigLicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigLicenseKeyConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseIntegrationConfigLicenseKeyConfig>(
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
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig { };

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
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementCreateResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        EntitlementCreateResponseIntegrationConfigLicenseKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseIntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseIntegrationType.Discord)]
    [InlineData(EntitlementCreateResponseIntegrationType.Telegram)]
    [InlineData(EntitlementCreateResponseIntegrationType.GitHub)]
    [InlineData(EntitlementCreateResponseIntegrationType.Figma)]
    [InlineData(EntitlementCreateResponseIntegrationType.Framer)]
    [InlineData(EntitlementCreateResponseIntegrationType.Notion)]
    [InlineData(EntitlementCreateResponseIntegrationType.DigitalFiles)]
    [InlineData(EntitlementCreateResponseIntegrationType.LicenseKey)]
    public void Validation_Works(EntitlementCreateResponseIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseIntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseIntegrationType.Discord)]
    [InlineData(EntitlementCreateResponseIntegrationType.Telegram)]
    [InlineData(EntitlementCreateResponseIntegrationType.GitHub)]
    [InlineData(EntitlementCreateResponseIntegrationType.Figma)]
    [InlineData(EntitlementCreateResponseIntegrationType.Framer)]
    [InlineData(EntitlementCreateResponseIntegrationType.Notion)]
    [InlineData(EntitlementCreateResponseIntegrationType.DigitalFiles)]
    [InlineData(EntitlementCreateResponseIntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseIntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
