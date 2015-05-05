using System;
using NUnit.Framework;
using Supermarket.Functional;
using Supermarket.Test.Core;

namespace Supermarket.Test.Functional.Product
{
    public class AndWeProvideASimplePriceFunction : WhenTestingTheProductBuilder
    {
        private Func<Supermarket.Functional.Product, int, decimal> _pricing;

        private Supermarket.Functional.Product _product;

        private decimal _price, _result;
 
        protected override void Given()
        {
            base.Given();

            _pricing = (product, i) => product.UnitPrice;

            _product = _builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(_price).UsingBulkDiscountPricing(2,2).Build();
        }

        protected override void When()
        {
            _result += _product.Price(1);
            _result += _product.Price(2);
            _result += _product.Price(3);
            _result += _product.Price(4);
        }

        [Test]
        public void ThenTheDiscountPriceShouldBeReturned()
        {
            Assert.That(_result, Is.EqualTo(2 * _price));
        }
    }

    public class AndWeProvideABulkDiscountFunction : WhenTestingTheProductBuilder
    {
        private Func<Supermarket.Functional.Product, int, decimal> _pricing;

        private Supermarket.Functional.Product _product;

        private decimal _price, _result;

        protected override void Given()
        {
            base.Given();

            _product = _builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(_price).UsingUnitPricing().Build();
        }

        protected override void When()
        {
            _result = _product.Price(1);
        }

        [Test]
        public void ThenTheUnitPriceShouldBeReturned()
        {
            Assert.That(_result, Is.EqualTo(_price));
        }
    }
}