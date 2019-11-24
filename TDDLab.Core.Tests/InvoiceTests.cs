using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class InvoiceTests
    {
        [Test]
        public void valid_invoice_should_be_valid()
        {
            Assert.IsTrue(ExampleData.ValidInvoiceOneLine.IsValid);
            Assert.IsTrue(ExampleData.ValidInvoiceThreeLines.IsValid);
        }

        [Test]
        public void invoice_line_can_be_attached_to_invoice()
        {
            var invoiceLineToAdd = new InvoiceLine("juice", ExampleData.ValidMoney);
            var invoice = ExampleData.ValidInvoiceThreeLines;
            invoice.AttachInvoiceLine(invoiceLineToAdd);

            foreach (var invoiceLine in ExampleData.ValidInvoiceThreeLines.Lines.ToList())
            {
                Assert.Contains(invoiceLine, invoice.Lines.ToList());
            }

            Assert.Contains(invoiceLineToAdd, invoice.Lines.ToList());
        }


        [Test]
        public void line_invoice_should_has_reference_to_invoice()
        {
            var invoiceLine = new InvoiceLine("juice", ExampleData.ValidMoney);
            var invoice = ExampleData.ValidInvoiceThreeLines;
            invoice.AttachInvoiceLine(invoiceLine);
            Assert.AreSame(invoiceLine.Invoice, invoice);
        }
    }
}