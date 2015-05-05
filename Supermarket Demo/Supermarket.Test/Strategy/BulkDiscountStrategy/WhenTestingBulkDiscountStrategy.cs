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

namespace Supermarket.Test.Strategy.BulkDiscountStrategy
{
    public abstract class WhenTestingBulkDiscountStrategy : SpecBase
    {
        protected Supermarket.Core.Product _product;

        protected ProductBuilder _builder;

        protected BulkDiscountPriceStrategy _strategy;

        protected int _trigger, _bonus;

        protected decimal _price, _result;

        protected string _sku, _name;

        protected override void Given()
        {
            base.Given();

            // 4 for the price of 2
            _trigger = 2;
            _bonus = 2;

            _strategy = new BulkDiscountPriceStrategy(_trigger, _bonus);

            var selector = MockRepository.GenerateMock<IStrategySelector>();
            selector.Stub(s => s.Create(Arg<string>.Is.Anything)).Return(_strategy);

            _builder = new ProductBuilder(selector);

            _sku = "001";
            _name = "Beans";
            _price = 1;

            _product = _builder.ForSKU(_sku).WithName(_name).WithUnitPrice(_price).Build();
        }

        
    }
}
