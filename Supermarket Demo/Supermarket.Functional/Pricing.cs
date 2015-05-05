using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Functional
{
    public static class Pricing
    {
        internal static ProductBuilder UsingUnitPricing(this ProductBuilder builder)
        {
            var func = builder.Product.CreateUnitPricing();

            builder.Product.Price = func;

            return builder;
        }

        internal static ProductBuilder UsingBulkDiscountPricing(this ProductBuilder builder, int trigger, int bonus)
        {
            var func = builder.Product.CreateBulkDiscountPricing(trigger, bonus);

            builder.Product.Price = func;

            return builder;
        }

        internal static Func<int, decimal> CreateUnitPricing(this Product product)
        {
            return i => product.UnitPrice;
        }

        internal static  Func<int, decimal> CreateBulkDiscountPricing(this Product product, int trigger, int bonus)
        {
            return i =>
            {
                decimal price = 0;

                int place = i % (trigger + bonus);

                if (place > 0 && place <= trigger)
                {
                    price = product.UnitPrice;
                }

                return price;
            };
        }
    }
}
