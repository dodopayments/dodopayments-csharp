using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        EntitlementListResponseIntegrationConfig expectedIntegrationConfig =
            new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementListResponseIntegrationType> expectedIntegrationType =
            EntitlementListResponseIntegrationType.Discord;
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        EntitlementListResponseIntegrationConfig expectedIntegrationConfig =
            new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementListResponseIntegrationType> expectedIntegrationType =
            EntitlementListResponseIntegrationType.Discord;
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
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
        var model = new EntitlementListResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementListResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EntitlementListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigTelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigFigmaConfig("figma_file_id");
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigFramerConfig("framer_template_id");
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigNotionConfig("notion_template_id");
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigDigitalFilesConfig(
                new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles()
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
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigLicenseKeyConfig()
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
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigTelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigFigmaConfig("figma_file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigFramerConfig("framer_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigNotionConfig("notion_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigDigitalFilesConfig(
                new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles()
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
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        EntitlementListResponseIntegrationConfig value =
            new EntitlementListResponseIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = TimeInterval.Day,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseIntegrationConfigGitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigGitHubConfig
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
        var model = new EntitlementListResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigGitHubConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigGitHubConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        EntitlementListResponseIntegrationConfigGitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigDiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
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
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDiscordConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDiscordConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
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
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        EntitlementListResponseIntegrationConfigDiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigTelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigTelegramConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigTelegramConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        EntitlementListResponseIntegrationConfigTelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigFigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigFigmaConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigFigmaConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        EntitlementListResponseIntegrationConfigFigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigFramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigFramerConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigFramerConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        EntitlementListResponseIntegrationConfigFramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigNotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigNotionConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigNotionConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        EntitlementListResponseIntegrationConfigNotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigDigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfig
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

        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles expectedDigitalFiles =
            new()
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfig
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
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfig
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
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles expectedDigitalFiles =
            new()
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfig
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfig
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

        EntitlementListResponseIntegrationConfigDigitalFilesConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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

        List<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> expectedFiles =
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> expectedFiles =
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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

        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFiles copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>(
                element,
                ModelBase.SerializerOptions
            );
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model = new EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
        {
            DownloadUrl = "download_url",
            ExpiresIn = 0,
            FileID = "file_id",
            Filename = "filename",
            Source = "source",
            ContentType = "content_type",
            FileSize = 0,
        };

        EntitlementListResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationConfigLicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigLicenseKeyConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseIntegrationConfigLicenseKeyConfig>(
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
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig { };

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
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementListResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        EntitlementListResponseIntegrationConfigLicenseKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseIntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseIntegrationType.Discord)]
    [InlineData(EntitlementListResponseIntegrationType.Telegram)]
    [InlineData(EntitlementListResponseIntegrationType.GitHub)]
    [InlineData(EntitlementListResponseIntegrationType.Figma)]
    [InlineData(EntitlementListResponseIntegrationType.Framer)]
    [InlineData(EntitlementListResponseIntegrationType.Notion)]
    [InlineData(EntitlementListResponseIntegrationType.DigitalFiles)]
    [InlineData(EntitlementListResponseIntegrationType.LicenseKey)]
    public void Validation_Works(EntitlementListResponseIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseIntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseIntegrationType.Discord)]
    [InlineData(EntitlementListResponseIntegrationType.Telegram)]
    [InlineData(EntitlementListResponseIntegrationType.GitHub)]
    [InlineData(EntitlementListResponseIntegrationType.Figma)]
    [InlineData(EntitlementListResponseIntegrationType.Framer)]
    [InlineData(EntitlementListResponseIntegrationType.Notion)]
    [InlineData(EntitlementListResponseIntegrationType.DigitalFiles)]
    [InlineData(EntitlementListResponseIntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(EntitlementListResponseIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseIntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
