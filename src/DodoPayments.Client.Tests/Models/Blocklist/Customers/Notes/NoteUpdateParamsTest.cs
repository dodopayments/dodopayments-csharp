using System;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers.Notes;

public class NoteUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NoteUpdateParams
        {
            EntryID = "entry_id",
            NoteID = "note_id",
            Note = "note",
        };

        string expectedEntryID = "entry_id";
        string expectedNoteID = "note_id";
        string expectedNote = "note";

        Assert.Equal(expectedEntryID, parameters.EntryID);
        Assert.Equal(expectedNoteID, parameters.NoteID);
        Assert.Equal(expectedNote, parameters.Note);
    }

    [Fact]
    public void Url_Works()
    {
        NoteUpdateParams parameters = new()
        {
            EntryID = "entry_id",
            NoteID = "note_id",
            Note = "note",
        };

        var url = parameters.Url(new() { BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://live.dodopayments.com/blocklist/customers/entry_id/notes/note_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NoteUpdateParams
        {
            EntryID = "entry_id",
            NoteID = "note_id",
            Note = "note",
        };

        NoteUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
