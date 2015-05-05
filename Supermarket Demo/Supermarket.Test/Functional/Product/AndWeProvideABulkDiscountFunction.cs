using System;
using NUnit.Framework;
using Supermarket.Core;

namespace Supermarket.Test.Functional.Product
{
    public class AndWeProvideABulkDiscountFunction : WhenTestingTheProductBuilder
    {
        private Func<Supermarket.Functional.Product, int, decimal> _pricing;

        private Supermarket.Functional.Product _product;

        private decimal _price, _result;

        protected override void Given()
        {
            base.Given();

            _product = _builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(_price).Build();
        }

        protected override void When()
        {
            _result += _product.Price(1);
            _result += _product.Price(2);
            _result += _product.Price(3);
            _result += _product.Price(4);
        }

        protected override Discounts Discounts
        {
            get
            {
                return new Discounts()
                {
                    discounts = new Discount[] { new Discount() { sku = "001", trigger = 2, bonus = 2 } }
                };
            }
        }

        [Test]
        public void ThenTheDiscountPriceShouldBeReturned()
        {
            Assert.That(_result, Is.EqualTo(2 * _price));
        }
    }
}