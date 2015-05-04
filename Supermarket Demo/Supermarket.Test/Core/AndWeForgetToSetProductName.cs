using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Supermarket.Test.Core
{
    public class AndWeForgetToSetProductName : WhenTestingProductInitialisation
    {
        private Exception _exception;

        protected override void When()
        {
            try
            {
                _product = _builder.ForSKU(_sku).Build();
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThenAnExceptionShallBeThrown()
        {
            throw _exception;
        }
    }
}
