using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class RecipientTests
    {
        [Test]
        public void can_create_valid_recipient()
        {
            var recipient = TestData.ValidRecipient;
            Assert.IsTrue(recipient.IsValid);
        }

        [Test]
        public void recipient_must_has_a_name()
        {
            var recipient = new Recipient(null, TestData.ValidAddress);
            Assert.IsFalse(recipient.IsValid);
        }

        [Test]
        public void recipient_must_has_valid_address()
        {
            var recipient = new Recipient("John", TestData.AddressWithoutCity);

            Assert.IsFalse(TestData.AddressWithoutCity.IsValid);
            Assert.IsFalse(recipient.IsValid);
        }
    }
}