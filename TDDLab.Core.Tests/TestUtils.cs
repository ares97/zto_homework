using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public static class TestData
    {
        public static readonly Address ValidAddress = new Address("Sobotki", "Gdansk", "Poland", "80-250");
        public static readonly Address AddressWithoutCity = new Address("Sobotki", null, "Poland", "80-250");

        public static readonly Recipient ValidRecipient = new Recipient("Donald Trump", ValidAddress);

        public static readonly Money TwoUsd = new Money(2, "USD");
        public static readonly Money FiveUsd = new Money(5, "USD");
        public static readonly Money TenUsd = new Money(10, "USD");
        public static readonly Money MoneyWithoutCurrency = new Money(2, null);

        

    }
}