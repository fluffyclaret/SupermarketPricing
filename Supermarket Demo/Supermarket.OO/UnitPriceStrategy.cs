using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public class UnitPriceStrategy : IPricingStrategy
    {
        public decimal GetPrice(Product product, int number)
        {
            // TODO: use contracts to specifiy entry criteria
            if (null == product)
            {
                throw new ArgumentNullException("Cannot price a null product");
            }

            return product.UnitPrice;
        }
    }
}
