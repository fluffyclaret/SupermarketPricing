using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;
using Supermarket.Test.Core;

namespace Supermarket.Test.Product
{
    public class AndWeDontSelectAPriceStrategy : WhenTestingProductInitialisation
    {
        protected override void When()
        {
            _product = _builder.ForSKU(_sku).WithName(_name).WithUnitPrice(_price).Build();
        }

        [NUnit.Framework.Test]
        public void ThenTheProductShoudAdoptAUnitPriceStrategy()
        {
            Assert.That(_product.Strategy, Is.InstanceOf<UnitPriceStrategy>());
        }
    }
}
