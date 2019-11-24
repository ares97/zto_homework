using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public static class ExampleData
    {
        public static readonly Address ValidAddress = new Address("Sobotki", "Gdansk", "Poland", "80-250");
        public static readonly Address InvalidAddress = new Address("Sobotki", "", "Poland", "80-250");
        public static readonly Recipient ValidRecipient = new Recipient("Bartlomiej Wroblewski", ValidAddress);
        public static readonly Money ValidMoney = new Money(2, "USD");
        public static readonly InvoiceLine ValidInvoiceLine = new InvoiceLine("Bread", ValidMoney);
        public static readonly Invoice ValidInvoiceOneLine = new Invoice("1", ValidRecipient, ValidAddress, new []{ ValidInvoiceLine }, ValidMoney);
        public static readonly Invoice ValidInvoiceThreeLines = new Invoice("1", ValidRecipient, ValidAddress, new[] { ValidInvoiceLine, ValidInvoiceLine, ValidInvoiceLine });
    }
}