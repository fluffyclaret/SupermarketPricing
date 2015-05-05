using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;
using Supermarket.Core;
using Supermarket.Test.Core;
using NUnit.Framework;

namespace Supermarket.Test.Product
{
    public class AndWeDoSelectAPriceStrategy : WhenTestingProductInitialisation
{
    private IPricingStrategy _strategy;

        protected override void Given()
        {
            base.Given();

            _strategy = MockRepository.GenerateMock<IPricingStrategy>();
        }

        protected override void When()
    {
        _product = _builder.ForSKU(_sku).WithName(_name).WithUnitPrice(_price).SetStrategy(_strategy).Build();
    }

    [NUnit.Framework.Test]
    public void ThenTheProductShouldAdoptTheGivenStrategy()
    {
        Assert.That(_product.Strategy, Is.EqualTo(_strategy));
    }
}
}
