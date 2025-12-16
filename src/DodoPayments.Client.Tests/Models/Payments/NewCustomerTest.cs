using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class NewCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewCustomer
        {
            Email = "email",
            Name = "name",
            PhoneNumber = "phone_number",
        };

        string expectedEmail = "email";
        string expectedName = "name";
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }
}
