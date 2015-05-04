using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;

namespace Supermarket.Test.Core
{
    public class WhenTestingProductInitialisation : SpecBase
    {
        private Product _product = null;

        private string _name, _sku;
        protected override void Given()
        {
            base.Given();

            _name = "Beans";
            _sku = "001";
        }

        protected override void When()
        {
            _product = new Product(_name, _sku);
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
