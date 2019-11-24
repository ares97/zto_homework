using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class InvoiceTests
    {
        private Invoice _invoiceWithTwoLines;
        private Invoice _invoiceWithOneLineAndTwoUsdDiscount;

        [SetUp]
        public void Setup()
        {
            _invoiceWithTwoLines = new Invoice("12", TestData.ValidRecipient, TestData.ValidAddress,
                new[] {TestData.InvoiceLineBread, TestData.InvoiceLineButter});

            _invoiceWithOneLineAndTwoUsdDiscount = new Invoice("13", TestData.ValidRecipient, TestData.ValidAddress,
                new[] {TestData.InvoiceLineButter}, TestData.TwoUsd);
        }
        

        [Test]
        public void can_create_valid_invoice()
        {
            Assert.IsTrue(_invoiceWithTwoLines.IsValid);
            Assert.IsTrue(_invoiceWithOneLineAndTwoUsdDiscount.IsValid);
        }

        [Test]
        public void counts_invoice_lines()
        {
            var linesCount = _invoiceWithTwoLines.Lines.Count;
            Assert.AreEqual(2, linesCount);
        }

        [Test]
        public void can_attach_invoice_line_to_existing_invoice()
        {
            var cocaCola = new InvoiceLine("coca-cola", TestData.TwoUsd);
            _invoiceWithTwoLines.AttachInvoiceLine(cocaCola);

            Assert.Contains(cocaCola, _invoiceWithTwoLines.Lines.ToList());
        }
        
        
        [Test]
        public void line_invoice_has_reference_to_its_invoice()
        {
            var cocaCola = new InvoiceLine("coca-cola", TestData.TwoUsd);
            _invoiceWithTwoLines.AttachInvoiceLine(cocaCola);

            Assert.AreSame(cocaCola.Invoice, _invoiceWithTwoLines);
        }
        
        
    }
}