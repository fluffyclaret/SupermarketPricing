using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Functional
{
    public class ProductBuilder
    {
        private Product _product;

        public ProductBuilder()
        {
        }

        public ProductBuilder Start()
        {
            _product = new Product();

            return this;
        }

        public ProductBuilder WithName(string name)
        {
            _product.Name = name;

            return this;
        }

        public ProductBuilder WithUnitPrice(decimal unitPrice)
        {
            _product.UnitPrice = unitPrice;

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

            if (_product.UnitPrice < 0)
            {
                throw new InvalidOperationException("A product cannot have a negative price");
            }

            return _product;
        }

        internal Product Product
        {
            get { return _product; }
        }
    }
}
