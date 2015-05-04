using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public class ProductBuilder
    {
        private Product _product;

        public ProductBuilder()
        {
            _product = new Product();
        }

        public ProductBuilder WithName(string name)
        {
            _product.Name = name;

            return this;
        }

        public ProductBuilder ForSKU(string sku)
        {
            _product.SKU = sku;

            return this;
        }

        public Product Build()
        {
            if (string.IsNullOrEmpty(_product.Name))
            {
                throw new InvalidOperationException("You must provide a name for the product");
            }

            if (string.IsNullOrEmpty(_product.SKU))
            {
                throw new InvalidOperationException("You must provide a SKU for the product");
            }

            return _product;
        }
    }
}
