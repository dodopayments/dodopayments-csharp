using System.Collections.Generic;
using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Moderation;

namespace DodoPayments.Client.Tests.Models.Moderation;

public class ModerationRetrieveUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModerationRetrieveUsageResponse
        {
            Daily = [new() { Date = "2019-12-27", Screens = 0 }],
            ScreensToNextBlock = 0,
            UnbilledScreens = 0,
        };

        List<Daily> expectedDaily = [new() { Date = "2019-12-27", Screens = 0 }];
        long expectedScreensToNextBlock = 0;
        long expectedUnbilledScreens = 0;

        Assert.Equal(expectedDaily.Count, model.Daily.Count);
        for (int i = 0; i < expectedDaily.Count; i++)
        {
            Assert.Equal(expectedDaily[i], model.Daily[i]);
        }
        Assert.Equal(expectedScreensToNextBlock, model.ScreensToNextBlock);
        Assert.Equal(expectedUnbilledScreens, model.UnbilledScreens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModerationRetrieveUsageResponse
        {
            Daily = [new() { Date = "2019-12-27", Screens = 0 }],
            ScreensToNextBlock = 0,
            UnbilledScreens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationRetrieveUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModerationRetrieveUsageResponse
        {
            Daily = [new() { Date = "2019-12-27", Screens = 0 }],
            ScreensToNextBlock = 0,
            UnbilledScreens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModerationRetrieveUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Daily> expectedDaily = [new() { Date = "2019-12-27", Screens = 0 }];
        long expectedScreensToNextBlock = 0;
        long expectedUnbilledScreens = 0;

        Assert.Equal(expectedDaily.Count, deserialized.Daily.Count);
        for (int i = 0; i < expectedDaily.Count; i++)
        {
            Assert.Equal(expectedDaily[i], deserialized.Daily[i]);
        }
        Assert.Equal(expectedScreensToNextBlock, deserialized.ScreensToNextBlock);
        Assert.Equal(expectedUnbilledScreens, deserialized.UnbilledScreens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModerationRetrieveUsageResponse
        {
            Daily = [new() { Date = "2019-12-27", Screens = 0 }],
            ScreensToNextBlock = 0,
            UnbilledScreens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModerationRetrieveUsageResponse
        {
            Daily = [new() { Date = "2019-12-27", Screens = 0 }],
            ScreensToNextBlock = 0,
            UnbilledScreens = 0,
        };

        ModerationRetrieveUsageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DailyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Daily { Date = "2019-12-27", Screens = 0 };

        string expectedDate = "2019-12-27";
        long expectedScreens = 0;

        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedScreens, model.Screens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Daily { Date = "2019-12-27", Screens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Daily>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Daily { Date = "2019-12-27", Screens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Daily>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        long expectedScreens = 0;

        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedScreens, deserialized.Screens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Daily { Date = "2019-12-27", Screens = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Daily { Date = "2019-12-27", Screens = 0 };

        Daily copied = new(model);

        Assert.Equal(model, copied);
    }
}
