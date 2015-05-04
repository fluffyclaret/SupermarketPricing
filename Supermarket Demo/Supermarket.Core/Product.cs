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
        }

        public string Name { get; internal set; }

        public string SKU { get; internal set; }
    }
}
