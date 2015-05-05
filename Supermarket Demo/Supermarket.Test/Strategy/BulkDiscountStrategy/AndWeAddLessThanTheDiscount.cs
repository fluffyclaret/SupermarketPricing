using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Supermarket.Test.Strategy.BulkDiscountStrategy
{
    public class AndWeAddLessThanTheDiscount : WhenTestingBulkDiscountStrategy
    {
        protected override void Given()
        {
            base.Given();

            _result = 0;
        }

        protected override void When()
        {
            _result += _strategy.GetPrice(_product, 1);
            _result += _strategy.GetPrice(_product, 2);
        }

        [Test]
        public void ThenTheCorrectPriceShallBeReturned()
        {
            Assert.That(_result, Is.EqualTo(2 * _price));
        }
    }
}
