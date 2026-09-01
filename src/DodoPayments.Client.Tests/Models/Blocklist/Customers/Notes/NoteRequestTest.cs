using System.Text.Json;
using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Blocklist.Customers.Notes;

namespace DodoPayments.Client.Tests.Models.Blocklist.Customers.Notes;

public class NoteRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NoteRequest { Note = "note" };

        string expectedNote = "note";

        Assert.Equal(expectedNote, model.Note);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NoteRequest { Note = "note" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoteRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NoteRequest { Note = "note" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoteRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNote = "note";

        Assert.Equal(expectedNote, deserialized.Note);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NoteRequest { Note = "note" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NoteRequest { Note = "note" };

        NoteRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
