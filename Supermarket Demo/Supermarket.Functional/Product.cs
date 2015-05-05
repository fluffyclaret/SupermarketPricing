using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Functional
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

        public Func<int, decimal> Price { get; internal set; } 
    }
}
