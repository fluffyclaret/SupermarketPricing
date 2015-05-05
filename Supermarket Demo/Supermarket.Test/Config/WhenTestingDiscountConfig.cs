using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.OO;
using Supermarket.Test.Core;

namespace Supermarket.Test.Config
{
    [Category("BehaviourTest")]
    public class WhenTestingDiscountConfig : SpecBase
    {
        private IDiscountConfig _config;

        private string _result, _input;

        protected override void Given()
        {
            base.Given();

            _input = "{\"discounts\":[{ \"sku\":\"001\", \"trigger\":2, \"bonus\":2 },{ \"sku\":\"002\", \"trigger\":3, \"bonus\":1 }]}";

            _config = new DiscountConfig();
        }

        protected override void When()
        {
            _result = _config.Read();
        }

        [Test]
        public void ThenItShouldReadTheSpecificConfigFile()
        {
            Assert.That(_result, Is.Not.Null);
        }
    }
}
