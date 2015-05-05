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
    public class WhenTestingDiscountDeserialiser : SpecBase
    {
        private Discounts _result;

        private string _input;

        private IDiscountDeserialiser _deserialiser;

        protected override void Given()
        {
            base.Given();

            _input = "{\"discounts\":[{ \"sku\":\"001\", \"trigger\":2, \"bonus\":2 },{ \"sku\":\"002\", \"trigger\":3, \"bonus\":1 }]}";

            _deserialiser = new DiscountDeserialiser();
        }

        protected override void When()
        {
            _result = _deserialiser.Deserialise(_input);
        }

        [NUnit.Framework.Test]
        public void ThenTheDiscountsShouldBeDeserialised()
        {
            Assert.That(_result, Is.Not.Null);
        }

        [NUnit.Framework.Test]
        public void ThenTheDiscountsContainTwoOffers()
        {
            Assert.That(_result.discounts.Length, Is.EqualTo(2));
        }
    }
}
