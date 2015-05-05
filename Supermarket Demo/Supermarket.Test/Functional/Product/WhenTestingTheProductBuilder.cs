using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Functional;
using Supermarket.Test.Core;

namespace Supermarket.Test.Functional.Product
{
    
    public abstract class WhenTestingTheProductBuilder : SpecBase
    {
        protected ProductBuilder _builder;

        protected override void Given()
        {
            base.Given();

            _builder = new ProductBuilder();
        } 
    }
}
