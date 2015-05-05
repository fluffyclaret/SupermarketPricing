using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.OO;

namespace Supermarket.Core
{
    public class ProductBuilder
    {
        private Product _product;

        private IStrategySelector _selector;

        public ProductBuilder(IStrategySelector selector)
        {
            _selector = selector;

            _product = new Product();

            _product.Strategy = new UnitPriceStrategy();
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

            _product.Strategy = _selector.Create(_product.SKU);

            return _product;
        }
    }
}
