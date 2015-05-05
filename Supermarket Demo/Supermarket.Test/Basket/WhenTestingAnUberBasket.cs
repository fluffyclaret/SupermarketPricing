using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Supermarket.Core;
using Supermarket.OO;
using Supermarket.Test.Core;

namespace Supermarket.Test.Basket
{
    public class WhenTestingAnUberBasket : SpecBase
    {
         protected Supermarket.Core.Basket _basket;

        protected Supermarket.Core.Product _beans, _soup, _cornflakes;

        protected override void Given()
        {
            base.Given();

            _basket = new Supermarket.Core.Basket();

            var selector = MockRepository.GenerateMock<IStrategySelector>();
            selector.Stub(s => s.Create(Arg<string>.Is.Equal("001"))).Return(new BulkDiscountPriceStrategy(2,1));
            selector.Stub(s => s.Create(Arg<string>.Is.NotEqual("001"))).Return(new UnitPriceStrategy());

            var builder = new ProductBuilder(selector);

            _beans = builder.Start().ForSKU("001").WithName("Beans").WithUnitPrice(1).Build();
            _soup = builder.Start().ForSKU("002").WithName("Soup").WithUnitPrice(1.5m).Build();
            _cornflakes= builder.Start().ForSKU("003").WithName("Cornflakes").WithUnitPrice(2.5m).Build();
        }

        protected override void When()
        {
            _basket.AddToBasket(_beans);
            _basket.AddToBasket(_soup);
            _basket.AddToBasket(_beans);
            _basket.AddToBasket(_soup);
            _basket.AddToBasket(_cornflakes);
            _basket.AddToBasket(_cornflakes);
            _basket.AddToBasket(_beans);
        }

        [NUnit.Framework.Test]
        public void ThenTheCountShouldIncrement()
        {
            Assert.That(_basket.Count, Is.EqualTo(7));
        }

        [Test]
        public void ThenThePriceShouldBeCalculatedCorrectly()
        {
            Assert.That(_basket.Price, Is.EqualTo(10));
        }
    }
}
