using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;
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

            _builder = new ProductBuilder();

            _strategy = new UnitPriceStrategy();
        }
    }
}
