using DodoPayments.Client.Models.Payments;

namespace DodoPayments.Client.Tests.Models.Payments;

public class CreateNewCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateNewCustomer
        {
            Email = "email",
            Name = "name",
            CreateNewCustomer1 = true,
            PhoneNumber = "phone_number",
        };

        string expectedEmail = "email";
        string expectedName = "name";
        bool expectedCreateNewCustomer1 = true;
        string expectedPhoneNumber = "phone_number";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreateNewCustomer1, model.CreateNewCustomer1);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }
}
