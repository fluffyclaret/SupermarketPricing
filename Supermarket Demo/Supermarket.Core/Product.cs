using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public class Product
    {
        public Product(string name, string sku)
        {
            this.Name = name;
            this.SKU = sku;
        }

        public string Name { get; set; }

        public string SKU { get; set; }
    }
}
