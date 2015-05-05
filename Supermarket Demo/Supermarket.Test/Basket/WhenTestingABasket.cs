using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;
using Supermarket.Test.Core;

namespace Supermarket.Test.Basket
{
    public class WhenTestingABasket : SpecBase
    {
        protected Supermarket.Core.Basket _basket;

        protected Supermarket.Core.Product _product;

        protected override void Given()
        {
            base.Given();

            _basket = new Supermarket.Core.Basket();

            var builder = new ProductBuilder();

            _product = builder.ForSKU("001").WithName("Beans").WithUnitPrice(1).Build();
        }

        protected override void When()
        {
            _basket.AddToBasket(_product);
            _basket.AddToBasket(_product);
        }

        [NUnit.Framework.Test]
        public void ThenTheCountShouldIncrement()
        {
            Assert.That(_basket.Count, Is.EqualTo(2));
        }

        [Test]
        public void ThenThePriceShouldBeCalculatedCorrectly()
        {
            Assert.That(_basket.Price, Is.EqualTo(2));
        }
    }
}
