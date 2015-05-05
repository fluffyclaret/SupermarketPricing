using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public class Product
    {
        internal Product()
        {
            UnitPrice = -1;
        }

        public string Name { get; internal set; }

        public string SKU { get; internal set; }

        public decimal UnitPrice { get; internal set; }

        public IPricingStrategy Strategy { get; internal set; }
    }
}
