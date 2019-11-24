using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class AddressTests
    {
        [TestCase("", "Gdansk", "Poland", "80-250")]
        [TestCase("Sobotki", "", "Poland", "80-250")]
        [TestCase("Sobotki", "Gdansk", "", "80-250")]
        [TestCase("Sobotki", "Gdansk", "Poland", "")]
        public void address_should_have_all_fields_non_empty(string addressLine, string city, string state, string zip)
        {
            var address = new Address(addressLine, city, state, zip);
            Assert.IsFalse(address.IsValid);
        }

        [Test]
        public void can_create_valid_address()
        {
            var address = TestData.ValidAddress;
            Assert.IsTrue(address.IsValid);
        }
    }
}