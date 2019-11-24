using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class MoneyTests
    {
        [TestCase(0ul)]
        [TestCase(123ul)]
        [TestCase(1000000ul)]
        public void money_amount_should_be_set(ulong amount)
        {
            var money = new Money(amount);
            Assert.AreEqual(money.Amount, amount);
        }

        [TestCase(0ul, "USD")]
        [TestCase(1ul, "PLN")]
        [TestCase(2ul, "EUR")]
        public void money_currency_should_be_set(ulong amount, string currency)
        {
            var money = new Money(amount, currency);
            Assert.AreEqual(money.Amount, amount);
        }

        [TestCase("USD")]
        public void money_default_currency_should_be_set(string defaultCurrency)
        {
            var money = new Money(0ul);
            Assert.AreEqual(money.Currency, defaultCurrency);
        }

        [TestCase(0ul, "USD")]
        [TestCase(1000000ul, "PLN")]
        [TestCase(ulong.MaxValue, "PLN")]
        public void valid_money_should_be_valid(ulong amount, string currency)
        {
            var money = new Money(amount, currency);
            Assert.IsTrue(money.IsValid);
        }

        [TestCase(0ul)]
        [TestCase(123ul)]
        public void valid_money_without_currency_should_be_valid(ulong amount)
        {
            var money = new Money(amount);
            Assert.IsTrue(money.IsValid);
        }

        [TestCase(0ul, 0ul)]
        [TestCase(0ul, 100ul)]
        [TestCase(110ul, 201ul)]
        [TestCase(ulong.MaxValue, ulong.MaxValue)]
        public void money_can_be_added_with_operator(ulong amount1, ulong amount2)
        {
            var expected = new Money(amount1 + amount2);
            var result = new Money(amount1) + new Money(amount2);
            Assert.AreEqual(expected, result);
        }

        [TestCase(0ul, 0ul)]
        [TestCase(100ul, 0ul)]
        [TestCase(201ul, 110ul)]
        [TestCase(ulong.MaxValue, ulong.MaxValue)]
        public void money_can_be_substracted_with_operator(ulong amount1, ulong amount2)
        {
            var expected = new Money(amount1 - amount2);
            var result = new Money(amount1) - new Money(amount2);
            Assert.AreEqual(expected, result);
        }

        [TestCase(0ul, 11ul)]
        [TestCase(3ul, 133ul)]
        public void money_substraction_underflow_should_result_in_zero(ulong amount1, ulong amount2)
        {
            var expectedAmount = 0ul;
            var result = new Money(amount1) - new Money(amount2);
            Assert.AreEqual(expectedAmount, result.Amount);
        }

        [TestCase("USD", "PLN")]
        [TestCase("EUR", "USD")]
        public void money_addition_with_different_currencies_should_be_valid(string currency1, string currency2)
        {
            var result = new Money(0ul, currency1) + new Money(0ul, currency2);
            Assert.IsTrue(result.IsValid);
        }

        [TestCase("USD", "PLN")]
        [TestCase("EUR", "USD")]
        public void money_substraction_with_different_currencies_should_be_valid(string currency1, string currency2)
        {
            var result = new Money(0ul, currency1) - new Money(0ul, currency2);
            Assert.IsTrue(result.IsValid);
        }

        [TestCase("USD", "USD")]
        [TestCase("USD", "PLN")]
        [TestCase("PLN", "USD")]
        [TestCase("EUR", "USD")]
        public void money_addiition_should_convert_to_first_operand_currency(string currency1, string currency2)
        {
            var result = new Money(0, currency1) + new Money(0, currency2);
            Assert.AreEqual(result.Currency, currency1);
        }

        [TestCase("USD", "USD")]
        [TestCase("USD", "PLN")]
        [TestCase("PLN", "USD")]
        [TestCase("EUR", "USD")]
        public void money_substraction_should_convert_to_first_operand_currency(string currency1, string currency2)
        {
            var result = new Money(0, currency1) - new Money(0, currency2);
            Assert.AreEqual(result.Currency, currency1);
        }

        [TestCase("USD", "USD")]
        [TestCase("USD", "PLN")]
        [TestCase("PLN", "USD")]
        [TestCase("EUR", "USD")]
        public void money_should_be_properly_converted(string currency1, string currency2)
        {
            var money1 = new Money(1000, currency1);
            var money2 = new Money(1000, currency2);

            var secondConvertedToFirst = money2.ToCurrency(currency1);

            var expected = money1 + secondConvertedToFirst;
            var result = money1 + money2;

            Assert.AreEqual(expected.Currency, result.Currency);
            Assert.AreEqual(expected.Amount, result.Amount);
        }
    }
}