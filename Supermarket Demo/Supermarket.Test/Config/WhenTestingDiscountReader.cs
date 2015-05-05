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

namespace Supermarket.Test.Config
{
    public class WhenTestingDiscountReader : SpecBase
    {
        private IDiscountReader _reader;

        private string _input;

        private Discounts _discounts, _results;

        protected override void Given()
        {
            base.Given();

            _input = "{\"discounts\":[{ \"sku\":\"001\", \"trigger\":2, \"bonus\":2 },{ \"sku\":\"002\", \"trigger\":3, \"bonus\":1 }]}";

            _discounts = new Discounts();

            var deserialiser = MockRepository.GenerateMock<IDiscountDeserialiser>();
            var config = MockRepository.GenerateMock<IDiscountConfig>();

            config.Stub(c => c.Read()).Return(_input);
            deserialiser.Stub(d => d.Deserialise(Arg<string>.Is.Equal(_input))).Return(_discounts);

            _reader = new DiscountReader(deserialiser, config);
        }

        protected override void When()
        {
            _results = _reader.Read();
        }

        [Test]
        public void ThenTheCorrectDiscountsShouldBeReturned()
        {
            Assert.That(_results, Is.EqualTo(_discounts));
        }
    }
}
