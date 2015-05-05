using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Core;

namespace Supermarket.OO
{
    public class StrategySelector : IStrategySelector
    {
        private readonly IDiscountReader _reader;

        public StrategySelector(IDiscountReader reader)
        {
            _reader = reader;
        }
        public IPricingStrategy Create(string sku)
        {
            IPricingStrategy strategy = null;

            var result = _reader.Read();

            var discount = result.discounts.FirstOrDefault(d => d.sku == sku);

            // TODO: Open/Closed principle violation if we create new discounts!!
            if (null != discount)
            {
                strategy = new BulkDiscountPriceStrategy(discount.trigger, discount.bonus);
            }
            else
            {
                strategy = new UnitPriceStrategy();
            }

            return strategy;
        }
    }
}
