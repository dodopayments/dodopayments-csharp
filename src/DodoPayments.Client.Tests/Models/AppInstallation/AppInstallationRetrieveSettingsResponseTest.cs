using System;
using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.AppInstallation;

namespace DodoPayments.Client.Tests.Models.AppInstallation;

public class AppInstallationRetrieveSettingsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
            LiveManifestVersion = 0,
            ManifestVersion = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedActionNeeded = true;
        string expectedAppID = "app_id";
        string expectedInstallationID = "installation_id";
        List<string> expectedInvalidKeys = ["string"];
        JsonElement expectedSecrets = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedValues = JsonSerializer.Deserialize<JsonElement>("{}");
        int expectedLiveManifestVersion = 0;
        int expectedManifestVersion = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActionNeeded, model.ActionNeeded);
        Assert.Equal(expectedAppID, model.AppID);
        Assert.Equal(expectedInstallationID, model.InstallationID);
        Assert.Equal(expectedInvalidKeys.Count, model.InvalidKeys.Count);
        for (int i = 0; i < expectedInvalidKeys.Count; i++)
        {
            Assert.Equal(expectedInvalidKeys[i], model.InvalidKeys[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedSecrets, model.Secrets));
        Assert.True(JsonElement.DeepEquals(expectedValues, model.Values));
        Assert.Equal(expectedLiveManifestVersion, model.LiveManifestVersion);
        Assert.Equal(expectedManifestVersion, model.ManifestVersion);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
            LiveManifestVersion = 0,
            ManifestVersion = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AppInstallationRetrieveSettingsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
            LiveManifestVersion = 0,
            ManifestVersion = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AppInstallationRetrieveSettingsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActionNeeded = true;
        string expectedAppID = "app_id";
        string expectedInstallationID = "installation_id";
        List<string> expectedInvalidKeys = ["string"];
        JsonElement expectedSecrets = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedValues = JsonSerializer.Deserialize<JsonElement>("{}");
        int expectedLiveManifestVersion = 0;
        int expectedManifestVersion = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedActionNeeded, deserialized.ActionNeeded);
        Assert.Equal(expectedAppID, deserialized.AppID);
        Assert.Equal(expectedInstallationID, deserialized.InstallationID);
        Assert.Equal(expectedInvalidKeys.Count, deserialized.InvalidKeys.Count);
        for (int i = 0; i < expectedInvalidKeys.Count; i++)
        {
            Assert.Equal(expectedInvalidKeys[i], deserialized.InvalidKeys[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedSecrets, deserialized.Secrets));
        Assert.True(JsonElement.DeepEquals(expectedValues, deserialized.Values));
        Assert.Equal(expectedLiveManifestVersion, deserialized.LiveManifestVersion);
        Assert.Equal(expectedManifestVersion, deserialized.ManifestVersion);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
            LiveManifestVersion = 0,
            ManifestVersion = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.LiveManifestVersion);
        Assert.False(model.RawData.ContainsKey("live_manifest_version"));
        Assert.Null(model.ManifestVersion);
        Assert.False(model.RawData.ContainsKey("manifest_version"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),

            LiveManifestVersion = null,
            ManifestVersion = null,
            UpdatedAt = null,
        };

        Assert.Null(model.LiveManifestVersion);
        Assert.True(model.RawData.ContainsKey("live_manifest_version"));
        Assert.Null(model.ManifestVersion);
        Assert.True(model.RawData.ContainsKey("manifest_version"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),

            LiveManifestVersion = null,
            ManifestVersion = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AppInstallationRetrieveSettingsResponse
        {
            ActionNeeded = true,
            AppID = "app_id",
            InstallationID = "installation_id",
            InvalidKeys = ["string"],
            Secrets = JsonSerializer.Deserialize<JsonElement>("{}"),
            Values = JsonSerializer.Deserialize<JsonElement>("{}"),
            LiveManifestVersion = 0,
            ManifestVersion = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AppInstallationRetrieveSettingsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
