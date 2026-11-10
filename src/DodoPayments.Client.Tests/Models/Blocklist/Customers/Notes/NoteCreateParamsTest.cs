using System;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers.Notes;

public class NoteCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NoteCreateParams { EntryID = "entry_id", Text = "text" };

        string expectedEntryID = "entry_id";
        string expectedText = "text";

        Assert.Equal(expectedEntryID, parameters.EntryID);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void Url_Works()
    {
        NoteCreateParams parameters = new() { EntryID = "entry_id", Text = "text" };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/blocklist/customers/entry_id/notes"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NoteCreateParams { EntryID = "entry_id", Text = "text" };

        NoteCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
