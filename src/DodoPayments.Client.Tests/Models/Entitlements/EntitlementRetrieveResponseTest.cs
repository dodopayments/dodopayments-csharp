using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Exceptions;
using DodoPayments.Client.Models.Entitlements;
using DodoPayments.Client.Models.Subscriptions;

namespace DodoPayments.Client.Tests.Models.Entitlements;

public class EntitlementRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        EntitlementRetrieveResponseIntegrationConfig expectedIntegrationConfig =
            new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementRetrieveResponseIntegrationType> expectedIntegrationType =
            EntitlementRetrieveResponseIntegrationType.Discord;
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBusinessID = "business_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        EntitlementRetrieveResponseIntegrationConfig expectedIntegrationConfig =
            new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        ApiEnum<string, EntitlementRetrieveResponseIntegrationType> expectedIntegrationType =
            EntitlementRetrieveResponseIntegrationType.Discord;
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
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
        var model = new EntitlementRetrieveResponse
        {
            ID = "id",
            BusinessID = "business_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IntegrationConfig = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            },
            IntegrationType = EntitlementRetrieveResponseIntegrationType.Discord,
            IsActive = true,
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EntitlementRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigTest : TestBase
{
    [Fact]
    public void GitHubValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        value.Validate();
    }

    [Fact]
    public void DiscordValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        value.Validate();
    }

    [Fact]
    public void TelegramValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigTelegramConfig("chat_id");
        value.Validate();
    }

    [Fact]
    public void FigmaValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigFigmaConfig("figma_file_id");
        value.Validate();
    }

    [Fact]
    public void FramerValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigFramerConfig("framer_template_id");
        value.Validate();
    }

    [Fact]
    public void NotionValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigNotionConfig("notion_template_id");
        value.Validate();
    }

    [Fact]
    public void DigitalFilesValidationWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig(
                new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles()
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
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig()
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
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigGitHubConfig()
            {
                Permission = "permission",
                TargetID = "target_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DiscordSerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigDiscordConfig()
            {
                GuildID = "guild_id",
                RoleID = "role_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TelegramSerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigTelegramConfig("chat_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FigmaSerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigFigmaConfig("figma_file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FramerSerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigFramerConfig("framer_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotionSerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigNotionConfig("notion_template_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DigitalFilesSerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig(
                new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles()
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
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LicenseKeySerializationRoundtripWorks()
    {
        EntitlementRetrieveResponseIntegrationConfig value =
            new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig()
            {
                ActivationMessage = "activation_message",
                ActivationsLimit = 0,
                DurationCount = 0,
                DurationInterval = TimeInterval.Day,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigGitHubConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigGitHubConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigGitHubConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigGitHubConfig
        {
            Permission = "permission",
            TargetID = "target_id",
        };

        EntitlementRetrieveResponseIntegrationConfigGitHubConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigDiscordConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDiscordConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDiscordConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        Assert.Null(model.RoleID);
        Assert.False(model.RawData.ContainsKey("role_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",

            RoleID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDiscordConfig
        {
            GuildID = "guild_id",
            RoleID = "role_id",
        };

        EntitlementRetrieveResponseIntegrationConfigDiscordConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigTelegramConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string expectedChatID = "chat_id";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigTelegramConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigTelegramConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigTelegramConfig
        {
            ChatID = "chat_id",
        };

        EntitlementRetrieveResponseIntegrationConfigTelegramConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigFigmaConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string expectedFigmaFileID = "figma_file_id";

        Assert.Equal(expectedFigmaFileID, model.FigmaFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigFigmaConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigFigmaConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFigmaConfig
        {
            FigmaFileID = "figma_file_id",
        };

        EntitlementRetrieveResponseIntegrationConfigFigmaConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigFramerConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string expectedFramerTemplateID = "framer_template_id";

        Assert.Equal(expectedFramerTemplateID, model.FramerTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigFramerConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigFramerConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigFramerConfig
        {
            FramerTemplateID = "framer_template_id",
        };

        EntitlementRetrieveResponseIntegrationConfigFramerConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigNotionConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string expectedNotionTemplateID = "notion_template_id";

        Assert.Equal(expectedNotionTemplateID, model.NotionTemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigNotionConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigNotionConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigNotionConfig
        {
            NotionTemplateID = "notion_template_id",
        };

        EntitlementRetrieveResponseIntegrationConfigNotionConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
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

        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles expectedDigitalFiles =
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
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
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
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
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles expectedDigitalFiles =
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig
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

        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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

        List<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> expectedFiles =
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile> expectedFiles =
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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
        var model = new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles
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

        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFiles copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFileTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile>(
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
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
        var model =
            new EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile
            {
                DownloadUrl = "download_url",
                ExpiresIn = 0,
                FileID = "file_id",
                Filename = "filename",
                Source = "source",
                ContentType = "content_type",
                FileSize = 0,
            };

        EntitlementRetrieveResponseIntegrationConfigDigitalFilesConfigDigitalFilesFile copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig>(
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
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig { };

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
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
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
        var model = new EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig
        {
            ActivationMessage = "activation_message",
            ActivationsLimit = 0,
            DurationCount = 0,
            DurationInterval = TimeInterval.Day,
        };

        EntitlementRetrieveResponseIntegrationConfigLicenseKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementRetrieveResponseIntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Discord)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Telegram)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.GitHub)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Figma)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Framer)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Notion)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.DigitalFiles)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.LicenseKey)]
    public void Validation_Works(EntitlementRetrieveResponseIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementRetrieveResponseIntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementRetrieveResponseIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DodoPaymentsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Discord)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Telegram)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.GitHub)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Figma)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Framer)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.Notion)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.DigitalFiles)]
    [InlineData(EntitlementRetrieveResponseIntegrationType.LicenseKey)]
    public void SerializationRoundtrip_Works(EntitlementRetrieveResponseIntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementRetrieveResponseIntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementRetrieveResponseIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementRetrieveResponseIntegrationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementRetrieveResponseIntegrationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
