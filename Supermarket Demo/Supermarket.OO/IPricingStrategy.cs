using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public interface IPricingStrategy
    {
        /// <summary>
        /// We're only interested in bulk discounts for now, so let's keep it simple
        /// </summary>
        /// <param name="product">The product</param>
        /// <param name="number">Number of units</param>
        /// <returns>Price of the current unit</returns>
        decimal GetPrice(Product product, int number);
    }
}
