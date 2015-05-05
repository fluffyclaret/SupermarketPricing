using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Supermarket.Core;
using Supermarket.OO;

namespace Supermarket.Test.Core
{
    public abstract class WhenTestingProductInitialisation : SpecBase
    {
        protected Supermarket.Core.Product _product = null;

        protected ProductBuilder _builder;

        protected string _name, _sku;

        protected decimal _price;

        protected override void Given()
        {
            base.Given();

            _name = "Beans";
            _sku = "001";
            _price = 1;

            var selector = MockRepository.GenerateMock<IStrategySelector>();
            selector.Stub(s => s.Create(Arg<string>.Is.Anything)).Return(new UnitPriceStrategy());

            _builder = new ProductBuilder(selector);
        }

        
    }


}
