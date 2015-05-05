using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Supermarket.Core;
using Supermarket.Functional;
using Supermarket.Test.Core;

namespace Supermarket.Test.Functional.Basket
{
    class WhenTestingAnUberBasket : SpecBase
    {
        private Supermarket.Functional.Basket _basket;

        private Supermarket.Functional.Product _beans, _milk, _cheese;

        private decimal _p1, _p2, _p3, _total;

        protected override void Given()
        {
            base.Given();

            _basket = new Supermarket.Functional.Basket();

            _basket.Start();

            _p1 = 1m;
            _p2 = 4m;
            _p3 = 5m;

            var reader = MockRepository.GenerateMock<IDiscountReader>();
            reader.Stub(r => r.Read()).Return(new Discounts() { discounts = new Discount[] { new Discount() { sku = "001", bonus = 2, trigger = 2 } } });

            var builder = new Supermarket.Functional.ProductBuilder(reader);
            _beans = builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(_p1).Build();
            _milk = builder.Start().ForSKU("002").WithName("Milk").WithUnitPrice(_p2).Build();
            _cheese = builder.Start().ForSKU("003").WithName("Cheese").WithUnitPrice(_p3).Build();
        }

        protected override void When()
        {
            _basket.Add(_beans);
            _basket.Add(_milk);
            _basket.Add(_milk);
            _basket.Add(_milk);
            _basket.Add(_beans);
            _basket.Add(_cheese);
            _basket.Add(_beans);
            _basket.Add(_beans);
            _basket.Add(_beans);

            _total = _basket.Price();
        }

        [Test]
        public void ThenTheCalculatedPriceShouldBeCorrect()
        {
            Assert.That(_total, Is.EqualTo(3 * _p1 + 3 * _p2 + _p3));
        }
    }
}
