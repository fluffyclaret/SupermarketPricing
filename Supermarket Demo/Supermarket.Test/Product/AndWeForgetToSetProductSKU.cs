using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Test.Core
{
    public class AndWeForgetToSetProductSKU : WhenTestingProductInitialisation
    {
        private Exception _exception;

        protected override void When()
        {
            try
            {
                _product = _builder.Start().WithName(_name).Build();
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
