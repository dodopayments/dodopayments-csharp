using DodoPayments.Client.Models.Meters;

namespace DodoPayments.Client.Tests.Models.Meters;

public class MeterListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MeterListParams
        {
            Archived = true,
            PageNumber = 0,
            PageSize = 0,
        };

        bool expectedArchived = true;
        int expectedPageNumber = 0;
        int expectedPageSize = 0;

        Assert.Equal(expectedArchived, parameters.Archived);
        Assert.Equal(expectedPageNumber, parameters.PageNumber);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MeterListParams { };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MeterListParams
        {
            // Null should be interpreted as omitted for these properties
            Archived = null,
            PageNumber = null,
            PageSize = null,
        };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.PageNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("page_number"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
    }
}
