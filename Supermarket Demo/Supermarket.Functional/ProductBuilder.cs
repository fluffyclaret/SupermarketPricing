using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Supermarket.Core;

namespace Supermarket.Functional
{
    public class ProductBuilder
    {
        private Product _product;

        private IDiscountReader _reader;

        public ProductBuilder(IDiscountReader reader)
        {
            _reader = reader;
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

            // TODO: Very very closed
            var config = _reader.Read();

            var discount = config.discounts.FirstOrDefault(d => d.sku == _product.SKU);

            if (null == discount)
            {
                this.UsingUnitPricing();
            }
            else
            {
                this.UsingBulkDiscountPricing(discount.trigger, discount.bonus);
            }

            return _product;
        }

        internal Product Product
        {
            get { return _product; }
        }
    }
}
