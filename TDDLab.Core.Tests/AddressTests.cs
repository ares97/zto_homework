using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class AddressTests
    {
        [TestCase("", "", "", "")]
        [TestCase("", "Gdansk", "Polska", "80-806")]
        [TestCase("Do Studzienki", "", "Polska", "80-806")]
        [TestCase("Do Studzienki", "Gdansk", "", "80-806")]
        [TestCase("Do Studzienki", "Gdansk", "Polska", "")]
        public void address_should_not_have_empty_fields(string addressLine1, string city, string state, string zip)
        {
            var address = new Address(addressLine1, city, state, zip);
            Assert.IsFalse(address.IsValid);
        }

        [TestCase("Do Studzienki", "Gdansk", "Polska", "123")]
        [TestCase("Do Studzienki", "Gdansk", "Polska", "123456")]
        [TestCase("Do Studzienki", "Gdansk", "Polska", "12345678901234567890")]
        [TestCase("Do Studzienki", "Gdansk", "Polska", "8xxx8")]
        [TestCase("Do Studzienki", "Gdansk", "Polska", "XABC")]
        public void address_zip_code_should_have_correct_format(string addressLine1, string city, string state, string zip)
        {
            var address = new Address(addressLine1, city, state, zip);
            Assert.IsFalse(address.IsValid);
        }

        [Test]
        public void valid_address_should_be_valid()
        {
            var address = ExampleData.ValidAddress;
            Assert.IsTrue(address.IsValid);
        }
    }
}