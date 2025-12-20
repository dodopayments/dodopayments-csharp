using System;
using DodoPayments.Client.Models.LicenseKeys;

namespace DodoPayments.Client.Tests.Models.LicenseKeys;

public class LicenseKeyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseKeyUpdateParams
        {
            ID = "lic_123",
            ActivationsLimit = 0,
            Disabled = true,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "lic_123";
        int expectedActivationsLimit = 0;
        bool expectedDisabled = true;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedActivationsLimit, parameters.ActivationsLimit);
        Assert.Equal(expectedDisabled, parameters.Disabled);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseKeyUpdateParams { ID = "lic_123" };

        Assert.Null(parameters.ActivationsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("activations_limit"));
        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseKeyUpdateParams
        {
            ID = "lic_123",

            ActivationsLimit = null,
            Disabled = null,
            ExpiresAt = null,
        };

        Assert.Null(parameters.ActivationsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("activations_limit"));
        Assert.Null(parameters.Disabled);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }
}
