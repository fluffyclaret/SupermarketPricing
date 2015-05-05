using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;
using Supermarket.Core;
using Supermarket.Test.Core;
using ProductBuilder = Supermarket.Functional.ProductBuilder;

namespace Supermarket.Test.Functional.Product
{
    
    public abstract class WhenTestingTheProductBuilder : SpecBase
    {
        protected ProductBuilder _builder;

        protected override void Given()
        {
            base.Given();

            var reader = MockRepository.GenerateMock<IDiscountReader>();
            reader.Stub(r => r.Read()).Return(Discounts);

            _builder = new ProductBuilder(reader);
        }

        protected abstract Discounts Discounts { get; }
    }
}
