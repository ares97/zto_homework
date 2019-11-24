using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class MoneyTests
    {
        [TestCase(0ul)]
        [TestCase(13ul)]
        public void properly_sets_money_amount(ulong amount)
        {
            var money = new Money(amount);
            Assert.AreEqual(money.Amount, amount);
        }
        

        [TestCase(2ul, "USD")]
        [TestCase(0ul, "PLN")]
        public void creates_valid_money_with_currency(ulong amount, string currency)
        {
            var money = new Money(amount, currency);
            Assert.IsTrue(money.IsValid);
        }

        [TestCase(7ul)]
        [TestCase(0ul)]
        public void creates_valid_money_without_currency(ulong amount)
        {
            var money = new Money(amount);
            Assert.IsTrue(money.IsValid);
        }

        [TestCase(2ul, 4ul, 6ul)]
        [TestCase(0ul, 0ul, 0ul)]
        [TestCase(1ul, 0ul, 1ul)]
        public void can_figure_money_up_with_plus_operator(ulong first, ulong second, ulong expectedValue)
        {
            var result = new Money(first) + new Money(second);
            var expected = new Money(expectedValue);
            Assert.AreEqual(expected, result);
        }

        [TestCase(4ul, 3ul, 1ul)]
        [TestCase(0ul, 0ul, 0ul)]
        [TestCase(1ul, 0ul, 1ul)]
        [TestCase(1ul, 1ul, 0ul)]
        public void can_figure_money_up_with_minus_operator(ulong first, ulong second, ulong expectedValue)
        {
            var result = new Money(first) - new Money(second);
            var expected = new Money(expectedValue);
            Assert.AreEqual(expected, result);
        }

        [TestCase(0ul, 11ul, 0ul)]
        [TestCase(3ul, 133ul, 0ul)]
        public void should_never_return_less_than_zero_when_subtracting(ulong first, ulong second, ulong expectedValue)
        {
            var result = new Money(first) - new Money(second);
            var expected = new Money(expectedValue);
            Assert.AreEqual(expected, result);
        }

        [TestCase(16ul, null, 16ul)]
        [TestCase(null, 32ul, 32ul)]
        public void money_plus_operator_should_treat_null_as_zero(ulong first, ulong second, ulong expectedValue)
        {
            var result = new Money(first) + new Money(second);
            var expected = new Money(expectedValue);
            Assert.AreEqual(expected, result);
        }

        [TestCase(16ul, null, 16ul)]
        [TestCase(null, 32ul, 0ul)]
        public void money_minus_operator_should_treat_null_as_zero(ulong first, ulong second, ulong expectedValue)
        {
            var result = new Money(first) - new Money(second);
            var expected = new Money(expectedValue);
            Assert.AreEqual(expected, result);
        }

        [TestCase("USD", "USD", "USD")]
        [TestCase("USD", "PLN", "USD")]
        [TestCase("PLN", "USD", "PLN")]
        public void should_convert_to_currency_same_as_in_first_param(string firstCurrency, string secondCurrency, string expectedCurrency)
        {
            var first = new Money(11, firstCurrency);
            var second = new Money(11, secondCurrency);
            var resultCurrency = (first + second).Currency;

            Assert.AreEqual(expectedCurrency, resultCurrency);
        }

        [Test]
        public void should_automatically_calculate_conversion_when_adding_different_currencies()
        {
            var twoPln = new Money(2, "PLN");
            var threeGbp = new Money(3, "GBP").ToCurrency("GBP");
            var threeGbpConvertedToPln = threeGbp.ToCurrency("PLN");

            var resultWithAutoConversion = twoPln + threeGbp;
            var resultWithManualConversion = twoPln + threeGbpConvertedToPln;
            
            Assert.AreEqual(resultWithManualConversion, resultWithAutoConversion);
        }
    }
}