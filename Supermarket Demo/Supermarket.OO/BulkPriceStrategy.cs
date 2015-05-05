using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Supermarket.Core;

namespace Supermarket.OO
{
    public class BulkDiscountPriceStrategy : IPricingStrategy
    {
        private int _trigger, _bonus, _total;

        public BulkDiscountPriceStrategy(int trigger, int bonus)
        {
            _trigger = trigger;
            _bonus = bonus;
            _total = (_trigger + _bonus);
        }

        public decimal GetPrice(Product product, int number)
        {
            decimal price = 0;

            int place = number % (_trigger + _bonus);

            if (place >0 && place <= _trigger)
            {
                price = product.UnitPrice;
            }

            return price;
        }
    }
}
