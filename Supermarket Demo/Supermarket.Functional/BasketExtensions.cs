using System.Collections.Generic;
using System.Linq;

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
}