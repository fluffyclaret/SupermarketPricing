﻿using System;
using NUnit.Framework;
using Supermarket.Core;
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

            _product = _builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(_price).Build();
        }

        protected override void When()
        {
            _result = _product.Price(1);
        }

        protected override Discounts Discounts
        {
            get { return new Discounts(); }
        }

        [Test]
        public void ThenTheUnitPriceShouldBeReturned()
        {
            Assert.That(_result, Is.EqualTo(_price));
        }
    }
}