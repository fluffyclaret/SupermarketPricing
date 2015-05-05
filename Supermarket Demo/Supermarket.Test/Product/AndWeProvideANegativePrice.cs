using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Supermarket.Test.Core
{
    public class AndWeProvideANegativePrice : WhenTestingProductInitialisation
    {
        private Exception _exception; // TODO: Create a base class for excpetion cases

        protected override void Given()
        {
            base.Given();
            _price = -1;
        }

        protected override void When()
        {
            try
            {
                _product = _builder.Start().ForSKU(_sku).WithName(_name).WithUnitPrice(_price).Build();
            }
            catch (Exception exception)
            {
                _exception = exception;
            }           
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void ThenAnExceptionShallBeThrown()
        {
            throw _exception;
        }
    }
}
