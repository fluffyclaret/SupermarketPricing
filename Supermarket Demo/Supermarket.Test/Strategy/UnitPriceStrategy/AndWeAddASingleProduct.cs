using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;

namespace Supermarket.Test.Strategy
{
    public class AndWeAddASingleProduct : WhenTestingUnitPriceStrategy
    {
        protected Supermarket.Core.Product _product;

        protected string _sku, _name;

        protected decimal _price, _result;

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
            _result = _strategy.GetPrice(_product, 1);
        }

        [Test]
        public void ThenTheCorrectPriceShallBeCalculated()
        {
            Assert.That(_result, Is.EqualTo(_price));
        }
    }
}
