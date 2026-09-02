using System.Threading.Tasks;

namespace DodoPayments.Client.Tests.Services.Blocklist.Customers;

public class NoteServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var blockedCustomerNote = await this.client.Blocklist.Customers.Notes.Create(
            "entry_id",
            new() { Note = "note" },
            TestContext.Current.CancellationToken
        );
        blockedCustomerNote.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var blockedCustomerNote = await this.client.Blocklist.Customers.Notes.Update(
            "note_id",
            new() { EntryID = "entry_id", Note = "note" },
            TestContext.Current.CancellationToken
        );
        blockedCustomerNote.Validate();
    }
}
