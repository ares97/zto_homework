using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class Tests
    {
        private Recipient _recipient;

        [SetUp]
        public void Setup()
        {
            _recipient = new Recipient("Radek S", new Address("Matki Polki 1a", "Gdansk", "Poland", "80-251"));
            var invoice = new Invoice("1", _recipient, _recipient.Address, new []{new InvoiceLine("bread", new Money(10, "PLN")), });
        }

        [TestCase("", "Gdansk", "Poland", "80-250")]
        [TestCase("Sobotki", "", "Poland", "80-250")]
        [TestCase("Sobotki", "Gdansk", "", "80-250")]
        [TestCase("Sobotki", "Gdansk", "Poland", "")]
        public void address_should_have_all_fields_non_empty(string addressLine, string city, string state, string zip)
        {
            var address = new Address(addressLine, city, state, zip);
            Assert.IsFalse(address.IsValid);
        }
        
        
        
    }
}