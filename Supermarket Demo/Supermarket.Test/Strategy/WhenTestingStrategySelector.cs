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

namespace Supermarket.Test.Strategy
{
    public abstract class WhenTestingStrategySelector : SpecBase
    {
        protected IStrategySelector _selector;

        protected IPricingStrategy _strategy;

        protected string _sku;

        protected override void Given()
        {
            base.Given();

            _sku = "001";
        }

        protected override void When()
        {
            _strategy = _selector.Create(_sku);
        }
    }

    public class AndWeHaveNoDiscountsDefined : WhenTestingStrategySelector
    {
        protected override void Given()
        {
            base.Given();

            var discounts = new Discounts();
            discounts.discounts = new Discount[0];

            var reader = MockRepository.GenerateMock<IDiscountReader>();

            reader.Stub(r => r.Read()).Return(discounts);
        }

        [Test]
        public void ThenAUnitPriceStrategyShouldBeReturned()
        {
            Assert.That(_strategy, Is.TypeOf<UnitPriceStrategy>());
        }
    }

    public class AndWeHaveADiscountDefined : WhenTestingStrategySelector
    {
        protected int _trigger, _bonus;

        protected override void Given()
        {
            base.Given();

            _trigger = 2;
            _bonus = 2;

            var discounts = new Discounts();
            discounts.discounts = new Discount[] { new Discount() { sku = _sku, bonus = _bonus, trigger = _trigger}};

            var reader = MockRepository.GenerateMock<IDiscountReader>();

            reader.Stub(r => r.Read()).Return(discounts);
        }

        [Test]
        public void ThenABulkDiscountPriceStrategyShouldBeReturned()
        {
            Assert.That(_strategy, Is.TypeOf<BulkDiscountPriceStrategy>());
        }

        [Test]
        public void ThenTheCorrectParametersShallBeSet()
        {
            var test = _strategy as BulkDiscountPriceStrategy;

            Assert.That(test.Trigger, Is.EqualTo(_trigger));
            Assert.That(test.Bonus, Is.EqualTo(_bonus));
        }
    }
}
