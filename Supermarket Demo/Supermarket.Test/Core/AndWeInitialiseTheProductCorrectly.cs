using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Test.Core
{
    public class AndWeInitialiseTheProductCorrectly : WhenTestingProductInitialisation
    {
        protected override void When()
        {
            _product = _builder.ForSKU(_sku).WithName(_name).Build();
        }

        [NUnit.Framework.Test]
        public void ThenTheProductShoudHaveTheCorrectName()
        {
            Assert.That(_product.Name, Is.EqualTo(_name));
        }

        [NUnit.Framework.Test]
        public void ThenTheProductShoudHaveTheCorrectSKU()
        {
            Assert.That(_product.SKU, Is.EqualTo(_sku));
        }
    }
}
