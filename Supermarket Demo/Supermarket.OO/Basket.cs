using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public class Basket
    {
        private IList<Product> _products;

        public Basket()
        {
            _products = new List<Product>();
        }

        public void AddToBasket(Product product)
        {
            if (null == product)
            {
                throw new ArgumentNullException("Cannot add a null product");
            }

            _products.Add(product);
        }

        public int Count
        {
            get { return _products.Count; }
        }

        public decimal Price
        {
            get { return CalculatePrice(); }
        }

        private decimal CalculatePrice()
        {
            decimal price = 0;

            // firstly group the products
            var groups = _products.GroupBy(product => product.SKU);

            // Keep it readable for now
            foreach (var group in groups)
            {
                var strategy = group.First().Strategy;

                int i = 1;
                foreach (var product in group.ToList())
                {
                    price += strategy.GetPrice(product, i++);
                }
            }

            return price;
        }
    }
}
