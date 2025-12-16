using DodoPayments.Client.Core;
using DodoPayments.Client.Models.Brands;

namespace DodoPayments.Client.Tests.Models.Brands;

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Brand
        {
            BrandID = "brand_id",
            BusinessID = "business_id",
            Enabled = true,
            StatementDescriptor = "statement_descriptor",
            VerificationEnabled = true,
            VerificationStatus = VerificationStatus.Success,
            Description = "description",
            Image = "image",
            Name = "name",
            ReasonForHold = "reason_for_hold",
            SupportEmail = "support_email",
            URL = "url",
        };

        string expectedBrandID = "brand_id";
        string expectedBusinessID = "business_id";
        bool expectedEnabled = true;
        string expectedStatementDescriptor = "statement_descriptor";
        bool expectedVerificationEnabled = true;
        ApiEnum<string, VerificationStatus> expectedVerificationStatus = VerificationStatus.Success;
        string expectedDescription = "description";
        string expectedImage = "image";
        string expectedName = "name";
        string expectedReasonForHold = "reason_for_hold";
        string expectedSupportEmail = "support_email";
        string expectedURL = "url";

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedBusinessID, model.BusinessID);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedStatementDescriptor, model.StatementDescriptor);
        Assert.Equal(expectedVerificationEnabled, model.VerificationEnabled);
        Assert.Equal(expectedVerificationStatus, model.VerificationStatus);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedImage, model.Image);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedReasonForHold, model.ReasonForHold);
        Assert.Equal(expectedSupportEmail, model.SupportEmail);
        Assert.Equal(expectedURL, model.URL);
    }
}
