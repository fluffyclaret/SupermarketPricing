using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Functional
{
    public static class BasketExtensions
    {
        public static decimal Price(this IGrouping<string, Product> group)
        {
            int i = 1;

            return group.Sum(product => product.Price(i++));
        }

        public static decimal Price(this IEnumerable<Product> products)
        {
            int i = 1;

            var groups = products.GroupBy(product => product.SKU);

            return groups.Sum(group => group.Price());
        }
    }

    public class Basket
    {
        public void Start()
        {
            var products = new List<Product>();

            this.Add = product => products.Add(product);

            this.Count = () => products.Count;

            this.Price = () => products.Price();
        }

        public Action<Product> Add { get; private set; }

        public Func<int> Count { get; private set; }

        public Func<decimal> Price { get; private set; } 

    }
}
