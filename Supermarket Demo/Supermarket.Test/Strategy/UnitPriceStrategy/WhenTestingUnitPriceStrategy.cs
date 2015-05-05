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
    public abstract class WhenTestingUnitPriceStrategy : SpecBase
    {
        protected ProductBuilder _builder;

        protected UnitPriceStrategy _strategy;

        protected override void Given()
        {
            base.Given();

            _strategy = new UnitPriceStrategy();

            var selector = MockRepository.GenerateMock<IStrategySelector>();
            selector.Stub(s => s.Create(Arg<string>.Is.Anything)).Return(_strategy);

            _builder = new ProductBuilder(selector);
         }
    }
}
