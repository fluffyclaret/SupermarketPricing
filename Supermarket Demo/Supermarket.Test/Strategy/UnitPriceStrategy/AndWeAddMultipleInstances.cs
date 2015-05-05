using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;

namespace Supermarket.Test.Strategy
{
    public class AndWeAddMultipleInstances : WhenTestingUnitPriceStrategy
    {
        protected Supermarket.Core.Product _product;

        protected string _sku, _name;

        protected decimal _price, _result1, _result2;

        protected override void Given()
        {
            base.Given();

            _sku = "001";
            _name = "Beans";
            _price = 1;

            _product = _builder.ForSKU(_sku).WithName(_name).WithUnitPrice(_price).Build();
        }

        protected override void When()
        {
            _result1 = _strategy.GetPrice(_product, 1);
            _result2 = _strategy.GetPrice(_product, 2);
        }

        [NUnit.Framework.Test]
        public void ThenTheCorrectPricesShallBeReturned()
        {
            Assert.That(_result1, Is.EqualTo(_price));
            Assert.That(_result2, Is.EqualTo(_price));
        }
    }
}
