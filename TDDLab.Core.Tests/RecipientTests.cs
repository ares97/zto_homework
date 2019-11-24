using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class RecipientTests
    {
        [Test]
        public void valid_recipient_should_be_valid()
        {
            var recipient = ExampleData.ValidRecipient;
            Assert.IsTrue(recipient.IsValid);
        }

        [Test]
        public void recipient_without_name_should_be_invelid()
        {
            var recipient = new Recipient("", ExampleData.ValidAddress);
            Assert.IsFalse(recipient.IsValid);
        }

        [Test]
        public void recipient_should_have_valid_address()
        {
            var recipient = new Recipient("Bartlomiej Wroblewski", ExampleData.InvalidAddress);
            Assert.IsFalse(ExampleData.InvalidAddress.IsValid);
            Assert.IsFalse(recipient.IsValid);
        }
    }
}