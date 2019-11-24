using System.Linq;
using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Core.Tests
{
    public class MoneyTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        // todo() money converter

        [TestCase(0ul)]
        [TestCase(13ul)]
        public void properly_sets_money_amount(ulong amount)
        {
            var money = new Money(amount);
            Assert.AreEqual(money.Amount, amount);
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
    }
}