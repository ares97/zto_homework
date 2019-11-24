using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class InvoiceLineTests
    {
        [Test]
        public void can_create_valid_invoice_line()
        {
            var invoiceLine = new InvoiceLine("bread", TestData.TwoUsd);
            Assert.IsTrue(invoiceLine.IsValid);
        }

        [Test]
        public void cant_create_valid_invoice_line_with_invalid_money()
        {
            var invoiceLine = new InvoiceLine("bread", TestData.MoneyWithoutCurrency);
            Assert.IsFalse(invoiceLine.IsValid);
        }

        [Test]
        public void cant_create_valid_invoice_line_without_product_name()
        {
            var invoiceLine = new InvoiceLine("", TestData.TwoUsd);
            Assert.IsFalse(invoiceLine.IsValid);
        }
    }
}