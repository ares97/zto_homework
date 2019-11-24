using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class InvoiceLineTests
    {
        [TestCase("milk", 2ul, "PLN")]
        [TestCase("breadwithnutsandcockiestakenfromwarmmilk", 2ul, "PLN")]
        [TestCase("monster_truck_version_2012313&", 2ul, "PLN")]
        public void valid_invoice_line_should_be_valid(string name, ulong amount, string currency)
        {
            var invoiceLine = new InvoiceLine(name, ExampleData.ValidMoney);
            Assert.IsTrue(invoiceLine.IsValid);
        }

        [TestCase("", 2ul, "PLN")]
        public void invoice_without_name_should_be_invalid(string name, ulong amount, string currency)
        {
            var invoiceLine = new InvoiceLine(name, ExampleData.ValidMoney);
            Assert.IsFalse(invoiceLine.IsValid);
        }
    }
}