using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Test.Core;

namespace Supermarket.Test.Functional.Basket
{   
    public class WhenTestingTheBasket : SpecBase
    {
        private Supermarket.Functional.Basket _basket;

        private Supermarket.Functional.Product _product;

        protected override void Given()
        {
            base.Given();

            _basket = new Supermarket.Functional.Basket();

            _basket.Start();

            var builder = new Supermarket.Functional.ProductBuilder();
            _product = builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(1m).Build();
        }

        protected override void When()
        {
            _basket.Add(_product);
            _basket.Add(_product);
        }

        [Test]
        public void ThenTheCountShouldIncrement()
        {
            Assert.That(_basket.Count(), Is.EqualTo(2));
        }
    }
        
}
