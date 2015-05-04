using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Core;

namespace Supermarket.Test.Core
{
    public abstract class WhenTestingProductInitialisation : SpecBase
    {
        protected Product _product = null;

        protected ProductBuilder _builder;

        protected string _name, _sku;

        protected override void Given()
        {
            base.Given();

            _name = "Beans";
            _sku = "001";

            _builder = new ProductBuilder();
        }

        
    }


}
